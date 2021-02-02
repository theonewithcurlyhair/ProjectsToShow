using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SearchEmployeeBL
    {
        public DataTable searchEmployee(string keywordId, string keywordName, int superId)
        {
            SearchEmployeeDB searchDB = new SearchEmployeeDB();

            DataTable dt = searchDB.RetrieveSearchResults(keywordId, keywordName, superId);

            return dt;
        }

        public User RetriveEmployee(int employeeId)
        {
            SearchEmployeeDB searchDB = new SearchEmployeeDB();
            return searchDB.RetrieveEmployee(employeeId);
        }

        public string ValidateEmployeeSearch(int index, string searchString)
        {
            string errMsg = string.Empty;
            if (index == 1)
            {
                if (searchString != String.Empty)
                {
                    if (searchString.Length != 8)
                    {
                        errMsg += "User ID can only be 8 digits long" + Environment.NewLine;
                    }
                    else if (!int.TryParse(searchString, out int x))
                    {
                        errMsg += "User ID can only contain digits" + Environment.NewLine;
                    }
                }
            }


            if (String.IsNullOrEmpty(searchString) && index != 0)
            {
                errMsg += "Please enter something into a search field";
            }

            return errMsg;
        }
    }
}
