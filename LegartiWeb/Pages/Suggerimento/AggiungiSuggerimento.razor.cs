using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Suggerimento
{
    public class AggiungiSuggerimentoBase : BaseCustomComponent
    {
        protected SuggerimentoModel model = new SuggerimentoModel();
        protected UtenteModel userModel = new UtenteModel();
        protected List<TipologicaModel> listaTipoSuggerimenti = new List<TipologicaModel>();
        protected string idTipoSuggerimento = "";
        protected SharedCore shardCore = new SharedCore();
        protected SuggerimentoCore core = new SuggerimentoCore();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    userModel = await Session.GetSession<UtenteModel>("UtenteLoggato");
                    if (userModel == null)
                    {
                        NavigationManager.NavigateTo("/login", true);
                    }
                    else
                    {
                        listaTipoSuggerimenti = shardCore.Tipologica_GetAll("Tipo_Suggerimento");
                    }
                }
                catch (EccezioneModel ex)
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = GetExceptionMessage(ex),
                        Severity = SeverityEnumClass.Error
                    });
                }
                catch (Exception ex)
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ex.Message,
                        Severity = SeverityEnumClass.Error
                    });
                }
                StateHasChanged();
            }
        }

       /* protected IEnumerable<string> MaxCharacters(string ch)
        {
          if (!string.IsNullOrEmpty(ch) && 1000 < ch?.Length)
                yield return "Massimo 1000 caratteri";
        }*/

        protected async Task Salva()
        {
            UtenteModel utn = await Session.GetSession<UtenteModel>("UtenteLoggato");
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {
                userModel = await Session.GetSession<UtenteModel>("UtenteLoggato");
                model.TipoSuggerimento.ID =int.Parse(idTipoSuggerimento.ToString());
                model.IDUtente = userModel.IDUtente;
                core.Suggerimento_Inserisci(model);


                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message =ConstantMessage.Successo,
                    Severity = SeverityEnumClass.Error
                });
                NavigationManager.NavigateTo("/suggerimento/dettaglio", true);

            }
            catch (EccezioneModel ex)
            {
                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = GetExceptionMessage(ex),
                    Severity = SeverityEnumClass.Error
                });
            }
            catch (Exception ex)
            {
                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = ex.Message,
                    Severity = SeverityEnumClass.Error
                });
            }
            finally
            {
                load.Close();
            }

        }










    }
}
