using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Models.Models;
using HotelManagement.Data.Repositories;

namespace HotelManagement.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepo )
        {
            _customerRepository = customerRepo;
        }

        public Customer AddCustomer(Customer customer)
        {
            return _customerRepository.Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        /// <summary>
        /// Gets all the customers
        /// </summary>
        /// <param name="customer"></param>
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.Get();
        }

        public Customer GetCustomerById(int? id)
        {
            return _customerRepository.Get(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Put(customer);
        }
    }
}
