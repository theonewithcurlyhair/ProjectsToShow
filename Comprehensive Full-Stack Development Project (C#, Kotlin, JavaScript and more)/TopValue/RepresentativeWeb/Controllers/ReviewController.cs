using BIgSystemSolutions_Web.Models;
using BLL;
using Model;
using Model.DTO;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewService reviewService = new ReviewService();
        private EmployeeBL empService = new EmployeeBL();
        // GET: Review
        /// <summary>
        /// get all employees of a logged in supervisor who needs reviews
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ReviewVM vm = new ReviewVM();
            vm.Review = new Review();
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");
                User logedInUser = (User)Session["User"];

                ViewBag.EmpName = logedInUser.FullName;

                vm.supervisedEmployeeList = FillSupervisedEmployee(vm, logedInUser.ID);
            }
            catch (Exception ex)
            {

                vm.Review.AddError(new Error(ex.Message));
            }


            return View(vm);
        }

        /// <summary>
        /// Get a review back from the form and upload it to the database
        /// </summary>
        /// <param name="r"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Review r, FormCollection form)
        {
            ReviewVM vm = new ReviewVM();
            vm.Review = new Review();
            User logedInUser = (User)Session["User"];
            try
            {
                ViewBag.EmpName = logedInUser.FullName;

                if (DateTime.TryParse(form["dtpReviewTime"], out DateTime d))
                {
                    r.ReviewDate = Convert.ToDateTime(form["dtpReviewTime"]);
                }
                else
                {
                    r.AddError(new Error("Date field cannot stay empty"));
                }

                r.Comment = form["reviewComment"].ToString();
                r.EmployeeId = Convert.ToInt32(form["cmbEmps"]);

                Enum.TryParse(form["Review.PerfomanceRating"].ToString(), out PerfomanceRating result);
                r.PerfomanceRating = result;
                reviewService.ReviewValidation(r);

                vm.Review = r;
                if (vm.Review.Errors.Count <= 0)
                {
                    if (reviewService.AddReview(r))
                    {
                        ViewBag.Success = "Review for employee with ID:" + r.EmployeeId + " was successfully added";
                    }
                }
                vm.supervisedEmployeeList = FillSupervisedEmployee(vm, logedInUser.ID);

                return View(vm);
            }
            catch (Exception ex)
            {
                r.AddError(new Error(ex.Message));
                vm.supervisedEmployeeList = FillSupervisedEmployee(vm, logedInUser.ID);
                vm.Review = r;
                return View(vm); 
            }
        }

        /// <summary>
        /// fill dropdown list of supervised employees
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="empID"></param>
        /// <returns></returns>
        private List<SelectListItem> FillSupervisedEmployee(ReviewVM vm, int empID)
        {
            vm = new ReviewVM();
            vm.supervisedEmployeeList = new List<SelectListItem>();
            DataTable dt = empService.GetSupervisedEmployees(empID);

            vm.supervisedEmployeeList.Add(new SelectListItem { Value = "0", Text = "---Select User---" });
            
            foreach (DataRow row in dt.Rows)
            {
                vm.supervisedEmployeeList.Add(new SelectListItem { Value = row["ID"].ToString(), Text = row["Name"].ToString() });
            }

            return vm.supervisedEmployeeList;
        }

        /// <summary>
        /// get a simple review o an employee
        /// </summary>
        /// <returns></returns>
        public ActionResult MyReviews()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");
            User logedInUser = (User)Session["User"];
            List<Review> myReviews  = reviewService.GetEmpReviews(logedInUser.ID);
            return View(myReviews);
        }

        /// <summary>
        /// get details of every single review
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Dashboard", "Login");

            ReviewDetailsDTO reviewDetails = reviewService.GetreviewDetails(id);
            reviewDetails.review.Comment = RemoveHTMLTags(reviewDetails.review.Comment);
            return View(reviewDetails);
        }

        private string RemoveHTMLTags(string value)
        {
            Regex regex = new Regex("\\<[^\\>]*\\>");
            value = regex.Replace(value, String.Empty);
            return value;
        }
    }
}