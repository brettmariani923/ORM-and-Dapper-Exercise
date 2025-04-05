using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM_Dapper.Models;
using System.Data;
using Dapper;
using System.Data.SqlClient;


namespace ORM_Dapper.Data
{
    internal interface IDepartmentRepository
    {
       public IEnumerable<Departments> GetAllDepartments();
       public void AddDepartments(string name);
    }
}
