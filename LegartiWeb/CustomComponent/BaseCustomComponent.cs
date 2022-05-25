using LegArtiCommon;
using LegArtiModel;
using LegartiWeb.Interface;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.CustomComponent
{
    public class BaseCustomComponent : ComponentBase
    {

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        /// <summary>
        /// Sessione
        /// </summary>
        [Inject]
        public ISessionRepository Session { get; set; }

        /// <summary>
        /// Proprietà per navigare tra le pagine
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public MainLayout MainLayout { get; set; }

        [CascadingParameter]
        public MainLayoutAdmin AdminMainLayout { get; set; }

        [CascadingParameter]
        public MainLayoutAdminWithoutMenu AdminMainLayoutWM { get; set; }
        /// <summary>
        ///UtenteLoggato
        /// </summary>
        public UtenteModel userLogged = new UtenteModel();


        /// <summary>
        /// Messaggi da mostrare all'utente
        /// </summary>
        protected MessageModel userMessage = new MessageModel();


        protected string GetExceptionMessage(EccezioneModel ex)
        {
            string message = null;
            if (!string.IsNullOrWhiteSpace(ex.CustomMessage))
                message = ex.CustomMessage;
            else if (!string.IsNullOrWhiteSpace(ex.ExceptionMessage))
                message = ex.ExceptionMessage;
            else if (!string.IsNullOrWhiteSpace(ex.Message))
                message = ex.Message;

            return message;
        }

        public async Task GoToBack(string path)
        {
            NavigationManager.NavigateTo(path, true);
        }


    }
}
