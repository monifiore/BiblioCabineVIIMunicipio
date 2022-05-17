using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class FileModel
    {
        public string PathImmagine { set; get; }
        public string PathImmagineFTP { set; get; }
        public string NomeFileImmagine { set; get; }
        public long SizeImmagine { get; set; }
        public byte[] BytesImmagine { get; set; }


    }
}
