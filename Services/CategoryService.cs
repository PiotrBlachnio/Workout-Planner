using System.Collections.Generic;
using System.Linq;
using NotesAPI.Database.Models;

namespace NotesAPI.Services {
    public class CategoryService : ICategoryService {
        private List<Category> categories;

        public CategoryService() {
            categories = new List<Category> {
                new Category{Id=0, Name="Programming", CreatedAt=Utils.GetCurrentDate() + 5000},
                new Category{Id=1, Name="School", CreatedAt=Utils.GetCurrentDate() + 60605},
                new Category{Id=2, Name="Personal Documents", CreatedAt=Utils.GetCurrentDate()}
            };
        }

        public Category GetCategory(int id) {
            return categories.SingleOrDefault(x => x.Id == id);
        }

        public List<Category> GetAllCategories() {
            return categories;
        }

        public Category CreateCategory(string Name) {
            var category = new Category{Id=3, Name=Name, CreatedAt=Utils.GetCurrentDate()};
            return category;
        }

        public bool DeleteCategory(int id) {
            var category = categories.Find(x => x.Id == id);

            if(category == null) return false;
            return true;
        }
    }
}