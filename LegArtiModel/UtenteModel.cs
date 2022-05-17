using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class UtenteModel
    {
        public int IDUtente { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string NomeVisualizzato { set; get; }
        public TokenModel Token { set; get; } = new TokenModel();
        public int IDRuolo { set; get; }
        public string DescRuolo { set; get; }

      //  public List<SuggerimentoModel> Suggerimenti { set; get; } = new List<SuggerimentoModel>();

    }
}
