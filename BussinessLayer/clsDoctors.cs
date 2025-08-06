using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsDoctors : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public int SpecialationID { get; set; }
        public string ImagePath { get; set; }
        public clsDoctors()
        {
            ID = 0;
            PersonID = 0;
            SpecialationID = 0;
            Mode = enMode.AddNew;
        }
        private clsDoctors(int id, int personId, int specialationID, string NationalNo, string FirstName, string SecondName, string thirdName, string lastname, DateTime DateofBirth, byte Gender, string PhoneNumber, string Email, string Address, string ImagePath)
        {
            ID = id;
            PersonID = personId;
            PersonInfo = clsPerson.Find(personId);
            SpecialationID = specialationID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = thirdName;
            this.LastName = lastname;
            this.DateOfBirth = DateofBirth;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Address = Address;
            Mode = enMode.Update;
        }
        public static clsDoctors Find(int id)
        {
            int personId = -1, specialationID = -1;
            byte Gender = 0;
            string /*FirstName = "", SecondName = "", thirdName = "", lastname = "", PhoneNumber = "", Email = "", Address = "",*/ NationalNo = "", ImagePath = "";
            DateTime DateofBirth = DateTime.Now;
            bool isFound = DataDoctor.GetDoctorByID(id, ref personId, ref specialationID, ref ImagePath);
            if (isFound)
            {
                clsPerson person = clsPerson.Find(personId);
                return new clsDoctors(id, personId,specialationID, NationalNo,person.FirstName, person.SecondName, person.ThirdName, person.LastName, person.DateOfBirth, person.Gender, person.PhoneNumber, person.Email, person.Address, ImagePath);
            }
            else
                return null;
        }
        public static DataTable GetAllDoctors()
        {
            return DataDoctor.GetAllDoctors();
        }
        private bool _AddNewDoctors()
        {
            int personID = this.PersonID;
            if (!_AddNewPerson(ref personID))
                return false;
            this.PersonID = personID; // Update PersonID after adding new person
            this.ID = DataDoctor.AddNewDoctors(personID, this.SpecialationID);
            return (this.ID != -1);
        }
        private bool _UpdateDocotrs()
        {
            int PersonID = this.PersonID;
            if (!_UpdatePerson(PersonID))
                return false;
            this.PersonID = PersonID;
            return DataDoctor.UpdateDoctors(this.ID, PersonID, this.SpecialationID, this.ImagePath);
        }
        public bool DeleteDocotrs()
        {
            DataDoctor.DeleteDoctors(this.ID);
            return DataPerson.DeletePerson(this.PersonID);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDoctors())
                        return true;
                    else
                        return false;
                case enMode.Update:
                    return _UpdateDocotrs();
            }
            return false;
        }
    }
}
