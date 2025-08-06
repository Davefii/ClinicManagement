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
    public partial class ListPatient : Form
    {
        private DataTable _DtAllPatients;
        public ListPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNewPatient addNewPatient = new addNewPatient();
            addNewPatient.ShowDialog();
            ListPatient_Load(null,null);
        }

        private void ListPatient_Load(object sender, EventArgs e)
        {
            _DtAllPatients = Patients.GetAllPatients();
            dgvAllPatients.DataSource = _DtAllPatients;
            lblCount.Text = dgvAllPatients.Rows.Count.ToString();
        }

        private void updatePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllPatients.CurrentRow.Cells[1].Value;
            PersonInformation personInformation = new PersonInformation(PersonID);
            personInformation.ShowDialog();
            ListPatient_Load(null, null);
        }

        private void updatePatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllPatients.CurrentRow.Cells[0].Value;
            addNewPatient addNewPatient = new addNewPatient(PersonID);
            addNewPatient.ShowDialog();
            ListPatient_Load(null, null);
        }

        private void deletePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllPatients.CurrentRow.Cells[0].Value;
            Patients patients = Patients.Find(PersonID);
            if (MessageBox.Show("Do You Want Delete Patient", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (patients.DeletePatient())
                {
                    MessageBox.Show("Delete Patient Succeccfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error Delete Patient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                return;
            ListPatient_Load(null, null);
        }
    }
}
