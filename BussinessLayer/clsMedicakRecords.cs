using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsMedicakRecords
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode mode = enMode.AddNew;
        public int AppointmentID { get; set; }
        public int ID {  get; set; }
        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }
        public clsMedicakRecords ()
        {
            ID = -1;
            VisitDescription = string.Empty;
            Diagnosis = string.Empty;
            AdditionalNotes = string.Empty;
            mode = enMode.AddNew;
        }
        private clsMedicakRecords(int iD, string visitDescription, string diagnosis, string additionalNotes)
        {
            ID = iD;
            VisitDescription = visitDescription;
            Diagnosis = diagnosis;
            AdditionalNotes = additionalNotes;
            mode = enMode.Update;
        }
        public static clsMedicakRecords FindMedicalRecord(int iD)
        {
            int prescriptions_ID = -1;
            string visitDescription ="", diagnosis = "", additionalNotes = "";
            bool isfound = DataMedicalRecord.GetMedicalRecordByID(iD, ref visitDescription, ref diagnosis, ref additionalNotes);
            if (isfound)
                return new clsMedicakRecords(iD, visitDescription, diagnosis, additionalNotes);
            else
                return null;
        }
        private bool _AddNewMedicalRecord()
        {
            this.ID = DataMedicalRecord.AddMedicalRecord(this.AppointmentID, this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
            return (this.ID != -1);
        }
        public bool _UpdateMedicalRecord()
        {
            return DataMedicalRecord.UpdateMedicalRecord(this.ID, this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
        }
        public bool DeleteMedicalRecord()
        {
            return DataMedicalRecord.DeleteMedicalRecord(this.ID, this.AppointmentID);
        }
        public bool Save()
        {
            switch(mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedicalRecord())
                        return true;
                    else
                        return false;
                case enMode.Update:
                        return _UpdateMedicalRecord();
            }
            return false;
        }
        public static bool CheckMedicalRecored(int ID)
        {
            return DataMedicalRecord.ChackMedicalRecored(ID);
        }
    }
}
