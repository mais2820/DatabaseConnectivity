﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Department
    {
        private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

        private static SqlConnection _connection;

        public static void GetDepartment()

        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "SELECT * FROM Department";

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
                        Console.WriteLine("Location_id: " + reader.GetInt32(2));
                        Console.WriteLine("Manager_id: " + reader.GetInt32(3));
                    }
                }
                else
                {
                    Console.WriteLine("No Department found.");
                }

                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to database.");
            }
        }

        public static void InsertDepartment(int id, string name, int location_id, int manager_id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "INSERT INTO Regions (Id, Name, location_id, manager_id) VALUES (@id, @name, @location_id, manager_id)";

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

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationId = new SqlParameter();
                pLocationId.ParameterName = "@location_id";
                pLocationId.SqlDbType = SqlDbType.Int;
                pLocationId.Value = location_id;
                sqlCommand.Parameters.Add(pLocationId);

                SqlParameter pManagerId = new SqlParameter();
                pLocationId.ParameterName = "@manager_id";
                pLocationId.SqlDbType = SqlDbType.Int;
                pLocationId.Value = manager_id;
                sqlCommand.Parameters.Add(pLocationId);

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

        public static void UpdateDepartment(int id, string newName, )
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "UPDATE Regions SET Name = @newName WHERE Id = @id";

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

                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@newName";
                pNewName.SqlDbType = SqlDbType.VarChar;
                pNewName.Value = newName;
                sqlCommand.Parameters.Add(pNewName);

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

        public static void DeleteDepartment(int id)
        {
            _connection = new SqlConnection(_connectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _connection;
            sqlCommand.CommandText = "DELETE FROM Regions WHERE Id = @id";

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

        public static void GetDepartmentById(int id)
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
    }
}
