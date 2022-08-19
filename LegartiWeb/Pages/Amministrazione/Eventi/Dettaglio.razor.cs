using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Amministrazione.Eventi
{
    public class DettaglioBase : BaseCustomComponent
    {
        [Parameter]
        public string IDEvento { set; get; }
        protected int idEvento = 0;
        protected string title = "";
        protected EventoModel evento = new EventoModel();
        protected string idStato = "";
        protected DateTime? minDataEvento = DateTime.Today;
        protected string errorFileEmpty = "";
        private EventoCore core = new EventoCore();
        private NetworkCredential ftpCredenziali = new NetworkCredential(ConfigHelper.Settings.FTPUser, ConfigHelper.Settings.FTPPass);
        private bool invioMail = false;
        protected bool isDisabled = false;
        protected MudForm form;

        // protected override async Task OnInitializedAsync()
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
                    idEvento = !string.IsNullOrEmpty(IDEvento) ? int.Parse(Helper.Base64Decode(IDEvento)) : idEvento;
                    evento.DataEvento = string.IsNullOrEmpty(IDEvento) ? DateTime.Today : evento.DataEvento;
                    var load = DialogService.Show<Loading>(ConstantMessage.LoadingMessage);
                    try
                    {
                        if (IDEvento != null)
                        {
                            title = "Modifca Evento";
                            evento = core.GetAllEventi(idEvento, true).FirstOrDefault();
                            idStato = evento.IDStato.ToString();
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

                foreach (IBrowserFile imgFile in e.GetMultipleFiles(1))
                {
                    long maxsize = 1512000;

                    MemoryStream ms = new MemoryStream();
                    await e.File.OpenReadStream(maxsize).CopyToAsync(ms);
                    var bytes = ms.ToArray();
                    evento.FileImg.BytesImmagine = bytes;
                    evento.FileImg.SizeImmagine = e.File.Size;
                    evento.FileImg.NomeFileImmagine = e.File.Name;
                }
            }
            catch (Exception ex)
            {
                await AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                {
                    Message = "ATTENZIONE! L'immagine non deve superare i ",
                    Severity = SeverityEnumClass.Error
                });
            }
        }
        protected void CancellaFile(MudChip chip)
        {
            var fileName = chip.Text;
            evento.FileImg = new();
        }
        protected async Task OnSelectedValuesChanged()
        {
             if (idStato == "2")
             {
                 var parameters = new DialogParameters();
                 parameters.Add("ContentText", ConfigHelper.Settings.ConsolidaEvento);
                 parameters.Add("ButtonText", "SI");
                 parameters.Add("Color", Color.Success);
                 var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
                 var dialog = DialogService.Show<PopUpSiNo>("Stato: CONSOLIDATO", parameters, options);
                invioMail = true;
             }
            else if (idStato == "1")
            {
                invioMail = false;
            }
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
                evento.IDStato = int.Parse(idStato);
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
                    ValorizzaDataGiorno((DateTime)evento.DataEvento);
                    ValorizzaDescBreve();
                    evento.FileImg.PathImmagineFTP = ConfigHelper.Settings.FTPSite + ConfigHelper.Settings.PathRoot + ConfigHelper.Settings.PathFileImgEventi + (((DateTime)evento.DataEvento).ToShortDateString().Replace("/", "-")) + "/";
                    evento.FileImg.PathImmagine = ConfigHelper.Settings.PathFileImgEventi + (((DateTime)evento.DataEvento).ToShortDateString().Replace("/", "-")) + "/";
                    /*//Cancella i files realtivi ad eventi passati
                    CancellaDirInFTP();*/
                    //Copia in file nella cartella
                    CopiaFile();
                    //Salvo nella base dati;
                    core.InsertEvento(evento);
                 /*   if (invioMail)
                    {
                        await core.InviaNewsLetter(evento);
                    }*/
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
            ValorizzaDataGiorno((DateTime)evento.DataEvento);
            ValorizzaDescBreve();
            if (ConvalidaCampi())
            {

                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Evento", evento);
                DialogService.Show<Preview>("Anteprima dell'evento", parameters, options);
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
        protected void OnDateChange(DateTime? newDate)
        {
            ValorizzaDataGiorno((DateTime)newDate);
        }
        protected void ValorizzaDescBreve()
        {
            if (evento.DescrizioneEvento.Length > 40)
            {
                evento.DescrizioneBreveEvento = evento.DescrizioneEvento.Substring(0, 40) + "...";
            }
            else
            {
                evento.DescrizioneBreveEvento = evento.DescrizioneEvento;
            }
        }
        protected void ValorizzaDataGiorno(DateTime newDate)
        {
            string giorno = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.GetDayName(newDate.DayOfWeek);
            evento.DataGiornoEvento = char.ToUpper(giorno[0]) + giorno.Substring(1) + ", " + evento.DataEvento.Value.ToString("dd/MM/yyyyy") + " dalle ";
            evento.DataEvento = newDate;
        }
        private bool ConvalidaCampi()
        {
            if (evento.DataEvento == null || string.IsNullOrEmpty(evento.OraEvento) || string.IsNullOrEmpty(evento.DescrizioneEvento)
                || string.IsNullOrEmpty(evento.LuogoEvento) || string.IsNullOrEmpty(evento.FileImg.NomeFileImmagine))
            {
                return false;
            }
            return true;
        }

        #region Funzioni FTP private
        private void CopiaFile()
        {

            try
            {
                if (evento.FileImg.BytesImmagine != null) //ho cambito immagino
                {
                    if (ListDirectoryExist(evento.FileImg.PathImmagineFTP) == null)
                    {
                        //Creo la directory
                        FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(evento.FileImg.PathImmagineFTP);
                        reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                        reqFTP.UseBinary = true;
                        reqFTP.Credentials = ftpCredenziali;
                        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                        Stream ftpStream = response.GetResponseStream();
                        ftpStream.Close();
                        response.Close();
                    }
                    //Copio il file
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(evento.FileImg.PathImmagineFTP + evento.FileImg.NomeFileImmagine);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = ftpCredenziali;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(evento.FileImg.BytesImmagine, 0, (int)evento.FileImg.SizeImmagine);
                    reqStream.Close();

                    var resp = (FtpWebResponse)request.GetResponse();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //private void CancellaDirInFTP()
        //{
        //    try
        //    {
        //        DateTimeFormatInfo cultureinfo = new CultureInfo("it-it", false).DateTimeFormat;
        //        DateTime dt =DateTime.Parse(DateTime.Now.Date.ToShortDateString(), cultureinfo);
        //        var path = ConfigHelper.Settings.FTPSite + ConfigHelper.Settings.PathRoot + ConfigHelper.Settings.PathFileImgEventi;
        //        //Lista Dir
        //        List<string> listaDir = ListaDirFtp(path);
        //        foreach (string singleDir in listaDir)
        //        {
        //            DateTime dataDir = Convert.ToDateTime(singleDir.Split("_")[0], cultureinfo);
        //            if (dataDir < dt)
        //            {
        //                //cancello tutti i files
        //                DeleteFile(path + singleDir + "/");
        //                //cancello la dir
        //                var removeRequest = (FtpWebRequest)WebRequest.Create(path + singleDir);
        //                removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
        //                removeRequest.Credentials = ftpCredenziali;
        //                removeRequest.GetResponse();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private List<string> ListaDirFtp(string path)
        {
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(path);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = ftpCredenziali;
                FtpWebResponse response = ListDirectoryExist(path);

                Stream ftpStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(ftpStream);
                string names = reader.ReadToEnd();
                List<string> listaDir = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ftpStream.Close();
                reader.Close();
                response.Close();
                return listaDir;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private void DeleteFile(string path)
        //{
        //    try
        //    {
        //        // Get the object used to communicate with the server.
        //        var request = (FtpWebRequest)WebRequest.Create(path);
        //        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        //        request.Credentials = ftpCredenziali;

        //        using (var response = (FtpWebResponse)request.GetResponse())
        //        {
        //            using (var responseStream = response.GetResponseStream())
        //            {
        //                var reader = new StreamReader(responseStream);
        //                while (!reader.EndOfStream)
        //                {
        //                    var line = reader.ReadLine();
        //                    if (string.IsNullOrWhiteSpace(line) == false)
        //                    {
        //                        string file = (line.Split(new[] { ' ', '\t' }).Last());
        //                        var removeRequest = (FtpWebRequest)WebRequest.Create(path + file);
        //                        removeRequest.Method = WebRequestMethods.Ftp.DeleteFile;
        //                        removeRequest.Credentials = ftpCredenziali;
        //                        removeRequest.GetResponse();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


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


        #endregion
    }
}
