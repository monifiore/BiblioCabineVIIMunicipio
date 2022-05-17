using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Suggerimento
{
    public class DettaglioBase : BaseCustomComponent
    {
        protected SuggerimentoCore core = new SuggerimentoCore();
        protected List<SuggerimentoModel> listaSuggerimenti = new List<SuggerimentoModel>();
        protected UtenteModel userModel = new UtenteModel();
        [Inject]
        IJSRuntime jsRuntime { set; get; }

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    userModel = await Session.GetSession<UtenteModel>("UtenteLoggato");
                    if (userModel == null)
                    {
                        NavigationManager.NavigateTo("/login", true);
                    }
                    else
                    {
                        listaSuggerimenti = core.Suggerimento_GetAll(userModel.IDUtente);
                    }
                }
                catch (Exception ex)
                {
                    var appo = ex.Message;

                }
                StateHasChanged();
            }
        }

        protected async Task CancellaSuggerimento(int idSuggerimento)
        {
            bool confirmed = await jsRuntime.InvokeAsync<bool>("confirm", "Sei sicura di voler cancelalre il suggerimento selezionato?");
            if (confirmed)
            {
                var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
                try
                {
                    core.Suggerimento_Cancella(idSuggerimento);
                    listaSuggerimenti.Remove(listaSuggerimenti.Where(x => x.IDSuggerimento == idSuggerimento).FirstOrDefault());
                StateHasChanged();
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
            }
        }

        protected async Task AggiungiSuggerimento()
        {
            NavigationManager.NavigateTo("/suggerimento/aggiungiSuggerimento", true);
        }





    }
}
