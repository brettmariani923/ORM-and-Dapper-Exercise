using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ORM_Dapper.Models;

namespace ORM_Dapper.Data
{
    internal class DepartmentRepository: IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM departments;");
        }
        public void AddDepartments(string name)
        {
            _connection.Execute("INSERT INTO departments (Name) Values (@Name);", new {name});
        }
   
    }
}
