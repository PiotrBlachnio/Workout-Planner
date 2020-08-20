using AutoMapper;
using NotesAPI.Contracts.Requests;
using NotesAPI.Contracts.Responses;
using NotesAPI.Database.Models;

namespace NotesAPI.Profiles {
    public class CategoriesProfile : Profile {
        public CategoriesProfile() {
            CreateMap<Category, CategoryResponse>();

            CreateMap<CreateCategoryRequest, Category>();

            CreateMap<UpdateCategoryRequest, Category>();

            CreateMap<Category, UpdateCategoryRequest>();
        }
    }
}