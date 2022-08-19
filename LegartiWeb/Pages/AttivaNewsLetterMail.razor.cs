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
    public class AttivaNewsLetterMailBase : BaseCustomComponent
    {
        [Parameter]
        public string component { get; set; }

        protected string mess = "";
        protected override async Task OnInitializedAsync()
        {
            component = component.Replace("§", "/").Replace("€", "+");
            string mailDecript = new Crypto().Decrypt(component);
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                HomeCore core = new HomeCore();
                bool isAttivo = core.AttivaMailNewsLetter(mailDecript);
                if (!isAttivo)
                {
                    mess = ConstantMessage.UtenteNonAttivato;
                }
                else
                {
                    mess = ConstantMessage.MailNewsLetterAttivata;
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

        protected void Home()
        {
            NavigationManager.NavigateTo("/", true);

        }




    }
}
