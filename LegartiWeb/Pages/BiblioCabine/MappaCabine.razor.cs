using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.BiblioCabine
{
    public class MappaCabineBase : BaseCustomComponent
    {
        BiblioCabineCore core = new BiblioCabineCore();
        protected List<BiblioCabineModel> lista = new List<BiblioCabineModel>();
     /*   protected override void  OnInitialized()
        {
            List<LocazioneModel> lista =  core.GetAllBiblione();
            base.OnInitialized();
        }*/


    }
}
