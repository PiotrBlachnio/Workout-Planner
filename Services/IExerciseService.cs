using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Services {
    public interface IExerciseService {
        Task<Exercise> GetExerciseAsync(Guid id);

        Task<List<Exercise>> GetAllExercisesAsync(Guid routineId);

        Task<bool> CreateExerciseAsync(Exercise exercise);

        Task<bool> DeleteExerciseAsync(Exercise exercise);

        Task<bool> UpdateExerciseAsync(Exercise exercise);
    }
}