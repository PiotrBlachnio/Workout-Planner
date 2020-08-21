using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Database;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Services {
    public class ExerciseService : IExerciseService {
        private readonly DatabaseContext _context;

        public ExerciseService(DatabaseContext context) {
            _context = context;
        }
        
        public async Task<Exercise> GetExerciseAsync(Guid id) {
            return await _context.Exercises.FirstOrDefaultAsync(exercise => exercise.Id == id);
        }

        public async Task<List<Exercise>> GetAllExercisesAsync(Guid routineId) {
            return await _context.Exercises.Where(exercise => exercise.RoutineId == routineId).ToListAsync();
        }

        public async Task<bool> CreateExerciseAsync(Exercise exercise) {
            await _context.Exercises.AddAsync(exercise);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteExerciseAsync(Exercise exercise) {
            _context.Exercises.Remove(exercise);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UpdateExerciseAsync(Exercise exercise) {
            _context.Exercises.Update(exercise);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
    }
}