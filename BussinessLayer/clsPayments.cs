using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsPayments
    {
        //public enum enMode { AddNew = 1, Update = 2 }
        //public enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // e.g., Cash, Credit Card, Insurance
        public decimal AmountPaid { get; set; }
        public string Addtionalnotes { get; set; }
        public clsPayments()
        {
            ID = -1;
            PaymentDate = DateTime.Now;
            PaymentMethod = string.Empty;
            AmountPaid = 0;
            Addtionalnotes = string.Empty;
            //_Mode = enMode.AddNew;
        }
        private clsPayments(int iD, DateTime paymentDate, string paymentMethod, decimal amountPaid, string addtionalnotes)
        {
            ID = iD;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            AmountPaid = amountPaid;
            Addtionalnotes = addtionalnotes;
            //_Mode = enMode.Update;
        }
        public static DataTable getAllPayments()
        {
            return DataPayments.GetAllPayments();
        }
        public static clsPayments find(int ID)
        {
            DateTime paymentDate = DateTime.Now; string paymentMethod = ""; decimal amountPaid = 0; string addtionalnotes = "";
            bool isFound = DataPayments.GetPaymentbyid(ID, ref paymentDate, ref paymentMethod, ref amountPaid, ref addtionalnotes);
            if (isFound)
            {
                return new clsPayments(ID, paymentDate, paymentMethod, amountPaid, addtionalnotes);
            }
            else
            {
                return null;
            }
        }
        public bool _AddnewPeryments()
        {
            this.ID = DataAccessLayer.DataPayments.addPayments(this.AppointmentID,this.PaymentDate, this.PaymentMethod, this.AmountPaid, this.Addtionalnotes);
            return (this.ID != -1);
        }
        //public bool _UpdatePayments()
        //{
        //    return DataAccessLayer.DataPayments.UpdatePayment(this.ID, this.PaymentDate, this.PaymentMethod, this.AmountPaid, this.Addtionalnotes);
        //}
        //public bool _DeletePayments()
        //{
        //    return DataAccessLayer.DataPayments.DeletePayment(this.ID);
        //}
        public bool save()
        {
            //switch(_Mode)
            //{
            //    case enMode.AddNew:
                    if(_AddnewPeryments())
                        return true;
                    else
                        return false;
            //    case enMode.Update:
            //        return _UpdatePayments();
            //}
            //return false;
        }
        public static bool CheckExistPayment(int PaymentID)
        {
            return DataPayments.CheckExistPaymentById(PaymentID);
        }
    }
}
