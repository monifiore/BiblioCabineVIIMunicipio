using LegArtiModel;
using LegartiWeb.CustomComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Amministrazione.Bibliocabine
{
    public class PreviewBase : BaseCustomComponent
    {

        [Parameter]
        public BiblioCabineModel cabina { set; get; }
        protected string imgSrc = "";

        protected override async Task OnInitializedAsync()
        {
            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                if (cabina.FileImg.BytesImmagine != null)
                {
                    var base64 = Convert.ToBase64String(cabina.FileImg.BytesImmagine);
                    imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                }
                else
                {
                    imgSrc = cabina.FileImg.PathImmagine + "/" + cabina.FileImg.NomeFileImmagine;
                }
            }
        }
 

    }
}
