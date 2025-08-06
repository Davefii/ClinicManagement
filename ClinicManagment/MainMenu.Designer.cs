namespace ClinicManagment
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewDoctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listDoctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSpecialationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAppointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPatientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDoctorInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confermingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.complateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueMedicalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMedicalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPaymentInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem,
            this.doctorsToolStripMenuItem,
            this.appointmentToolStripMenuItem,
            this.userToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPatientToolStripMenuItem,
            this.listPatientToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(94, 34);
            this.patientToolStripMenuItem.Text = "&Patient";
            // 
            // addNewPatientToolStripMenuItem
            // 
            this.addNewPatientToolStripMenuItem.Image = global::ClinicManagment.Properties.Resources._855637;
            this.addNewPatientToolStripMenuItem.Name = "addNewPatientToolStripMenuItem";
            this.addNewPatientToolStripMenuItem.Size = new System.Drawing.Size(253, 34);
            this.addNewPatientToolStripMenuItem.Text = "Add New Patient";
            this.addNewPatientToolStripMenuItem.Click += new System.EventHandler(this.addNewPatientToolStripMenuItem_Click);
            // 
            // listPatientToolStripMenuItem
            // 
            this.listPatientToolStripMenuItem.Image = global::ClinicManagment.Properties.Resources._9025639_list_bullets_icon;
            this.listPatientToolStripMenuItem.Name = "listPatientToolStripMenuItem";
            this.listPatientToolStripMenuItem.Size = new System.Drawing.Size(253, 34);
            this.listPatientToolStripMenuItem.Text = "List Patient";
            this.listPatientToolStripMenuItem.Click += new System.EventHandler(this.listPatientToolStripMenuItem_Click);
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewDoctorsToolStripMenuItem,
            this.listDoctorsToolStripMenuItem,
            this.manageSpecialationsToolStripMenuItem});
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(101, 34);
            this.doctorsToolStripMenuItem.Text = "&Doctors";
            // 
            // addNewDoctorsToolStripMenuItem
            // 
            this.addNewDoctorsToolStripMenuItem.Image = global::ClinicManagment.Properties.Resources._855637;
            this.addNewDoctorsToolStripMenuItem.Name = "addNewDoctorsToolStripMenuItem";
            this.addNewDoctorsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.addNewDoctorsToolStripMenuItem.Text = "Add New Doctors";
            this.addNewDoctorsToolStripMenuItem.Click += new System.EventHandler(this.addNewDoctorsToolStripMenuItem_Click);
            // 
            // listDoctorsToolStripMenuItem
            // 
            this.listDoctorsToolStripMenuItem.Image = global::ClinicManagment.Properties.Resources._9025639_list_bullets_icon;
            this.listDoctorsToolStripMenuItem.Name = "listDoctorsToolStripMenuItem";
            this.listDoctorsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.listDoctorsToolStripMenuItem.Text = "List Doctors";
            this.listDoctorsToolStripMenuItem.Click += new System.EventHandler(this.listDoctorsToolStripMenuItem_Click);
            // 
            // manageSpecialationsToolStripMenuItem
            // 
            this.manageSpecialationsToolStripMenuItem.Name = "manageSpecialationsToolStripMenuItem";
            this.manageSpecialationsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.manageSpecialationsToolStripMenuItem.Text = "Manage Specialations";
            this.manageSpecialationsToolStripMenuItem.Click += new System.EventHandler(this.manageSpecialationsToolStripMenuItem_Click);
            // 
            // appointmentToolStripMenuItem
            // 
            this.appointmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAppointmentsToolStripMenuItem});
            this.appointmentToolStripMenuItem.Name = "appointmentToolStripMenuItem";
            this.appointmentToolStripMenuItem.Size = new System.Drawing.Size(166, 34);
            this.appointmentToolStripMenuItem.Text = "&Appointments";
            // 
            // addAppointmentsToolStripMenuItem
            // 
            this.addAppointmentsToolStripMenuItem.Name = "addAppointmentsToolStripMenuItem";
            this.addAppointmentsToolStripMenuItem.Size = new System.Drawing.Size(274, 34);
            this.addAppointmentsToolStripMenuItem.Text = "Add Appointments";
            this.addAppointmentsToolStripMenuItem.Click += new System.EventHandler(this.addAppointmentsToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem,
            this.listUsersToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.personInfoToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(77, 34);
            this.userToolStripMenuItem.Text = "&Users";
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // listUsersToolStripMenuItem
            // 
            this.listUsersToolStripMenuItem.Name = "listUsersToolStripMenuItem";
            this.listUsersToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.listUsersToolStripMenuItem.Text = "List Users";
            this.listUsersToolStripMenuItem.Click += new System.EventHandler(this.listUsersToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // personInfoToolStripMenuItem
            // 
            this.personInfoToolStripMenuItem.Name = "personInfoToolStripMenuItem";
            this.personInfoToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.personInfoToolStripMenuItem.Text = "Person Info";
            this.personInfoToolStripMenuItem.Click += new System.EventHandler(this.personInfoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(87, 34);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(12, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1086, 406);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPatientInfoToolStripMenuItem,
            this.showDoctorInfoToolStripMenuItem,
            this.changeStatusToolStripMenuItem,
            this.issueMedicalRecordsToolStripMenuItem,
            this.showMedicalRecordsToolStripMenuItem,
            this.payToolStripMenuItem,
            this.showPaymentInformationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(220, 158);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showPatientInfoToolStripMenuItem
            // 
            this.showPatientInfoToolStripMenuItem.Name = "showPatientInfoToolStripMenuItem";
            this.showPatientInfoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.showPatientInfoToolStripMenuItem.Text = "Show Patient Info";
            this.showPatientInfoToolStripMenuItem.Click += new System.EventHandler(this.showPatientInfoToolStripMenuItem_Click);
            // 
            // showDoctorInfoToolStripMenuItem
            // 
            this.showDoctorInfoToolStripMenuItem.Name = "showDoctorInfoToolStripMenuItem";
            this.showDoctorInfoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.showDoctorInfoToolStripMenuItem.Text = "Show Doctor info";
            this.showDoctorInfoToolStripMenuItem.Click += new System.EventHandler(this.showDoctorInfoToolStripMenuItem_Click);
            // 
            // changeStatusToolStripMenuItem
            // 
            this.changeStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confermingToolStripMenuItem,
            this.complateToolStripMenuItem,
            this.cancledToolStripMenuItem,
            this.notShowToolStripMenuItem});
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.changeStatusToolStripMenuItem.Text = "Change Status";
            // 
            // confermingToolStripMenuItem
            // 
            this.confermingToolStripMenuItem.Name = "confermingToolStripMenuItem";
            this.confermingToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.confermingToolStripMenuItem.Text = "Conferming";
            this.confermingToolStripMenuItem.Click += new System.EventHandler(this.confermingToolStripMenuItem_Click);
            // 
            // complateToolStripMenuItem
            // 
            this.complateToolStripMenuItem.Name = "complateToolStripMenuItem";
            this.complateToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.complateToolStripMenuItem.Text = "Complate";
            this.complateToolStripMenuItem.Click += new System.EventHandler(this.complateToolStripMenuItem_Click);
            // 
            // cancledToolStripMenuItem
            // 
            this.cancledToolStripMenuItem.Name = "cancledToolStripMenuItem";
            this.cancledToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cancledToolStripMenuItem.Text = "Cancled";
            this.cancledToolStripMenuItem.Click += new System.EventHandler(this.cancledToolStripMenuItem_Click);
            // 
            // notShowToolStripMenuItem
            // 
            this.notShowToolStripMenuItem.Name = "notShowToolStripMenuItem";
            this.notShowToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.notShowToolStripMenuItem.Text = "Not Show";
            this.notShowToolStripMenuItem.Click += new System.EventHandler(this.notShowToolStripMenuItem_Click);
            // 
            // issueMedicalRecordsToolStripMenuItem
            // 
            this.issueMedicalRecordsToolStripMenuItem.Name = "issueMedicalRecordsToolStripMenuItem";
            this.issueMedicalRecordsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.issueMedicalRecordsToolStripMenuItem.Text = "Issue Medical Records";
            this.issueMedicalRecordsToolStripMenuItem.Click += new System.EventHandler(this.issueMedicalRecordsToolStripMenuItem_Click);
            // 
            // showMedicalRecordsToolStripMenuItem
            // 
            this.showMedicalRecordsToolStripMenuItem.Name = "showMedicalRecordsToolStripMenuItem";
            this.showMedicalRecordsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.showMedicalRecordsToolStripMenuItem.Text = "Show Medical Records";
            this.showMedicalRecordsToolStripMenuItem.Click += new System.EventHandler(this.showMedicalRecordsToolStripMenuItem_Click);
            // 
            // payToolStripMenuItem
            // 
            this.payToolStripMenuItem.Name = "payToolStripMenuItem";
            this.payToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.payToolStripMenuItem.Text = "Pay";
            this.payToolStripMenuItem.Click += new System.EventHandler(this.payToolStripMenuItem_Click);
            // 
            // showPaymentInformationToolStripMenuItem
            // 
            this.showPaymentInformationToolStripMenuItem.Name = "showPaymentInformationToolStripMenuItem";
            this.showPaymentInformationToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.showPaymentInformationToolStripMenuItem.Text = "Show Payment information";
            this.showPaymentInformationToolStripMenuItem.Click += new System.EventHandler(this.showPaymentInformationToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Records :";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(111, 526);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(23, 25);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "0";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Appointment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(213, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Refrech";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1105, 560);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Clinic Mangment";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAppointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewDoctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listDoctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSpecialationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listPatientToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPatientInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDoctorInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confermingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem complateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueMedicalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMedicalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPaymentInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}

