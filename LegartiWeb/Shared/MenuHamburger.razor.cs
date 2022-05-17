using LegArtiCommon;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Shared
{
    public class MenuHamburgerBase : BaseCustomComponent
    {
        protected string voceMenuSelezionata = "";
        protected bool isBackVisible = false;
        protected string backUrl = "";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                voceMenuSelezionata = await Session.GetSession<string>("voceMenuSelezionata");
                if (voceMenuSelezionata == "suggerimento/dettaglio" || voceMenuSelezionata == "login")
                {
                    isBackVisible = true;
                    backUrl = "/suggerimento/index";
                }
                else if (voceMenuSelezionata == "/suggerimento/aggiungiSuggerimento")
                {
                    isBackVisible = true;
                    backUrl = "suggerimento/dettaglio";
                }

            }
            StateHasChanged();
        }
        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += async (s, e) =>
            {
                voceMenuSelezionata = NavigationManager.ToBaseRelativePath(e.Location).ToLower();
                if (voceMenuSelezionata.EndsWith("index")) // Salvo solo se fa parte del menu principale
                    await Session.SetSession("voceMenuSelezionata", voceMenuSelezionata);
                StateHasChanged();
            };
        }

    }
}
