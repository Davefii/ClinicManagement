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
    public partial class PersonInformation : Form
    {
        private int _PersonId = -1;
        public PersonInformation(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonInformation_Load(object sender, EventArgs e)
        {
            ctrlPatientInfo1.LoadInfoByPersonID(_PersonId);
        }
    }
}
