using Microsoft.AspNetCore.Mvc;
using NotesAPI.Services;
using NotesAPI.Contracts;

namespace NotesAPI.Controllers {

    [Produces("application/json")]
    public class CategoriesController : ControllerBase {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet(ApiRoutes.Category.GetAll)]
        public ActionResult GetAllCategories() {
            var categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }
    }
}