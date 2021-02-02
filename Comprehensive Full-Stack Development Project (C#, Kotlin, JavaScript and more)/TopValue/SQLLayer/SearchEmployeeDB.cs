using DAL;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Types.Types;

namespace SQLLayer
{
    public class SearchEmployeeDB
    {
        public DataTable RetrieveSearchResults(string keywordId, string keywordName, int superId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@keywordId", keywordId, SqlDbType.VarChar, ParameterDirection.Input, 8));
            parms.Add(new ParmStruct("@keywordName", keywordName, SqlDbType.VarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@SupervisorId", superId, SqlDbType.Int, ParameterDirection.Input, 30));

            DataAccess da = new DataAccess();
            return da.Execute("sp_SearchEmployee", CommandType.StoredProcedure, parms);
        }

        public User RetrieveEmployee(int empId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@id", empId, SqlDbType.VarChar, ParameterDirection.Input, 8));

            DataAccess da = new DataAccess();
            DataTable dt = da.Execute("sp_RetrieveEmployee", CommandType.StoredProcedure, parms);
            return PopulateEmployee(dt.Rows[0]);
        }

        public User PopulateEmployee(DataRow dr)
        {
            User user = new User();
            user.Departments = new Departments();
            user.Job = new Job();

            user.ID = Convert.ToInt32(dr["ID"]);
            user.WorkPhoneNumber = dr["WorkPhoneNumber"].ToString();
            user.CellPhoneNumber = dr["CellPhoneNumber"].ToString();
            user.Email = dr["Email"].ToString();
            user.StreetAddress = dr["StreetAddress"].ToString();
            user.PostalCode = dr["PostalCode"].ToString();
            user.City = dr["City"].ToString();
            user.Country = dr["Country"].ToString();
            user.Province = dr["Province"].ToString();
            user.TimeStamp = (byte[])dr["Timestamp"];
            user.SIN = dr["SIN"].ToString();

            user.Departments.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
            user.Job.ID = Convert.ToInt32(dr["JobID"]);
            user.SupervisorID = Convert.ToInt32(dr["SupervisorID"]);
            user.JobStartDate = Convert.ToDateTime(dr["JobStartDate"]);
            user.SeniorityDate = Convert.ToDateTime(dr["SeniorityDate"]);
            user.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
            user.TimeStamp = (byte[])dr["TimeStamp"];
            user.IsSupervisor = Convert.ToBoolean(dr["IsSupervisor"]);

            Enum.TryParse(dr["Status"].ToString(), out Status myStatus);
            user.Status = myStatus;

            return user;
        }
    }
}
