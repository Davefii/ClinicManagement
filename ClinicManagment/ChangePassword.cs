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
    public partial class ChangePassword : Form
    {
        private clsUsers _user;
        public ChangePassword(clsUsers user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user.ChangePassword())
                MessageBox.Show("Password Has Been Changed","Sucssess",MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed Change Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
