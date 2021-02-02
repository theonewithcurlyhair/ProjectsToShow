using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Model.Entities;

namespace TopValue
{
    public partial class OutdatedReviews : Form
    {
        DataTable dt;
        private Main myMain;
        EmployeeBL empService = new EmployeeBL();
        ReviewService review = new ReviewService();
        public OutdatedReviews()
        {
            InitializeComponent();
        }

        public OutdatedReviews(Main main)
        {
            myMain = main;
            InitializeComponent();
        }

        /// <summary>
        /// SEnd all emails in one click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendReminders_Click(object sender, EventArgs e)
        {
            try
            {
                SendEmailBL sendEmail = new SendEmailBL();
                bool flag = false;
                foreach (DataRowView item in cmbSupervisors.Items)
                {
                    if (!item.Row.IsNull(1))
                    {
                        // depend on last review date for each of the users he will be put onto one of these two lists. One list for those who are 3- to 4 months late
                        // another is  4 and more
                        DataTable dt = empService.GetSupervisedEmployees((int)item["superID"]);
                        List<string> pendingEmployee = new List<string>();
                        List<string> outdatedEmployee = new List<string>();

                        foreach (DataRow employee in dt.Rows)
                        {
                            if (!(employee["ReviewDate"] is DBNull))
                            {
                                string date = Convert.ToDateTime(employee["ReviewDate"]).ToString();
                            }

                            if (!(employee["ReviewDate"] is DBNull) && Convert.ToDateTime(employee["ReviewDate"]) < DateTime.Now.AddMonths(-4))
                            {
                                outdatedEmployee.Add(employee["Name"].ToString());
                            }
                            else if (employee["ReviewDate"] is DBNull || Convert.ToDateTime(employee["ReviewDate"]) < DateTime.Now.AddMonths(-3))
                            {
                                pendingEmployee.Add(employee["Name"].ToString());
                            }
                        };

                        string emailBody = "";
                        if (outdatedEmployee.Count > 0)
                        {
                            emailBody += "</p>Please keem in mind that these employees had last review more than 4 months ago<p>" + Environment.NewLine;
                            emailBody += "</p>Check them ASAP!<p>" + Environment.NewLine;
                            emailBody += "<ul>";
                            foreach (string empName in outdatedEmployee)
                            {
                                emailBody += $"<li>{ empName }</li>" + Environment.NewLine;
                            }
                            emailBody += "</ul>" + Environment.NewLine;

                            // add link to enter our service
                            emailBody += "<a href='http://localhost:7900/Dashboard/Login'>Click here to start immediately</a>";

                            Email email = new Email();
                            email.EmailBody = emailBody;
                            email.EmailFrom = Properties.Settings.Default.SupervisorEmail;

                            // CC all HR employees to the email with users who has more than 4 months pendig review
                            List<string> CC = new List<string>();
                            foreach (DataRow row in empService.GetAllHREmployees().Rows)
                            {
                                CC.Add(row["Email"].ToString());
                            }

                            email.EmailSubject = "Pending outdated reviews";
                            email.EmailTo = $"{item["Email"].ToString()}";
                            email.LastReminderDate = DateTime.Now;

                            if (sendEmail.SendEmail(email, "greatguy@gmail.com", "Ylm.Bumk-999%", CC))
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                        }



                        if (pendingEmployee.Count > 0)
                        {
                            emailBody = "";
                            emailBody += "</p>Please keem in mind that these employees still dont have any reviews or had last review  3 months ago<p>" + Environment.NewLine;
                            emailBody += "<ul>";
                            foreach (string empName in pendingEmployee)
                            {
                                emailBody += $"<li>{ empName }</li>" + Environment.NewLine;
                            }
                            emailBody += "</ul>";

                            Email email = new Email();
                            email.EmailBody = emailBody;
                            email.EmailFrom = Properties.Settings.Default.SupervisorEmail;
                            email.EmailSubject = "Pending reviews";
                            email.EmailTo = $"{item["Email"].ToString()}";
                            email.LastReminderDate = DateTime.Now;

                            if (sendEmail.SendEmail(email, "greatguy@gmail.com", "Ylm.Bumk-999%"))
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                }
                if (flag)
                {
                    if (review.UpdateLastEmailSendDate())
                    {
                        MessageBox.Show("Emails were sent successfully");
                        btnSendReminders.Enabled = false;

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void OutdatedReviews_Load(object sender, EventArgs e)
        {
            try
            {
                cmbSupervisors.DataSource = empService.GetSupervisorsWithPendReviews();
                cmbSupervisors.DisplayMember = "Name";
                cmbSupervisors.ValueMember = "superID";

                // here we are checking when the last email reminder was sent, and if it is less than 24 hours ago we dissable the button
                DateTime lastReminderSent = review.LastEmailSentDate();
                if (lastReminderSent > DateTime.Now.AddDays(-1))
                {
                    btnSendReminders.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSupervisors_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbSupervisors.SelectedIndex > 0)
                {
                    dt = empService.GetSupervisedEmployees((int)cmbSupervisors.SelectedValue);
                    dgvEmpWithPendingReviews.DataSource = dt;
                    dgvEmpWithPendingReviews.AutoResizeColumns();
                    dgvEmpWithPendingReviews.Columns[0].HeaderText = "ID";
                    dgvEmpWithPendingReviews.Columns[1].HeaderText = "Employee Name";
                    dgvEmpWithPendingReviews.Columns[3].HeaderText = "Employee Email";
                    dgvEmpWithPendingReviews.Columns[2].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
