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
    public partial class AddOrUpdateMedicalRecord : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        int _MrID = -1;
        int _AppointmentID = -1;
        private enMode _Mode;
        clsMedicakRecords medicakRecords;
        public AddOrUpdateMedicalRecord(int appointmentID)
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _AppointmentID = appointmentID;
        }
        public AddOrUpdateMedicalRecord(int mrid, int appointmentID)
        {
            InitializeComponent();
            _MrID = mrid;
            _Mode = enMode.Update;
        }
        private void _DefaultData()
        {
            this.Text = "Add Medical Record";
            lblTitle.Text = "Add New Medical Record";
            medicakRecords = new clsMedicakRecords();
        }
        private void _LoadData()
        {
            this.Text = "Update Medical Record";
            lblTitle.Text = "Update Medical Record";
            medicakRecords = clsMedicakRecords.FindMedicalRecord(_MrID);
            if (medicakRecords == null)
            {
                MessageBox.Show("No Medical Record With " + _MrID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = _MrID.ToString();
            txtvisitDescription.Text = medicakRecords.VisitDescription;
            txtDiagnosis.Text = medicakRecords.Diagnosis;
            txtAdditionalNotes.Text = medicakRecords.AdditionalNotes;
        }

        private void AddOrUpdateMedicalRecord_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
                _DefaultData();
            else
                _LoadData();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            medicakRecords.AppointmentID = _AppointmentID;
            medicakRecords.VisitDescription = txtvisitDescription.Text.Trim();
            medicakRecords.AdditionalNotes = txtAdditionalNotes.Text.Trim();
            medicakRecords.Diagnosis = txtDiagnosis.Text.Trim();
            if (medicakRecords.Save())
            {
                MessageBox.Show("issued Medical Record Sucseesfuley","Sucssess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                this.Text = "Update Medical Record";
                lblTitle.Text = "Update Medical Record";
                lblID.Text = medicakRecords.ID.ToString();
            }
            else
                MessageBox.Show("issued Medical Record Sucseesfuley", "Sucssess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
