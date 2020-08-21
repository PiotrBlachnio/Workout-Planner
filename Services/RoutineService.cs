using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Database;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Services {
    public class RoutineService : IRoutineService {
        private readonly DatabaseContext _context;

        public RoutineService(DatabaseContext context) {
            _context = context;
        }

        public async Task<Routine> GetRoutineAsync(Guid id) {
            return await _context.Routines.FirstOrDefaultAsync(routine => routine.Id == id);
        }

        public async Task<List<Routine>> GetAllRoutinesAsync() {
            return await _context.Routines.ToListAsync();
        }

        public async Task<bool> CreateRoutineAsync(Routine routine) {
            await _context.Routines.AddAsync(routine);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteRoutineAsync(Routine routine) {
            _context.Routines.Remove(routine);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UpdateRoutineAsync(Routine routine) {
            _context.Routines.Update(routine);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
    }
}