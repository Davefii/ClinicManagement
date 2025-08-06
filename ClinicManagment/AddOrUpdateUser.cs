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
using static BussinessLayer.clsUsers;

namespace ClinicManagment
{
    public partial class AddOrUpdateUser : Form
    {
        public class ComboxItem
        {
            public string Text { get; set; }  // What shows in the box
            public int Value { get; set; }    // The actual PatientID or DoctorID

            public override string ToString()
            {
                return Text;
            }
        }
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode mode;
        private int _UserID = -1;
        private int _StoredPermition = 0;
        clsUsers user;
        clsDoctors doctor;
        public AddOrUpdateUser()
        {
            InitializeComponent();
            mode = enMode.AddNew;
        }
        public AddOrUpdateUser(int userId)
        {
            InitializeComponent();
            mode = enMode.Update;
            _UserID = userId;
        }
        private void _FillDoctorsinCombobox()
        {
            DataTable Dt = clsDoctors.GetAllDoctors();
            foreach (DataRow dt in Dt.Rows)
            {
                ComboxItem item = new ComboxItem
                {
                    Text = dt["FullName"].ToString(),
                    Value = Convert.ToInt32(dt["ID"])
                };
                cbDoctors.Items.Add(item);
            }
        }
        private void _DefaultDataUser()
        {
            user = new clsUsers();
            _FillDoctorsinCombobox();
        }
        private void _LoadDataUser()
        {
            user = clsUsers.FindUser(_UserID);
            if (user == null)
            {
                MessageBox.Show(
                    "This User is Doesn't Exitst",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            lblTitle.Text = "Update User";
            lblID.Text = user.ID.ToString();
            cbDoctors.Items.Clear();
            //cbDoctors.Enabled = false;
            _FillDoctorsinCombobox();
            cbDoctors.Text = user.DoctorInfo.FullName;
            tbUserName.Text = user.UserName;
            tbPassword.Text = user.Password;
            ckadddoctor.Checked = user.Permition.HasFlag(clsUsers.enMainMenuPermitions.AddDoctor);
            ckSpecialation.Checked = user.Permition.HasFlag(clsUsers.enMainMenuPermitions.Specialation);
            ckadduser.Checked = user.Permition.HasFlag(clsUsers.enMainMenuPermitions.AddUser);
            cklistuser.Checked = user.Permition.HasFlag(clsUsers.enMainMenuPermitions.ListUsers);
            cklistDoctor.Checked = user.Permition.HasFlag(clsUsers.enMainMenuPermitions.ListDoctors);
            ckAll.Checked = user.Permition.HasFlag(clsUsers.enMainMenuPermitions.All);
        }
        private void AddOrUpdateUser_Load(object sender, EventArgs e)
        {
            if (mode == enMode.AddNew)
                _DefaultDataUser();
            else
                _LoadDataUser();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbDoctors.SelectedItem is ComboxItem SelectedItem)
                doctor = clsDoctors.Find(SelectedItem.Value);
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
            user.DoctorID = doctor.ID;
            user.UserName = tbUserName.Text.Trim();
            user.Password = tbPassword.Text.Trim();
            if (user.Save())
            {
                MessageBox.Show(
                    "Added User Successfulley",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                mode = enMode.Update;
                AddOrUpdateUser_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Failed to Add User",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ckadddoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckadddoctor.Checked)
            {
                user.Permition |= enMainMenuPermitions.AddDoctor; // Add permission
            }
            else
            {
                user.Permition &= ~enMainMenuPermitions.AddDoctor; // Remove permission
            }
        }

        private void ckSpecialation_CheckedChanged(object sender, EventArgs e)
        {
            if(ckSpecialation.Checked)
            {
                user.Permition |= enMainMenuPermitions.Specialation; // Add permission
            }
            else
            {
                user.Permition &= ~enMainMenuPermitions.Specialation; // Remove permission
            }
        }

        private void ckadduser_CheckedChanged(object sender, EventArgs e)
        {
            if (ckadduser.Checked)
            {
                user.Permition |= enMainMenuPermitions.AddUser; // Add permission
            }
            else
            {
                user.Permition &= ~enMainMenuPermitions.AddUser; // Remove permission
            }
        }

        private void cklistuser_CheckedChanged(object sender, EventArgs e)
        {
            if (cklistuser.Checked)
            {
                user.Permition |= enMainMenuPermitions.ListUsers; // Add permission
            }
            else
            {
                user.Permition &= ~enMainMenuPermitions.ListUsers; // Remove permission
            }
        }

        private void cklistDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (cklistDoctor.Checked)
            {
                user.Permition |= enMainMenuPermitions.ListDoctors; // Add permission
            }
            else
            {
                user.Permition &= ~enMainMenuPermitions.ListDoctors; // Remove permission
            }
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAll.Checked)
            {
                user.Permition |= enMainMenuPermitions.All; // Add permission
            }
            else
            {
                user.Permition &= ~enMainMenuPermitions.All; // Remove permission
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
