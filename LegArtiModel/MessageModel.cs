using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiModel
{
    public class MessageModel
    {
        public string Message { set; get; }
        public SeverityEnumClass Severity { set; get; }
    }


    public enum SeverityEnumClass
    {

        Normal = 0,
        Info = 1,
        Success = 2,
        Warning = 3,
        Error = 4

    }


}