using LegArtiCommon;
using LegArtiCore;
using LegArtiModel;
using LegartiWeb.CustomComponent;
using LegartiWeb.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LegartiWeb.Pages.Amministrazione.Eventi
{
    public class IndexBase : BaseCustomComponent
    {

        EventoCore core = new EventoCore();
        public List<EventoModel> lista = new();
        protected MudTable<EventoModel> table;
        private NetworkCredential ftpCredenziali = new NetworkCredential(ConfigHelper.Settings.FTPUser, ConfigHelper.Settings.FTPPass);


        protected async Task<TableData<EventoModel>> GetEventi(TableState tableState)
        {
            userLogged = await Session.GetSession<UtenteModel>("UtenteLoggatoAdmin");

            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                var dialog = DialogService.Show<Loading>(".... ATTENDRE PREGO ....");
                try
                {
                    lista = await Task.Run(() => core.GetAllEventi(null, true));

                    string giorno = "";
                    foreach (var single in lista)
                    {
                        giorno = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.GetDayName(((DateTime)single.DataEvento).DayOfWeek);
                        single.DataGiornoEvento = char.ToUpper(giorno[0]) + giorno.Substring(1) + ", " + single.DataEvento.Value.ToString("dd/MM/yyyyy") + " dalle ";
                        single.DescrizioneBreveEvento = single.DescrizioneEvento.Length > 40 ? single.DescrizioneEvento.Substring(0, 40) + "..." : single.DescrizioneEvento;
                    }
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
                    dialog.Close();
                    base.OnInitialized();
                }
            }
            return new TableData<EventoModel>() { Items = lista, TotalItems = lista.Count };
        }

        public void EventoDettaglio(int idEvento)
        {
            NavigationManager.NavigateTo("/amministrazione/eventi/dettaglio/" + Helper.Base64Encode(idEvento.ToString()), true);
        }
        public async Task CancellaEventoConfirm(int idEvento)
        {
            if (userLogged == null)
            {
                NavigationManager.NavigateTo("/amministrazione/index", true);
            }
            else
            {
                var parameters = new DialogParameters();
                parameters.Add("ContentText", ConstantMessage.ConfirmMessage);
                parameters.Add("ButtonText", "SI");
                parameters.Add("Color", Color.Success);

                var dialog = DialogService.Show<LegartiDialog>("Confirm", parameters);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    dialog.Close();
                    try
                    {

                        CancellaEvento(idEvento);
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
                        dialog.Close();
                    }
                }
            }
        }


        private void CancellaEvento(int idEvento)
        {
            var dialog = DialogService.Show<Loading>(".... ATTENDRE PREGO ....");
            try
            {
                EventoModel evento = core.GetAllEventi(idEvento, true).FirstOrDefault();
                evento.FileImg.PathImmagineFTP = ConfigHelper.Settings.FTPSite + ConfigHelper.Settings.PathRoot + evento.FileImg.PathImmagine;
                //Cancello evento nel db
                core.DeleteEvento(evento.IDEvento);
                CancellaDirInFTP(evento.FileImg.PathImmagineFTP, evento.FileImg.NomeFileImmagine);
                NavigationManager.NavigateTo("/amministrazione/eventi/index", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dialog.Close();
            }
        }

        private void CancellaDirInFTP(string path, string nomeFile)
        {
            try
            {
                //cancello tutti i files
                DeleteFile(path);
                //cancello la dir
                var removeRequest = (FtpWebRequest)WebRequest.Create(path);
                removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                removeRequest.Credentials = ftpCredenziali;
                removeRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void DeleteFile(string path)
        {
            try
            {
                // Get the object used to communicate with the server.
                var request = (FtpWebRequest)WebRequest.Create(path);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = ftpCredenziali;
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream);
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(line) == false)
                            {
                                string file = (line.Split(new[] { ' ', '\t' }).Last());
                                var removeRequest = (FtpWebRequest)WebRequest.Create(path + file);
                                removeRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                                removeRequest.Credentials = ftpCredenziali;
                                removeRequest.GetResponse();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AggiungiEvento()
        {
            NavigationManager.NavigateTo("/amministrazione/eventi/dettaglio/", true);
        }



    }
}
