using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;

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
        //UpdateRegions(13,"GG");
        //DeleteRegions(13);
        //GetRegionsById(1);

        //GetJobs();
        //InsertJobs(13, "Chief Officer", 9999, 9999);
        //UpdateJobs(13, "Programmer", 4909, 4909);
        //DeleteJobs(13);
        //GetJobsById(11);

        //GetCountries();
        //InsertCountries("MY", "Malaysia", 13);

    }
}