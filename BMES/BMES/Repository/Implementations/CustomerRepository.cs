using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Database;
using BMES.Models.Customer;

namespace BMES.Repository.Implementations
{
    public class CustomerRepository:ICustomerRepository
    {
        private BmesDbContext _context;

        public CustomerRepository(BmesDbContext context)
        {
            _context = context;
        }

        public Customer FindCustomerById(long id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers;
            return customers;
        }

        public void SaveCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
