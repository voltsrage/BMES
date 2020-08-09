using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Customer;

namespace BMES.Repository
{
    public interface ICustomerRepository
    {
        Customer FindCustomerById(long id);
        IEnumerable<Customer> GetAllCustomers();
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
