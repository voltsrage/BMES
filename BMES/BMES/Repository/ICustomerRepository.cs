using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Customer;

namespace BMES.Repository
{
    public interface ICustomerRepository
    {
        CustomerModel FindCustomerById(long id);
        IEnumerable<CustomerModel> GetAllCustomers();
        void SaveCustomer(CustomerModel customer);
        void UpdateCustomer(CustomerModel customer);
        void DeleteCustomer(CustomerModel customer);
    }
}
