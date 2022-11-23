using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Linq
{
    public class EmployeeRepository
    {
        private List<Employee> _customers;
        private static EmployeeRepository instance = null;

        private EmployeeRepository()
        {
            _customers = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"northwind.json")));
        }
        public static EmployeeRepository CreateInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeRepository();
            }
            return instance;
        }

        public Employee[] GetAllEmployees()
        {
            return _customers.ToArray();
        }

    }
}
