using System.Collections.Generic;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public interface ICategoryService {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
    }
}