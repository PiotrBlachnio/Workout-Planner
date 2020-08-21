using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Contracts;
using WorkoutPlanner.Contracts.Responses;
using WorkoutPlanner.Services;

namespace WorkoutPlanner.Controllers {
    
    [ApiController]
    public class ExercisesController : ControllerBase {
        private readonly IExerciseService _exerciseService;
        private readonly IRoutineService _routineService;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseService exerciseService, IRoutineService routineService, IMapper mapper) {
            _exerciseService = exerciseService;
            _routineService = routineService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Exercise.Get)]
        public async Task<ActionResult> GetExercise([FromRoute] Guid id) {
            var exercise = await _exerciseService.GetExerciseAsync(id);

            if(exercise == null) return NotFound();

            var output = _mapper.Map<ExerciseResponse>(exercise);

            return Ok(output);
        }

        [HttpGet(ApiRoutes.Exercise.GetAll)]
        public async Task<ActionResult> GetExercises([FromQuery] Guid routineId) {
            var routine = await _routineService.GetRoutineAsync(routineId);

            if(routine == null) return NotFound(new { message = "Routine does not exist" });

            var exercises = await _exerciseService.GetAllExercisesAsync(routineId);
            var output = _mapper.Map<List<ExerciseResponse>>(exercises);

            return Ok(output);
        }
    }
}