using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataAccessLayer
{
    public class DataUsers
    {
        public static DataTable GatAllUsers()
        {
            DataTable Dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using(SqlCommand command = new SqlCommand("Select * From Users_View;", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if(connection.State == ConnectionState.Open) connection.Close(); }
                return Dt;
            }
        }
        public static bool GetUserByID(int ID,ref int DoctorID,ref string username,ref string password,ref byte Permition)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("Sp_GetUserByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                var DoctorIdParam = new SqlParameter("@Doctor_ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var UserNameParam = new SqlParameter("@UserName", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                var PasswordParam = new SqlParameter("@Password", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                var PermitionParam = new SqlParameter("@Permition", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                command.Parameters.Add(DoctorIdParam);
                command.Parameters.Add(UserNameParam);
                command.Parameters.Add(PasswordParam);
                command.Parameters.Add(PermitionParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (DoctorIdParam.Value != DBNull.Value) DoctorID = (int)DoctorIdParam.Value;
                    if (UserNameParam.Value != DBNull.Value) username = UserNameParam.Value.ToString();
                    if (PasswordParam.Value != DBNull.Value) password = PasswordParam.Value.ToString();
                    if (PermitionParam.Value != DBNull.Value) Permition = Convert.ToByte(PermitionParam.Value);
                    isFound = true;
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if(connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static bool GetUserByUserNameandPassword(ref int ID, ref int DoctorID, string username, string password, ref byte Permition)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("spGetUserByUserNameandPassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                var IDParam = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var DoctorIdParam = new SqlParameter("@Doctor_ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var PermitionParam = new SqlParameter("@Permition", SqlDbType.TinyInt) { Direction = ParameterDirection.Output };
                command.Parameters.Add(IDParam);
                command.Parameters.Add(DoctorIdParam);
                command.Parameters.Add(PermitionParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (IDParam.Value != DBNull.Value) ID = (int)IDParam.Value;
                    if (DoctorIdParam.Value != DBNull.Value) DoctorID = (int)DoctorIdParam.Value;
                    if (PermitionParam.Value != DBNull.Value) Permition = Convert.ToByte(PermitionParam.Value);
                    isFound = (ID != -1);
                }
                catch (Exception ex) { Debug.WriteLine(ex); isFound = false; }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return isFound;
            }
        }
        public static int AddNewUser(int DoctorID,string username, string password, byte Permition)
        {
            int? UserID = null;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using(SqlCommand command = new SqlCommand("Sp_AddNewUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Doctor_ID", DoctorID);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Permition", Permition);
                SqlParameter outputparameter = new SqlParameter("@NewUserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    UserID = (int)command.Parameters["@NewUserID"].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return UserID?? -1;
        }
        public static bool UpdateUser(int ID,int DoctorID, string username, string password, byte Permition)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_UpdateUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", ID);
                command.Parameters.AddWithValue("@Doctor_ID", DoctorID);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Permition", Permition);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) {Debug.WriteLine(ex);}
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return RowAffected > 0;
            }
        }
        public static bool DeleteUser(int ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_DeleteUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", ID);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return RowAffected > 0;
            }
        }
        public static bool ChangePassword(int ID, string password)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_ChangePassword",connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID",ID);
                command.Parameters.AddWithValue("@Password", password);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                return RowAffected > 0;
            }
        }
    }
}
