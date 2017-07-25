using HotelManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.Services
{
    public interface ICustomerService 
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int? id);
        Customer AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

    }
}
