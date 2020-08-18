using System.Collections.Generic;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public interface ICategoryService {
        Category GetCategory(int id);

        List<Category> GetAllCategories();

        Category CreateCategory(string Name);

        bool DeleteCategory(int id);

        bool UpdateCategory(int id);
    }
}