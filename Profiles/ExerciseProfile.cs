using AutoMapper;
using WorkoutPlanner.Contracts.Requests;
using WorkoutPlanner.Contracts.Responses;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Profiles {
    public class ExerciseProfile : Profile {
        public ExerciseProfile() {
            CreateMap<Exercise, ExerciseResponse>();

            CreateMap<CreateExerciseRequest, Exercise>();

            CreateMap<UpdateExerciseRequest, Exercise>();

            CreateMap<Exercise, UpdateExerciseRequest>();
        }
    }
}