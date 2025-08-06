using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew; 
        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get { return this.FirstName + this.SecondName + this.ThirdName + this.LastName; } }
        public clsPerson ()
        {
            this.ID = 0;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.PhoneNumber = "";
            this.Email = "";
            this.Address = "";
            Mode = enMode.AddNew;
        }
        private clsPerson(int id,string nationalNo, string firstName, string secondName, string thirdName, string LastName, DateTime DateOfBirth, byte Gender, string PhoneNumber, string Email, string Address)
        {
            this.ID = id;
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
        
        public static clsPerson Find(int id)
        {
            string nationalNo = "", firstName = "", secondName = "", thirdName = "", LastName = "", PhoneNumber = "", Email = "", Address = "";
            byte Gender = 0;
            DateTime DateOfBirth = DateTime.Now;
            bool isFound = DataAccessLayer.DataPerson.GetPersonByID(id, ref nationalNo, ref firstName, ref secondName, ref thirdName, ref LastName, ref DateOfBirth, ref Gender, ref PhoneNumber, ref Email, ref Address);
            if (isFound)
                return new clsPerson(id, nationalNo, firstName, secondName, thirdName, LastName, DateOfBirth, Gender, PhoneNumber, Email, Address);
            else
                return null;
        }
        public static clsPerson FindbyNational(string nationalNo)
        {
            int id = -1;
            string firstName = "", secondName = "", thirdName = "", LastName = "", PhoneNumber = "", Email = "", Address = "";
            byte Gender = 0;
            DateTime DateOfBirth = DateTime.Now;
            bool isFound = DataAccessLayer.DataPerson.GetPersonByNationalNo(nationalNo, ref id, ref firstName, ref secondName, ref thirdName, ref LastName, ref DateOfBirth, ref Gender, ref PhoneNumber, ref Email, ref Address);
            if (isFound)
                return new clsPerson(id, nationalNo, firstName, secondName, thirdName, LastName, DateOfBirth, Gender, PhoneNumber, Email, Address);
            else
                return null;
        }
        protected bool _AddNewPerson(ref int PersonID)
        {
            this.ID = DataAccessLayer.DataPerson.AddNewPerson(this.NationalNo,this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.PhoneNumber, this.Email, this.Address);
            PersonID = this.ID;
            return (this.ID != -1);
        }
        protected bool _UpdatePerson(int PersonID)
        {
            return DataAccessLayer.DataPerson.UpdatePerson(PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.PhoneNumber, this.Email, this.Address);
        }
        //public bool save()
        //{
        //    switch(Mode)
        //    {
        //        case enMode.AddNew:
        //            {
        //                if (_AddNewPerson())
        //                {
        //                    Mode = enMode.Update;
        //                    return true;
        //                }
        //                else
        //                    return false;
        //            }
        //        case enMode.Update:
        //            return _UpdatePerson();
        //    }
        //    return false;
        //}
        public static DataTable GetAllPersons()
        {
            return DataAccessLayer.DataPerson.GetAllPersons();
        }
        public static bool DeletePerson(int ID)
        {
            return DataAccessLayer.DataPerson.DeletePerson(ID);
        }
        public static bool isPersonExist(int ID)
        {
            return DataAccessLayer.DataPerson.IsPersonExist(ID);
        }
        public static bool isPersonExist(string NationlNo)
        {
            return DataAccessLayer.DataPerson.IsPersonExist(NationlNo);
        }
    }
}
