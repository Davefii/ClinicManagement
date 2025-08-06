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
    public partial class AddorUpdateSpecialation : Form
    {
        private int _id = -1;
        private enum enMode { AddNew =  0, Update = 1 }
        private enMode _mode = enMode.AddNew;
        private clsSpecialation _specialation;
        public AddorUpdateSpecialation()
        {
            InitializeComponent();
            _mode = enMode.AddNew;
        }
        public AddorUpdateSpecialation(int id)
        {
            InitializeComponent();
            _id = id;
            _mode = enMode.Update;
        }
        private void LoadData()
        {
            if (_mode == enMode.AddNew)
            {
                this.Text = "Add New Specialation";
                lbltitle.Text = "Add New Specialation";
                _specialation = new clsSpecialation();
            }
            else
            {
                this.Text = "Update Specialation";
                lbltitle.Text = "Update Specialation";
                label4.Text = _id.ToString();
                _specialation = clsSpecialation.Find(_id);
                if (_specialation == null)
                {
                    MessageBox.Show("Specialation not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                txtSpecialationName.Text = _specialation.SpecialationName;
                txtSalary.Text = _specialation.Salary.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSalary.Text) && float.TryParse(txtSalary.Text, out float salary))
                _specialation.Salary = salary;
            else
                MessageBox.Show("Please enter a valid salary.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _specialation.SpecialationName = txtSpecialationName.Text.Trim();
            if (_specialation.save())
            {
                MessageBox.Show("Success to save specialation.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save specialation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddorUpdateSpecialation_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
