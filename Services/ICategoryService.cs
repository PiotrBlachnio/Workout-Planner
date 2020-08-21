using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Services {
    public interface ICategoryService {
        Task<Category> GetCategoryAsync(Guid id);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<bool> CreateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(Category category);

        Task<bool> UpdateCategoryAsync(Category category);
    }
}