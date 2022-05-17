using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages
{
    public class AttivaUtenteBase : BaseCustomComponent
    {
        [Parameter]
        public string component { get; set; }

        protected override async Task OnInitializedAsync()
        {
            component = component.Replace("§", "/").Replace("€", "+");
            int idDecript = int.Parse(new Crypto().Decrypt(component));
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                LoginCore core = new LoginCore();
                bool isAttivo=core.AttivaUtente(idDecript);
                if (!isAttivo)
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.UtenteNonAttivato,
                        Severity = SeverityEnumClass.Success
                    });
                }
                else
                {
                    string login = new Crypto().Encrypt("UserActive");
                    NavigationManager.NavigateTo("/login/login", true);
                }
            }
            catch (EccezioneModel ex)
            {
                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = GetExceptionMessage(ex),
                    Severity = SeverityEnumClass.Error
                });
            }
            catch (Exception ex)
            {
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

            base.OnInitialized();
        }


    }
}
