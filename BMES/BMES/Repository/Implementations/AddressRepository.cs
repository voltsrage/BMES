using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Database;
using BMES.Models.Address;


namespace BMES.Repository.Implementations
{
    public class AddressRepository:IAddressRepository
    {
        private BmesDbContext _context;

        public AddressRepository(BmesDbContext context)
        {
            _context = context;
        }

        public AddressModel FindAddressById(long id)
        {
            var address = _context.Addresses.Find(id);
            return address;
        }

        public IEnumerable<AddressModel> GetAllAddresses()
        {
            var addresss = _context.Addresses;
            return addresss;
        }

        public void SaveAddress(AddressModel address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(AddressModel address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void DeleteAddress(AddressModel address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

    }
}

