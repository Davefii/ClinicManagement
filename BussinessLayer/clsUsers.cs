using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 }
        [Flags]
        public enum enMainMenuPermitions 
        { 
            AddDoctor = 1,
            Specialation = 2,
            AddUser = 4,
            ListUsers = 8,
            ListDoctors = 16,
            All = 32
        }
        public enMode mode;
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public clsDoctors DoctorInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public enMainMenuPermitions Permition { get; set; }
        public clsUsers()
        {
            this.ID = -1;
            this.DoctorID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permition = 0;
            mode = enMode.AddNew;
        }
        private clsUsers(int iD, int doctorID, string username, string password, byte permition)
        {
            ID = iD;
            DoctorID = doctorID;
            DoctorInfo = clsDoctors.Find(DoctorID);
            this.UserName = username;
            this.Password = password;
            Permition = (enMainMenuPermitions)permition;
            mode = enMode.Update;
        }
        public static DataTable GetAllUsers()
        {
            return DataUsers.GatAllUsers();
        }
        public static clsUsers FindUser(int ID)
        {
            int DoctorID = -1; string username = ""; string password = ""; byte Permition = 0;
            bool isFound = DataUsers.GetUserByID(ID,ref DoctorID, ref username, ref password, ref Permition);
            if (isFound)
                return new clsUsers(ID, DoctorID, username, password, Permition);
            else
                return null;
        }
        public static clsUsers FindByUserNameandPassword(string username, string password)
        {
            int ID = -1;
            int DoctorID = -1;
            byte Permition = 0;
            bool isFound = DataUsers.GetUserByUserNameandPassword(ref ID, ref DoctorID, username, password, ref Permition);
            if (isFound)
                return new clsUsers(ID, DoctorID, username, password, Permition);
            else
                return null;
        }
        private bool _AddNewUser()
        {
            //string hashpassword = clsUtility.ComputeHash(this.Password);
            this.ID = DataUsers.AddNewUser(this.DoctorID ,this.UserName, this.Password /*hashpassword*/, (byte)this.Permition);
            return (this.ID != -1);
        }
        private bool _UpdateUser()
        {
            string hashpassword = clsUtility.ComputeHash(this.Password);
            return DataUsers.UpdateUser(this.ID, this.DoctorID, this.UserName, this.Password /*hashpassword*/, (byte)this.Permition);
        }
        public bool DeleteUser()
        {
            if (this.UserName != "Admin")
                return DataUsers.DeleteUser(this.ID);
            else
                return false;
        }
        public bool ChangePassword()
        {
            string hashpassword = clsUtility.ComputeHash(this.Password);
            return DataUsers.ChangePassword(this.ID, this.Password /*hashpassword*/);
        }
        public bool Save()
        {
            switch(mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                            return true;
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
    }
}
