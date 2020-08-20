using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Database;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public class CategoryService : ICategoryService {
        private List<Category> categories;
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context) {
            _context = context;
        }

        public Category GetCategory(Guid id) {
            return categories.SingleOrDefault(x => x.Id == id);
        }

        public List<Category> GetAllCategories() {
            return categories;
        }

        public Category CreateCategory(string Name) {
            var category = new Category{Id=Guid.NewGuid(), Name=Name, CreatedAt=Utils.GetCurrentDate()};
            return category;
        }

        public bool DeleteCategory(Guid id) {
            var category = categories.Find(x => x.Id == id);

            if(category == null) return false;
            return true;
        }

        public bool UpdateCategory(Guid id) {
            var category = categories.Find(x => x.Id == id);

            if(category == null) return false;
            return true;
        }

        public async Task<Category> GetCategoryAsync(Guid id) {
            return await _context.Categories.FirstOrDefaultAsync(category => category.Id == id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync() {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> CreateCategoryAsync(Category category) {
            await _context.Categories.AddAsync(category);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteCategoryAsync(Category category) {
            _context.Categories.Remove(category);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UpdateCategoryAsync(Category category) {
            _context.Categories.Update(category);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
    }
}