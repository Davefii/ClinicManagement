using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsAppointments
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode _Mode = enMode.AddNew;
        public enum enStatus {Pending = 0, Confirme = 1, Complete = 2, Canceled = 3, NotShow = 4}
        public int ID { get; set; }
        public int PatientID { get; set; }
        public Patients PatientInfo { get; set; }
        public int DoctorID { get; set; }
        public clsDoctors DoctorInfo;
        public DateTime AppointmentDate { get; set; }
        public byte Status { get; set; }
        public int MedicalRecordID { get; set; }
        public int PaymentID { get; set; }
        public clsAppointments()
        {
            ID = -1;
            PatientID = -1;
            DoctorID = -1;
            AppointmentDate = DateTime.Now;
            Status = 1;
            MedicalRecordID = -1;
            PaymentID = -1;
            _Mode = enMode.AddNew;
        }
        private clsAppointments(int id, int patientId, int doctorId, DateTime appointmentDate, byte status, int medicalRecordId, int paymentId)
        {
            ID = id;
            PatientID = patientId;
            DoctorID = doctorId;
            AppointmentDate = appointmentDate;
            Status = status;
            MedicalRecordID = medicalRecordId;
            PaymentID = paymentId;
            _Mode = enMode.Update;
        }
        public static clsAppointments Find(int ID)
        {
            int patientId = -1 ,doctorId = -1; DateTime appointmentDate = DateTime.Now; byte status = 0; int medicalRecordId = -1, paymentId = -1;
            bool isFound = DataAppointments.GetAppointmentById(ID, ref patientId,ref doctorId,ref appointmentDate,ref status,ref medicalRecordId,ref paymentId);
            if (isFound)
                return new clsAppointments(ID, patientId, doctorId, appointmentDate, status, medicalRecordId, paymentId);
            else
                return null;
        }
        public static DataTable GetAllAppointments()
        {
            return DataAppointments.GetAllAppointments();
        }
        private bool _addnewAppointments()
        {
            this.ID = DataAppointments.addNewAppointment(this.PatientID, this.DoctorID, this.AppointmentDate, this.Status, this.MedicalRecordID, this.PaymentID);
            return (this.ID != -1);
        }
        private bool _updateAppointments()
        {
            return DataAppointments.UpdateAppointment(this.ID, this.PatientID, this.DoctorID, this.AppointmentDate, this.Status, this.MedicalRecordID, this.PaymentID);
        }
        public bool DeleteAppointments()
        {
            return DataAppointments.DeleteAppointment(this.ID);
        }
        public bool ComplateAppointment()
        {
            return DataAppointments.UpdateAppointmentStatus(this.ID, 2);
        }
        public bool CancelAppointment()
        {
            return DataAppointments.UpdateAppointmentStatus(this.ID, 3);
        }
        public bool ConfirmeAppointment()
        {
            return DataAppointments.UpdateAppointmentStatus(this.ID, 1);
        }
        public bool NotShowAppointment()
        {
            return DataAppointments.UpdateAppointmentStatus(this.ID, 5);
        }
        public bool save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_addnewAppointments())
                        return true;
                    else
                        return false;
                case enMode.Update:
                    if (this.Status == 4)
                        return false; // Cannot update if the appointment is canceled
                    else
                        return _updateAppointments();
            }
            return false;
        }
    }
}
