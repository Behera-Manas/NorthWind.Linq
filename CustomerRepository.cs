using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Linq
{
    public class CustomerRepository
    {
        private List<Customer> _customers;
        private static CustomerRepository instance = null;

        private CustomerRepository()
        {
            _customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"northwind.json")));
        }
        public static CustomerRepository CreateInstance()
        {
            if (instance == null)
            {
                instance = new CustomerRepository();
            }
            return instance;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}
