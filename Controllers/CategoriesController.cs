using Microsoft.AspNetCore.Mvc;
using NotesAPI.Services;
using NotesAPI.Contracts;
using AutoMapper;
using System.Collections.Generic;
using NotesAPI.Contracts.Responses;
using NotesAPI.Contracts.Requests;

namespace NotesAPI.Controllers {

    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper) {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Category.Get)]
        public ActionResult GetCategory([FromRoute] int id) {
            var category = _categoryService.GetCategory(id);

            var mappedCategory = _mapper.Map<CategoryResponse>(category);

            return Ok(mappedCategory);
        }

        [HttpGet(ApiRoutes.Category.GetAll)]
        public ActionResult GetAllCategories() {
            var categories = _categoryService.GetAllCategories();
            
            var mappedCategories = _mapper.Map<List<CategoryResponse>>(categories);

            return Ok(mappedCategories);
        }

        [HttpPost(ApiRoutes.Category.Create)]
        public ActionResult CreateCategory([FromBody] CreateCategoryRequest input) {
            var category = _categoryService.CreateCategory(input.Name);

            var mappedCategory = _mapper.Map<CategoryResponse>(category);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Category.Get.Replace("{id}", category.Id.ToString());

            return Created(locationUrl, mappedCategory);
        }

        [HttpDelete(ApiRoutes.Category.Delete)]
        public ActionResult DeleteCategory([FromRoute] int id) {
            var isSuccess = _categoryService.DeleteCategory(id);

            if(isSuccess) return Ok();
            else return Unauthorized();
        }
    }
}