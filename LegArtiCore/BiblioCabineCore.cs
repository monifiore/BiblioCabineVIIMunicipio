using LegArtiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{

    public class BiblioCabineCore : BaseCore
    {
        public  List<BiblioCabineModel> GetAllBiblioCabine(int? idBiblioCabina, bool isAdmin=false)
        {
            List<BiblioCabineModel> ret = new List<BiblioCabineModel>();
            try
            {
              /*  string list = genericDal.ExecuteWhitJsonRet("LocazioneCabine_GetAll", null);
                ret = JsonSerializer.Deserialize<List<BiblioCabineModel>>(list);*/

                string list = genericDal.ExecuteWhitJsonRet("LocazioneCabine_GetAll", new Dictionary<string, object>() {
                                                                { "idBiblioCabina",idBiblioCabina},
                                                                { "isAdmin",isAdmin}
                                                                });
                ret = !string.IsNullOrEmpty(list) ? JsonSerializer.Deserialize<List<BiblioCabineModel>>(list) : ret;
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }

        public void InsertBiblioCabina(BiblioCabineModel cabina)
        {
            try
            {
                string cabinaJson = JsonSerializer.Serialize(cabina);

                genericDal.ExecuteNonQuery("LocazioneCabine_Merge", new Dictionary<string, object>() {
                                            { "cabina",cabinaJson}
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