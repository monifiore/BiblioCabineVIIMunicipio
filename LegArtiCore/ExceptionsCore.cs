using LegArtiModel;
using System;
using System.Collections.Generic;


namespace LegArtiCore
{
    public class ExceptionsCore : BaseCore
    {
        public void Insert(EccezioneModel _model)
        {
            try
            {
                genericDal.ExecuteNonQuery("Eccezione_Insert", new Dictionary<string, object>
                {
                    { "CustomMessage", _model.CustomMessage },
                    { "MessaggioEccezione ", _model.ExceptionMessage},
                    { "Eccezione ", _model.Exception}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
