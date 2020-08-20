using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public interface ICategoryService {
        Task<Category> GetCategoryAsync(Guid id);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> CreateCategoryAsync(string Name);

        Task<bool> DeleteCategoryAsync(Guid id);

        Task<bool> UpdateCategoryAsync(Guid id);
    }
}