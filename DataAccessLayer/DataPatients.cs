using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataPatients
    {
        public static DataTable GetAllPatiens()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string query = "SELECT * FROM Patiens_View;";
            SqlCommand cmd = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }
        public static bool GetPatientByID(int ID, ref int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = @"SELECT * FROM Patiens WHERE ID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    if (reader["Person_ID"] == DBNull.Value)
                    {
                        isFound = false;
                    }
                    else
                        PersonID = (int)reader["Person_ID"];
                }
                else
                    isFound = false;
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex); }
            finally { connection.Close(); }
            return isFound;
        }
        public static int AddNewPatient(int PersonID)
        {
            int personID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string query = @"INSERT INTO Patiens(Person_ID)
                         VALUES (@Person_ID);
                        SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Person_ID", PersonID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    personID = insertedID;
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex); }
            finally { connection.Close(); }
            return personID;
        }
        public static bool DeletePatient(int ID)
        {
            int RowAffected = 0;
            string query = @"DELETE FROM Patiens
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
        public static bool IsPatientExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string query = "SELECT Found=1 FROM Patiens WHERE ID = @ID;";
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
    }
}
