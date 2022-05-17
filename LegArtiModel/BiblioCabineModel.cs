using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class BiblioCabineModel
    {
        public int IDLocazione{ set; get; }
        public int IDStato { set; get; }
        public string DescStato { set;get;}
        public string NomeCabina { set; get; }
        public string Link { set; get; }
        public string Posizione { set; get; }
        public FileModel FileImg { set; get; } = new();
    }
}
