using LegartiWeb.CustomComponent;
using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.Shared;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using System.Web;

namespace LegartiWeb.Pages
{
    public class IndexBase : BaseCustomComponent
    {

        protected List<HomeModel> listHomeDescription = new List<HomeModel>();
        HomeCore core = new HomeCore();
        protected MarkupString resultStringHome = new MarkupString();
        protected MarkupString resultStringMondo = new MarkupString();
        protected MarkupString resultStringObbiettivi = new MarkupString();
        protected string mailNewsLetter = "";

        protected bool disabled = false;

        protected bool arrows = true;
        protected bool autocycleB = false;

        public int spacing { get; set; } = 6;
        public int spacingB { get; set; } = 0;

        protected bool bullets = false;
        protected bool autocycle = true;
        protected Transition transition = Transition.Slide;

        bool success;
        string[] errors = { };
        MudForm form;

        protected override async Task OnInitializedAsync()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            try
            {

                listHomeDescription = core.GetInfoHome();
                resultStringHome = (MarkupString)Regex.Replace(HttpUtility.HtmlEncode(listHomeDescription.Where(x => x.Sezione.ToUpper() == "HOME").FirstOrDefault().Descrizione), "\r?\n|\r", "<br />");
                resultStringMondo = (MarkupString)Regex.Replace(HttpUtility.HtmlEncode(listHomeDescription.Where(x => x.Sezione.ToUpper() == "MONDO").FirstOrDefault().Descrizione), "\r?\n|\r", "<br />");
                resultStringObbiettivi = (MarkupString)Regex.Replace(HttpUtility.HtmlEncode(listHomeDescription.Where(x => x.Sezione.ToUpper() == "OBIETTIVI").FirstOrDefault().Descrizione), "\r?\n|\r", "<br />");

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
        private bool ConvalidaMail()
        {
            var addr = new System.Net.Mail.MailAddress(mailNewsLetter);
            return addr.Address == mailNewsLetter;
        }

        protected async Task SalvaMail()
        {
            var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
            IDialogReference dialog = null;
            try
            {
                if (string.IsNullOrEmpty(mailNewsLetter) || !ConvalidaMail())
                {
                    await MainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.MailErrata,
                        Severity = SeverityEnumClass.Error
                    });
                }
                else
                {
                    bool ret=await Task.Run(() => core.SalvaMailNewsLetter(mailNewsLetter));
                    if (ret)
                    {
                        await MainLayout.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = ConstantMessage.MailNewsLetterOk,
                            Severity = SeverityEnumClass.Success
                        });
                    }
                    else
                    {
                        await MainLayout.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = ConstantMessage.MailErrata,
                            Severity = SeverityEnumClass.Error
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                if (ex.HResult == -2146233033)
                {
                    mess = ConstantMessage.MailErrata;
                }
                await MainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = mess,
                    Severity = SeverityEnumClass.Error
                });
            }
            finally
            {
                if (dialog != null)
                    dialog.Close();
                load.Close();
            }
        }

    }
}