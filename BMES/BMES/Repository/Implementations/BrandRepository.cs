using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Database;
using BMES.Models.Products;

namespace BMES.Repository.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private BmesDbContext _context;

        public BrandRepository(BmesDbContext context)
        {
            _context = context;
        }

        public Brand FindBrandById(long id)
        {
            var brand = _context.Brands.Find(id);
            return brand;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            var brands = _context.Brands;
            return brands;
        }

        public void SaveBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

    }
}
