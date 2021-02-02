using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentBL
    {
        private DepartmentDB departmentDB;
        /// <summary>
        /// Adding department to DB
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int AddDepartment(Departments d)
        {
            departmentDB = new DepartmentDB();
            return departmentDB.AddDepartment(d);
        }
        /// <summary>
        /// Validate department fields according to the business rule
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public List<Error> Validate(Departments d)
        {
            if(String.IsNullOrEmpty(d.Name))
            {
                d.AddError(new Error("Department Name Cannot be empty"));
            }
            if (String.IsNullOrEmpty(d.Description))
            {
                d.AddError(new Error("Department Description Cannot be empty"));
            }
            if (d.InvocDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                d.AddError(new Error("Department Invoc Date Cannot be empty"));
            }
            return d.Errors;
        }

        /// <summary>
        /// Modifydepartment and send new info to the DB
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool ModifyDepartment(Departments d)
        {
            departmentDB = new DepartmentDB();
            return departmentDB.ModifyDepartment(d);
        }

        /// <summary>
        /// Delete department from the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDepartment(int id)
        {
            departmentDB = new DepartmentDB();
            return departmentDB.DeleteDepartment(id);
        }

        /// <summary>
        /// Get all department OR just a department of a specific supervisor depend on the parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Departments> GetDepartments(int? id = null)
        {
            departmentDB = new DepartmentDB();
            return departmentDB.GetDepartments(id);
        }

        /// <summary>
        /// get one department by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Departments GetDepartmentById(int id)
        {
            departmentDB = new DepartmentDB();
            return departmentDB.GetDepartmentById(id);
        }
    }
}
