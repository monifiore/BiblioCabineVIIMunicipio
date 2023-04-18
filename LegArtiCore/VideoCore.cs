using LegArtiModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{
    public class VideoCore : BaseCore
    {
        public ProgettoLegalitaModel GetAllVideo(int? idVideo,bool isAdmin = false)
        {
            ProgettoLegalitaModel ret = new();

            try
            {
                string list = genericDal.ExecuteWhitJsonRet("Video_GetAll", new Dictionary<string, object>() {
                                                                { "idVideo",idVideo},
                                                                { "isAdmin",isAdmin}
                                                                });
                string titolo = genericDal.ExecuteWhitJsonRet("Video_GetTitoloPagina", new Dictionary<string, object>() {
                                                                });
                ret.ListaVideo = !string.IsNullOrEmpty(list) ? JsonSerializer.Deserialize<List<VideoModel>>(list) : ret.ListaVideo;
                ret.Descrizione = !string.IsNullOrEmpty(list) ? JsonSerializer.Deserialize< List<TipologicaModel>>(titolo)[0] : ret.Descrizione;
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }

        public void InsertVideo(VideoModel video)
        {
            try
            {
                string json = JsonSerializer.Serialize(video);

                genericDal.ExecuteNonQuery("Video_Merge", new Dictionary<string, object>() {
                                            { "video",video}
                });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }

        public async Task DeleteBiblioCabina(int? idCabina)
        {
            try
            {
                genericDal.ExecuteNonQuery("LocazioneCabine_Delete", new Dictionary<string, object>() {
                                                                { "idCabina",idCabina}
                                                            });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }


    }
}
