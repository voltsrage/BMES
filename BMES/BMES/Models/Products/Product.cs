using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;

namespace BMES.Models.Products
{
    public class Product:BaseObject
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Meta_description { get; set; }
        public string Meta_keywords { get; set; }
        public string Sku { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal Sale_price { get; set; }
        public decimal Old_price { get; set; }
        public string Image_url { get; set; }
        public bool Is_bestseller { get; set; }
        public bool Is_featured { get; set; }
        public int QuantityInStock { get; set; }
        public ProductStatus ProductStatus { get; set; }

        public long CategoryId { get; set; }
        public long BrandId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }

    }
}
