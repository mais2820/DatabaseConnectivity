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
    public class Countries
    {
        private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

        private static SqlConnection _connection;
        public static void GetCountries()
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Countries";

            try
            {
                _connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                        Console.WriteLine("Region_id: " + reader.GetInt32(2));
                    }
                }
                else
                {
                    Console.WriteLine("No countries found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void InsertCountries(string id, string name, int region_id) 
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO Countries (id, name, region_id ) VALUES (@id, @name, @region_id)";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pRegion_id = new SqlParameter();
                pRegion_id.ParameterName = "@region_id";
                pRegion_id.SqlDbType = SqlDbType.Int;
                pRegion_id.Value = region_id;
                sqlCommand.Parameters.Add(pRegion_id);

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

        public static void UpdateCountries(string id, string newName, int newRegion_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "UPDATE Countries SET name = @newName, region_id = newRegion_id WHERE Id = @id";


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

                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@newName";
                pNewName.SqlDbType = SqlDbType.VarChar;
                pNewName.Value = newName;
                sqlCommand.Parameters.Add(pNewName);

                SqlParameter pNewRegionId = new SqlParameter();
                pNewRegionId.ParameterName = "@newRegion_id";
                pNewRegionId.SqlDbType = SqlDbType.Int;
                pNewRegionId.Value = newRegion_id;
                sqlCommand.Parameters.Add(pNewRegionId);

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

        public static void DeleteCountries(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM Countries WHERE id = @id";

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

        public static void GetCountriesById(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Countries WHERE id = @id";

            try
            {
                _connection.Open();

                // Declare parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@_id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                        Console.WriteLine("Region_id: " + reader.GetInt32(2));
                    }
                }
                else
                {
                    Console.WriteLine("No Countries found with the given ID.");
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
