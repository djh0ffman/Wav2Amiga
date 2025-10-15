using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wav2Amiga
{
    public partial class MainForm : Form
    {
        private List<PTNote> _notes = new List<PTNote>();
        private List<ConvertItem> _items = new List<ConvertItem>();

        public MainForm()
        {
            InitializeComponent();

            var json = File.ReadAllText("notes.json");
            _notes = JsonConvert.DeserializeObject<List<PTNote>>(json);

            cbxNote.Items.Clear();
            cbxNote.Items.AddRange(_notes.ToArray());
            cbxNote.SelectedIndex = 4;

            cbxMode.Items.Clear();
            cbxMode.DataSource = System.Enum.GetValues(typeof(ConvertMode));

            _items = new List<ConvertItem>();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Convert();
        }

        private void Convert()
        {
            if (_items.Count == 0)
            {
                return;
            }

            var mode = (ConvertMode)cbxMode.SelectedItem;
            switch (mode)
            {
                case ConvertMode.Single:
                    ConvertSingle();
                    break;
                case ConvertMode.Stacked:
                    ConvertStacked();
                    break;
                case ConvertMode.StackedEqual:
                    ConvertStackedEqual();
                    break;
                default:
                    MessageBox.Show("WTF?");
                    break;
            }
            LoadList();
        }

        private byte[] Align256(byte[] data)
        {
            var newSize = data.Length + (256 - (data.Length % 256));
            var padSize = newSize - data.Length;
            var temp = data.ToList();
            temp.AddRange(new byte[padSize]);
            return temp.ToArray();
            
        }

        private void ConvertStackedEqual()
        {
            var stacked = new List<byte[]>();
            var largest = 0;

            foreach (var item in _items)
            {
                try
                {
                    var pcm = Resample8bit(item.FilePath, (int)item.Note.Rate);
                    pcm = Align256(pcm);
                    if (pcm.Length > largest)
                    {
                        largest = pcm.Length;
                    }

                    stacked.Add(pcm);
                    if (pcm.Length > 0xffff)
                    {
                        item.Status = "Warning, sample size > 64kb";
                    }
                    else
                    {
                        item.Status = "Done!";
                    }
                }
                catch (Exception ex)
                {
                    item.Status = $"Error - {ex.Message}";
                }

                LoadList();
            }

            var posText = $"{(largest >> 8):X2}";

            var result = new List<byte>();

            for (var i = 0; i < stacked.Count; i++)
            {
                var current = stacked[i];
                var temp = current.ToList();
                var remain = largest - current.Length;
                temp.AddRange(new byte[remain]);
                result.AddRange(temp.ToArray());
            }

            var first = _items[0];
            var fileOnly = $"{Path.GetFileNameWithoutExtension(first.FilePath)}_{posText}.8SVX";
            //var fileName = Path.Combine(Path.GetDirectoryName(first.FilePath), fileOnly);
            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Path.GetDirectoryName(first.FilePath);
            saveDialog.FileName = fileOnly;
            saveDialog.Filter = "Amiga Sample (*.8SVX)|*.8SVX";
            var saveResult = saveDialog.ShowDialog();
            if (saveResult == DialogResult.OK)
            {
                File.WriteAllBytes(saveDialog.FileName, result.ToArray());
            }
        }

        private void ConvertStacked()
        {
            var stacked = new List<byte>();

            var positions = new List<int>();

            foreach (var item in _items)
            {
                try
                {
                    positions.Add(stacked.Count);

                    var pcm = Resample8bit(item.FilePath, (int)item.Note.Rate);
                    pcm = Align256(pcm);
                    stacked.AddRange(pcm);
                    if (pcm.Length > 0xffff)
                    {
                        item.Status = "Warning, sample size > 64kb";
                    }
                    else
                    {
                        item.Status = "Done!";
                    }
                }
                catch (Exception ex)
                {
                    item.Status = $"Error - {ex.Message}";
                }

                LoadList();
            }

            var posText = "";
            foreach (var pos in positions)
            {
                posText += $"{(pos >> 8):X2}";
                if (positions.IndexOf(pos) < positions.Count - 1)
                {
                    posText += "_";
                }
            }

            var first = _items[0];
            var fileOnly = $"{Path.GetFileNameWithoutExtension(first.FilePath)}_{posText}.8SVX";
            //var fileName = Path.Combine(Path.GetDirectoryName(first.FilePath), fileOnly);
            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Path.GetDirectoryName(first.FilePath);
            saveDialog.FileName = fileOnly;
            saveDialog.Filter = "Amiga Sample (*.8SVX)|*.8SVX";
            var result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllBytes(saveDialog.FileName, stacked.ToArray());
            }
        }

        private void ConvertSingle()
        {
            foreach (var item in _items)
            {
                try
                {
                    var pcm = Resample8bit(item.FilePath, (int)item.Note.Rate);
                    var newFile = Path.ChangeExtension(item.FilePath, ".8SVX");
                    File.WriteAllBytes(newFile, pcm);
                    if (pcm.Length > 0xffff)
                    {
                        item.Status = "Warning, sample size > 64kb";
                    }
                    else
                    {
                        item.Status = "Done!";
                    }
                }
                catch (Exception ex)
                {
                    item.Status = $"Error - {ex.Message}";
                }

                LoadList();
            }
        }

        private void LoadList()
        {
            dgvItems.AutoGenerateColumns = false;
            var source = new BindingSource();
            source.DataSource = _items;
            dgvItems.DataSource = source;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _items = new List<ConvertItem>();
            LoadList();
        }

        private void btnApplyNote_Click(object sender, EventArgs e)
        {
            ApplyNote();
        }

        private void ApplyNote()
        {
            var selectedNote = (PTNote)cbxNote.SelectedItem;
            foreach (var item in _items)
            {
                item.Note = selectedNote;
                item.Status = "";
            }
            LoadList();
        }

        private void dgvItems_DragDrop(object sender, DragEventArgs e)
        {
            var selectedNote = (PTNote)cbxNote.SelectedItem;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var newList = new List<string>();
            foreach (var file in files)
            {
                var attr = File.GetAttributes(file);

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    newList.AddRange(Directory.GetFiles(file, "*.wav", SearchOption.AllDirectories));
                }
                else
                {
                    newList.Add(file);
                }
            }

            files = newList.ToArray();
            Array.Sort(files);

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file);
                if (Path.GetExtension(file) == ".wav")
                {
                    var newItem = new ConvertItem();
                    newItem.FilePath = file;
                    newItem.Note = selectedNote;
                    newItem.Status = "";
                    _items.Add(newItem);
                }
            }

            LoadList();
        }


        private void dgvItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private string ConvertDesc()
        {
            var mode = (ConvertMode)cbxMode.SelectedItem;
            switch (mode)
            {
                case ConvertMode.Single:
                    return "Convert each file individually";
                case ConvertMode.Stacked:
                    return "Convert all to a single sample snapping to offset boundary";
                case ConvertMode.StackedEqual:
                    return "Convert all to a single sample based on largest sample";
                default:
                    return "Unknown?";
            }
        }

        private void cbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var desc = ConvertDesc();
            lblMode.Text = desc;
        }

        private byte[] Resample8bit(string filename, int rate)
        {

            var pcm = Resample(filename, rate);
            var newPcm = new byte[pcm.Length / 2];

            var reader = new BinaryReader(new MemoryStream(pcm));
            for (var i = 0; i < pcm.Length / 2; i++)
            {
                var sample = reader.ReadInt16();

                newPcm[i] = (byte)(sample >> 8);
            }
            return newPcm;
        }

        private byte[] Resample(string filename, int rate)
        {
            using (var reader = new WaveFileReader(filename))
            {
                var outFormat = new WaveFormat(rate, reader.WaveFormat.Channels);
                using (var resampler = new MediaFoundationResampler(reader, outFormat))
                {
                    var monoSource = resampler.ToSampleProvider().ToWaveProvider16();
                    using (var outputStream = new MemoryStream())
                    {
                        byte[] bytesOutput = new byte[monoSource.WaveFormat.AverageBytesPerSecond];
                        while (true)
                        {
                            int bytesRead = monoSource.Read(bytesOutput, 0, bytesOutput.Length);
                            if (bytesRead == 0)
                            {
                                break;
                            }
                            outputStream.Write(bytesOutput, 0, bytesRead);
                        }
                        return outputStream.ToArray(); // This is raw PCM data
                    }
                }
            }
        }
    }
}
