using DAL;
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
    public class EmployeeDB
    {
        public int AddUser(User user, string hashedPasword)
        {
            try
            {
                DataAccess db = new DataAccess();
                List<ParmStruct> parms = new List<ParmStruct>();

                parms.Add(new ParmStruct("@empId", user.ID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@fName", user.FName, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@lName", user.LName, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@mName", user.MName, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@bDate", user.BirthDate, SqlDbType.DateTime2, ParameterDirection.Input));
                parms.Add(new ParmStruct("@streetAddress", user.StreetAddress, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@City", user.City, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@postalCode", user.PostalCode, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@sin", user.SIN, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@senorityDate", user.SeniorityDate, SqlDbType.DateTime2, ParameterDirection.Input));
                parms.Add(new ParmStruct("@wPhone", user.WorkPhoneNumber, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@cPhone", user.CellPhoneNumber, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@email", user.Email, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@departmentId", user.Departments.DepartmentID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@jobId", user.Job.ID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@supId", user.SupervisorID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@password", hashedPasword, SqlDbType.NVarChar, ParameterDirection.Input, 255));

                parms.Add(new ParmStruct("@country", user.Country, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@province", user.Province, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@isSuper", user.IsSupervisor, SqlDbType.Bit, ParameterDirection.Input));
                parms.Add(new ParmStruct("@status", "Active", SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@jobStartDate", user.JobStartDate, SqlDbType.Date, ParameterDirection.Input));
                
                return db.ExecuteNonQuery("sp_createEmployee", CommandType.StoredProcedure, parms);
            }
            catch (Exception ex)
            {

                user.AddError(new Error(ex.Message));
                return 0;
            }
        }

        public bool ModifyUser(User user)
        {
            try
            {
                DataAccess db = new DataAccess();
                List<ParmStruct> parms = new List<ParmStruct>();

                parms.Add(new ParmStruct("@Timestamp", user.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
                parms.Add(new ParmStruct("@empId", user.ID, SqlDbType.Int, ParameterDirection.Input));
                //parms.Add(new ParmStruct("@fName", user.FName, SqlDbType.VarChar, ParameterDirection.Input, 50));
                //parms.Add(new ParmStruct("@lName", user.LName, SqlDbType.VarChar, ParameterDirection.Input, 50));
                //parms.Add(new ParmStruct("@mName", user.MName, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@streetAddress", user.StreetAddress, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@City", user.City, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@postalCode", user.PostalCode, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@sin", user.SIN, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@senorityDate", user.SeniorityDate, SqlDbType.DateTime2, ParameterDirection.Input));
                parms.Add(new ParmStruct("@wPhone", user.WorkPhoneNumber, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@cPhone", user.CellPhoneNumber, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@email", user.Email, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@departmentId", user.Departments.DepartmentID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@jobId", user.Job.ID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@supId", user.SupervisorID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@jobStartDate", user.JobStartDate, SqlDbType.Date, ParameterDirection.Input));
                parms.Add(new ParmStruct("@country", user.Country, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@province", user.Province, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@StatusDate", user.StatusDate, SqlDbType.Date, ParameterDirection.Input));
                parms.Add(new ParmStruct("@Status", user.Status, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@Birthday", user.BirthDate, SqlDbType.Date, ParameterDirection.Input));

                int update = db.ExecuteNonQuery("sp_ModifyUser", CommandType.StoredProcedure, parms);
                if (update > 0) user.TimeStamp = (byte[])parms.First().Value;
                return update > 0;
            }
            catch (Exception ex)
            {
                user.AddError(new Error(ex.Message));
                return false;
            }
        }

        public bool ModifyPersonalData(User user)
        {
            try
            {
                DataAccess db = new DataAccess();
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@TimeStamp", user.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
                parms.Add(new ParmStruct("@Id", user.ID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@StreetAddress", user.StreetAddress, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@City", user.City, SqlDbType.VarChar, ParameterDirection.Input, 255));
                parms.Add(new ParmStruct("@PostalCode", user.PostalCode, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@Wphone", user.WorkPhoneNumber, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@Cphone", user.CellPhoneNumber, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@Country", user.Country, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@Province", user.Province, SqlDbType.VarChar, ParameterDirection.Input, 50));

                int update = db.ExecuteNonQuery("sp_ModifyPersonalInfo", CommandType.StoredProcedure, parms);

                if (update > 0) user.TimeStamp = (byte[])parms.First().Value;
                return update > 0;
            }
            catch (Exception ex)
            {

                user.AddError(new Error(ex.Message));
                return false;
            }

        }

        public int GetLastId()
        {
            DataAccess db = new DataAccess();
            string sql = "SELECT TOP 1 ID FROM Employee ORDER BY ID DESC";
            return (int)db.ExecuteScaler(sql, CommandType.Text, null);
        }

        public DataTable GetDepartments()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = null;
            string sql = "SELECT * FROM Department";
            DataTable dt = db.Execute(sql, CommandType.Text, parms);
            DataRow nullRow = dt.NewRow();
            dt.Columns["ID"].AllowDBNull = true;
            nullRow["ID"] = DBNull.Value;
            nullRow["Name"] = "";
            dt.Rows.InsertAt(nullRow, 0);
            return dt;
        }

        public DataTable GetEmployees()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = null;
            string sql = "SELECT ID, FName + ' ' + LName as Name FROM Employee";
            DataTable dt = db.Execute(sql, CommandType.Text, parms);
            DataRow nullRow = dt.NewRow();
            dt.Columns["ID"].AllowDBNull = true;
            nullRow["ID"] = DBNull.Value;
            nullRow["Name"] = "";
            dt.Rows.InsertAt(nullRow, 0);
            return dt;
        }

        public DataTable GetSupervisors(int departmentId)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@departmentId", departmentId, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = db.Execute("sp_getSupervisors", CommandType.StoredProcedure, parms);
            DataRow nullRow = dt.NewRow();
            dt.Columns["ID"].AllowDBNull = true;
            nullRow["ID"] = DBNull.Value;
            nullRow["Name"] = "";
            dt.Rows.InsertAt(nullRow, 0);
            return dt;
        }

        public DataTable GetAllHREmployees()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();

            return db.Execute("sp_GetAllHREmployees", CommandType.StoredProcedure, parms);

        }


        public DataTable GetSupervisorsWithPendReviews()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();

            DataTable dt = db.Execute("sp_GetSuperWithPendReviews", CommandType.StoredProcedure, parms);
            DataRow nullRow = dt.NewRow();
            dt.Columns["superID"].AllowDBNull = true;
            nullRow["superID"] = DBNull.Value;
            nullRow["Name"] = "";
            dt.Rows.InsertAt(nullRow, 0);
            return dt;
        }

        public DataTable GetJobs()
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = null;

            string sql = "SELECT * FROM Job";
            DataTable dt = db.Execute(sql, CommandType.Text, parms);
            DataRow nullRow = dt.NewRow();
            dt.Columns["ID"].AllowDBNull = true;
            nullRow["ID"] = DBNull.Value;
            nullRow["Name"] = "";
            dt.Rows.InsertAt(nullRow, 0);
            return dt;
        }

        public DataTable GetSupervisedEmployees(int supervisorId)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@empId", supervisorId, SqlDbType.Int, ParameterDirection.Input));
            DataTable dt = db.Execute("sp_GetSupervisedEmployee", CommandType.StoredProcedure, parms);
            return dt;
        }

        public DataTable GetEmployeeByDepartment(int departmentId)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = null;

            string sql = "SELECT Employee.ID, FName + ' ' + LName as Name, CellPhoneNumber, Email, OfficeLocation, Department.Name as DepartmentName, Job.Name as JobName FROM Employee INNER JOIN Department ON Employee.DepartmentID = Department.ID INNER JOIN Job ON Employee.JobID = Job.ID WHERE DepartmentId = " + departmentId + " ORDER BY Employee.LName";
            DataTable dt = db.Execute(sql, CommandType.Text, parms);

            return dt;
        }
    }
}
