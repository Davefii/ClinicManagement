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
    public class DataMedicalRecord
    {
        public static bool GetMedicalRecordByID(int ID,ref string VisitDescription,ref string Diagnosis,ref string AdditionalNotes)
        {
            bool isfound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_GetMedicalRecordBYID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID",ID);
                try
                {
                    var visitDescriptionParam = new SqlParameter("@VisitDescription", SqlDbType.VarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var DiagnosisParam = new SqlParameter("@Diagnosis", SqlDbType.VarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    var AdditionalNotesParam = new SqlParameter("@AdditionalNotes", SqlDbType.VarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(visitDescriptionParam);
                    command.Parameters.Add(DiagnosisParam);
                    command.Parameters.Add(AdditionalNotesParam);
                    connection.Open();
                    command.ExecuteNonQuery();
                    isfound = true;
                    VisitDescription = visitDescriptionParam.Value?.ToString();
                    Diagnosis = DiagnosisParam.Value?.ToString();
                    AdditionalNotes = AdditionalNotesParam.Value?.ToString();
                }
                catch (Exception ex) { Debug.WriteLine(ex); isfound = false; }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                return isfound;
            }
        }
        public static int AddMedicalRecord(int AppointmentID, string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            int? MedicalRecordID = null;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_AddMedicalRecord", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDAppointment", AppointmentID);
                command.Parameters.AddWithValue("@VisitDescription", VisitDescription);
                command.Parameters.AddWithValue("@Diagnosis", Diagnosis);
                if (AdditionalNotes == "" || AdditionalNotes == null)
                    command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
                SqlParameter Outputparameter = new SqlParameter("@NewMedicalRecordID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(Outputparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MedicalRecordID = (int)command.Parameters["@NewMedicalRecordID"].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally { if (connection.State == ConnectionState.Open) connection.Close(); }
            }
            return MedicalRecordID ?? -1;
        }
        public static bool UpdateMedicalRecord(int ID, string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_UpdateMedicalRecord", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@VisitDescription", VisitDescription);
                command.Parameters.AddWithValue("@Diagnosis", Diagnosis);
                if (AdditionalNotes == "" || AdditionalNotes == null)
                    command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
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
        public static bool DeleteMedicalRecord(int ID, int AppointmentID)
        {
            int RowAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_DeleteMedicalRecord", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                SqlParameter returnparameter = new SqlParameter();
                returnparameter.Direction = ParameterDirection.ReturnValue;
                returnparameter.DbType = DbType.Int32;
                command.Parameters.Add(returnparameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RowAffected = (int)returnparameter.Value;
                }
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
                finally 
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return RowAffected > 0;
        }
        public static bool ChackMedicalRecored(int ID)
        {
            bool isFount = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_CheckExistMedicalrecord", connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    SqlParameter Outputparameter = new SqlParameter()
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(Outputparameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                    isFount = Convert.ToBoolean(Outputparameter.Value);
                    connection.Close();
                }
                catch(Exception ex) { Debug.WriteLine(ex.Message); }
            }
            return isFount;
        }
    }
}
