using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Database;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Services {
    public class CategoryService : ICategoryService {
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context) {
            _context = context;
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