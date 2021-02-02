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
    public partial class EmployeeForm : Form
    {
        private EmployeeBL empBL;
        private Main myMain;
        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(Main main)
        {
            myMain = main;
            InitializeComponent();
        }
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // load Department combobox 
            empBL = new EmployeeBL();
            cmbDepartment.DataSource = empBL.GetDepartments();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            // load countries
            cmbCountry.DataSource = Enum.GetValues(typeof(Country));
            cmbCountry.SelectedIndex = -1;


            // load jobs
            cmbJob.DataSource = empBL.GetJobs();
            cmbJob.DisplayMember = "Name";
            cmbJob.ValueMember = "ID";
            cmbJob.SelectedIndex = -1;

            cmbSupervisor.Enabled = false;

            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            AddText(txtSin, e , "#111-111-111");
            AddText(txtEmail, e, "#wds.bms@gmail.com");
            AddText(txtPostalCode, e, "#E1C4W2");
            AddText(txtCellPhone, e, "#(506)-111-01-01");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            empBL = new EmployeeBL();
            string errorMessages = String.Empty;

            user.ID = empBL.GetLastStudentId() + 1; // we get the last user ID and add 1 to it , int this case it will be always unique
            user.FName = txtFName.Text;
            user.LName = txtLName.Text;
            user.MName = txtMName.Text;
            user.SIN = txtSin.Text;
            user.StreetAddress = txtStreetAddress.Text;
            user.City = txtCity.Text;
            user.PostalCode = txtPostalCode.Text;
            user.WorkPhoneNumber = txtWorkPhone.Text;
            user.CellPhoneNumber = txtCellPhone.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;

            user.BirthDate = dtpBirthDate.Value;
            user.SeniorityDate = dtpSeniority.Value.Date;
            user.JobStartDate = dtpJobStartDate.Value.Date;

            user.Departments = new Departments();
            if (cmbDepartment.SelectedIndex > 0)
            {
                user.Departments.DepartmentID = (int)cmbDepartment.SelectedValue;
            }



                if(cmbSupervisor.SelectedIndex > 0)
                {
                    user.SupervisorID = (int)cmbSupervisor.SelectedValue;
                }
                else if (chkIsSuper.Checked)
                {
                    user.IsSupervisor = chkIsSuper.Checked;
                }
                else
                {
                    errorMessages += "Please select supervisor for employee";
                }

            user.Job = new Job();
            if (cmbJob.SelectedIndex > 0)
            {
                user.Job.ID = (int)cmbJob.SelectedValue;
            }


            user.IsSupervisor = chkIsSuper.Checked;


            if(cmbCountry.SelectedIndex >= 0)
            {
                user.Country = cmbCountry.SelectedItem.ToString();
            }

            if(cmbProvince.Text != "")
            {
                user.Province = cmbProvince.Text;
            }

            List<Error> errs = empBL.EmployeeValidation(user);

            if(errs.Count > 0)
            {
                foreach (var err in errs)
                {
                    errorMessages += err.ErrorName + "\n";
                }
                MessageBox.Show(errorMessages, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int useradded = empBL.AddUser(user);
                if(useradded < 0)
                {
                    MessageBox.Show("User with ID " + user.ID + " was successfully added");
                    FillSupervCombobox();
                }
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //load supervisors
            if (cmbDepartment.SelectedIndex > 0)
            {
                FillSupervCombobox();
            }
            else
            {
                cmbSupervisor.DataSource = null;
            }

            cmbSupervisor.Enabled = true;
            if (cmbSupervisor.Items.Count <= 1)
            {
                chkIsSuper.Checked = true;
                chkIsSuper.Enabled = false;
            }
            else
            {
                chkIsSuper.Checked = false;
                chkIsSuper.Enabled = true;
            }
        }

        private void FillSupervCombobox()
        {
            cmbSupervisor.DataSource = empBL.GetSupervisors((int)cmbDepartment.SelectedValue);
            cmbSupervisor.DisplayMember = "Name";
            cmbSupervisor.ValueMember = "ID";
            cmbSupervisor.SelectedIndex = -1;
        }

        private void cmbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex == 1)
            {
                cmbProvince.DataSource = Enum.GetValues(typeof(States)); 
            }
            else
            {
                cmbProvince.DataSource = Enum.GetValues(typeof(Provincies));
            }

            cmbProvince.SelectedIndex = -1;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.ForeColor = Color.Black;
            textBox.Text = "";
        }

        public void AddText(object sender, EventArgs e, string placeholder)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = placeholder;
            }
        }

        private void txtSin_Enter(object sender, EventArgs e)
        {
            RemoveText(sender, e);
        }

        private void txtSin_Leave(object sender, EventArgs e)
        {
            AddText(sender, e, "111-111-111");
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            RemoveText(sender, e);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            AddText(txtEmail, e, "wds.bms@gmail.com");
        }

        private void txtPostalCode_Enter(object sender, EventArgs e)
        {
            RemoveText(sender, e);
        }

        private void txtPostalCode_Leave(object sender, EventArgs e)
        {
            AddText(txtPostalCode, e, "E1C4W2");
        }

        private void txtCellPhone_Enter(object sender, EventArgs e)
        {
            RemoveText(sender, e);
        }

        private void txtCellPhone_Leave(object sender, EventArgs e)
        {
            AddText(txtCellPhone, e, "(506)-111-01-01");
        }

        private void chkIsSuper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSuper.Checked)
            {
                cmbSupervisor.SelectedIndex = -1;
                cmbSupervisor.Enabled = false;
            }
            else
            {
                cmbSupervisor.Enabled = true;
            }
        }

        private void ClearForm(object sender, EventArgs e)
        {
            cmbDepartment.SelectedIndex = -1;

            // load countries
            cmbCountry.SelectedIndex = -1;

            // load jobs
            cmbJob.SelectedIndex = -1;

            cmbSupervisor.Enabled = false;
            cmbSupervisor.SelectedIndex = -1;



            txtCity.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtMName.Text = "";
            txtPassword.Text = "";
            txtStreetAddress.Text = "";
            txtWorkPhone.Text = "";

            AddText(txtSin, e, "#111-111-111");
            AddText(txtEmail, e, "#wds.bms@gmail.com");
            AddText(txtPostalCode, e, "#E1C4W2");
            AddText(txtCellPhone, e, "#(506)-111-01-01");
        }
    }
}
