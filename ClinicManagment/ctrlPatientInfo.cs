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
    public partial class ctrlPersonInfo : UserControl
    {
        private int _PersonID = -1;
        private int _PatientID = -1;
        private Patients _Patient;
        private clsPerson _Person;
        public int Person_ID { get { return _PersonID; } }
        public int Patient_ID { get { return _PatientID; } }
        public Patients SelectedPatientInfo {  get { return _Patient; } }
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        public void LoadInfoByID(int PatientID)
        {
            _PatientID = PatientID;
            _Patient = Patients.Find(_PatientID);
            if (_Patient == null)
            {
                MessageBox.Show("Patient Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblfullname.Text = _Patient.FullName;
            lblDOB.Text = _Patient.DateOfBirth.ToShortDateString();
            lblgender.Text = _Patient.Gender == 0 ? "Male" : "Female";
            lblphonenumber.Text = _Patient.PhoneNumber;
            lblEmail.Text = _Patient.Email;
            lblAddress.Text = _Patient.Address;
        }
        public void LoadInfoByPersonID(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Person Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblfullname.Text = _Person.FullName;
            lblDOB.Text = _Person.DateOfBirth.ToShortDateString();
            lblgender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblphonenumber.Text = _Person.PhoneNumber;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
        }
    }
}
