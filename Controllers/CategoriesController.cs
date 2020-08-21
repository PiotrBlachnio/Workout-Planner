using Microsoft.AspNetCore.Mvc;
using NotesAPI.Services;
using NotesAPI.Contracts;
using AutoMapper;
using System.Collections.Generic;
using NotesAPI.Contracts.Responses;
using NotesAPI.Contracts.Requests;
using System;
using System.Threading.Tasks;
using NotesAPI.Database.Models;
using Microsoft.AspNetCore.JsonPatch;
using NotesAPI.Utils;

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
        public async Task<ActionResult> GetCategory([FromRoute] Guid id) {
            var category = await _categoryService.GetCategoryAsync(id);

            if(category == null) return NotFound();

            var output = _mapper.Map<CategoryResponse>(category);

            return Ok(output);
        }

        [HttpGet(ApiRoutes.Category.GetAll)]
        public async Task<ActionResult> GetAllCategories() {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var output = _mapper.Map<List<CategoryResponse>>(categories);

            return Ok(output);
        }

        [HttpPost(ApiRoutes.Category.Create)]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequest input) {
            var category = _mapper.Map<Category>(input);
            category.CreatedAt = DateUtils.GetCurrentDate();

            await _categoryService.CreateCategoryAsync(category);

            var output = _mapper.Map<CategoryResponse>(category);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Category.Get.Replace("{id}", category.Id.ToString());

            return Created(locationUrl, output);
        }

        [HttpDelete(ApiRoutes.Category.Delete)]
        public async Task<ActionResult> DeleteCategory([FromRoute] Guid id) {
            var category = await _categoryService.GetCategoryAsync(id);

            if(category == null) return NotFound();

            await _categoryService.DeleteCategoryAsync(category);

            return NoContent();
        }

        [HttpPatch(ApiRoutes.Category.Update)]
        public async Task<ActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateCategoryRequest> input) {
            var category = await _categoryService.GetCategoryAsync(id);

            if(category == null) return NotFound();

            var categoryToPatch = _mapper.Map<UpdateCategoryRequest>(category);

            input.ApplyTo(categoryToPatch, ModelState);
            _mapper.Map(categoryToPatch, category);
            
            await _categoryService.UpdateCategoryAsync(category);
            
            return Ok();
        }
    }
}