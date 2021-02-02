using BLL;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TopValue
{
    public partial class Department : Form
    {
        private Main myMain;
        private DepartmentBL depBL;
        private Departments d;
        public Department(Main main)
        {
            myMain = main;
            InitializeComponent();
        }

        public Department()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creating department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                depBL = new DepartmentBL();
                d = new Departments();
                d.Name = txtDepName.Text;
                d.Description = txtDepDescription.Text;
                d.InvocDate = dtpInvocationDate.Value;

                if (depBL.Validate(d).Count == 0)
                {
                    depBL.AddDepartment(d);
                    MessageBox.Show("Department was successfully added");
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// picking department data from a database by ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepartments_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                d = depBL.GetDepartmentById(Convert.ToInt32(cmbDepartments.SelectedValue));
                txtDepName.Text = d.Name;
                txtDepDescription.Text = d.Description;
                dtpInvocationDate.Value = d.InvocDate;
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// modifying department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                d.DepartmentID = (int)cmbDepartments.SelectedValue;
                d.Name = txtDepName.Text;
                d.Description = txtDepDescription.Text;
                d.InvocDate = dtpInvocationDate.Value;
                string errors = "";
                if (depBL.Validate(d).Count <= 0)
                {
                    if (depBL.ModifyDepartment(d))
                    {
                        MessageBox.Show("Department with ID: " + d.DepartmentID + " was modified successfully");
                    }
                }
                if (d.Errors.Count > 0)
                {
                    foreach (var error in d.Errors)
                    {
                        errors += error.ErrorName + Environment.NewLine;
                    }
                    MessageBox.Show(errors);
                    d.Errors.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// loading number of department depending of user role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Department_Load(object sender, EventArgs e)
        {
            try
            {
                depBL = new DepartmentBL();
                BindingSource bindingSource = new BindingSource();
                btnModify.Enabled = false;
                btnDelete.Enabled = false;

                if (Properties.Settings.Default.DepartmentName == "HR Department")
                {
                    BindDepartmentCmb();
                }
                else if (Properties.Settings.Default.role == "Supervisor" && Properties.Settings.Default.DepartmentName != "HR Department")
                {
                    bindingSource.DataSource = depBL.GetDepartments(Convert.ToInt32(Properties.Settings.Default.EmpID));
                    cmbDepartments.DataSource = bindingSource.DataSource;
                    cmbDepartments.DisplayMember = "Name";
                    cmbDepartments.ValueMember = "DepartmentID";
                    cmbDepartments.SelectedIndex = -1;

                    txtDepName.Enabled = false;
                    dtpInvocationDate.Enabled = false;

                    btnCreate.Visible = false;
                    btnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Deleting department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (depBL.DeleteDepartment((int)cmbDepartments.SelectedValue))
                {
                    MessageBox.Show("Department was deleted successfully");
                    BindDepartmentCmb();
                    btnModify.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDepartmentCmb()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = depBL.GetDepartments();
            cmbDepartments.DataSource = bindingSource.DataSource;
            cmbDepartments.DisplayMember = "Name";
            cmbDepartments.ValueMember = "DepartmentID";
            cmbDepartments.SelectedIndex = -1;
        }
    }
}
