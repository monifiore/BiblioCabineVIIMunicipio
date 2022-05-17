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
namespace LegartiWeb.Pages.BiblioCabine
{
    public class IndexBase : BaseCustomComponent
    {
        protected List<BiblioCabineModel> listaBiblioCabine = new List<BiblioCabineModel>();
        BiblioCabineCore core = new BiblioCabineCore();
        protected string link = "https://www.google.it/maps/place/Via+Pinerolo,+31,+00182+Roma+RM/@41.8831157,12.5140425,17z/data=!3m1!4b1!4m5!3m4!1s0x132f61ed108e7ad5:0x5a3123f707f28a1e!8m2!3d41.8831157!4d12.5162312?hl=en";
        protected override async Task OnInitializedAsync()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                listaBiblioCabine = core.GetAllBiblioCabine(null,false);
                listaBiblioCabine.ForEach(x => x.FileImg.PathImmagine = x.FileImg.PathImmagine +  x.FileImg.NomeFileImmagine);
            }
            catch (Exception ex)
            {
                var appo = ex.Message;

            }
            finally
            {
                load.Close();
                base.OnInitialized();
            }
        }



    }
}
