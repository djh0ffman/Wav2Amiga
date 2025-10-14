using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wav2Amiga
{
    public enum ConvertMode
    {
        Single,
        Stacked,
        StackedEqual
    }

    public class PTNote
    {
        public string Note { get; set; }
        public int Period { get; set; }
        public double Rate { get; set; }

        public override string ToString()
        {
            return Note;
        }
    }
}
