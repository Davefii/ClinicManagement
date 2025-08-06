using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagment
{
    public partial class ctrlAddorUpdateAppointment : UserControl
    {
        public class ComboBoxItem
        {
            public string Text { get; set; }  // What shows in the box
            public int Value { get; set; }    // The actual PatientID or DoctorID

            public override string ToString()
            {
                return Text;
            }
        }
        public enum enMode { AddNew = 1, Update = 2 }
        private int? appointmentID = null;
        public enMode mode = enMode.AddNew;
        Patients patients;
        clsDoctors Doctor;
        clsAppointments appointments;
        public ctrlAddorUpdateAppointment()
        {
            InitializeComponent();
        }
        private void _FillNamePatientinCombobox()
        {
            comboBox1.Items.Clear();
            DataTable DT = Patients.GetAllPatients();
            foreach (DataRow row in DT.Rows)
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Text = row["FullName"].ToString(),
                    Value = Convert.ToInt32(row["ID"])
                };
                comboBox1.Items.Add(item);
            }
        }
        private void _FillNameDoctorsinCombobox()
        {
            DataTable DT = clsDoctors.GetAllDoctors();
            foreach (DataRow row in DT.Rows)
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Text = row["FullName"].ToString(),
                    Value = Convert.ToInt32(row["ID"])
                };
                comboBox2.Items.Add(item);
            }
        }
        public void LoadDataViaID(int? AppointmentID)
        {
            appointmentID = AppointmentID;
            if (appointmentID == null)
            {
                label1.Text = "Add New Appointment";
                appointments = new clsAppointments();
                _FillNamePatientinCombobox();
                _FillNameDoctorsinCombobox();
            }
            else
            {
                button2.Enabled = false;
                appointments = clsAppointments.Find((int)appointmentID);
                if (appointments == null)
                {
                    MessageBox.Show("No appointment With ID = " + appointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                patients = Patients.Find(appointments.PatientID);
                Doctor = clsDoctors.Find(appointments.DoctorID);
                lblID.Text = appointmentID.ToString();
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button2.Enabled = false;
                dateTimePicker1.Value = appointments.AppointmentDate;
                comboBox3.SelectedIndex = appointments.Status;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            addNewPatient AddNewPatient = new addNewPatient();
            AddNewPatient.ShowDialog();
            LoadDataViaID(appointmentID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ComboBoxItem selectedPatientItem)
                patients = Patients.Find(selectedPatientItem.Value);
            else
            {
                MessageBox.Show(
                    "Please select a valid Patient Person.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (comboBox2.SelectedItem is ComboBoxItem selectedDoctorItem)
                Doctor = clsDoctors.Find(selectedDoctorItem.Value);
            else
            {
                MessageBox.Show(
                    "Please select a valid Doctor Person.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            appointments.PatientID = patients.ID;
            appointments.DoctorID = Doctor.ID;
            appointments.AppointmentDate = dateTimePicker1.Value;
            appointments.Status = (byte)comboBox3.SelectedIndex;
            if (appointments.save())
            {
                lblID.Text = appointments.ID.ToString();
                label1.Text = "Update Appintments";
                mode = enMode.Update;
                MessageBox.Show("Appointmet Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Adding Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
