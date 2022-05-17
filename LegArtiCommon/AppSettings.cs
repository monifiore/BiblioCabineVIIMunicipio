using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiCommon
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public int TokenExpirationTime { get; set; }
        public string TokenKey { get; set; }
        public bool UseLDAP { get; set; }
    
        public string HostSito  { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string From { get; set; }
        public bool Ssl { get; set; }
        public string Subject { get; set; }
        public string SubjectNewsLetter { get; set; }
        public string SubjectActiveNewsLetter { get; set; }
        public string Text { get; set; }
        public string TextMailActiveNewsLetter { get; set; }
        public string PathRoot { get; set; }
        public string PathFileImgEventi { get; set; }
        public string PathFileImgBiblioCabine { get; set; }
        public string FTPSite { get; set; }
        public string FTPUser { get; set; }
        public string FTPPass { get; set; }
        public string ConsolidaEvento { get; set; }
       
    }

}
