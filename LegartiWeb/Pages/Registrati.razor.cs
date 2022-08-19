using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Shared
{
    public class RegistratiBase : BaseCustomComponent
    {
        /// <summary>
        /// Modello per le info dell'utente
        /// </summary>
        protected RegitrazioneModel utenteModel = new RegitrazioneModel();
        /// <summary>
        /// Modello con le informazioni dell'utente
        /// </summary>
        bool isShow;
        bool isConfPassShow;
        protected InputType PasswordInput = InputType.Password;
        protected string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        protected InputType ConfermaPassInput = InputType.Password;
        protected string ConfermaPassInputIcon = Icons.Material.Filled.VisibilityOff;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }
        protected void ViewHiddenPassword()
        {
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        protected void ViewHiddenConfPassword()
        {
            if (isConfPassShow)
            {
                isConfPassShow = false;
                ConfermaPassInputIcon = Icons.Material.Filled.VisibilityOff;
                ConfermaPassInput = InputType.Password;
            }
            else
            {
                isConfPassShow = true;
                ConfermaPassInputIcon = Icons.Material.Filled.Visibility;
                ConfermaPassInput = InputType.Text;
            }
        }


        private bool ConvalidaEmail()
        {
            try
            {
                new System.Net.Mail.MailAddress(utenteModel.Email);
                return true;
            }
            catch(Exception ex)
            {
                        this.WriteException(ex);
                return false;
            }
        }
        public async Task Registrati()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            utenteModel.IDUtente = 0;
            

            try
            {
                if (utenteModel.Password != utenteModel.ConfermaPass)
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.DifferentPassword,
                        Severity = SeverityEnumClass.Warning
                    });
                }
                else if (string.IsNullOrEmpty(utenteModel.NomeVisualizzato) || string.IsNullOrEmpty(utenteModel.Email) || string.IsNullOrEmpty(utenteModel.Password))
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.CampiVuoti,
                        Severity = SeverityEnumClass.Warning
                    });
                }
                else if (!ConvalidaEmail())
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.MailErrata,
                        Severity = SeverityEnumClass.Error
                    });
                }
                else
                {
                    LoginCore core = new LoginCore();
                    core.Registrati(utenteModel);
                    utenteModel.Email = new Crypto().Decrypt(utenteModel.Email);
                    utenteModel.Password = new Crypto(utenteModel.Email).Decrypt(utenteModel.Password);
                    if (utenteModel.IDUtente == -100)
                    {
                        await MainLayout.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = ConstantMessage.RegistrazioneFallita,
                            Severity = SeverityEnumClass.Error
                        });
                    }
                    else
                    {
                        await MainLayout.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = ConstantMessage.InvioMail.Replace("{USER}", utenteModel.NomeVisualizzato).Replace("{MAIL}", utenteModel.Email),
                            Severity = SeverityEnumClass.Success
                        });
                    }
                }
            }
            catch (EccezioneModel ex)
            {
                 this.WriteException(ex);
                utenteModel.Password = new Crypto(utenteModel.Email).Decrypt(utenteModel.Password);
                utenteModel.Email = new Crypto().Decrypt(utenteModel.Email);
                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = GetExceptionMessage(ex),
                    Severity = SeverityEnumClass.Error
                });
            }
            catch (Exception ex)
            {
                        this.WriteException(ex);
                utenteModel.Password = new Crypto(utenteModel.Email).Decrypt(utenteModel.Password);
                utenteModel.Email = new Crypto().Decrypt(utenteModel.Email);
                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = ex.Message,
                    Severity = SeverityEnumClass.Error
                });
            }
            finally
            {
                load.Close();
            }
        }

    }
}
