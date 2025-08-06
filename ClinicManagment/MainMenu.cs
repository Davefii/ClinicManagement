using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagment
{
    public partial class MainMenu : Form
    {
        private DataTable _DtAllAppointment;
        Login _login;
        public MainMenu()
        {
            InitializeComponent();
        }
        public MainMenu(Login login)
        {
            InitializeComponent();
            _login = login;
        }

        private void addNewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewPatient addNewPatient = new addNewPatient();
            addNewPatient.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            _DtAllAppointment = clsAppointments.GetAllAppointments();
            dataGridView1.DataSource = _DtAllAppointment;
            lblCount.Text = dataGridView1.Rows.Count.ToString();
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    dataGridView1.Columns[0].HeaderText = "ID";
            //    dataGridView1.Columns[0].Width = 50;

            //    dataGridView1.Columns[1].HeaderText = "Patient ID";
            //    dataGridView1.Columns[1].Width = 50;

            //    dataGridView1.Columns[2].HeaderText = "Full Name";
            //    dataGridView1.Columns[2].Width = 400;

            //    dataGridView1.Columns[3].HeaderText = "Doctor ID";
            //    dataGridView1.Columns[3].Width = 140;

            //    dataGridView1.Columns[4].HeaderText = "Date";
            //    dataGridView1.Columns[4].Width = 120;

            //    dataGridView1.Columns[5].HeaderText = "Status";
            //    dataGridView1.Columns[5].Width = 120;

            //    dataGridView1.Columns[6].HeaderText = "MedicalRecord ID";
            //    dataGridView1.Columns[6].Width = 50;

            //    dataGridView1.Columns[7].HeaderText = "Payment_ID";
            //    dataGridView1.Columns[7].Width = 50;
            //}
        }


        private void addNewDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddorUpdateDoctors addorUpdateDoctors = new AddorUpdateDoctors();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.AddDoctor))
            {
                addorUpdateDoctors.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDoctors listDoctors = new ListDoctors();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.ListDoctors))
            {
                listDoctors.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void manageSpecialationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listSpecialations listSpecialations = new listSpecialations();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.Specialation))
            {
                listSpecialations.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPatient listPatient = new ListPatient();
            listPatient.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddorUpdateAppointment addorUpdateAppointment = new AddorUpdateAppointment(null);
            addorUpdateAppointment.ShowDialog();
            MainMenu_Load(null, null);
        }

        private void addAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddorUpdateAppointment addorUpdateAppointment = new AddorUpdateAppointment(null);
            addorUpdateAppointment.ShowDialog();
            MainMenu_Load(null, null);
        }

        private void showPatientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PatientId = (int)dataGridView1.CurrentRow.Cells[1].Value;
            int PersonID = Patients.Find(PatientId).PersonID;
            PersonInformation personInformation = new PersonInformation(PersonID);
            personInformation.ShowDialog();
        }

        private void showDoctorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DoctorId = (int)dataGridView1.CurrentRow.Cells[2].Value;
            int PersonID = clsDoctors.Find(DoctorId).PersonID;
            PersonInformation personInformation = new PersonInformation(PersonID);
            personInformation.ShowDialog();
        }

        private void confermingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsAppointments appointment = clsAppointments.Find(AppintmentID);
            if (appointment.ConfirmeAppointment())
                MessageBox.Show("Changed Status Sucessefully", "Sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Changed Status Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MainMenu_Load(null, null);
        }

        private void complateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsAppointments appointment = clsAppointments.Find(AppintmentID);
            if (appointment.ComplateAppointment())
                MessageBox.Show("Changed Status Sucessefully", "Sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Changed Status Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MainMenu_Load(null, null);
        }

        private void cancledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsAppointments appointment = clsAppointments.Find(AppintmentID);
            if (appointment.CancelAppointment())
                MessageBox.Show("Changed Status Sucessefully", "Sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Changed Status Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MainMenu_Load(null, null);
        }

        private void notShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsAppointments appointment = clsAppointments.Find(AppintmentID);
            if (appointment.NotShowAppointment())
                MessageBox.Show("Changed Status Sucessefully", "Sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Changed Status Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MainMenu_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            //int PaymentID = (int)dataGridView1.CurrentRow.Cells[6].Value;
            clsAppointments appointment = clsAppointments.Find(AppintmentID);
            //payToolStripMenuItem.Enabled = clsPayments.CheckExistPayment(PaymentID) ? true : false;
            // Appointment status logic
            if (appointment.Status == 1)
            {
                confermingToolStripMenuItem.Enabled = false;
                complateToolStripMenuItem.Enabled = true;
                cancledToolStripMenuItem.Enabled = true;
                notShowToolStripMenuItem.Enabled = true;
            }
            else if (appointment.Status == 2)
            {
                confermingToolStripMenuItem.Enabled = false;
                complateToolStripMenuItem.Enabled = false;
                cancledToolStripMenuItem.Enabled = false;
                notShowToolStripMenuItem.Enabled = false;
            }
            else if (appointment.Status == 3)
            {
                confermingToolStripMenuItem.Enabled = false;
                complateToolStripMenuItem.Enabled = false;
                cancledToolStripMenuItem.Enabled = false;
                notShowToolStripMenuItem.Enabled = false;
            }
            else if (appointment.Status == 4)
            {
                confermingToolStripMenuItem.Enabled = false;
                complateToolStripMenuItem.Enabled = true;
                cancledToolStripMenuItem.Enabled = true;
                notShowToolStripMenuItem.Enabled = false;
            }
        }

        private void issueMedicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsAppointments appointment = clsAppointments.Find(AppintmentID);
            AddOrUpdateMedicalRecord addOrUpdateMedicalRecord = new AddOrUpdateMedicalRecord(AppintmentID);
                addOrUpdateMedicalRecord.ShowDialog();
            MainMenu_Load(null, null);
        }

        private void showMedicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MedicalRecordID = (int)dataGridView1.CurrentRow.Cells[5].Value;
            int AppintmentID = 0;
            //bool hasMedicalRecord = clsMedicakRecords.CheckMedicalRecored(MedicalRecordID);
            AddOrUpdateMedicalRecord addOrUpdateMedicalRecord = new AddOrUpdateMedicalRecord(MedicalRecordID, AppintmentID);
                addOrUpdateMedicalRecord.ShowDialog();
            MainMenu_Load(null, null);
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppintmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Payfrm payfrm = new Payfrm(AppintmentID);
            payfrm.ShowDialog();
            MainMenu_Load(null, null);
        }

        private void showPaymentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PaymentID = (int)dataGridView1.CurrentRow.Cells[6].Value;
            Payfrm payfrm = new Payfrm(PaymentID,0);
            payfrm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrUpdateUser addOrUpdateUser = new AddOrUpdateUser();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.AddUser))
            {
                addOrUpdateUser.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListUsers listUsers = new ListUsers();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.ListUsers))
            {
                listUsers.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(clsGlobal.CurrentUser);
            changePassword.ShowDialog();
        }

        private void personInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show("No current user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsGlobal.CurrentUser.DoctorInfo == null)
            {
                MessageBox.Show("Doctor information is not available for the current user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsGlobal.CurrentUser.DoctorInfo.PersonInfo == null)
            {
                MessageBox.Show("Person information is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int PersonId = clsGlobal.CurrentUser.DoctorInfo.PersonInfo.ID;
            PersonInformation personInformation = new PersonInformation(PersonId);
            personInformation.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            _login.ShowDialog();
        }
    }
}
