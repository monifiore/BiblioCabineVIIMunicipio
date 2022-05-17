using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obbligatorio")] 
        public string Email { set; get; }
        public string Password { set; get; }
    }
}
