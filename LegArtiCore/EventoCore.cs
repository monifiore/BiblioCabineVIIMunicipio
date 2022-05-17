using LegArtiCommon;
using LegArtiModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{
    public class EventoCore : BaseCore
    {
        LoginCore loginCore = new LoginCore();

        public List<EventoModel> GetAllEventi(int? idEvento, bool isAdmin)
        {
            List<EventoModel> ret = new List<EventoModel>();
            try
            {

                string list = genericDal.ExecuteWhitJsonRet("Evento_GetAll", new Dictionary<string, object>() {
                                                                { "idEvento",idEvento},
                                                                { "isAdmin",isAdmin}
                                                                });
                ret = !string.IsNullOrEmpty(list) ? JsonSerializer.Deserialize<List<EventoModel>>(list) : ret;

            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }

        public void InsertEvento(EventoModel evento)
        {
            try
            {
                string eventoJson = JsonSerializer.Serialize(evento);

                genericDal.ExecuteNonQuery("Evento_Merge", new Dictionary<string, object>() {
                                            { "evento",eventoJson}
                });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

        public async Task InviaNewsLetter(EventoModel evento)
        {
            try
            {
                string list = genericDal.ExecuteWhitJsonRet("NewsLetter_SelectAll");
                if (!string.IsNullOrEmpty(list))
                {
                    List<NewsLetterModel> ret = JsonSerializer.Deserialize<List<NewsLetterModel>>(list);
                    await InvioEmail(evento, ret);
                }
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

        private string GetTemplate()
        {
            string html = string.Empty;
            try
            {
                var myTemp = "wwwroot/TemplateMail/NewsLetter.htm";

                var stream = new StreamReader(myTemp);
                html = stream.ReadToEnd();
                stream.Close();
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return html;
        }

        private async Task InvioEmail(EventoModel evento, List<NewsLetterModel> ret)
        {
            try
            {
                string hostSito = ConfigHelper.Settings.HostSito;
                string template = GetTemplate();
                string url = "";
                var baseHtml = template.Replace("[TITOLO]", evento.TitoloEvento).Replace("[DESCRIZIONE_EVENTO]", evento.DescrizioneEvento);

                foreach (NewsLetterModel single in ret)
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(single.ID.ToString().ToArray());
                    url = $"{ hostSito }DisattivaMailNewsLetter/{Convert.ToBase64String(plainTextBytes)}";
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(ConfigHelper.Settings.From);
                        mail.To.Add(single.IndirizzoMail);
                        mail.Subject = ConfigHelper.Settings.SubjectNewsLetter;
                        mail.Body = baseHtml.Replace("[URL]", url);
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient(ConfigHelper.Settings.Host, ConfigHelper.Settings.Port))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(ConfigHelper.Settings.Username, ConfigHelper.Settings.Pass);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }

            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }

        }

        public async Task DeleteEvento(int? idEvento)
        {
            try
            {
               genericDal.ExecuteNonQuery("Evento_Delete", new Dictionary<string, object>() {
                                                                { "idEvento",idEvento}
                                                            });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

    }
}
