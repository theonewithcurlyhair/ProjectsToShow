namespace TopValue
{
    partial class OutdatedReviews
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutdatedReviews));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvEmpWithPendingReviews = new System.Windows.Forms.DataGridView();
            this.btnSendReminders = new System.Windows.Forms.Button();
            this.cmbSupervisors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpWithPendingReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // dgvEmpWithPendingReviews
            // 
            this.dgvEmpWithPendingReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpWithPendingReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpWithPendingReviews.Location = new System.Drawing.Point(212, 140);
            this.dgvEmpWithPendingReviews.Name = "dgvEmpWithPendingReviews";
            this.dgvEmpWithPendingReviews.Size = new System.Drawing.Size(838, 273);
            this.dgvEmpWithPendingReviews.TabIndex = 12;
            // 
            // btnSendReminders
            // 
            this.btnSendReminders.Location = new System.Drawing.Point(571, 445);
            this.btnSendReminders.Name = "btnSendReminders";
            this.btnSendReminders.Size = new System.Drawing.Size(147, 50);
            this.btnSendReminders.TabIndex = 13;
            this.btnSendReminders.Text = "Send Reminders";
            this.btnSendReminders.UseVisualStyleBackColor = true;
            this.btnSendReminders.Click += new System.EventHandler(this.btnSendReminders_Click);
            // 
            // cmbSupervisors
            // 
            this.cmbSupervisors.FormattingEnabled = true;
            this.cmbSupervisors.Location = new System.Drawing.Point(581, 52);
            this.cmbSupervisors.Name = "cmbSupervisors";
            this.cmbSupervisors.Size = new System.Drawing.Size(192, 21);
            this.cmbSupervisors.TabIndex = 14;
            this.cmbSupervisors.SelectionChangeCommitted += new System.EventHandler(this.cmbSupervisors_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Supervisers with pending reviews:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Employees with Pending reviews by supervisor";
            // 
            // OutdatedReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 663);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSupervisors);
            this.Controls.Add(this.btnSendReminders);
            this.Controls.Add(this.dgvEmpWithPendingReviews);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OutdatedReviews";
            this.Text = "OutdatedReviews";
            this.Load += new System.EventHandler(this.OutdatedReviews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpWithPendingReviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvEmpWithPendingReviews;
        private System.Windows.Forms.Button btnSendReminders;
        private System.Windows.Forms.ComboBox cmbSupervisors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}