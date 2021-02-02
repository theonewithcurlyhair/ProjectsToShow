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
    public partial class Main : Form
    {
        private Department department;
        private EmployeeForm employee;
        private EmployeeSearch empSearch;
        private User currentUser = new User();
        private ModifyEmployee modifyEmployee;
        private OutdatedReviews outdatedReviews;
        private POMainForm poForm;
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load menu + closing menu items according to permissions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            Splash mysplash = new Splash();
            mysplash.ShowDialog();
            //show Login form
            Login myLogin = new Login();
            myLogin.ShowDialog();
            if (myLogin.DialogResult != DialogResult.OK)
            {
                this.Close();   
            }
            currentUser = myLogin.loggedInUser;
            if (Properties.Settings.Default.role != "Supervisor" && Properties.Settings.Default.DepartmentName != "HR Department")
            {
                addDepartmentToolStripMenuItem.Visible = false;
                addEmployeeToolStripMenuItem.Visible = false;
                searchEmployeeToolStripMenuItem.Visible = false;
                modifyEmployeeToolStripMenuItem.Visible = false;
                sendReviewRemindersToolStripMenuItem.Visible = false;
            }
            if (Properties.Settings.Default.role != "Supervisor" && Properties.Settings.Default.DepartmentName == "HR Department")
            {
                sendReviewRemindersToolStripMenuItem.Visible = false;
            }
            if (Properties.Settings.Default.role == "Supervisor" && Properties.Settings.Default.DepartmentName != "HR Department")
            {
                addEmployeeToolStripMenuItem.Visible = false;
                modifyEmployeeToolStripMenuItem.Visible = false;
                sendReviewRemindersToolStripMenuItem.Visible = false;
                searchEmployeeToolStripMenuItem.Visible = false;
            }

            tsslActiveUser.Text = currentUser.ToString();
            tsslCurrentDate.Text = DateTime.Now.ToLongDateString();
            //if (Properties.Settings.Default.role == "1")
            //{
            //    addDepartmentToolStripMenuItem.Visible = false;
            //}
        }

        private void OpenNewTab(Form myF)
        {
            if (tabControl1.Contains(myF))
            {
                tabControl1.TabPages[myF].Select();
            }
            else
            {
                tabControl1.TabPages.Add(myF);
            }
        }



        private void addDepartmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (department == null || department.IsDisposed)
            {
                department = new Department(this);
                OpenNewTab(department);
            }
            else
            {
                OpenNewTab(department);
            }
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employee == null || employee.IsDisposed)
            {
                employee = new EmployeeForm(this);
                OpenNewTab(employee);
            }
            else
            {
                OpenNewTab(employee);
            }
        }

        private void searchEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (empSearch == null || empSearch.IsDisposed)
            {
                empSearch = new EmployeeSearch(this);
                OpenNewTab(empSearch);
            }
            else
            {
                OpenNewTab(empSearch);
            }
        }

        private void addPurchaseRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(poForm == null || poForm.IsDisposed)
            {
                poForm = new POMainForm(this, currentUser);
                OpenNewTab(poForm);
            }
            else
            {
                OpenNewTab(poForm);
            }
        }

        private void modifyEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modifyEmployee == null || modifyEmployee.IsDisposed)
            {
                modifyEmployee = new ModifyEmployee(this);
                OpenNewTab(modifyEmployee);
            }
            else
            {
                OpenNewTab(modifyEmployee);
            }
        }

        private void sendReviewRemindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (outdatedReviews == null || outdatedReviews.IsDisposed)
            {
                outdatedReviews = new OutdatedReviews(this);
                OpenNewTab(outdatedReviews);
            }
            else
            {
                OpenNewTab(outdatedReviews);
            }
        }

    }
}
