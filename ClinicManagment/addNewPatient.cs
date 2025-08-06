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
    public partial class addNewPatient : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _mode = enMode.AddNew;
        private Patients _patients;
        private int _patientid = -1;
        public addNewPatient()
        {
            InitializeComponent();
            _mode = enMode.AddNew;
        }
        public addNewPatient(int PatientID)
        {
            InitializeComponent();
            _patientid = PatientID;
            _mode = enMode.Update;
        }
        private void _LoadData()
        {
            if (_mode == enMode.AddNew)
            {
                this.Text = "Add New Patient";
                lblTitle.Text = "Add New Patient";
                _patients = new Patients();
                //_mode = enMode.Update;
                return;
            }
            else
            {
                _patients = Patients.Find(_patientid);
                if (_patients == null)
                {
                    MessageBox.Show("Patient Doesn't Exist","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                this.Text = "Update Patient";
                lblTitle.Text = "Update Patient";
                lblPersonID.Text = _patients.PersonID.ToString();
                txtFirstName.Text = _patients.FirstName;
                txtSecondName.Text = _patients.SecondName;
                txtThirdName.Text = _patients.ThirdName;
                txtLastName.Text = _patients.LastName;
                txtNationalNo.Text = _patients.NationalNo;
                txtPhone.Text = _patients.PhoneNumber;
                dtpDateOfBirth.Value = _patients.DateOfBirth;
                txtEmail.Text = _patients.Email;
                txtAddress.Text = _patients.Address;
                rbMale.Checked = _patients.Gender == 0 ?  true : rbFemale.Checked = true;
            }
        }

        private void addNewPatient_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _patients.Mode = (BussinessLayer.Patients.enMode)_mode;
            _patients.FirstName = txtFirstName.Text.Trim();
            _patients.SecondName = txtSecondName.Text.Trim();
            _patients.ThirdName = txtThirdName.Text.Trim();
            _patients.LastName = txtLastName.Text.Trim();
            _patients.NationalNo = txtNationalNo.Text.Trim();
            _patients.PhoneNumber = txtPhone.Text.Trim();
            _patients.DateOfBirth = dtpDateOfBirth.Value;
            _patients.Email = txtEmail.Text.Trim();
            _patients.Address = txtAddress.Text.Trim();
            if (rbMale.Checked)
                _patients.Gender = 0;
            else
                _patients.Gender = 1;
            if (_patients.save())
            {
                MessageBox.Show("Patients Saved Successfuly", "Succcess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mode = enMode.Update;
                _LoadData();
                //return;
            }
            else
            {
                MessageBox.Show("Error in Saving Patients", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
            if (txtNationalNo.Text.Trim() != _patients.NationalNo && Patients.isPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            }
        }
    }
}
