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
    public class DataPayments
    {
        public static DataTable GetAllPayments()
        {
            DataTable dT = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion);
            string query = "SELECT * FROM Payments";
            SqlCommand command = new SqlCommand(query, connection);
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
                Debug.WriteLine("Error in GetAllPayments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dT;
        }
        public static bool GetPaymentbyid(int PaymentID,ref DateTime PaymentsDate,ref string PaymentsMethod,ref decimal AmountPaid,ref string AddtionalNotes)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using (SqlCommand command = new SqlCommand("sp_GetPaymentById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", PaymentID);
                var PaymentDateParam = new SqlParameter("@PaymentDate", SqlDbType.Date)
                {
                    Direction = ParameterDirection.Output
                };
                var PaymentMethodParam = new SqlParameter("@PaymentMethod", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                var AmountPaidParam = new SqlParameter("@AmountPaid", SqlDbType.SmallMoney)
                {
                    Direction = ParameterDirection.Output
                };
                var AdditionalNotesParam = new SqlParameter("@AdditionalNotes", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(PaymentDateParam);
                command.Parameters.Add(PaymentMethodParam);
                command.Parameters.Add(AmountPaidParam);
                command.Parameters.Add(AdditionalNotesParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (PaymentDateParam.Value != DBNull.Value) PaymentsDate = (DateTime)PaymentDateParam.Value;
                    if (PaymentMethodParam.Value != DBNull.Value) PaymentsMethod = PaymentMethodParam.Value.ToString();
                    if (AmountPaidParam.Value != DBNull.Value) AmountPaid = Convert.ToDecimal(AmountPaidParam.Value);
                    if (AdditionalNotesParam.Value != DBNull.Value) AddtionalNotes = AdditionalNotesParam.Value.ToString();

                    isFound = true;
                }
                catch (Exception ex) {Debug.WriteLine("Error in GetPaymentbyid: " + ex.Message); isFound = false; }
                finally {if (connection.State == ConnectionState.Open) connection.Close();}
            }
            return isFound;
        }
        public static int addPayments(int AppointmentID,DateTime PaymentsDate, string PaymentsMethod, decimal AmountPaid, string AddtionalNotes)
        {
            int? PayID = null;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using(SqlCommand command = new SqlCommand("sp_AddPayment", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                command.Parameters.AddWithValue("@PaymentDate", PaymentsDate);
                command.Parameters.AddWithValue("@PaymentMethod", PaymentsMethod);
                command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                command.Parameters.AddWithValue("@AdditionalNotes", AddtionalNotes);
                SqlParameter PayIDParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(PayIDParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    PayID = (int)command.Parameters["@NewPaymentID"].Value;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return PayID ?? -1;
        }
        public static bool CheckExistPaymentById(int PaymentID)
        {
            bool isFound = false;
            string Query = "Select Found=1 From Payments Where ID = @PaymentID;";
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
            using(SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        isFound = true;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    isFound = false;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                return isFound;
            }
        }
        //public static bool UpdatePayment(int PaymentID, DateTime PaymentsDate, string PaymentsMethod, float AmountPaid, string AddtionalNotes)
        //{
        //    bool isUpdated = false;
        //    string Query = @"
        //    UPDATE Payments
        //       SET PaymentDate = @PaymentDate
        //          ,PaymentMethod = @PaymentMethod
        //          ,AmountPaid = @AmountPaid
        //          ,AdditionalNotes = @AdditionalNotes
        //     WHERE ID = @PaymentID;";
        //    using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
        //    using (SqlCommand command = new SqlCommand(Query, connection))
        //    {
        //        command.Parameters.AddWithValue("@PaymentID", PaymentID);
        //        command.Parameters.AddWithValue("@PaymentDate", PaymentsDate);
        //        command.Parameters.AddWithValue("@PaymentMethod", PaymentsMethod);
        //        command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
        //        command.Parameters.AddWithValue("@AdditionalNotes", AddtionalNotes);
        //        try
        //        {
        //            connection.Open();
        //            int rowsAffected = command.ExecuteNonQuery();
        //            isUpdated = rowsAffected > 0;
        //        }
        //        catch (Exception ex) {Debug.WriteLine(ex.Message); isUpdated = false; }
        //        finally {connection.Close();}
        //    }
        //    return isUpdated;
        //}
        //public static bool DeletePayment(int PaymentID)
        //{
        //    bool isDeleted = false;
        //    string Query = "DELETE FROM Payments WHERE ID = @PaymentID";
        //    using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataAccessSettings.Connetcion))
        //    using (SqlCommand command = new SqlCommand(Query, connection))
        //    {
        //        command.Parameters.AddWithValue("@PaymentID", PaymentID);
        //        try
        //        {
        //            connection.Open();
        //            int rowsAffected = command.ExecuteNonQuery();
        //            isDeleted = rowsAffected > 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return isDeleted;
        //}
    }
}
