using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Amministrazione.Bibliocabine
{
    public class DettaglioBase : BaseCustomComponent
    {
        [Parameter]
        public string IDBiblioCambina { set; get; }
        protected int idBiblioCambina = 0;
        protected string title = "Nuova postazione";
        protected BiblioCabineModel cabina = new BiblioCabineModel();
        protected string idStato = "";
        protected DateTime? minDataEvento = DateTime.Today;
        protected string errorFileEmpty = "";
        private BiblioCabineCore core = new BiblioCabineCore();
        private NetworkCredential ftpCredenziali = new NetworkCredential(ConfigHelper.Settings.FTPUser, ConfigHelper.Settings.FTPPass);
        protected bool isDisabled = false;
        protected MudForm form;


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
                    idBiblioCambina = !string.IsNullOrEmpty(IDBiblioCambina) ? int.Parse(Helper.Base64Decode(IDBiblioCambina)) : idBiblioCambina;
                    var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
                    try
                    {
                        if (IDBiblioCambina != null)
                        {
                            title = "Modifca postazione";
                            cabina = core.GetAllBiblioCabine(idBiblioCambina, true).FirstOrDefault();
                            idStato = cabina.IDStato.ToString();
                            if (idStato == "2")
                            {
                                isDisabled = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        await AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
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
            StateHasChanged();
        }


   

        protected async Task LoadFile(InputFileChangeEventArgs e)
        {
            try
            {
                foreach (IBrowserFile imgFile in e.GetMultipleFiles(5))
                {
                    MemoryStream ms = new MemoryStream();
                    await e.File.OpenReadStream().CopyToAsync(ms);
                    var bytes = ms.ToArray();
                    cabina.FileImg.BytesImmagine = bytes;
                    cabina.FileImg.SizeImmagine = e.File.Size;
                    cabina.FileImg.NomeFileImmagine = e.File.Name;
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
        }

        protected void CancellaFile(MudChip chip)
        {
            var fileName = chip.Text;
            cabina.FileImg = new();
        }

        protected async Task Salva()
        {
            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
                cabina.IDStato = int.Parse(idStato);
                IDialogReference dialog = null;
                try
                {
                    if (!ConvalidaCampi())
                    {

                        await AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = "ATTENZIONE! I campi con * sono obbligatori",
                            Severity = SeverityEnumClass.Error
                        });
                    }
                    else
                    {
                        dialog = DialogService.Show<Loading>(".... ATTENDRE PREGO ....");
                        await Task.Run(SalvaAsyn);
                    }
                }
                catch (Exception ex)
                {
                    await AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ex.Message,
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
        private async Task SalvaAsyn()
        {
            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                try
                {
                    cabina.FileImg.PathImmagineFTP = ConfigHelper.Settings.FTPSite + ConfigHelper.Settings.PathRoot + ConfigHelper.Settings.PathFileImgBiblioCabine;
                    cabina.FileImg.PathImmagine = ConfigHelper.Settings.PathFileImgBiblioCabine;
                    CopiaFile();
                    //Salvo nella base dati;
                    core.InsertBiblioCabina(cabina);
                    AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ConstantMessage.Successo,
                        Severity = SeverityEnumClass.Success
                    });
                }
                catch (Exception ex)
                {
                    AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                    {
                        Message = ex.Message,
                        Severity = SeverityEnumClass.Error
                    });
                }
            }
        }
        protected async Task Preview()
        {
            if (ConvalidaCampi())
            {

                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Cabina", cabina);
                DialogService.Show<Preview>("Anteprima della nuova bibliocabina", parameters, options);
            }
            else
            {
                await AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = ConstantMessage.CampiVuoti,
                    Severity = SeverityEnumClass.Error
                });
            }
        }

        private bool ConvalidaCampi()
        {
            if (string.IsNullOrEmpty(cabina.NomeCabina) || string.IsNullOrEmpty(cabina.Posizione)
                || string.IsNullOrEmpty(cabina.FileImg.NomeFileImmagine))
            {
                return false;
            }
            return true;
        }
        private void CopiaFile()
        {
            try
            {
                if (cabina.FileImg.BytesImmagine != null) //ho cambito immagino
                {
                    if (ListDirectoryExist(cabina.FileImg.PathImmagineFTP) == null)
                    {
                        //Creo la directory
                        FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(cabina.FileImg.PathImmagineFTP);
                        reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                        reqFTP.UseBinary = true;
                        reqFTP.Credentials = ftpCredenziali;
                        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                        Stream ftpStream = response.GetResponseStream();
                        ftpStream.Close();
                        response.Close();
                    }
                    //Copio il file
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(cabina.FileImg.PathImmagineFTP + cabina.FileImg.NomeFileImmagine);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = ftpCredenziali;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(cabina.FileImg.BytesImmagine, 0, (int)cabina.FileImg.SizeImmagine);
                    reqStream.Close();

                    var resp = (FtpWebResponse)request.GetResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public FtpWebResponse ListDirectoryExist(string path)
        {
            FtpWebResponse response = null;
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(path);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = ftpCredenziali;
                response = (FtpWebResponse)reqFTP.GetResponse();
            }
            catch (WebException ex)
            {
                return response;
            }
            return response;
        }





    }
}
