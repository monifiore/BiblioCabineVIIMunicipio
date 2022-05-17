using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LegartiWeb.Pages.Eventi
{
    public class IndexBase : BaseCustomComponent
    {
        protected List<EventoModel> listaEventi = new List<EventoModel>();
        EventoCore core = new EventoCore();
        protected bool isViewAll = false;
     
        protected override async Task OnInitializedAsync()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                var culture = new System.Globalization.CultureInfo("it-it");
                listaEventi = core.GetAllEventi(null, false);
                foreach(EventoModel single in listaEventi)
                {
                    single.FileImg.PathImmagine = single.FileImg.PathImmagine + "/" + single.FileImg.NomeFileImmagine;
                    single.DescrizioneBreveEvento = single.DescrizioneEvento.Length > 40 ? single.DescrizioneEvento.Substring(0, 40) + "..." : single.DescrizioneEvento;
                    string giorno = culture.DateTimeFormat.GetDayName(((DateTime)single.DataEvento).DayOfWeek);
                    single.DataGiornoEvento = char.ToUpper(giorno[0]) + giorno.Substring(1) + ", " + single.DataEvento.Value.ToString("dd/MM/yyyyy") + " dalle ";
                }

               
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

        [Inject]
        protected IJSRuntime JSRuntime { set; get; }

        protected async Task LeggiTutto(string idBtn, string idTesto)
        {
             await JSRuntime.InvokeVoidAsync("Evento_LeggiTutto", idBtn, idTesto);
        }

        protected async Task LeggiMeno(string idEvento, string isleggitutto)
        {
             await JSRuntime.InvokeVoidAsync("Evento_LeggiTutto",idEvento, isleggitutto);
        }


    }
}
