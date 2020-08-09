using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Database;
using BMES.Models.Products;

namespace BMES.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private BmesDbContext _context;

        public CategoryRepository(BmesDbContext context)
        {
            _context = context;
        }

        public Category FindCategoryById(long id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categorys = _context.Categories;
            return categorys;
        }

        public void SaveCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

    }
}
