using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Histories
    {
        private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

        private static SqlConnection _connection;

        public static void GetHistories()
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Histories";

            try
            {
                _connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Start date: " + reader.GetDateTime(0));
                        Console.WriteLine("Employee_id: " + reader.GetInt32(1));
                        Console.WriteLine("End_date: " + reader.GetDateTime(2));
                        Console.WriteLine("Department_Id: " + reader.GetInt32(3));
                        Console.WriteLine("Job_Id: " + reader.GetString(4));
                    }
                }
                else
                {
                    Console.WriteLine("No Histories found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void InsertHistories(DateTime start_date, int employee_id, DateTime end_date, int department_id, int job_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO Histories (start_date, employee_id, end_date, department_id,job_id) " +
                "VALUES (@start_date, @employee_id, @end_date, @department_id,@job_id)";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@StartDate", start_date);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", employee_id);
            sqlCommand.Parameters.AddWithValue("@EndDate", end_date);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", department_id);
            sqlCommand.Parameters.AddWithValue("@JobID", job_id);
            
            try
            {          
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert success.");
                }
                else
                {
                    Console.WriteLine("Insert failed.");
                }

                transaction.Commit();
                _connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void UpdateHistories(DateTime newStart_date, int newEmployee_id, DateTime newEnd_date, int newDepartment_id, int newJob_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "UPDATE Histories SET start_date = @newStart_date, employee_id = newEmployee_id, end_date = newEnd_date, job_id = newJob_id, department_id = newDepartment_id " +
                "WHERE employee_id = @newEmployee_id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@newStart_date", newStart_date);
            sqlCommand.Parameters.AddWithValue("@newEmployee_id", newEmployee_id);
            sqlCommand.Parameters.AddWithValue("@newEnd_date", newEnd_date);
            sqlCommand.Parameters.AddWithValue("@newDepartment_id", newDepartment_id);
            sqlCommand.Parameters.AddWithValue("@newJob_id", newJob_id);

            try
            {       
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update success.");
                }
                else
                {
                    Console.WriteLine("Update failed.");
                }

                transaction.Commit();
                _connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void DeleteHistories(int employee_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM Histories WHERE employee_id = @employee_id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@employee_id";
                pJobId.SqlDbType = SqlDbType.Int;
                pJobId.Value = employee_id;
                sqlCommand.Parameters.Add(pJobId);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete success.");
                }
                else
                {
                    Console.WriteLine("Delete failed.");
                }

                transaction.Commit();
                _connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void GetHistoriesById(int employee_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Histories WHERE employee_id = @employee_id";

            try
            {
                _connection.Open();

                // Declare parameter
                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@employee_id";
                pJobId.SqlDbType = SqlDbType.Int;
                pJobId.Value = employee_id;
                sqlCommand.Parameters.Add(pJobId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Start date: " + reader.GetDateTime(0));
                        Console.WriteLine("Employee_id: " + reader.GetInt32(1));
                        Console.WriteLine("End_date: " + reader.GetDateTime(2));
                        Console.WriteLine("Department_Id: " + reader.GetInt32(3));
                        Console.WriteLine("Job_Id: " + reader.GetString(4));
                    }
                }
                else
                {
                    Console.WriteLine("No Histories found with the given ID.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to the database.");
            }
        }
    }
}
