using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using ORM_Dapper.Data;
using ORM_Dapper.Models;
using System.Collections.Generic;


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

            //var departmentRepository = new Data.DepartmentRepository(conn);

            //departmentRepository.AddDepartments("HR");

            // var departments = departmentRepository.GetAllDepartments();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine($"Department ID: {department.DepartmentId}, Name: {department.Name}");
            //}
            var newProduct = new Data.ProductRepository(conn);
            newProduct.CreateProduct(888, "Brett's Laptop", 1200.00, 8, true, 9230 );
         
            var productRepository = new ProductRepository(conn);

            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"ProductId: {product.ProductID}, Name: {product.Name}, Price: {product.Price}, Category ID: {product.CategoryID}, On Sale: {product.OnSale}, Stock Price: {product.StockLevel}");
            }
        }
    }
}
