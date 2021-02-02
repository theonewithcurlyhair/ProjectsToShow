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
    public class LoginDB
    {
        private const string LOGIN = "sp_Authorization";
        public DataTable RetrieveLevelAccess(string login, string password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@loginId", login, SqlDbType.Int, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@password", password, SqlDbType.NVarChar, ParameterDirection.Input, 50));

            DataAccess db = new DataAccess();
            return db.Execute(LOGIN, CommandType.StoredProcedure, parms);
        }

        public User Login(User user)
        {
            try
            {
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@loginId", user.ID, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@password", user.Password, System.Data.SqlDbType.NVarChar));
                DataAccess dal = new DataAccess();
                DataTable dt = dal.Execute(LOGIN, CommandType.StoredProcedure, parms);
                if(dt.Rows.Count == 0)
                { 
                    user.AddError(new Error("No user was found with those credentials"));
                    return user;
                }
                user.Status = (Status)Enum.Parse(typeof(Status), dt.Rows[0]["Status"].ToString());

                user.FName = dt.Rows[0]["FName"].ToString();
                user.MName = dt.Rows[0]["MName"].ToString();
                user.LName = dt.Rows[0]["LName"].ToString();
                user.IsSupervisor = Convert.ToInt32(dt.Rows[0]["IsSupervisor"]) == 1;
                user.Departments.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                user.BirthDate = Convert.ToDateTime(dt.Rows[0]["BirthDate"]);
                user.StreetAddress = dt.Rows[0]["StreetAddress"].ToString();
                user.City = dt.Rows[0]["City"].ToString();
                user.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                user.SIN = dt.Rows[0]["SIN"].ToString();
                user.SeniorityDate = Convert.ToDateTime(dt.Rows[0]["SeniorityDate"]);
                user.WorkPhoneNumber = dt.Rows[0]["WorkPhoneNumber"].ToString();
                user.CellPhoneNumber = dt.Rows[0]["CellPhoneNumber"].ToString();
                user.Email = dt.Rows[0]["Email"].ToString();
                //department
                user.Departments = new Departments();
                user.Departments.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                user.Departments.Name = dt.Rows[0]["DepartmentName"].ToString();
                
                //job
                user.Job = new Job();
                user.Job.ID = Convert.ToInt32(dt.Rows[0]["JobID"]);
                user.Job.Name = dt.Rows[0]["JobName"].ToString();

                //supervisor
                user.Supervisor = new Employee();
                user.Supervisor.ID = Convert.ToInt32(dt.Rows[0]["SupervisorID"]);
                user.IsSupervisor = Convert.ToInt32(dt.Rows[0]["IsSupervisor"]) > 0;
                if (!user.IsSupervisor)
                {
                    user.Supervisor.FName = dt.Rows[0]["SFName"].ToString();
                    user.Supervisor.MName = dt.Rows[0]["SMName"].ToString();
                    user.Supervisor.LName = dt.Rows[0]["SLName"].ToString();
                }
                else
                {
                    user.Supervisor.FName = dt.Rows[0]["FName"].ToString();
                    user.Supervisor.MName = dt.Rows[0]["MName"].ToString();
                    user.Supervisor.LName = dt.Rows[0]["LName"].ToString();
                }
                
                user.Country = dt.Rows[0]["Country"].ToString();
                user.Province = dt.Rows[0]["Province"].ToString();
                user.JobStartDate = Convert.ToDateTime(dt.Rows[0]["JobStartDate"].ToString());
                user.OfficeLocation = dt.Rows[0]["OfficeLocation"].ToString();

            }
            catch (Exception ex)
            {
                user.AddError(new Error(ex.Message));
            }

            return user;
        }
    }
}
