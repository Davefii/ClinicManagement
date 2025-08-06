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
    public partial class AddorUpdateDoctors : Form
    {
        private int _DoctorId = -1;
        private clsDoctors _doctor;
        public enum enMode { AddNew = 1, update = 2};
        private enMode _Mode = enMode.AddNew;
        public AddorUpdateDoctors()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddorUpdateDoctors(int doctorId)
        {
            InitializeComponent();
            _DoctorId = doctorId;
            _Mode = enMode.update;
        }
        private void _FillSpecialiationinCombobox()
        {
            DataTable dT = clsSpecialation.GetAllSpecialations();
            foreach (DataRow row in dT.Rows)
            {
                comboBox1.Items.Add(row["SpecialationName"]);
            }
        }
        private void _LoadData()
        {
            _FillSpecialiationinCombobox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Doctor";
                this.Text = "Add New Doctor";
                _doctor = new clsDoctors();
            }
            else
            {
                lblTitle.Text = "Update Doctor";
                this.Text = "Update Doctor";
                _doctor = clsDoctors.Find(_DoctorId);
                if (_doctor == null)
                {
                    MessageBox.Show("Doctor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                lblPersonID.Text = _doctor.PersonID.ToString();
                txtFirstName.Text = _doctor.FirstName;
                txtSecondName.Text = _doctor.SecondName;
                txtThirdName.Text = _doctor.ThirdName;
                txtLastName.Text = _doctor.LastName;
                txtNationalNo.Text = _doctor.NationalNo;
                dtpDateOfBirth.Value = _doctor.DateOfBirth;
                if (_doctor.Gender == 0)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
                comboBox1.SelectedIndex = comboBox1.FindString(clsSpecialation.Find(_doctor.SpecialationID).SpecialationName);
                txtEmail.Text = _doctor.Email;
                txtPhone.Text = _doctor.PhoneNumber;
                txtAddress.Text = _doctor.Address;
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
            if (txtNationalNo.Text.Trim() != _doctor.NationalNo && clsPerson.isPersonExist(txtNationalNo.Text.Trim()))
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 1) Ensure _doctor is not null
            if (_doctor == null)
                _doctor = new clsDoctors();
            // 2) Safely look up the specialization
            var spec = clsSpecialation.Find(comboBox1.Text);
            if (spec == null)
            {
                MessageBox.Show(
                    "Please select a valid Specialization.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            int specialationId = spec.ID;
            _doctor.FirstName = txtFirstName.Text.Trim();
            _doctor.SecondName = txtSecondName.Text.Trim();
            _doctor.ThirdName = txtThirdName.Text.Trim();
            _doctor.LastName = txtLastName.Text.Trim();
            _doctor.NationalNo = txtNationalNo.Text.Trim();
            _doctor.DateOfBirth = dtpDateOfBirth.Value;
            _doctor.PhoneNumber = txtPhone.Text.Trim();
            if(rbMale.Checked)
                _doctor.Gender = 0;
            else
                _doctor.Gender = 1;
            _doctor.Email = txtEmail.Text.Trim();
            _doctor.Address = txtAddress.Text.Trim();
            _doctor.SpecialationID = specialationId;
            if (_doctor.Save())
            {
                lblTitle.Text = "Update Doctor";
                this.Text = "Update Doctor";
                _Mode = enMode.update;
                MessageBox.Show("Doctor saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error saving doctor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddorUpdateDoctors_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
