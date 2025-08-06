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
    public partial class Payfrm : Form
    {
        public enum enMode { Addnew = 0, ReadOnly = 1 }
        enMode mode;
        int _PaymentID = -1;
        int _AppointmentID = -1;
        clsPayments payments;
        public Payfrm(int appointmentID)
        {
            InitializeComponent();
            mode = enMode.Addnew;
            _AppointmentID = appointmentID;
        }
        public Payfrm(int PaymentID, int appointmentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;
            mode = enMode.ReadOnly;
        }
        private void _DefaultLoadData()
        {
            payments = new clsPayments();
        }
        private void _LoadData()
        {
            txtPaymentMethod.ReadOnly = true;
            txtAmountPaid.ReadOnly = true;
            txtAdditionalNotes.ReadOnly = true;
            btnPay.Enabled = false;
            payments = clsPayments.find(_PaymentID);
            if (payments == null)
            {
                MessageBox.Show("Payment record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // or handle gracefully
                return;
            }
            lblID.Text = _PaymentID.ToString();
            txtPaymentMethod.Text = payments.PaymentMethod;
            txtAmountPaid.Text = payments.AmountPaid.ToString();
            txtAdditionalNotes.Text = payments.Addtionalnotes;
        }

        private void Payfrm_Load(object sender, EventArgs e)
        {
            if(mode == enMode.Addnew)
                _DefaultLoadData();
            else
                _LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            payments.AppointmentID = _AppointmentID;
            payments.PaymentDate = DateTime.Now;
            payments.PaymentMethod = txtPaymentMethod.Text.Trim();
            if (decimal.TryParse(txtAmountPaid.Text, out decimal AmountPaid))
                payments.AmountPaid = AmountPaid;
            else
                MessageBox.Show("Please Enter Number","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            payments.Addtionalnotes = txtAdditionalNotes.Text.Trim();
            if (payments.save())
            {
                payments.ID = _PaymentID;
                mode = enMode.ReadOnly;
                Payfrm_Load(null, null);
                MessageBox.Show("Payment Sucssefully", "Succssecc", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Failed To Pay", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
