using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Jobs
    {
        private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

        private static SqlConnection _connection;
        public static void GetJobs()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM Jobs";

                try
                {
                    connection.Open();
                    using SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: " + reader.GetString(0));
                            Console.WriteLine("Title: " + reader.GetString(1));
                            Console.WriteLine("Min_salary: " + reader.GetInt32(2));
                            Console.WriteLine("Max_salary: " + reader.GetInt32(3));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No jobs found.");
                    }

                    reader.Close();
                }
                catch
                {
                    Console.WriteLine("Error connecting to database.");
                }
            }
        }

        public static void InsertJobs(int id, string title, int min_salary, int max_salary)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO Jobs (id, title, min_salary, max_salary) VALUES (@id, @title,@min_salary,@max_salary)";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Char;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMinSalary = new SqlParameter();
                pMinSalary.ParameterName = "@min_salary";
                pMinSalary.SqlDbType = SqlDbType.Int;
                pMinSalary.Value = min_salary;
                sqlCommand.Parameters.Add(pMinSalary);

                SqlParameter pMaxSalary = new SqlParameter();
                pMaxSalary.ParameterName = "@max_salary";
                pMaxSalary.SqlDbType = SqlDbType.Int;
                pMaxSalary.Value = max_salary;
                sqlCommand.Parameters.Add(pMaxSalary);

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

        public static void UpdateJobs(int id, string newTitle, int newMin_salary, int newMax_salary)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "UPDATE Jobs SET title = @newTitle, min_salary = @newMin_salary, max_salary = @newMax_salary WHERE Id = @id";


            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Char;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pNewTitle = new SqlParameter();
                pNewTitle.ParameterName = "@newTitle";
                pNewTitle.SqlDbType = SqlDbType.VarChar;
                pNewTitle.Value = newTitle;
                sqlCommand.Parameters.Add(pNewTitle);

                SqlParameter pNewMinSalary = new SqlParameter();
                pNewMinSalary.ParameterName = "@newMin_salary";
                pNewMinSalary.SqlDbType = SqlDbType.Int;
                pNewMinSalary.Value = newMin_salary;
                sqlCommand.Parameters.Add(pNewMinSalary);

                SqlParameter pNewMaxSalary = new SqlParameter();
                pNewMaxSalary.ParameterName = "@newMax_salary";
                pNewMaxSalary.SqlDbType = SqlDbType.Int;
                pNewMaxSalary.Value = newMax_salary;
                sqlCommand.Parameters.Add(pNewMaxSalary);

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

        public static void DeleteJobs(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM Jobs WHERE Id = @id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

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

        public static void GetJobsById(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Jobs WHERE ID = @id";

            try
            {
                _connection.Open();

                // Declare parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Title: " + reader.GetString(1));
                        Console.WriteLine("Min_salary: " + reader.GetInt32(2));
                        Console.WriteLine("Max_salary: " + reader.GetInt32(3));
                    }
                }
                else
                {
                    Console.WriteLine("No Jobs found with the given ID.");
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
