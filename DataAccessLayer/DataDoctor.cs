using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataDoctor
    {
        public static DataTable GetAllDoctors()
        {
            DataTable dT = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = "SELECT * FROM Doctors_View;";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dT.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally { connection.Close(); }
            return dT;
        }
        public static bool GetDoctorByID(int ID, ref int PersonID, ref int SpecialationID, ref string ImagePath)
        {
            bool isFound = false;
            string Query = "SELECT * FROM Doctors Where ID = @ID;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        PersonID = (int)reader["Person_ID"];
                        SpecialationID = (int)reader["SpecialationID"];
                        ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                    }
                    else
                        isFound = false;
                }
                catch (Exception ex) { Debug.WriteLine(ex);isFound = false; }
                finally { connection.Close(); }
                return isFound;
            }
        }
        public static int AddNewDoctors(int PersonId, int SpecialationID)
        {
            int DoctorId = -1;
            string query = @"                
                	INSERT INTO Doctors (Person_ID ,SpecialationID)
                        VALUES (@PersonID ,@SpecialationID)
                	SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonId);
                command.Parameters.AddWithValue("@SpecialationID", SpecialationID);
                try
                {
                    connection.Open();
                    object Reader = command.ExecuteScalar();
                    if (Reader != null && int.TryParse(Reader.ToString(), out int InsertedId))
                    {
                        DoctorId = InsertedId;
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { connection.Close(); }
            }
            return DoctorId;
        }
        public static bool UpdateDoctors(int ID, int PersonID, int SpecialationID, string ImagePath)
        {
            int RowAffected = 0;
            string Query = @"
                UPDATE [dbo].[Doctors]
                   SET Person_ID = @Person_ID,
                	   SpecialationID = @SpecialationID,
                       ImagePath = @ImagePath          
                 WHERE ID = @ID;";
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Person_ID", PersonID);
                command.Parameters.AddWithValue("@SpecialationID", SpecialationID);
                if (ImagePath != null && ImagePath != "")
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                else
                    command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
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
        public static bool DeleteDoctors(int ID)
        {
            int RowAffected = 0;
            string query = @"DELETE FROM Doctors
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
    }
}
