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
    public class DepartmentDB
    {
        public int AddDepartment(Departments d)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@name", d.Name, SqlDbType.VarChar, ParameterDirection.Input, 250));
            parms.Add(new ParmStruct("@description", d.Description, SqlDbType.VarChar, ParameterDirection.Input, 250));
            parms.Add(new ParmStruct("@invocDate", d.InvocDate, SqlDbType.DateTime2, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            return db.ExecuteNonQuery("sp_AddDepartment", CommandType.StoredProcedure, parms);
        }

        public List<Departments> GetDepartments(int? id = null)
        {
            List<Departments> dep = new List<Departments>();
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@id", id, SqlDbType.Int, ParameterDirection.Input));
            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_GetDepartments", CommandType.StoredProcedure, parms);

            if(dt.Rows.Count > 0)
            {
                Departments department;
                foreach (DataRow row in dt.Rows)
                {
                    department = new Departments();
                    department.DepartmentID = Convert.ToInt32(row["ID"]);
                    department.Name = row["Name"].ToString();
                    dep.Add(department);
                }
            }

            return dep;
        }

        public Departments GetDepartmentById(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            Departments department = new Departments();
            parms.Add(new ParmStruct("@depId", id, SqlDbType.Int, ParameterDirection.Input));
            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getDepByID", CommandType.StoredProcedure, parms);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    department.DepartmentID = Convert.ToInt32(row["ID"]);
                    department.Name = row["Name"].ToString();
                    department.Description = row["Description"].ToString();
                    department.InvocDate = Convert.ToDateTime(row["InvocDate"]);
                    department.TimeStamp = (byte[])row["Timestamp"];
                }
            }

            return department;
        }


        public bool ModifyDepartment(Departments d)
        {
            try
            {
                DataAccess db = new DataAccess();
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@TimeStamp", d.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
                parms.Add(new ParmStruct("@Id", d.DepartmentID, SqlDbType.Int, ParameterDirection.Input));
                parms.Add(new ParmStruct("@Name", d.Name, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@Description", d.Description, SqlDbType.VarChar, ParameterDirection.Input, 50));
                parms.Add(new ParmStruct("@InvocDate", d.InvocDate, SqlDbType.Date, ParameterDirection.Input));

                int update = db.ExecuteNonQuery("sp_ModifyDepartment", CommandType.StoredProcedure, parms);

                if (update > 0) d.TimeStamp = (byte[])parms.First().Value;
                return update > 0;
            }
            catch (Exception ex)
            {

                d.AddError(new Error(ex.Message));
                return false;
            }
        }

        public bool DeleteDepartment(int id)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@id", id, SqlDbType.Int, ParameterDirection.Input));

            int delete = db.ExecuteNonQuery("sp_DeleteDepartment", CommandType.StoredProcedure, parms);

            return delete > 0;
        }
    }
}
