using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Services {
    public interface IRoutineService {
        Task<Routine> GetRoutineAsync(Guid id);

        Task<List<Routine>> GetAllRoutinesAsync();

        Task<bool> CreateRoutineAsync(Routine routine);

        Task<bool> DeleteRoutineAsync(Routine routine);

        Task<bool> UpdateRoutineAsync(Routine routine);
    }
}