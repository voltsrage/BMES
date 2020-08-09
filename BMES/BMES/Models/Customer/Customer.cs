using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;
using BMES.Models.Address;
//using BMES.Models.Orders;

namespace BMES.Models.Customer
{
    public class Customer:BaseObject
    {   
        public long PersonId { get; set; }

        public Person Person { get; set; }

        public IEnumerable<AddressModel> Addresses { get; set; }

        //public IEnumerable<Order> Orders { get; set; }
    }
}
