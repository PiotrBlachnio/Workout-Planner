using AutoMapper;
using WorkoutPlanner.Contracts.Requests;
using WorkoutPlanner.Contracts.Responses;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Profiles {
    public class CategoriesProfile : Profile {
        public CategoriesProfile() {
            CreateMap<Category, CategoryResponse>();

            CreateMap<CreateCategoryRequest, Category>();

            CreateMap<UpdateCategoryRequest, Category>();

            CreateMap<Category, UpdateCategoryRequest>();
        }
    }
}