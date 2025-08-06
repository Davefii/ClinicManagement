using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Patients : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public Patients()
        {
            this.ID = 0;
            this.PersonID = 0;
            Mode = enMode.AddNew;
        }
        private Patients(int id, int personID, string nationalNo, string firstName, string secondName, string thirdName, string LastName, DateTime DateOfBirth, byte Gender, string PhoneNumber, string Email, string Address)
        {
            this.ID = id;
            this.PersonID = personID;
            this.PersonInfo = Find(personID);
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Address = Address;
            Mode = enMode.Update;
        }
        public static Patients Find(int id)
        {
            int PersonID = -1;
            bool isFound = DataAccessLayer.DataPatients.GetPatientByID(id, ref PersonID);
            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);
                return new Patients(id, PersonID, person.NationalNo, person.FirstName, person.SecondName, person.ThirdName, person.LastName, person.DateOfBirth, person.Gender, person.PhoneNumber, person.Email, person.Address);
            }
            else
                return null;
        }
        public static DataTable GetAllPatients()
        {
            return DataPatients.GetAllPatiens();
        }
        private bool _AddNewPatient()
        {
            int PersonID = -1;
            _AddNewPerson(ref PersonID);
            this.PersonID = PersonID;
            DataPatients.AddNewPatient(this.PersonID);
            return (this.PersonID != -1);
        }
        public bool DeletePatient()
        {
            DataPatients.DeletePatient(this.ID);
            return DeletePerson(this.PersonID);
        }
        private bool _UpdatePatient()
        {
            return base._UpdatePerson(this.PersonID);
        }
        public bool save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPatient())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdatePatient();
            }
            return false;
        }
    }
}
