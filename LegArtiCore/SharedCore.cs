using LegArtiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{
    public class SharedCore : BaseCore
    {
        public List<TipologicaModel> Tipologica_GetAll(string nomeTabella)
        {
            List<TipologicaModel> ret = new List<TipologicaModel>();
            try
            {
                string retString = genericDal.ExecuteWhitJsonRet("Tipologica_GetAll",
                                            new Dictionary<string, object>() { { "NomeTabella", nomeTabella } });
                ret = JsonSerializer.Deserialize<List<TipologicaModel>>(retString);
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }

    }
}
