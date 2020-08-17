using System.Collections.Generic;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public class CategoryService : ICategoryService {
        public List<Category> GetAllCategories()
        {
            var categories = new List<Category> {
                new Category{Id=0, Name="Programming", CreatedAt=Utils.GetCurrentDate() + 5000},
                new Category{Id=1, Name="School", CreatedAt=Utils.GetCurrentDate() + 60605},
                new Category{Id=2, Name="Personal Documents", CreatedAt=Utils.GetCurrentDate()}
            };

            return categories;
        }

        public Category GetCategory(int id)
        {
            return new Category{Id=0, Name="Personal Documents", CreatedAt=Utils.GetCurrentDate()};
        }
    }
}