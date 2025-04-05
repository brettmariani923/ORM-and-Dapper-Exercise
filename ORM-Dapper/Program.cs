using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper

{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepository = new Data.DepartmentRepository(conn);

            //departmentRepository.AddDepartments("HR");

            var departments = departmentRepository.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"Department ID: {department.DepartmentId}, Name: {department.Name}");
            }
        }
    }
}
