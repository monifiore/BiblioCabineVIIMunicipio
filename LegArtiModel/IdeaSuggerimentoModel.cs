using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class SuggerimentoModel
    {
        public int IDSuggerimento { set; get; }
        public int IDUtente { set; get; }
        public string Titolo { set; get; }
        public string Testo { set; get; }
        public string NomeVisualizzato { set; get; }
        public DateTime DataInserimento { set; get; }
        public TipologicaModel TipoSuggerimento { set; get; } = new TipologicaModel();
    }
}
