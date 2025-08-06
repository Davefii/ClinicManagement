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
    public partial class listSpecialations : Form
    {
        private DataTable _dtSpecialationManager = new DataTable();
        public listSpecialations()
        {
            InitializeComponent();
        }
        private void listSpecialations_Load(object sender, EventArgs e)
        {
            _dtSpecialationManager = clsSpecialation.GetAllSpecialations();
            lblCountRecords.Text = _dtSpecialationManager.Rows.Count.ToString();
            if (_dtSpecialationManager.Rows.Count > 0)
            {
                dataGridView1.DataSource = _dtSpecialationManager;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "Salary";
                dataGridView1.Columns[2].Width = 100;
            }
            else
            {
                MessageBox.Show("No specialations found.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddorUpdateSpecialation addorUpdateSpecialation = new AddorUpdateSpecialation();
            addorUpdateSpecialation.ShowDialog();
        }

        private void addNewSpecialationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddorUpdateSpecialation addorUpdateSpecialation = new AddorUpdateSpecialation();
            addorUpdateSpecialation.ShowDialog();
        }

        private void updateSpecialationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            AddorUpdateSpecialation addorUpdateSpecialation = new AddorUpdateSpecialation(ID);
            addorUpdateSpecialation.ShowDialog();
        }
    }
}
