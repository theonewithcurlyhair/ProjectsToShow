using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SQLLayer;
using System.Web.Security;
using System.Security.Cryptography;
using System.Data;

namespace BLL
{
    public class EmployeeBL
    {
        private EmployeeDB empDB;
        /// <summary>
        /// Validate all fields according to business rules when we add user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Error> EmployeeValidation(User user)
        {
            Regex sinRegex = new Regex(@"^(\d{3}-\d{3}-\d{3})|(\d{9})$");
            if(user.SIN != null)
            {
                Match sinMatch = sinRegex.Match(user.SIN);
                if (!sinMatch.Success)
                {
                    user.AddError(new Error(15, "Please enter a valid SIN number"));
                }
            }


            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if(user.Email != null)
            {
                Match emailMatch = emailRegex.Match(user.Email);
                if (!emailMatch.Success)
                {
                    user.AddError(new Error(14, "Please senter your valid email"));
                }
            }



            if (user.FName != null && String.IsNullOrWhiteSpace(user.FName))
            {
                user.AddError(new Error(2, "First Name field cannot be empty"));
            }
            if(user.LName != null && String.IsNullOrWhiteSpace(user.LName))
            {
                user.AddError(new Error(3, "Last Name field cannot be empty"));
            }
            if (user.SIN != null && String.IsNullOrWhiteSpace(user.SIN))
            {
                user.AddError(new Error(4, "Sin field cannot be empty"));
            }
            if (user.StreetAddress != null && String.IsNullOrWhiteSpace(user.StreetAddress))
            {
                user.AddError(new Error(5, "Street Address field cannot be empty"));
            }
            if (user.City != null && String.IsNullOrWhiteSpace(user.City))
            {
                user.AddError(new Error(6, "City field cannot be empty"));
            }
            if (user.PostalCode != null && String.IsNullOrWhiteSpace(user.PostalCode))
            {
                user.AddError(new Error(7, "Postal Code field cannot be empty"));
            }
            if (user.WorkPhoneNumber!= null && String.IsNullOrWhiteSpace(user.WorkPhoneNumber))
            {
                user.AddError(new Error(8, "Work Phone field cannot be empty"));
            }
            if (user.CellPhoneNumber != null && String.IsNullOrWhiteSpace(user.CellPhoneNumber))
            {
                user.AddError(new Error(9, "Cell Phone field cannot be empty"));
            }
            if (user.Email != null && String.IsNullOrWhiteSpace(user.Email))
            {
                user.AddError(new Error(10, "Email field cannot be empty"));
            }
            if(user.Departments != null && user.Departments.DepartmentID == 0)
            {
                user.AddError(new Error(11, "Please select department"));
            }
            if (user.Job != null && user.Job.ID == 0)
            {
                user.AddError(new Error(13, "Please select job"));
            }
            if (user.Password != null &&  user.Password == "")
            {
                user.AddError(new Error(17, "Please enter User Password"));
            }
            if(user.SeniorityDate != null && user.JobStartDate != null &&  user.SeniorityDate > user.JobStartDate)
            {
                user.AddError(new Error(18, "Job start date cannot be less than the seniority date"));
            }
            if(user.Province != null &&  String.IsNullOrWhiteSpace(user.Province.ToString()))
            {
                user.AddError(new Error(19, "Please choose or enter something into a state / province field"));
            }

            if(user.BirthDate != null && user.SeniorityDate != null && Convert.ToDateTime(user.BirthDate).Year > (Convert.ToDateTime(user.SeniorityDate).Year - 18))
            {
                user.AddError(new Error(19, "You cannot hire kids, please check the birthdate of the Employee you want to add"));
            }
            if(!user.IsSupervisor && user.SupervisorID == 0)
            {
                user.AddError(new Error(19, "Please assign a supervisor to the user"));
            }

            return user.Errors;
        }


        /// <summary>
        /// Validate fields when we try to modify personal data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Error> PersonalDataModifValidation(User user)
        {
            if (user.StreetAddress == null && String.IsNullOrWhiteSpace(user.StreetAddress))
            {
                user.AddError(new Error(5, "Street Address field cannot be empty"));
            }
            if (user.City == null && String.IsNullOrWhiteSpace(user.City))
            {
                user.AddError(new Error(6, "City field cannot be empty"));
            }
            if (user.PostalCode == null && String.IsNullOrWhiteSpace(user.PostalCode))
            {
                user.AddError(new Error(7, "Postal Code field cannot be empty"));
            }
            if (user.WorkPhoneNumber == null && String.IsNullOrWhiteSpace(user.WorkPhoneNumber))
            {
                user.AddError(new Error(8, "Work Phone field cannot be empty"));
            }
            if (user.CellPhoneNumber == null && String.IsNullOrWhiteSpace(user.CellPhoneNumber))
            {
                user.AddError(new Error(9, "Cell Phone field cannot be empty"));
            }
            return user.Errors;
        }

        /// <summary>
        /// Adding new user to the DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            empDB = new EmployeeDB();
            var data = Encoding.ASCII.GetBytes(user.Password);

            var md5 = new MD5CryptoServiceProvider();
            var hashedPassword = md5.ComputeHash(data);
            string hashString = BitConverter.ToString(hashedPassword).Replace("-", String.Empty).ToLower(); // this one we will send to the DB

            return empDB.AddUser(user, hashString);
        }

        /// <summary>
        /// Modify personal data of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyPersonalData(User user)
        {
            empDB = new EmployeeDB();

            return empDB.ModifyPersonalData(user);
        }

        /// <summary>
        /// Modify user on Desktop by HR employee
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyUser(User user)
        {
            empDB = new EmployeeDB();
            user.Errors = EmployeeValidation(user);
            if (user.Status.ToString() == "Retired")
            {
                int age = DateTime.Now.Year - user.BirthDate.Year;

                // For leap years we need this
                if (user.BirthDate > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                if (age < 55)
                {
                    user.AddError(new Error("This user is too young for retirement"));
                }
            }
            if (user.Errors.Count > 0)
            {
                return false;
            }

            return empDB.ModifyUser(user);
        }

        /// <summary>
        /// Get all Employees of HR department
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllHREmployees()
        {
            empDB = new EmployeeDB();

            return empDB.GetAllHREmployees();

        }

        public int GetLastStudentId()
        {
            empDB = new EmployeeDB();
            return empDB.GetLastId();
        }

        public DataTable GetDepartments()
        {
            empDB = new EmployeeDB();
            return empDB.GetDepartments();
        }

        public DataTable GetEmployees()
        {
            empDB = new EmployeeDB();
            return empDB.GetEmployees();
        }

        public DataTable GetSupervisors(int departmentId)
        {
            empDB = new EmployeeDB();
            return empDB.GetSupervisors(departmentId);
        }

        public DataTable GetJobs()
        {
            empDB = new EmployeeDB();
            return empDB.GetJobs();
        }

        public DataTable GetSupervisedEmployees(int supervisorId)
        {
            empDB = new EmployeeDB();
            return empDB.GetSupervisedEmployees(supervisorId);
        }

        public DataTable GetEmployeeByDepartment(int departmentId)
        {
            empDB = new EmployeeDB();
            return empDB.GetEmployeeByDepartment(departmentId);
        }

        public DataTable GetSupervisorsWithPendReviews()
        {
            empDB = new EmployeeDB();
            return empDB.GetSupervisorsWithPendReviews();
        }

        
    }
}
