using ORM_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ORM_Dapper.Data
{
    public class ProductRepository : IProductRepository
    {
        public readonly IDbConnection _connection;
        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(int ProductID, string Name, double Price, int CategoryID, bool OnSale, int StockLevel)
        {
            _connection.Execute("INSERT INTO products (ProductID, Name, Price, CategoryID, OnSale, StockLevel) Values (@ProductID, @Name, @Price, @CategoryID, @OnSale, @StockLevel);", new { ProductID, Name, Price, CategoryID, OnSale, StockLevel });
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM products;");
        }



    }
}
