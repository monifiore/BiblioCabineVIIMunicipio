using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class EccezioneModel : Exception
    {
        /// <summary>
        /// Identificativo
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Codice dell'errore
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// CustomMessage
        /// </summary>
        public string CustomMessage { get; set; }
        /// <summary>
        /// Messaggio dell'eccezione 
        /// </summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// Eccezione originale
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// La data dell'eccezione
        /// </summary>
        public DateTime ExceptionDate { get; set; }
        /// <summary>
        /// Imposta il css della classe
        /// </summary>
        public string CssClass { get; set; }
    }
    public class ExceptionNotFound : EccezioneModel
    {
        public ExceptionNotFound()
        {
            base.ErrorCode = 404;
            base.CustomMessage = "Elementi o elemento non trovati\\o.";
        }
    }
    public class ExceptionLogin : EccezioneModel
    {
        public ExceptionLogin(Exception Ex)
        {
            base.ErrorCode = 404;
            base.CustomMessage = "Errore nella procedura di login.";
            base.Exception = Ex.ToString();
            base.ExceptionMessage = Ex.Message;
        }
    }
    public class ExceptionToken : EccezioneModel
    {
        public ExceptionToken()
        {
            base.ErrorCode = 401;
            base.CustomMessage = "Refresh token non valido.";
        }
    }



    public class ExceptionBaseModel
    {
        /// <summary>
        /// Identificativo
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Codice dell'errore
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// CustomMessage
        /// </summary>
        public string CustomMessage { get; set; }
        /// <summary>
        /// Messaggio dell'eccezione 
        /// </summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// Eccezione originale
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// La data dell'eccezione
        /// </summary>
        public DateTime ExceptionDate { get; set; }
    }
}
