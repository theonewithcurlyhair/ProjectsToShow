using BLL;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopValue
{
    public partial class ModifyEmployee : Form
    {
        private Main myMain;
        private EmployeeBL empBL;
        private User user;
        public ModifyEmployee()
        {
            InitializeComponent();
        }

        public ModifyEmployee(Main main)
        {
            myMain = main;
            InitializeComponent();
        } 

        private void PopulateEmpFields(User user)
        {
            txtWorkPhone.Text = user.WorkPhoneNumber;
            txtCellPhone.Text = user.CellPhoneNumber;
            txtEmail.Text = user.CellPhoneNumber;
            txtEmpId.Text = user.ID.ToString();
            txtCity.Text = user.City;
            txtStreetAddress.Text = user.StreetAddress;
            txtPostalCode.Text = user.PostalCode;

            txtSin.Text = user.SIN;
            dtpJobStartDate.Value = user.JobStartDate;
            cmbDepartment.SelectedValue = user.Departments.DepartmentID;

            cmbSupervisor.DataSource = empBL.GetSupervisors((int)cmbDepartment.SelectedValue);
            cmbSupervisor.DisplayMember = "Name";
            cmbSupervisor.ValueMember = "ID";
            cmbSupervisor.SelectedValue = user.SupervisorID;

            cmbJob.SelectedValue = user.Job.ID;

            dtpSeniority.Value = user.SeniorityDate;
            dtpBirthday.Value = user.BirthDate;

            cmbCountry.DataSource = Enum.GetValues(typeof(Country));
            cmbCountry.Text = user.Country;

            cmbStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbStatus.Text = user.Status.ToString();

            PopulateProvinceDropDown(cmbCountry.SelectedIndex);
            cmbProvince.Text = user.Province;

        }

        private void ModifyEmployee_Load_1(object sender, EventArgs e)
        {
            try
            {
                empBL = new EmployeeBL();

                cmbSearchCriteria.Items.Add("Retrieve all");
                cmbSearchCriteria.Items.Add("By Id");
                cmbSearchCriteria.Items.Add("By Last Name");
                cmbSearchCriteria.SelectedIndex = 0;


                cmbDepartment.DataSource = empBL.GetDepartments();
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "ID";


                // load jobs
                cmbJob.DataSource = empBL.GetJobs();
                cmbJob.DisplayMember = "Name";
                cmbJob.ValueMember = "ID";

                dtpStatus.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Searching employee by picked criterias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                SearchEmployeeBL searchBL = new SearchEmployeeBL();
                string errMsg = searchBL.ValidateEmployeeSearch(cmbSearchCriteria.SelectedIndex, txtSearchInput.Text);

                if (errMsg != string.Empty)
                {
                    MessageBox.Show(errMsg);
                }
                else
                {
                    string keyword = txtSearchInput.Text;
                    DataTable dt = new DataTable();
                    if (cmbSearchCriteria.SelectedIndex == 0)
                    {
                        dt = searchBL.searchEmployee(null, null, Convert.ToInt32(Properties.Settings.Default.EmpID));
                    }
                    else if (cmbSearchCriteria.SelectedIndex == 1)
                    {
                        dt = searchBL.searchEmployee(keyword, null, Convert.ToInt32(Properties.Settings.Default.EmpID));
                    }
                    else if (cmbSearchCriteria.SelectedIndex == 2)
                    {
                        dt = searchBL.searchEmployee(null, keyword, Convert.ToInt32(Properties.Settings.Default.EmpID));
                    }

                    if (dt.Rows.Count > 0)
                    {
                        cmbSearchResults.DataSource = dt;
                        cmbSearchResults.DisplayMember = "Name";
                        cmbSearchResults.ValueMember = "ID";
                    }
                    else
                    {
                        MessageBox.Show("Employee doesnt exist");
                        txtSearchInput.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Taking all fields back to the vodel to send them to the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click_1(object sender, EventArgs e)
        {
            try
            {
                empBL = new EmployeeBL();

                user.WorkPhoneNumber = txtWorkPhone.Text;
                user.CellPhoneNumber = txtCellPhone.Text;
                user.CellPhoneNumber = txtEmail.Text;

                user.City = txtCity.Text;
                user.StreetAddress = txtStreetAddress.Text;
                user.PostalCode = txtPostalCode.Text;

                user.SIN = txtSin.Text;
                user.JobStartDate = dtpJobStartDate.Value;

                user.BirthDate = dtpBirthday.Value;

                user.Departments = new Departments();
                if (cmbDepartment.SelectedIndex > 0)
                {
                    user.Departments.DepartmentID = (int)cmbDepartment.SelectedValue;
                }

                if (cmbSupervisor.SelectedIndex > 0)
                {
                    user.SupervisorID = (int)cmbSupervisor.SelectedValue;
                }

                user.Job = new Job();
                if (cmbJob.SelectedIndex > 0)
                {
                    user.Job.ID = (int)cmbJob.SelectedValue;
                }

                user.SeniorityDate = dtpSeniority.Value;

                user.Country = cmbCountry.Text;

                user.Status = (Status)cmbStatus.SelectedValue;

                user.Province = cmbProvince.Text;

                user.StatusDate = dtpStatus.Value;
                user.Errors.Clear();

                empBL.ModifyUser(user);

                if (user.Errors.Count > 0)
                {
                    string errors = "";
                    foreach (var error in user.Errors)
                    {
                        errors += error.ErrorName + Environment.NewLine;
                    }
                    MessageBox.Show(errors, "Please fix errors before modifying employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    user.Errors = new List<Error>();
                }
                else
                {
                    MessageBox.Show("Employee with ID " + user.ID + " was successfully modified");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        /// <summary>
        /// Pick employee from search results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSearchResults_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            try
            {
                int employeeId = (int)cmbSearchResults.SelectedValue;

                SearchEmployeeBL searchBL = new SearchEmployeeBL();

                user = searchBL.RetriveEmployee(employeeId);

                if (user.ID == Convert.ToInt32(Properties.Settings.Default.EmpID) || (Properties.Settings.Default.role != "Supervisor" && Properties.Settings.Default.DepartmentName == "HR Department"))
                {
                    grpJob.Enabled = false;
                    grpStatus.Enabled = false;
                }
                else
                {
                    grpJob.Enabled = true;
                    grpStatus.Enabled = true;
                }

                if (user.Status.ToString() == "Retired")
                {
                    cmbStatus.Enabled = false;
                    dtpStatus.Enabled = false;
                }
                else
                {
                    cmbStatus.Enabled = true;
                    dtpStatus.Enabled = true;
                }

                PopulateEmpFields(user);

                btnModify.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Change employee status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStatus_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedIndex != 0)
            {
                dtpStatus.Enabled = true;
            }
            else
            {
                dtpStatus.Enabled = false;
                dtpStatus.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// Change country 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProvinceDropDown(cmbCountry.SelectedIndex);
        }

        /// <summary>
        /// filling dropdown with provincies
        /// </summary>
        /// <param name="index"></param>
        private void PopulateProvinceDropDown(int index)
        {
            if (index == 1)
            {
                cmbProvince.DataSource = Enum.GetValues(typeof(States));
            }
            else
            {
                cmbProvince.DataSource = Enum.GetValues(typeof(Provincies));
            }
        }

        /// <summary>
        /// Pick another department of the employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex > 0)
            {
                cmbSupervisor.DataSource = empBL.GetSupervisors(cmbDepartment.SelectedIndex);
                cmbSupervisor.DisplayMember = "Name";
                cmbSupervisor.ValueMember = "ID";
                cmbSupervisor.SelectedIndex = -1;
            }
        }
    }
}
