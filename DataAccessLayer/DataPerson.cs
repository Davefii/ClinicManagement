using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessSettings;
namespace DataAccessLayer
{
    public class DataPerson
    {
        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = "SELECT * FROM Persons;";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Debug.WriteLine("Error : " + ex); }
            finally { connection.Close(); }
            return dt;
        }
        public static bool GetPersonByID(int ID, ref string nationalNo, ref string firstName, ref string secondName, ref string thirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string PhoneNumber, ref string Email, ref string Address)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = @"SELECT * FROM Persons WHERE ID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    nationalNo = (string)reader["NationalNo"];
                    firstName = (string)reader["FisrtName"];
                    secondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                    thirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateofBirth"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                    Address = (string)reader["Address"];
                }
                else
                    isFound = false;
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex); }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GetPersonByNationalNo(string nationalNo, ref int ID, ref string firstName, ref string secondName, ref string thirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string PhoneNumber, ref string Email, ref string Address)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = @"SELECT * FROM Persons WHERE NationalNo = @nationalNo;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["ID"];
                    firstName = (string)reader["FisrtName"];
                    secondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                    thirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateofBirth"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                    Address = (string)reader["Address"];
                }
                else
                    isFound = false;
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex); }
            finally { connection.Close(); }
            return isFound;
        }
        public static int AddNewPerson(string nationalNo, string firstName, string secondName, string thirdName, string LastName, DateTime DateOfBirth, byte Gender, string PhoneNumber, string Email, string Address)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string query = @"INSERT INTO Persons(NationalNo ,FisrtName,SecondName,ThirdName,LastName,DateofBirth,Gender,PhoneNumber,Email,Address)
                         VALUES (@NationalNo ,@FisrtName ,@SecondName ,@ThirdName ,@LastName ,@DateofBirth ,@Gender ,@PhoneNumber ,@Email ,@Address);
                        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FisrtName", firstName);
            if (secondName != "" && secondName != null)
                command.Parameters.AddWithValue("@SecondName", secondName);
            else
                command.Parameters.AddWithValue("@SecondName", System.DBNull.Value);
            if (thirdName != "" && thirdName != null)
                command.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateofBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            command.Parameters.AddWithValue("@Address", Address);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex); }
            finally { connection.Close(); }
            return PersonID;
        }
        public static bool UpdatePerson(int ID, string nationalNo, string firstName, string secondName, string thirdName, string LastName, DateTime DateOfBirth, byte Gender, string PhoneNumber, string Email, string Address)
        {
            int RowAffcted = 0;
            string query = @"
            UPDATE Persons
                      SET FisrtName = FisrtName,
                       		SecondName = @SecondName,
                       		ThirdName = @ThirdName,
                       		LastName = @LastName,
                       		DateofBirth = @DateofBirth,
                       		Gender = @Gender,
                       		PhoneNumber = @PhoneNumber,
                       		Email = @Email,
                       		Address = Address
                     WHERE ID = @ID;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FisrtName", firstName);
                if (secondName != "" && secondName != null)
                    command.Parameters.AddWithValue("@SecondName", secondName);
                else
                    command.Parameters.AddWithValue("@SecondName", System.DBNull.Value);
                if (thirdName != "" && thirdName != null)
                    command.Parameters.AddWithValue("@ThirdName", thirdName);
                else
                    command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@DateofBirth", DateOfBirth);
                command.Parameters.AddWithValue("@date", Gender);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                if (Email != "" && Email != null)
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    RowAffcted = command.ExecuteNonQuery();
                }
                catch (Exception ex) { Debug.WriteLine("Error " + ex); }
                finally { connection.Close(); }
            }
            return (RowAffcted > 0);
        }
        public static bool DeletePerson(int ID)
        {
            int RowAffected = 0;
            string query = @"DELETE FROM Persons
                         WHERE ID = @ID;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    RowAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex) { Debug.WriteLine("Error " + ex); }
                finally { connection.Close(); }
            }
            return (RowAffected > 0);
        }
        public static bool IsPersonExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);

            string query = "SELECT Found=1 FROM Persons WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool IsPersonExist(string Nationalno)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);

            string query = "SELECT Found=1 FROM Persons WHERE NationalNo = @No";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@No", Nationalno);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
