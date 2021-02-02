using BLL;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class EmployeeController : ApiController
    {
        private SearchEmployeeBL service = new SearchEmployeeBL();
        private DepartmentBL depService = new DepartmentBL();
        private EmployeeBL empService = new EmployeeBL();

        [HttpGet]
        [Route("searchemployee")]
        public IHttpActionResult GetEmployees(string lastName = "", int? id = -1) // if we don't specify URI in a root it will expect to see this parameter in queryString, same name
        {
            try
            {
                List<EmployeeVM> employees = new List<EmployeeVM>();
                if (lastName != "")
                {
                    DataTable dt = service.searchEmployee(null, lastName, 0);
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmployeeVM emp = new EmployeeVM();
                        emp.ID = Convert.ToInt32(dr["ID"]);
                        emp.Name = dr["Name"].ToString();
                        emp.CellPhone = dr["CellPhoneNumber"].ToString();
                        emp.Email = dr["Email"].ToString();
                        emp.JobName = dr["JobName"].ToString();
                        emp.DepartmentsName = dr["DepartmentName"].ToString();
                        emp.OfficeLocation = dr["OfficeLocation"].ToString();

                        employees.Add(emp);
                    }
                }
                else if (id != -1)
                {
                    DataTable dt = service.searchEmployee(id.ToString(), null, 0);
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmployeeVM emp = new EmployeeVM();
                        emp.ID = Convert.ToInt32(dr["ID"]);
                        emp.Name = dr["Name"].ToString();
                        emp.CellPhone = dr["CellPhoneNumber"].ToString();
                        emp.Email = dr["Email"].ToString();
                        emp.JobName = dr["JobName"].ToString();
                        emp.DepartmentsName = dr["DepartmentName"].ToString();
                        emp.OfficeLocation = dr["OfficeLocation"].ToString();

                        employees.Add(emp);
                    }
                }
                else
                {
                    DataTable dt = service.searchEmployee(null, null, 0);
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmployeeVM emp = new EmployeeVM();
                        emp.ID = Convert.ToInt32(dr["ID"]);
                        emp.Name = dr["Name"].ToString();
                        emp.CellPhone = dr["CellPhoneNumber"].ToString();
                        emp.Email = dr["Email"].ToString();
                        emp.JobName = dr["JobName"].ToString();
                        emp.DepartmentsName = dr["DepartmentName"].ToString();
                        emp.OfficeLocation = dr["OfficeLocation"].ToString();

                        employees.Add(emp);
                    }
                }

                string json = JsonConvert.SerializeObject(employees);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.ToString());
            }
        }

        [HttpGet]
        [Route("departments")]
        public IHttpActionResult GetDepartments()
        {
            try
            {
                List<Departments> dep = depService.GetDepartments();
                string json = JsonConvert.SerializeObject(dep);
                return Ok(json);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.ToString());
            }
        }


        [HttpGet]
        [Route("departments/{id}")]
        public IHttpActionResult GetEmployeeByDepartment(int id)
        {
            try
            {
                List<EmployeeVM> employees = new List<EmployeeVM>();

                DataTable dt = empService.GetEmployeeByDepartment(id);
                EmployeeVM emp;
                foreach (DataRow dr in dt.Rows)
                {
                    emp = new EmployeeVM();
                    emp.ID = Convert.ToInt32(dr["ID"]);
                    emp.Name = dr["Name"].ToString();
                    emp.CellPhone = dr["CellPhoneNumber"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.JobName = dr["JobName"].ToString();
                    emp.DepartmentsName = dr["DepartmentName"].ToString();
                    emp.OfficeLocation = dr["OfficeLocation"].ToString();

                    employees.Add(emp);
                }
                string json = JsonConvert.SerializeObject(employees);
                return Ok(json);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.ToString());
            }
        }
    }
}
