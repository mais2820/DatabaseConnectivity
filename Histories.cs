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
                        Console.WriteLine("Start date: " + reader.GetInt32(0));
                        Console.WriteLine("Employee_id: " + reader.GetInt32(1));
                        Console.WriteLine("End_date: " + reader.GetInt32(2));
                        Console.WriteLine("Department_Id: " + reader.GetInt32(3));
                        Console.WriteLine("Job_Id: " + reader.GetInt32(4));
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

        public static void InsertHistories(int start_date, int employee_id, int end_date, int department_id, int job_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO Histories (start_date, employee_id, end_date, department_id,job_id) " +
                "VALUES (@start_date, @employee_id, @end_date, @department_id,@job_id)";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pStartDate = new SqlParameter();
                pStartDate.ParameterName = "@start_date";
                pStartDate.SqlDbType = SqlDbType.Int;
                pStartDate.Value = start_date;
                sqlCommand.Parameters.Add(pStartDate);

                SqlParameter pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "@employee_id";
                pEmployeeId.SqlDbType = SqlDbType.Int;
                pEmployeeId.Value = employee_id;
                sqlCommand.Parameters.Add(pEmployeeId);

                SqlParameter pEndDate = new SqlParameter();
                pEndDate.ParameterName = "@end_date";
                pEndDate.SqlDbType = SqlDbType.Int;
                pEndDate.Value = end_date;
                sqlCommand.Parameters.Add(pEndDate);

                SqlParameter pDepartmentId = new SqlParameter();
                pDepartmentId.ParameterName = "@department_id";
                pDepartmentId.SqlDbType = SqlDbType.Int;
                pDepartmentId.Value = department_id;
                sqlCommand.Parameters.Add(pDepartmentId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@job_id";
                pJobId.SqlDbType = SqlDbType.Int;
                pJobId.Value = job_id;
                sqlCommand.Parameters.Add(pJobId);


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

        public static void UpdateHistories(int newStart_date, int newEmployee_id, int newEnd_date, int newDepartment_id, int newJob_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "UPDATE Histories SET start_date = @newStart_date, employee_id = newEmployee_id, end_date = newEnd_date, job_id = newJob_id WHERE job_id = @newJob_id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pStartDate = new SqlParameter();
                pStartDate.ParameterName = "@newStart_date";
                pStartDate.SqlDbType = SqlDbType.Int;
                pStartDate.Value = newStart_date;
                sqlCommand.Parameters.Add(pStartDate);

                SqlParameter pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "@newEmployee_id";
                pEmployeeId.SqlDbType = SqlDbType.Int;
                pEmployeeId.Value = newEmployee_id;
                sqlCommand.Parameters.Add(pEmployeeId);

                SqlParameter pEndDate = new SqlParameter();
                pEndDate.ParameterName = "@newEnd_date";
                pEndDate.SqlDbType = SqlDbType.Int;
                pEndDate.Value = newEnd_date;
                sqlCommand.Parameters.Add(pEndDate);

                SqlParameter pDepartmentId = new SqlParameter();
                pDepartmentId.ParameterName = "@newDepartment_id";
                pDepartmentId.SqlDbType = SqlDbType.Int;
                pDepartmentId.Value = newDepartment_id;
                sqlCommand.Parameters.Add(pDepartmentId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@newJob_id";
                pJobId.SqlDbType = SqlDbType.Int;
                pJobId.Value = newJob_id;
                sqlCommand.Parameters.Add(pJobId);

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

        public static void DeleteHistories(int job_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM Histories WHERE job_id = @job_id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@job_id";
                pJobId.SqlDbType = SqlDbType.Int;
                pJobId.Value = job_id;
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

        public static void GetHistoriesById(int job_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Histories WHERE job_id = @job_id";

            try
            {
                _connection.Open();

                // Declare parameter
                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@job_id";
                pJobId.SqlDbType = SqlDbType.Int;
                pJobId.Value = job_id;
                sqlCommand.Parameters.Add(pJobId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No region found with the given ID.");
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
