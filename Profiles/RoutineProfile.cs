using AutoMapper;
using WorkoutPlanner.Contracts.Requests;
using WorkoutPlanner.Contracts.Responses;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Profiles {
    public class CategoriesProfile : Profile {
        public CategoriesProfile() {
            CreateMap<Routine, RoutineResponse>();

            CreateMap<CreateRoutineRequest, Routine>();

            CreateMap<UpdateRoutineRequest, Routine>();

            CreateMap<Routine, UpdateRoutineRequest>();
        }
    }
}