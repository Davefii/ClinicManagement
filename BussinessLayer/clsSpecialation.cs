using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsSpecialation
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string SpecialationName { get; set; }
        public float Salary { get; set; }
        public clsSpecialation()
        {
            this.ID = 0;
            this.SpecialationName = "";
            this.Salary = 0;
            Mode = enMode.AddNew;
        }
        private clsSpecialation(int id, string SpecialationName, float Salary)
        {
            this.ID = id;
            this.SpecialationName = SpecialationName;
            this.Salary = Salary;
            Mode = enMode.Update;
        }
        public static clsSpecialation Find(int id)
        {
            string SpecialationName = ""; float Salary = 0;
            bool isFound = DataAccessLayer.DataSpecialation.GetSpecialationByID(id,ref SpecialationName,ref Salary);
            if (isFound)

                return new clsSpecialation(id, SpecialationName, Salary);
            else
                return null;
        }
        public static clsSpecialation Find(string SpecialationName)
        {
            int id = -1; float Salary = 0;
            bool isFound = DataAccessLayer.DataSpecialation.GetSpecialationByName(SpecialationName, ref id, ref Salary);
            if (isFound)

                return new clsSpecialation(id, SpecialationName, Salary);
            else
                return null;
        }
        public static DataTable GetAllSpecialations()
        {
            return DataSpecialation.GetAllSpecialations();
        }
        private bool _AddNewSpecialation()
        {
            this.ID = DataSpecialation.AddNewSpecialation(this.SpecialationName, this.Salary);
            return (this.ID != -1);
        }
        public bool DeleteSpecialation()
        {
            return DataSpecialation.DeleteSpecialation(this.ID);
        }
        private bool _UpdateSpecialation()
        {
            return DataSpecialation.UpdateSpecialation(this.ID,this.SpecialationName, this.Salary);
        }
        public bool save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewSpecialation())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdateSpecialation();
            }
            return false;
        }
    }
}
