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
    public partial class EmployeeSearch : Form
    {
        private Main myMain;
        private EmployeeBL empBL;
        public EmployeeSearch()
        {
            InitializeComponent();
        }

        public EmployeeSearch(Main main)
        {
            myMain = main;
            InitializeComponent();
        }

        private void EmployeeSearch_Load(object sender, EventArgs e)
        {

            cmbSearchCriteria.Items.Add("Retrieve all");
            cmbSearchCriteria.Items.Add("By Id");
            cmbSearchCriteria.Items.Add("By Last Name");
            cmbSearchCriteria.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
                    if(cmbSearchCriteria.SelectedIndex == 0)
                    {
                        dt = searchBL.searchEmployee(null, null, Convert.ToInt32(Properties.Settings.Default.EmpID));
                    }
                    else if (cmbSearchCriteria.SelectedIndex == 1)
                    {
                        dt = searchBL.searchEmployee(keyword, null, Convert.ToInt32(Properties.Settings.Default.EmpID));
                    }
                    else if(cmbSearchCriteria.SelectedIndex == 2)
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

        private void cmbSearchResults_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int employeeId = (int)cmbSearchResults.SelectedValue;

            SearchEmployeeBL searchBL = new SearchEmployeeBL();

            User user;

            user = searchBL.RetriveEmployee(employeeId);

            PopulateEmpFields(user);
        }

        private void PopulateEmpFields(User user)
        {
            txtWorkPhone.Text = user.WorkPhoneNumber;
            txtCellPhone.Text = user.CellPhoneNumber;
            txtEmail.Text = user.CellPhoneNumber;
            txtEmpId.Text = user.ID.ToString();

            txtFullAddress.Text = user.StreetAddress + " , " + user.City + Environment.NewLine +
                user.Province + " , " + user.Country + Environment.NewLine + user.PostalCode;


        }
    }
}
