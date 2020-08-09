﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;

namespace BMES.Models.Address
{
    public class AddressModel:BaseObject
    {
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
