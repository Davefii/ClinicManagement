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
    public partial class ListUsers : Form
    {
        public ListUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdateUser addOrUpdateUser = new AddOrUpdateUser();
            addOrUpdateUser.ShowDialog();
            ListUsers_Load(null, null);
        }

        private void ListUsers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsUsers.GetAllUsers();
            label3.Text = dataGridView1.RowCount.ToString();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrUpdateUser addOrUpdateUser = new AddOrUpdateUser();
            addOrUpdateUser.ShowDialog();
            ListUsers_Load(null, null);
        }

        private void updateUsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            AddOrUpdateUser addOrUpdateUser = new AddOrUpdateUser(UserID);
            addOrUpdateUser.ShowDialog();
            ListUsers_Load(null, null);
        }

        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PersonID = clsUsers.FindUser(UserID).DoctorInfo.PersonInfo.ID;
            PersonInformation personInformation = new PersonInformation(PersonID);
            personInformation.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsUsers user = clsUsers.FindUser(UserID);
            if (MessageBox.Show("Do You Want Delete This User ? ", "Ensure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (user.DeleteUser())
                {
                    MessageBox.Show("Deleted User Successfuly", "Succcsess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to Deleted User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListUsers_Load(null, null);
        }
    }
}
