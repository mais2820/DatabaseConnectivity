using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseConnectivity
{
    public class Location
    {
        private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

        private static SqlConnection _connection;

        public static void GetLocation()
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Location";

            try
            {
                _connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Street Address: " + reader.GetString(1));
                        Console.WriteLine("Postal Code: " + reader.GetString(2));
                        Console.WriteLine("City: " + reader.GetString(3));
                        Console.WriteLine("State Province: " + reader.GetString(4));
                        Console.WriteLine("Country ID: " + reader.GetInt32(5));
                    }
                }
                else
                {
                    Console.WriteLine("No Location found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void InsertLocation(int id, string street_address, string postal_code, string city, string state_province, string country_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO Location (id, street_address, postal_code, city, state_province, country_id) " +
                "VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id)";

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

                SqlParameter pStreetAddress = new SqlParameter();
                pStreetAddress.ParameterName = "@street_address";
                pStreetAddress.SqlDbType = SqlDbType.VarChar;
                pStreetAddress.Value = street_address;
                sqlCommand.Parameters.Add(pStreetAddress);

                SqlParameter pPostalCode = new SqlParameter();
                pPostalCode.ParameterName = "@postal_code";
                pPostalCode.SqlDbType = SqlDbType.Int;
                pPostalCode.Value = postal_code;
                sqlCommand.Parameters.Add(pPostalCode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = SqlDbType.VarChar;
                pCity.Value = city;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pStateProvince = new SqlParameter();
                pStateProvince.ParameterName = "@state_province";
                pStateProvince.SqlDbType = SqlDbType.VarChar;
                pStateProvince.Value = state_province;
                sqlCommand.Parameters.Add(pStateProvince);

                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.SqlDbType = SqlDbType.Int;
                pCountryId.Value = country_id;
                sqlCommand.Parameters.Add(pCountryId);

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

        public static void UpdateLocation(int id, string newStreet_address, string newPostal_code, string newCity, string newState_province, string newCountry_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "UPDATE Location SET street_address = @newStreet_address, postal_code = @newPostal_code, city = @newCity, state_province = @newState_province,country_id = @newCountry_id WHERE id = @id";

            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@newStreet_address", newStreet_address);
            sqlCommand.Parameters.AddWithValue("@newPostal_code", newPostal_code);
            sqlCommand.Parameters.AddWithValue("@newCity", newCity);
            sqlCommand.Parameters.AddWithValue("@newState_province", newState_province);
            sqlCommand.Parameters.AddWithValue("@newCountry_id", newCountry_id);
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

        public static void DeleteLocation(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM Location WHERE Id = @id";

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

        public static void GetLocationById(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Location WHERE ID = @id";

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
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Street Address: " + reader.GetString(1));
                        Console.WriteLine("Postal Code: " + reader.GetString(2));
                        Console.WriteLine("City: " + reader.GetString(3));
                        Console.WriteLine("State Province: " + reader.GetString(4));
                        Console.WriteLine("Country ID: " + reader.GetInt32(5));
                    }
                }
                else
                {
                    Console.WriteLine("No Location found with the given ID.");
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
