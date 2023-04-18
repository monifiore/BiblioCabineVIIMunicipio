using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Video
{
    public class IndexBase : BaseCustomComponent
    {
        protected ProgettoLegalitaModel video = new ();
        VideoCore core = new VideoCore();
        protected override async Task OnInitializedAsync()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                video = core.GetAllVideo(null, false);
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
