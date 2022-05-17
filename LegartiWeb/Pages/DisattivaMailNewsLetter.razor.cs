using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Text;
using System.Threading.Tasks;

namespace LegartiWeb.Pages
{
    public class DisattivaMailNewsLetterBase : BaseCustomComponent
    {
        [Parameter]
        public string component { get; set; }

        protected string mess = "";
        protected override async Task OnInitializedAsync()
        {
            var idEmail = Encoding.UTF8.GetString(Convert.FromBase64String(component));
           
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                HomeCore core = new HomeCore();
                core.DisattivaMailNewsLetter(int.Parse(idEmail));
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
