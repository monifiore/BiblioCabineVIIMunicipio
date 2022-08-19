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
    public class LoginCore : BaseCore
    {
        public UtenteModel Login(LoginModel model)
        {
            UtenteModel ret = new UtenteModel();
            try
            {
                model.Password = new Crypto(model.Email).Encrypt(model.Password);
                model.Email = new Crypto().Encrypt(model.Email);
                string jsonUtente = genericDal.ExecuteWhitJsonRet("Utente_Login",
                                                     new Dictionary<string, object>() {
                                                        { "email", model.Email},
                                                        { "password", model.Password } }
                                                    );
                if (string.IsNullOrEmpty(jsonUtente))
                {
                    ret.IDUtente = -100;
                }
                else
                {
                    ret = JsonSerializer.Deserialize<UtenteModel>(jsonUtente);
                }
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }

            return ret;
        }
        public RegitrazioneModel Registrati(RegitrazioneModel model)
        {
            string mailDecript = model.Email;
            try
            {
                model.Password = new Crypto(model.Email).Encrypt(model.Password);
                model.Email = new Crypto().Encrypt(model.Email);
                DataSet list = genericDal.ExecuteWhitDataSetRet("Utente_Registrati",
                                                    new Dictionary<string, object>() { { "Data", JsonSerializer.Serialize(model) } }
                                                   ).Result;
                model.IDUtente = int.Parse(list.Tables[0].Rows[0][0].ToString());
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            try
            {
              /*  if (model.IDUtente > 0)
                {
                    string hostSito = ConfigHelper.Settings.HostSito;
                    string component = (new Crypto().Encrypt(model.IDUtente.ToString())).Replace("/", "§").Replace("+", "€");
                    //Invio la mail
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(ConfigHelper.Settings.From);
                        mail.To.Add(mailDecript);
                        mail.Subject = ConfigHelper.Settings.Subject;
                        mail.Body = ConfigHelper.Settings.Text.Replace("{LINK_SITO}", hostSito + "AttivaUtente/" + component);
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient(ConfigHelper.Settings.Host, ConfigHelper.Settings.Port))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(ConfigHelper.Settings.Username, ConfigHelper.Settings.Pass);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }*/
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return model;
        }

        public bool AttivaUtente(int idUser)
        {
            try
            {
                DataSet list = genericDal.ExecuteWhitDataSetRet("Utente_Attivazione",
                                                    new Dictionary<string, object>() { { "idUtente", idUser } }
                                                   ).Result;
                return bool.Parse(list.Tables[0].Rows[0][0].ToString());
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }

        }

        public void InsertTokenFake()
        {
            try
            {
                genericDal.ExecuteNonQuery("LoginFakeToken_Insert");
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

        public bool VerifyTokenFake()
        {
            try
            {
                DataSet list = genericDal.ExecuteWhitDataSetRet("LoginFakeToken_Verify").Result;
                return bool.Parse(list.Tables[0].Rows[0][0].ToString());
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

    }
}
