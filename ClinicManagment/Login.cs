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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //string entredPasswordHash = clsUtility.ComputeHash(txtPassword.Text);
            clsUsers user = clsUsers.FindByUserNameandPassword(txtusername.Text, txtPassword.Text /*entredPasswordHash*/);
            if (user != null)
            {
                if (ckRemeberUsernameandPassword.Checked)
                {
                    clsGlobal.RememberUserNameandPassword(txtusername.Text, txtPassword.Text /*entredPasswordHash*/);
                }
                else
                {
                    clsGlobal.RememberUserNameandPassword("", "");
                }
                clsGlobal.CurrentUser = user;
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                //this.Hide();
            }
            else
            {
                txtusername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtusername.Text = UserName;
                txtPassword.Text = Password;
                ckRemeberUsernameandPassword.Checked = true;
            }
            else
                ckRemeberUsernameandPassword.Checked = false;
        }
    }
}
