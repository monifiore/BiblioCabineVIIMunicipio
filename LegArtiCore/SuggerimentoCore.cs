using LegArtiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{
    public class SuggerimentoCore: BaseCore
    {

        public List<SuggerimentoModel> Suggerimento_GetAll(int? idUtete)
        {
            List<SuggerimentoModel> ret = new List<SuggerimentoModel>();
            try
            {
                string retString = genericDal.ExecuteWhitJsonRet("Suggerimento_GetAll",
                                            new Dictionary<string, object>() { { "idUtente", idUtete } });
                ret = JsonSerializer.Deserialize<List<SuggerimentoModel>>(retString);
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }


    

        
        public void Suggerimento_Cancella(int id)
        {
            try
            {
                genericDal.ExecuteNonQuery("Suggerimento_Cancella", 
                                            new Dictionary<string, object>() { { "Id", id } });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }
        public void Suggerimento_Inserisci(SuggerimentoModel model)
        {
            try
            {
              string id = genericDal.ExecuteWhitJsonRet("Suggerimento_Insert",
                                                      new Dictionary<string, object>() { { "Data", JsonSerializer.Serialize(model) } }
                                                     );
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
        }
    }
}
