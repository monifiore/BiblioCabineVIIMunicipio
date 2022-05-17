using LegArtiCommon;
using LegArtiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{
    public class UserCore : BaseCore
    {
        public UtenteModel Login(LoginModel model)
        {
            string pass = Helper.Base64Encode(model.Password); //prova
            string email = Helper.Base64Encode(model.Email); //moni.fiore@libero.it
            UtenteModel ret = new UtenteModel();
            try
            {
                string userModel = genericDal.ExecuteWhitJsonRet("User_Login", new Dictionary<string, object>
                {
                    { "email", email },
                    { "password ", pass}
                });
                ret = JsonSerializer.Deserialize<UtenteModel>(userModel);
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return ret;
        }

     

    }
}
