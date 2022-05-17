using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class EventoModel
    {
        public int IDEvento  {set;get;}
      
        public string TitoloEvento { set;get;}
        public string DescrizioneBreveEvento { set; get; }
        public string DescrizioneEvento { set;get;}
        public DateTime? DataEvento  {set;get;}
        public string OraEvento  {set;get;}
        public int IDStato { set;get;}
        public string DescStato { set;get;}
        public string LuogoEvento { set;get;}
        public FileModel FileImg { set; get; } = new();
        public string DataGiornoEvento { set; get; }


    }
}
