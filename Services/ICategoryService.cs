using System;
using System.Collections.Generic;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public interface ICategoryService {
        Category GetCategory(Guid id);

        List<Category> GetAllCategories();

        Category CreateCategory(string Name);

        bool DeleteCategory(Guid id);

        bool UpdateCategory(Guid id);
    }
}