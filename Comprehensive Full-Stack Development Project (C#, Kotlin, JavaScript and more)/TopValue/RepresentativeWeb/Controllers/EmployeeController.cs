using BIgSystemSolutions_Web.Models;
using BLL;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Controllers
{
    public class EmployeeController : Controller
    {

        private SearchEmployeeBL searchBL;
        private EmployeeBL empBL;
        // GET: Employee
        /// <summary>
        /// retrieving personal employee information
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");
            User logedInUser = (User)Session["User"];
            searchBL = new SearchEmployeeBL();
            User user = searchBL.RetriveEmployee(Convert.ToInt32(logedInUser.ID));
            TempData["TimeStamp"] = user.TimeStamp;

            return View(user);
        }

        /// <summary>
        /// posting back modified information
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(User user)  
        {
            empBL = new EmployeeBL();
            user.Errors = empBL.PersonalDataModifValidation(user);

            if(user.Errors.Count <= 0)
            {
                user.TimeStamp = (byte[])TempData["TimeStamp"];
                if (empBL.ModifyPersonalData(user))
                {
                    ViewBag.Success = "You successfully modified your personal data";
                    TempData["TimeStamp"] = user.TimeStamp;
                }
            }

            return View(user);
        }

        /// <summary>
        /// search employee by different criterias
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchEmployee()
        {
            EmpSearchVM vm = new EmpSearchVM();
            vm.User = new User();
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");
                vm.foundEmployee = new List<SelectListItem>();
                vm.foundEmployee.Add(new SelectListItem { Value = "", Text = "---Select User---" });
                vm.searchList = FillSearchDropBox();
            }
            catch (Exception ex)
            {

                vm.User.AddError(new Error(ex.Message));
            }

            return View(vm);
        }

        /// <summary>
        /// submitting search criterias to DB and retrieving appropriate info from there
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchEmployee(EmpSearchVM vm, FormCollection form) 
        {
            try
            {
                string search = form["cmbSearch"].ToString();
                string employeeName = form["employeeName"].ToString();
                vm.foundEmployee = new List<SelectListItem>();
                vm.User = new User();

                DataTable dt = new DataTable();
                searchBL = new SearchEmployeeBL();
                vm.searchList = FillSearchDropBox();

                if (search == "0")
                {
                    dt = searchBL.searchEmployee(null, null, 0);
                }
                else if (search == "1")
                {
                    string error = searchBL.ValidateEmployeeSearch(Convert.ToInt32(search), employeeName);
                    if (error == String.Empty)
                    {
                        dt = searchBL.searchEmployee(employeeName, null, Convert.ToInt32(Session["EmployeeID"]));
                    }
                    else
                    {
                        vm.User.AddError(new Error(error));
                    }
                }
                else
                {
                    dt = searchBL.searchEmployee(null, employeeName, Convert.ToInt32(Session["EmployeeID"]));
                }

                vm.foundEmployee.Add(new SelectListItem { Value = "", Text = "---Select User---" });
                foreach (DataRow row in dt.Rows)
                {
                    vm.foundEmployee.Add(new SelectListItem { Value = row["ID"].ToString(), Text = row["Name"].ToString() });
                }
            }
            catch (Exception ex)
            {

                vm.User.AddError(new Error(ex.Message));
            }

            return View(vm);
        }

        /// <summary>
        /// partial view that is responsible for getting individual employee information
        /// </summary>
        /// <param name="cmbEmployee"></param>
        /// <returns></returns>
        public PartialViewResult GetEmployeeRecord(int cmbEmployee)
        {
            searchBL = new SearchEmployeeBL();
            User user = searchBL.RetriveEmployee(cmbEmployee);
            return PartialView("GetEmployeeRecord", user);
        }

        private List<SelectListItem> FillSearchDropBox()
        {
            List<SelectListItem> searchList = new List<SelectListItem>();
            searchList.Add(new SelectListItem{Value = "0",Text = "Retrieve all"});
            searchList.Add(new SelectListItem { Value = "1", Text = "By Id" });
            searchList.Add(new SelectListItem { Value = "2", Text = "By Last Name" });

            return searchList;
        }
    }
}