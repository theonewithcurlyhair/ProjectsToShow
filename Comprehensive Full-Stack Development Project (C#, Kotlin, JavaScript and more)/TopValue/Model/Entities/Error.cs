using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Error
    {
        public Error(int eNumber, string eName, string eDescription)
        {
            ErrorNumber = eNumber;
            ErrorName = eName;
            ErrorDescription = eDescription;
        }
        public Error(int eNumber, string eName)
        {
            ErrorNumber = eNumber;
            ErrorName = eName;
        }

        public Error(string eMsg)
        {
            ErrorName = eMsg;
        }

        public int ErrorNumber { get; set; }
        public string ErrorName { get; set; }
        public string ErrorDescription { get; set; }
    }
}
