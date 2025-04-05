using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ORM_Dapper.Models;

namespace ORM_Dapper.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAllProducts();
        public void CreateProduct (int ProductID, string Name, double Price, int CategoryID, bool OnSale, int StockLevel);

    }
}
