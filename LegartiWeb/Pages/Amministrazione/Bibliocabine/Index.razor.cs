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

namespace LegartiWeb.Pages.Amministrazione.Bibliocabine
{
    public class IndexBase : BaseCustomComponent
    {
        protected bool visibilityPopUp = true;
        BiblioCabineCore core = new();
        public List<BiblioCabineModel> lista = new();
        protected MudTable<BiblioCabineModel> table;
        private NetworkCredential ftpCredenziali = new NetworkCredential(ConfigHelper.Settings.FTPUser, ConfigHelper.Settings.FTPPass);


        protected async Task<TableData<BiblioCabineModel>> GetBiblioCabine(TableState tableState)
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
                    lista = await Task.Run(() => core.GetAllBiblioCabine(null, true));
                    lista.ForEach(x => x.FileImg.PathImmagine = x.FileImg.PathImmagine + "/" + x.FileImg.NomeFileImmagine);
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
                    dialog.Close();
                    base.OnInitialized();
                }
            }
            return new TableData<BiblioCabineModel>() { Items = lista, TotalItems = lista.Count };
        }

        public void CabinaDettaglio(int idEvento)
        {
            NavigationManager.NavigateTo("/amministrazione/bibliocabine/dettaglio/" + Helper.Base64Encode(idEvento.ToString()), true);
        }
        public async Task CancellaCabinaConfirm(int idEvento)
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
                    try
                    {
                        CancellaCabina(idEvento);
                        AdminMainLayout.SetVisibilitySnackBar(new MessageModel()
                        {
                            Message = ConstantMessage.Successo,
                            Severity = SeverityEnumClass.Error
                        });
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
                    }
                }
            }
        }


        private void CancellaCabina(int idCabina)
        {
            var dialog = DialogService.Show<Loading>(".... ATTENDRE PREGO ....");
            try
            {
                BiblioCabineModel cabina = core.GetAllBiblioCabine(idCabina, true).FirstOrDefault();
                cabina.FileImg.PathImmagineFTP = ConfigHelper.Settings.FTPSite + ConfigHelper.Settings.PathRoot + cabina.FileImg.PathImmagine;
                //Cancello evento nel db
                core.DeleteBiblioCabina(cabina.IDLocazione);
                DeleteFile(cabina.FileImg.PathImmagineFTP, cabina.FileImg.NomeFileImmagine);
                NavigationManager.NavigateTo("/amministrazione/bibliocabine/index", true);
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

      

        private void DeleteFile(string path, string nomeFile)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path +nomeFile);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = ftpCredenziali;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AggiungiBibliocabina()
        {
            NavigationManager.NavigateTo("/amministrazione/bibliocabine/dettaglio/", true);
        }



    }
}
