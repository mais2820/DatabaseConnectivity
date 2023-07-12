using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;

namespace DatabaseConnectivity;
public class Program
{
    private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Main()
    {
        /*_connection = new SqlConnection(_connectionString);

        try
        {
            _connection.Open();
            Console.WriteLine("Connection successful.");
            _connection.Close();
        }

        catch
        {
            Console.WriteLine("Error connecting to database.");
        }*/
        //GetRegions();
        //InsertRegions(13,"MZ");
        //UpdateRegion(13,"GG");
        //DeleteRegion(13);
        //GetRegionById(1);
        GetJobs();
    }
    // GET ALL
    public static void GetRegions()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Regions";

        try
        {
            _connection.Open();
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
                Console.WriteLine("No regions found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }

    // INSERT
    public static void InsertRegions(int id, string name)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Regions (Id, Name) VALUES (@id, @name)";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = name;
                sqlCommand.Parameters.Add(pName);

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
                connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database.");
            }
        }
    }

    // UPDATE
    public static void UpdateRegion(int id, string newName)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Regions SET Name = @newName WHERE Id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@newName";
                pNewName.SqlDbType = SqlDbType.VarChar;
                pNewName.Value = newName;
                sqlCommand.Parameters.Add(pNewName);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update berhasil.");
                }
                else
                {
                    Console.WriteLine("Update gagal. Data dengan ID tersebut tidak ditemukan.");
                }

                transaction.Commit();
                connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Kesalahan saat menghubungkan ke database.");
            }
        }
    }

    // DELETE
    public static void DeleteRegion(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM Regions WHERE Id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
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
                    Console.WriteLine("Penghapusan berhasil.");
                }
                else
                {
                    Console.WriteLine("Penghapusan gagal. Data dengan ID tersebut tidak ditemukan.");
                }

                transaction.Commit();
                connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Kesalahan saat menghubungkan ke database.");
            }
        }
    }

    // GET BY ID
    public static void GetRegionById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Regions WHERE ID = @id";

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


    public static void GetJobs()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Jobs";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min_salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max_salary: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No regions found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }
}