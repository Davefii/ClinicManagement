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
    public class DataSpecialation
    {
        public static DataTable GetAllSpecialations()
        {
            DataTable dT = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = "SELECT * FROM Specialation;";
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
        public static bool GetSpecialationByID(int ID, ref string SpecialationName, ref float Salary)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = "SELECT * FROM Specialation Where ID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    SpecialationName = reader["SpecialationName"] == DBNull.Value ? "" : (string)reader["SpecialationName"];
                    Salary = reader["Salary"] == DBNull.Value ? 0 : Convert.ToSingle(reader["Salary"]);
                }
                else
                    isFound = false;
            }
            catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GetSpecialationByName(string SpecialationName, ref int ID , ref float Salary)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string Query = "SELECT * FROM Specialation Where SpecialationName = @SpecialationName;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@SpecialationName", SpecialationName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = reader["ID"] == DBNull.Value ? -1 : (int)reader["ID"];
                    Salary = reader["Salary"] == DBNull.Value ? 0 : Convert.ToSingle(reader["Salary"]);
                }
                else
                    isFound = false;
            }
            catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
            finally { connection.Close(); }
            return isFound;
        }
        public static int AddNewSpecialation(string SpecialationName,float Salary)
        {
            int SpecialationId = -1;
            string query = @"
                INSERT INTO Specialation (SpecialationName,Salary)
                    VALUES (@SpecialationName,@Salary)
                	SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SpecialationName", SpecialationName);
                command.Parameters.AddWithValue("@Salary", Salary);
                try
                {
                    connection.Open();
                    object Reader = command.ExecuteScalar();
                    if (Reader != null && int.TryParse(Reader.ToString(), out int InsertedId))
                    {
                        SpecialationId = InsertedId;
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { connection.Close(); }
            }
            return SpecialationId;
        }
        public static bool UpdateSpecialation(int ID, string SpecialationName, float Salary)
        {
            int RowAffected = 0;
            string Query = @"
                    UPDATE Specialation
                      SET SpecialationName = @SpecialationName
                         ,Salary = @Salary
                    WHERE ID = @ID;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@SpecialationName", SpecialationName);
                command.Parameters.AddWithValue("@Salary", Salary);
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
        public static bool DeleteSpecialation(int ID)
        {
            int RowAffected = 0;
            string query = @"DELETE FROM Specialation
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
