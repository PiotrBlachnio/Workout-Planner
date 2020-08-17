using System.Collections.Generic;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public interface ICategoryService {
        IEnumerable<Category> GetAllCategories();
        Category GetCategory();
    }
}