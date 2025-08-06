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
    public partial class AddorUpdateAppointment : Form
    {
        private int? appintmentID = null;
        public AddorUpdateAppointment(int? AppintmentID)
        {
                this.appintmentID = AppintmentID;
            InitializeComponent();
        }

        private void AddorUpdateAppointment_Load(object sender, EventArgs e)
        {
            if (appintmentID.HasValue)
            {
                ctrlAddorUpdateAppointment1.LoadDataViaID(appintmentID);
            }
            else
                ctrlAddorUpdateAppointment1.LoadDataViaID(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
