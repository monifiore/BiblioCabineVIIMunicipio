using LegArtiCommon;
using LegArtiModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{

    public class HomeCore : BaseCore
    {
        public List<HomeModel> GetInfoHome()
        {
            List<HomeModel> ret = new List<HomeModel>();
            try
            {
                string info = genericDal.ExecuteWhitJsonRet("Home_GetInfo", null);
                ret = JsonSerializer.Deserialize<List<HomeModel>>(info);
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }

        public void SalvaDescHome(int idSez, string desc)
        {
            try
            {
                genericDal.ExecuteNonQuery("Home_SaveInfo",
                                                             new Dictionary<string, object>() {
                                                                {"idSez", idSez},
                                                                {"desc", desc}
                                                             });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SalvaMailNewsLetter(string email)
        {
            var ret = true;
            try
            {
                string hostSito = ConfigHelper.Settings.HostSito;
                string component = (new Crypto().Encrypt(email)).Replace("/", "§").Replace("+", "€");
                DataSet ds = await genericDal.ExecuteWhitDataSetRet("NewsLetter_Save",
                                                                      new Dictionary<string, object>() {
                                                                        {"mail", email}
                                                                      });

                ret = bool.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (ret)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(ConfigHelper.Settings.From);
                        mail.To.Add(email);
                        mail.Subject = ConfigHelper.Settings.SubjectActiveNewsLetter;
                        mail.Body = ConfigHelper.Settings.TextMailActiveNewsLetter.Replace("{LINK_SITO}", hostSito + "AttivaEmailNewsLetter/" + component);
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
            return ret;
        }

        public void DisattivaMailNewsLetter(int id )
        {
            try
            {
                DataSet list = genericDal.ExecuteWhitDataSetRet("NewsLetter_Cancella",
                                                             new Dictionary<string, object>() {
                                                                {"@id", id}
                                                             }).Result;
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }
        public bool AttivaMailNewsLetter(string email)
        {
            try
            {
                DataSet list = genericDal.ExecuteWhitDataSetRet("NewsLetter_ActiveMail",
                                                             new Dictionary<string, object>() {
                                                                {"mail", email}
                                                             }).Result;

                return bool.Parse(list.Tables[0].Rows[0][0].ToString());

            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }




    }
}