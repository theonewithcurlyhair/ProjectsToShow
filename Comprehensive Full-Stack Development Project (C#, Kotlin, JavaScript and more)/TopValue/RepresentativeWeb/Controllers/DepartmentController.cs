using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;
using System.Globalization;

namespace BIgSystemSolutions_Web.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentBL depService;
        // GET: Department
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");
            return View();
        }


        /// <summary>
        /// Modifying Department GET action
        /// </summary>
        /// <returns></returns>
        public ActionResult Modify()
        {
            Departments department = new Departments();
            List<Departments> dep = new List<Departments>();
            try
            {
                User logedInUser = (User)Session["User"];
                if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");

                department.DepartmentID = 0;
                department.Name = "Select department to Modify";
                dep.Add(department);

                // Depending on the department of the logged in user we will retrieve different deprtments for him to modify
                depService = new DepartmentBL();

                if (logedInUser.DepartmentName == "HR Department")
                {
                    dep.AddRange(depService.GetDepartments());
                }
                else
                {
                    dep.AddRange(depService.GetDepartments(logedInUser.ID));
                }

                return View(dep);
            }
            catch (Exception ex)
            {

                department.AddError(new Error(ex.Message));
            }
            return View(dep);
        }

        /// <summary>
        /// Modify Department POST
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Modify(Departments d)
        {
            try
            {
                User logedInUser = (User)Session["User"];
                depService = new DepartmentBL();
                if(logedInUser.DepartmentName == "HR Department")
                {
                    List<Departments> dep = depService.GetDepartments();
                }
                else
                {
                    List<Departments> dep = depService.GetDepartments(logedInUser.ID);
                }

            }
            catch (Exception ex)
            {

                d.AddError(new Error(ex.Message));
            }
            
            return View(d);
        }

        /// <summary>
        /// GET for partial view where we display all department info we are willing to modify
        /// </summary>
        /// <param name="cmbDepartments"></param>
        /// <returns></returns>
        public PartialViewResult GetDepartmentRecord(int cmbDepartments)
        {
            User logedInUser = (User)Session["User"];
            ViewBag.UserDep = logedInUser.DepartmentName;
            depService = new DepartmentBL();
            Departments dep = depService.GetDepartmentById(cmbDepartments);
            TempData["DepTimeStamp"] = dep.TimeStamp;
            return PartialView("GetDepartmentRecord", dep);
        }

        /// <summary>
        /// Picking the department it will download appropriate information from the database
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult GetDepartmentRecord(Departments d)
        {
            User logedInUser = (User)Session["User"];
            ViewBag.UserDep = logedInUser.DepartmentName;
            try
            {
                depService = new DepartmentBL();
                if (depService.Validate(d).Count == 0)
                {
                    d.TimeStamp = (byte[])TempData["DepTimeStamp"];
                    if (depService.ModifyDepartment(d))
                    {
                        ViewBag.Success = "Department Modification went successfull";
                        TempData["DepTimeStamp"] = d.TimeStamp;
                    }
                }
            }
            catch (Exception ex)
            {

                d.AddError(new Error(ex.Message));
            }

            return PartialView(d);
        }
    }
}