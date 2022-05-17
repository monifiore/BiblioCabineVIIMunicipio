using LegArtiModel;
using LegartiWeb.CustomComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LegartiWeb.Shared
{
    public class MenuTopAdminBase : BaseCustomComponent
    {
        protected string voceMenuSelezionata = "";
        protected bool isBackVisible = false;
        protected string backUrl = "";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
           
            StateHasChanged();
        }
        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += async (s, e) =>
            {
                voceMenuSelezionata = NavigationManager.ToBaseRelativePath(e.Location).ToLower();
                if (voceMenuSelezionata.EndsWith("index")) // Salvo solo se fa parte del menu principale
                    await Session.SetSession("voceMenuSelezionataAdmin", voceMenuSelezionata);
                StateHasChanged();
            };
        }

    }
}
