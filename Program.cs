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
        //Region.GetRegions();
        //Region.InsertRegions(13,"MZ");
        //Region.UpdateRegions(13,"GG");
        //Region.DeleteRegions(13);
        //Region.GetRegionsById(1);

        //Jobs.GetJobs();
        //Jobs.InsertJobs(13, "Chief Officer", 9999, 9999);
        //Jobs.UpdateJobs(13, "Programmer", 4909, 4909);
        //Jobs.DeleteJobs(13);
        //Jobs.GetJobsById(11);

        //GetCountries();
        //InsertCountries("MY", "Malaysia", 13);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("== MENU ==");
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Departments");
            Console.WriteLine("3. Jobs");
            Console.WriteLine("4. Histories");
            Console.WriteLine("5. Locations");
            Console.WriteLine("6. Countries");
            Console.WriteLine("7. Regions");
            Console.WriteLine("8. Exit");

            Console.Write("Input Menu: ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (menuChoice)
            {
                case 1:
                    ProcessSubMenuEmployees();
                    break;
                case 2:
                    ProcessSubMenuDepartment();
                    break;
                case 3:
                    ProcessSubMenuJobs();
                    break;
                case 4:
                    ProcessSubMenuHistories();
                    break;
                case 5:
                    ProcessSubMenuLocation();
                    break;
                case 6:
                    ProcessSubMenuCountries();
                    break;
                case 7:
                    ProcessSubMenuRegion();
                    Console.ReadLine();
                    break;
                case 8:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid, coba lagi.");
                    break;  
            }
            Console.WriteLine();
            Console.Clear();
        }

        static void ProcessSubMenuRegion()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n== REGION ==");

                Console.WriteLine("1. Get");
                Console.WriteLine("2. GetById");
                Console.WriteLine("3. Insert");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Back");

                Console.Write("Input Menu: ");
                int subMenuChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (subMenuChoice)
                {
                    case 1:
                        Region.GetRegions();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Region ID: ");
                        int regionGetId = Convert.ToInt32(Console.ReadLine());
                        Region.GetRegionsById(regionGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Region ID: ");
                        int regionId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Region Name: ");
                        string regionName = Console.ReadLine();
                        Region.InsertRegions(regionId, regionName);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Region ID: ");
                        int updateRegionId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Region Name: ");
                        string updateRegionName = Console.ReadLine();
                        Region.UpdateRegions(updateRegionId, updateRegionName);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input Region ID: ");
                        int deleteRegionId = Convert.ToInt32(Console.ReadLine());
                        Region.DeleteRegions(deleteRegionId);
                        Console.ReadLine();
                        break;
                    case 6:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice. Please try again.");
                        break;
                }
                Console.Clear();
            }
        }

        static void ProcessSubMenuEmployees()
        {
            Console.WriteLine("Invalid, coba lagi.");
        }

        static void ProcessSubMenuDepartment()
        {
            Console.WriteLine("Invalid, coba lagi.");
        }

        static void ProcessSubMenuJobs()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n== JOBS ==");

                Console.WriteLine("1. Get");
                Console.WriteLine("2. GetById");
                Console.WriteLine("3. Insert");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Back");

                Console.Write("Input Menu: ");
                int subMenuChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (subMenuChoice)
                {
                    case 1:
                        Region.GetRegions();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Region ID: ");
                        int regionGetId = Convert.ToInt32(Console.ReadLine());
                        Region.GetRegionsById(regionGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Region ID: ");
                        int regionId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Region Name: ");
                        string regionName = Console.ReadLine();
                        Region.InsertRegions(regionId, regionName);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Region ID: ");
                        int updateRegionId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Region Name: ");
                        string updateRegionName = Console.ReadLine();
                        Region.UpdateRegions(updateRegionId, updateRegionName);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input Region ID: ");
                        int deleteRegionId = Convert.ToInt32(Console.ReadLine());
                        Region.DeleteRegions(deleteRegionId);
                        Console.ReadLine();
                        break;
                    case 6:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice. Please try again.");
                        break;
                }
                Console.Clear();
            }
        }

        static void ProcessSubMenuHistories()
        {
            Console.WriteLine("Invalid, coba lagi.");
        }

        static void ProcessSubMenuLocation()
        {
            Console.WriteLine("Invalid, coba lagi.");
        }

        static void ProcessSubMenuCountries()
        {
            Console.WriteLine("Invalid, coba lagi.");
        }




    }
}