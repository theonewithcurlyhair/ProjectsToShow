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
    public partial class Login : Form
    {
        private string role { get; set; }
        public User loggedInUser { get; set; } = new User();
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validating login info and if it is good storing crucial information in settings of the solution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                LoginBL loginBL = new LoginBL();
                loggedInUser.Password = txtPassword.Text.Trim();
                loggedInUser.ID = Convert.ToInt32(txtUsername.Text);
                loggedInUser.Errors.Clear();

                if (loginBL.LoginSuccessful(loggedInUser))
                {
                    DataTable dt = loginBL.Authenticate(txtUsername.Text, txtPassword.Text);
                    //mike's way to login and store in defaults
                    if (dt.Rows.Count > 0)
                    {
                        Properties.Settings.Default.role = Convert.ToBoolean(dt.Rows[0]["IsSupervisor"]) ? "Supervisor" : "Employee";
                        Properties.Settings.Default.EmpName = dt.Rows[0]["FName"].ToString() + dt.Rows[0]["LName"].ToString();
                        Properties.Settings.Default.SupervisorEmail = dt.Rows[0]["Email"].ToString();
                        Properties.Settings.Default.EmpID = dt.Rows[0]["ID"].ToString();
                        Properties.Settings.Default.DepartmentName = dt.Rows[0]["DepartmentName"].ToString();
                    }
                    else{
                        MessageBox.Show("There is no such user in the system");
                        loggedInUser.Password = "";
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                        return;
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    loggedInUser.Errors.ForEach(x => MessageBox.Show(x.ErrorName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            loggedInUser.ID = 10000002;
            loggedInUser.Password = "testpassword";
            userBindingSource.DataSource = loggedInUser;
            errorProvider1.Clear();
            loggedInUser.Error = null;
            //TODO: Make error provider cancellable
        }
    }
}
