using LegArtiModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Shared
{
    public class MainLayoutAdminWithoutMenuBase : LayoutComponentBase
    {
        public bool isVisibleSpinner { get; set; }


        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public RenderFragment ChildContentMainAdminWM { get; set; }

        public Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }



        public async Task SetVisibilitySnackBar(MessageModel messageDTO)
        {
            var severity = (Severity)Enum.Parse(typeof(Severity), messageDTO.Severity.ToString());

            Snackbar.Configuration.SnackbarVariant = Variant.Outlined;
            Snackbar.Configuration.MaxDisplayedSnackbars = 10;
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add(messageDTO.Message, severity);
            StateHasChanged();
        }



        public void SetSpinner(bool vis)
        {
            isVisibleSpinner = vis;
            StateHasChanged();
        }


    }
}
