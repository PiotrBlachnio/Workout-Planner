using System;
using System.Collections.Generic;
using System.Linq;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public class CategoryService : ICategoryService {
        private List<Category> categories;

        public CategoryService() {
            categories = new List<Category> {
                new Category{Id=Guid.NewGuid(), Name="Programming", CreatedAt=Utils.GetCurrentDate() + 5000},
                new Category{Id=Guid.NewGuid(), Name="School", CreatedAt=Utils.GetCurrentDate() + 60605},
                new Category{Id=Guid.NewGuid(), Name="Personal Documents", CreatedAt=Utils.GetCurrentDate()}
            };
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
    }
}