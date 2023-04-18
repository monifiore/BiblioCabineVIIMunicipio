using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class ProgettoLegalitaModel
    {
        public List<VideoModel> ListaVideo { get; set; } = new();
        public TipologicaModel Descrizione { get; set; }
    }

    public class VideoModel
    {
        public int IdVideo { get; set; }
        public string LinkYoutube { get; set; }
        public string Descrizione { get; set; }
        public string Titolo { get; set; }
        public string NumeroRiconoscimento { get; set; }
    }

}
