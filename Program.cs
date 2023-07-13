using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Reflection.PortableExecutable;

namespace DatabaseConnectivity;
public class Program
{
    private static string _connectionString = "Data Source = LAPTOP-6G2JJTAJ;Database = db_datakaryawan;Integrated Security = True;Connect Timeout = 30;";

    private static SqlConnection _connection;
    public static void Main()
    {
        _connection = new SqlConnection(_connectionString);

        try
        {
            _connection.Open();
            Console.WriteLine("Connection successful.");
            _connection.Close();
        }

        catch
        {
            Console.WriteLine("Error connecting to database.");
        }

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("== MENU DATABASE AL MAIS ==");
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
                Console.WriteLine("== REGION ==");

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
            bool back = false;

            while (!back)
            {
                Console.WriteLine("== EMPLOYEES ==");

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
                        Employees.GetEmployees();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Employees ID: ");
                        int employeesGetId = Convert.ToInt32(Console.ReadLine());
                        Employees.GetEmployeesById(employeesGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Employee ID: ");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Hire Date: ");
                        DateTime hireDate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salary: " );
                        int salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Comission PCT: ");
                        int comission = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Manager Id: ");
                        int managerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Job Id: ");
                        string jobId = Console.ReadLine();
                        Console.Write("Department Id: ");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        string regionName = Console.ReadLine();
                        Employees.InsertEmployees(employeeId,firstName,lastName,email,phoneNumber,hireDate,salary,comission,managerId,jobId,departmentId);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Employee ID: ");
                        int updateemployeeId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("First Name: ");
                        string updatefirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string updatelastName = Console.ReadLine();
                        Console.Write("Email: ");
                        string updateemail = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string updatephoneNumber = Console.ReadLine();
                        Console.Write("Hire Date: ");
                        DateTime updatehireDate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salary: ");
                        int updatesalary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Comission PCT: ");
                        int updatecomission = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Manager Id: ");
                        int updatemanagerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Job Id: ");
                        string updatejobId = Console.ReadLine();
                        Console.Write("Department Id: ");
                        int updatedepartmentId = Convert.ToInt32(Console.ReadLine());
                        Employees.InsertEmployees(updateemployeeId, updatefirstName, updatelastName, updateemail, updatephoneNumber, updatehireDate, updatesalary, updatecomission, updatemanagerId, updatejobId, updatedepartmentId);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input Employees ID: ");
                        int deleteEmployeesId = Convert.ToInt32(Console.ReadLine());
                        Employees.DeleteEmployees(deleteEmployeesId);
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

        static void ProcessSubMenuDepartment()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("== DEPARTMENT ==");

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
                        Department.GetDepartment();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Department ID: ");
                        int departmentGetId = Convert.ToInt32(Console.ReadLine());
                        Department.GetDepartmentById(departmentGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Department ID: ");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Department Name: ");
                        string departmentName = Console.ReadLine();
                        Console.Write("Input Location ID: ");
                        int locationID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Manager ID: ");
                        int managerID = Convert.ToInt32(Console.ReadLine());
                        Department.InsertDepartment(departmentId, departmentName, locationID, managerID);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Department ID: ");
                        int updateDepartmentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Department Name: ");
                        string updateDepartmentName = Console.ReadLine();
                        Console.Write("Input Location ID: ");
                        int updateLocationID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Manager ID: ");
                        int updateManagerID = Convert.ToInt32(Console.ReadLine());
                        Department.UpdateDepartment(updateDepartmentId, updateDepartmentName, updateLocationID ,updateManagerID);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input ID: ");
                        int deleteDepartmentId = Convert.ToInt32(Console.ReadLine());
                        Department.DeleteDepartment(deleteDepartmentId);
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

        static void ProcessSubMenuJobs()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("== JOBS ==");

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
                        Jobs.GetJobs();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Jobs ID: ");
                        int jobsGetId = Convert.ToInt32(Console.ReadLine());
                        Jobs.GetJobsById(jobsGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Jobs ID: ");
                        int jobsId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Jobs Name: ");
                        string jobsName = Console.ReadLine();
                        Console.Write("Input Min Salary: ");
                        int jobsMinSalary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Max Salary: ");
                        int jobsMaxSalary = Convert.ToInt32(Console.ReadLine());
                        Jobs.InsertJobs(jobsId, jobsName, jobsMinSalary, jobsMaxSalary);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Jobs ID: ");
                        int updateJobsId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Jobs Name: ");
                        string updateJobsName = Console.ReadLine();
                        Console.Write("Input Min Salary: ");
                        int updatejobsMinSalary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Max Salary: ");
                        int updatejobsMaxSalary = Convert.ToInt32(Console.ReadLine());
                        Jobs.UpdateJobs(updateJobsId, updateJobsName, updatejobsMinSalary, updatejobsMaxSalary);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input Jobs ID: ");
                        int deleteJobsId = Convert.ToInt32(Console.ReadLine());
                        Jobs.DeleteJobs(deleteJobsId);
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
            bool back = false;

            while (!back)
            {
                Console.WriteLine("== HISTORIES ==");

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
                        Histories.GetHistories();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Employee ID: ");
                        int historiesGetId = Convert.ToInt32(Console.ReadLine());
                        Histories.GetHistoriesById(historiesGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Start Date: ");
                        DateTime startDate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Employee ID: ");
                        int employeeID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input End Date: ");
                        DateTime endDate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Department ID: ");
                        int departmentID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Job ID: ");
                        int jobID = Convert.ToInt32(Console.ReadLine());
                        string regionName = Console.ReadLine();
                        Histories.InsertHistories(startDate,employeeID,endDate,departmentID,jobID);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Start Date: ");
                        DateTime updatestartDate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Employee ID: ");
                        int updateemployeeID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input End Date: ");
                        DateTime updateendDate = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Department ID: ");
                        int updatedepartmentID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input Job ID: ");
                        int updatejobID = Convert.ToInt32(Console.ReadLine());
                        Histories.UpdateHistories(updatestartDate, updateemployeeID, updateendDate, updatedepartmentID, updatejobID);
                        break;
                    case 5:
                        Console.Write("Input Employee ID: ");
                        int deleteHistoriesId = Convert.ToInt32(Console.ReadLine());
                        Histories.DeleteHistories(deleteHistoriesId);
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

        static void ProcessSubMenuLocation()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("== LOCATION ==");

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
                        Location.GetLocation();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Location ID: ");
                        int locationGetId = Convert.ToInt32(Console.ReadLine());
                        Location.GetLocationById(locationGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Location ID: ");
                        int locationId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input String address: ");
                        string stringAddress = Console.ReadLine();
                        Console.Write("Input Postal Code: ");
                        string postalCode = Console.ReadLine();
                        Console.Write("Input City: ");
                        string inputCity = Console.ReadLine();
                        Console.Write("Input State Province: ");
                        string stateProvince = Console.ReadLine();
                        Console.Write("Input Country Id: ");
                        string countryId = Console.ReadLine();
                        Location.InsertLocation(locationId, stringAddress, postalCode, inputCity, stateProvince, countryId);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Location ID: ");
                        int updatelocationId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input String address: ");
                        string updatestringAddress = Console.ReadLine();
                        Console.Write("Input Postal Code: ");
                        string updatepostalCode = Console.ReadLine();
                        Console.Write("Input City: ");
                        string updateinputCity = Console.ReadLine();
                        Console.Write("Input State Province: ");
                        string updatestateProvince = Console.ReadLine();
                        Console.Write("Input Country Id: ");
                        string updatecountryId = Console.ReadLine();
                        Location.InsertLocation(updatelocationId, updatestringAddress, updatepostalCode, updateinputCity, updatestateProvince, updatecountryId);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input Location ID: ");
                        int deleteLocationId = Convert.ToInt32(Console.ReadLine());
                        Location.DeleteLocation(deleteLocationId);
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

        static void ProcessSubMenuCountries()// BUG
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("== COUNTRIES ==");

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
                        Countries.GetCountries();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Input Region ID: ");
                        int countriesGetId = Convert.ToInt32(Console.ReadLine());
                        Countries.GetCountriesById(countriesGetId);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Input Countries ID: ");
                        string countriesId = Console.ReadLine();
                        Console.Write("Input Countries Name: ");
                        string countriesName = Console.ReadLine();
                        Console.Write("Input Region ID: ");
                        int countriesRegionId = Convert.ToInt32(Console.ReadLine());
                        Countries.InsertCountries(countriesId, countriesName, countriesRegionId);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Input Countries ID: ");
                        string updateCountriesId = Console.ReadLine();
                        Console.Write("Input Countries Name: ");
                        string updateCountriesName = Console.ReadLine();
                        Console.Write("Input Region ID: ");
                        int updateCountriesRegionId = Convert.ToInt32(Console.ReadLine());
                        Countries.UpdateCountries(updateCountriesId, updateCountriesName, updateCountriesRegionId);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Input Region ID: ");
                        int deleteCountriesId = Convert.ToInt32(Console.ReadLine());
                        Countries.DeleteCountries(deleteCountriesId);
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
    }
}