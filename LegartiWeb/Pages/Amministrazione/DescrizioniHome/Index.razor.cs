using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace LegartiWeb.Pages.Amministrazione.DescrizioniHome
{
    public class IndexBase : BaseCustomComponent
    {


        protected List<HomeModel> listHomeDescription = new List<HomeModel>();
        HomeCore core = new HomeCore();
        int idSez = 0;

        protected MarkupString resultStringHome = new MarkupString();
        protected MarkupString resultStringMondo = new MarkupString();
        protected MarkupString resultStringObbiettivi = new MarkupString();

        protected string descStoria = "";
        protected string descMondo = "";
        protected string descObbiettivi = "";

        protected bool isModificaStoria = false;
        protected bool isModificaMondo = false;
        protected bool isModificaObiettivi = false;

        protected override async Task OnInitializedAsync()
        {
            

          
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                userLogged = await Session.GetSession<UtenteModel>("UtenteLoggatoAdmin");
                if (userLogged == null)
                {
                    NavigationManager.NavigateTo("/amministrazione/index", true);
                }
                else
                {
                    var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
                    try
                    {
                        GetInfo();
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

            StateHasChanged();
        }


        private void GetInfo()
        {
            listHomeDescription = core.GetInfoHome();
            resultStringHome = (MarkupString)Regex.Replace(HttpUtility.HtmlEncode(listHomeDescription.Where(x => x.Sezione.ToUpper() == "HOME").FirstOrDefault().Descrizione), "\r?\n|\r", "<br />");
            descStoria = listHomeDescription.Where(x => x.Sezione.ToUpper() == "HOME").FirstOrDefault().Descrizione;

            resultStringMondo = (MarkupString)Regex.Replace(HttpUtility.HtmlEncode(listHomeDescription.Where(x => x.Sezione.ToUpper() == "MONDO").FirstOrDefault().Descrizione), "\r?\n|\r", "<br />");
            descMondo = listHomeDescription.Where(x => x.Sezione.ToUpper() == "MONDO").FirstOrDefault().Descrizione;

            resultStringObbiettivi = (MarkupString)Regex.Replace(HttpUtility.HtmlEncode(listHomeDescription.Where(x => x.Sezione.ToUpper() == "OBIETTIVI").FirstOrDefault().Descrizione), "\r?\n|\r", "<br />");
            descObbiettivi = listHomeDescription.Where(x => x.Sezione.ToUpper() == "OBIETTIVI").FirstOrDefault().Descrizione;

        }

        protected void ModificaTesti(string tipo)
        {
            if (tipo.ToUpper() == "STORIA")
            {
                idSez = 1;
                isModificaStoria = true;
                isModificaMondo = false;
                isModificaObiettivi = false;
            }
            else if (tipo.ToUpper() == "MONDO")
            {
                idSez = 2;
                isModificaStoria = false;
                isModificaMondo = true;
                isModificaObiettivi = false;
            }
            else if (tipo.ToUpper() == "OBBIETTIVI")
            {
                idSez = 3;
                isModificaStoria = false;
                isModificaMondo = false;
                isModificaObiettivi = true;
            }
        }

        protected async Task Salva(string tipo)
        {
            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
                try
                {

                    string desc = "";
                    if (idSez == 1) desc = descStoria;
                    else if (idSez == 2) desc = descMondo;
                    else if (idSez == 3) desc = descObbiettivi;
                    core.SalvaDescHome(idSez, desc);
                    GetInfo();
                    Annulla();
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
                    base.OnInitialized();
                }
            }
        }

        protected void Annulla()
        {
            isModificaStoria = false;
            isModificaMondo = false;
            isModificaObiettivi = false;
        }





    }
}
