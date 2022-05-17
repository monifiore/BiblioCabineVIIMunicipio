using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace LegartiWeb.Pages.Amministrazione
{
    public class IndexBase : BaseCustomComponent
    {

        /// <summary>
        /// Modello per la login
        /// </summary>
        protected LoginModel loginModel = new LoginModel();
        /// <summary>
        /// Modello con le informazioni dell'utente
        /// </summary>
        protected UtenteModel userModel = new UtenteModel();
        bool isShow;
        protected InputType PasswordInput = InputType.Password;
        protected string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
     
        protected override async Task OnInitializedAsync()
        {
            loginModel.Email = "legarti2021@gmail.com";
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


        public async Task Login()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                if (string.IsNullOrEmpty(loginModel.Password) || string.IsNullOrEmpty(loginModel.Email))
                {
                    await AdminMainLayoutWM.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.CampiVuoti,
                        Severity = SeverityEnumClass.Warning
                    });
                }
                else
                {
                    LoginCore core = new LoginCore();
                    userModel = core.Login(loginModel);
                    loginModel.Email = new Crypto().Decrypt(loginModel.Email);
                    loginModel.Password = new Crypto(loginModel.Email).Decrypt(loginModel.Password);
                    if (userModel.IDUtente == -100)
                    {
                        await AdminMainLayoutWM.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = ConstantMessage.LoginFallito,
                            Severity = SeverityEnumClass.Error
                        });
                    }
                    else
                    {
                        await Session.SetSession("UtenteLoggatoAdmin", userModel);
                        NavigationManager.NavigateTo("/amministrazione/home/index", true);
                    }
                }
            }
            catch (EccezioneModel ex)
            {
                loginModel.Email = new Crypto().Decrypt(loginModel.Email);
                loginModel.Password = new Crypto(loginModel.Email).Decrypt(loginModel.Password);
                await AdminMainLayoutWM.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = GetExceptionMessage(ex),
                    Severity = SeverityEnumClass.Error
                });
            }
            catch (Exception ex)
            {
                loginModel.Email = new Crypto().Decrypt(loginModel.Email);
                loginModel.Password = new Crypto(loginModel.Email).Decrypt(loginModel.Password);
                await AdminMainLayoutWM.SetVisibilitySnackBar(new MessageModel()
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
