using LegArtiModel;
using LegartiWeb.CustomComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Amministrazione.Eventi
{
    public class PreviewBase : BaseCustomComponent
    {

        /*
         * @{
    var base64 = Convert.ToBase64String(Model.ByteArray);
    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
}
<img src="@imgSrc" />
         */

        [Parameter]
        public EventoModel evento { set; get; }
        protected string imgSrc = "";
        protected bool isViewAll = false;

        protected override async Task OnInitializedAsync()
        {
            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                if (evento.FileImg.BytesImmagine != null)
                {
                    var base64 = Convert.ToBase64String(evento.FileImg.BytesImmagine);
                    imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                }
                else
                {
                    imgSrc = evento.FileImg.PathImmagine + "/" + evento.FileImg.NomeFileImmagine;
                }
            }

        }


        protected void LeggiTutto()
        {
            isViewAll = true;
        }

        protected void LeggiMeno()
        {
            isViewAll = false;
        }


    }
}
