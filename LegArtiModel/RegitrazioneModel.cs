using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class RegitrazioneModel
    {
        public int IDUtente { set; get; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string ConfermaPass { set; get; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string NomeVisualizzato { set; get; }

    }
}
