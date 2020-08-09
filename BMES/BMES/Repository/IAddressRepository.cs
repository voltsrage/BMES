using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Address;

namespace BMES.Repository
{
    public interface IAddressRepository
    {
        AddressModel FindAddressById(long id);
        IEnumerable<AddressModel> GetAllAddresses();
        void SaveAddress(AddressModel address);
        void UpdateAddress(AddressModel address);
        void DeleteAddress(AddressModel address);
    }
}
