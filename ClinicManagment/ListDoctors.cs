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
    public partial class ListDoctors : Form
    {
        private DataTable _dtDoctors;
        public ListDoctors()
        {
            InitializeComponent();
        }

        private void ListDoctors_Load(object sender, EventArgs e)
        {
            _dtDoctors = clsDoctors.GetAllDoctors();
            dataGridView1.DataSource = _dtDoctors;
            label3.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddorUpdateDoctors addorUpdateDoctors = new AddorUpdateDoctors();
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.AddDoctor))
            {
                addorUpdateDoctors.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ListDoctors_Load(null,null);
        }

        private void updateDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DoctorID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            AddorUpdateDoctors addorUpdateDoctors = new AddorUpdateDoctors(DoctorID);
            if (clsGlobal.CheckPermition(clsUsers.enMainMenuPermitions.AddDoctor))
            {
                addorUpdateDoctors.ShowDialog();
                return;
            }
            MessageBox.Show("Access Denid Please Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ListDoctors_Load(null, null);
        }

        private void deleteDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DoctorID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsDoctors doctor = clsDoctors.Find(DoctorID);
            if (MessageBox.Show("Do You Want Delete This Doctor", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (doctor == null)
                {
                    MessageBox.Show("This Doctor Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (doctor.DeleteDocotrs())
                {
                    MessageBox.Show("Doctor Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListDoctors_Load(null,null);
                }
                else
                {
                    MessageBox.Show("Error in Deleting Doctor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showPersonInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            PersonInformation personInformation = new PersonInformation(PersonID);
            personInformation.ShowDialog();
        }
    }
}
