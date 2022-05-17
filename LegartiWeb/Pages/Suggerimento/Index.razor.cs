using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Suggerimento
{
    public class IndexBase : BaseCustomComponent
    {
        protected List<SuggerimentoModel> listaSuggerimenti = new List<SuggerimentoModel>();
        SuggerimentoCore core = new SuggerimentoCore();
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                listaSuggerimenti = core.Suggerimento_GetAll(null);
            }
            catch (Exception ex)
            {
                var appo = ex.Message;
            }
            finally
            {
                load.Close();
            }
        }


        public async Task SuggerimentiPersonali()
        {
            var utenteLoggato = await Session.GetSession<UtenteModel>("UtenteLoggato");
            if (utenteLoggato == null)
            {
                await Session.SetSession("PagProvenienza", "suggerimenti");
                NavigationManager.NavigateTo("/login", true);
            }
            else
            {
                NavigationManager.NavigateTo("/suggerimento/dettaglio", true);
            }
        }



    }
}
