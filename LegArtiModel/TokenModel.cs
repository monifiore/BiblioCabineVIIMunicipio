using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class TokenModel
    {
        public string Token { set; get; }
        public string RefreshToken { set; get; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
