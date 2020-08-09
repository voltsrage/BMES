using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;

namespace BMES.Models.Products
{
    public class Brand:BaseObject
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Meta_description { get; set; }
        public string Meta_keywords { get; set; }

        public BrandStatus BrandStatus { get; set; }
    }
}
