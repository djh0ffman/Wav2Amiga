using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wav2Amiga
{
    public class ConvertItem
    {
        public string FilePath { get; set; }    
        public string Filename
        {
            get
            {
                return Path.GetFileName(FilePath);
            }
        }
        public PTNote Note { get; set; }
        public string Status { get; set; }  
    }
}
