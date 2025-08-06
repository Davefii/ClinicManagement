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
    public class DataAppointments
    {
        public static DataTable GetAllAppointments()
        {
            DataTable dT = new DataTable();
            string Query = "SELECT * FROM Appointments;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dT.Load(Reader);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return dT;
        }
        public static bool GetAppointmentById(int AppointmentID, ref int Patiens_ID, ref int Doctors_ID, ref DateTime AppointmentDateTime, ref byte AppointmentStatus, ref int MedicalRecord_ID, ref int Payment_ID)
        {
            bool isFound = false;
            string Query = "SELECT * FROM Appointments WHERE ID = @AppointmentID";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();
                    if (Reader.Read())
                    {
                        isFound = true;
                        Patiens_ID = Reader["Patiens_ID"] == DBNull.Value ? -1 : (int)Reader["Patiens_ID"];
                        Doctors_ID = Reader["Doctors_ID"] == DBNull.Value ? -1 : (int)Reader["Doctors_ID"];
                        AppointmentDateTime = Reader["AppointmentDateTime"] == DBNull.Value ? DateTime.Now : (DateTime)Reader["AppointmentDateTime"];
                        AppointmentStatus = Reader["AppointmentStatus"] == DBNull.Value ? (byte)0 : Convert.ToByte(Reader["AppointmentStatus"]);
                        MedicalRecord_ID = Reader["MedicalRecord_ID"] == DBNull.Value ? 0 : (int)Reader["MedicalRecord_ID"];
                        Payment_ID = Reader["Payment_ID"] == DBNull.Value ? 0 : (int)Reader["Payment_ID"];
                    }
                    Reader.Close();
                }
                catch (Exception ex) { Debug.WriteLine("Error in GetAppointmentById: " + ex.Message); isFound = false; }
                finally { connection.Close(); }
            }
            return isFound;
        }
        public static int addNewAppointment(int Patiens_ID, int Doctors_ID, DateTime AppointmentDateTime, byte AppointmentStatus, int MedicalRecord_ID, int Payment_ID)
        {
            int? NewAppintmentID = null;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            {
                using (SqlCommand command = new SqlCommand("Sp_AddAppintments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters
                    command.Parameters.AddWithValue("@Patients_ID", Patiens_ID);
                    command.Parameters.AddWithValue("@Doctor_ID", Doctors_ID);
                    command.Parameters.AddWithValue("@Appintments_Date", AppointmentDateTime);
                    command.Parameters.AddWithValue("@Appintments_Status", AppointmentStatus);
                    if (MedicalRecord_ID == -1 || MedicalRecord_ID == 0)
                        command.Parameters.AddWithValue("@MedicalRecord_ID", System.DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@MedicalRecord_ID", MedicalRecord_ID);
                    if(Payment_ID == -1 || Payment_ID == 0)
                        command.Parameters.AddWithValue("@Payment_ID", System.DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Payment_ID", Payment_ID);
                    try
                    {
                        SqlParameter outputIdParam = new SqlParameter("@NewAppintment", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);
                        // Execute
                        connection.Open();
                        command.ExecuteNonQuery();
                        // Retrieve the ID of the new person
                        NewAppintmentID = (int)command.Parameters["@NewAppintment"].Value;
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }
            if (NewAppintmentID.HasValue)
                return (int)NewAppintmentID;
            else
                return -1;
        }
        public static bool UpdateAppointment(int ID, int Patiens_ID, int Doctors_ID, DateTime AppointmentDateTime, byte AppointmentStatus, int MedicalRecord_ID, int Payment_ID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_UpdateAppointments", connection))
            {
                command.Parameters.AddWithValue("@Patiens_ID", Patiens_ID);
                command.Parameters.AddWithValue("@Doctors_ID", Doctors_ID);
                command.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
                command.Parameters.AddWithValue("@MedicalRecord_ID", MedicalRecord_ID);
                command.Parameters.AddWithValue("@Payment_ID", Payment_ID);
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    SqlParameter returnparameter = new SqlParameter();
                    returnparameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnparameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                    connection.Close();
                }
                catch (Exception ex) { Debug.WriteLine(ex); }    
                return RowAffected > 0;
            }
        }
        public static bool DeleteAppointment(int ID)
        {
            int RowAffected = 0;
            string Query = "DELETE FROM Appointments WHERE ID = @ID;";
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    RowAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
            return RowAffected > 0;
        }
        public static bool UpdateAppointmentStatus(int ID, byte AppointmentStatus)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_UpdateStatusAppointment", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnparameter = new SqlParameter();
                    returnparameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnparameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                    connection.Close();
                }
                catch(Exception ex) { Debug.WriteLine(ex); }
                return RowAffected > 0;
            }
        }
    }
}
