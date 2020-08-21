using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Contracts;
using WorkoutPlanner.Contracts.Requests;
using WorkoutPlanner.Contracts.Responses;
using WorkoutPlanner.Database.Models;
using WorkoutPlanner.Services;
using WorkoutPlanner.Utils;

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

        [HttpPost(ApiRoutes.Exercise.Create)]
        public async Task<ActionResult> CreateExercise([FromBody] CreateExerciseRequest input) {
            var exercise = _mapper.Map<Exercise>(input);
            exercise.CreatedAt = DateUtils.GetCurrentDate();

            var routine = await _routineService.GetRoutineAsync(exercise.RoutineId);

            if(routine == null) return NotFound();

            routine.ExercisesNumber++;
            await _routineService.UpdateRoutineAsync(routine);

            await _exerciseService.CreateExerciseAsync(exercise);
            var output = _mapper.Map<ExerciseResponse>(exercise);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Exercise.Get.Replace("{id}", exercise.Id.ToString());

            return Created(locationUrl, output);
        }

        [HttpDelete(ApiRoutes.Exercise.Delete)]
        public async Task<ActionResult> DeleteExercise([FromRoute] Guid id) {
            var exercise = await _exerciseService.GetExerciseAsync(id);
            if(exercise == null) return NotFound();

            var routine = await _routineService.GetRoutineAsync(exercise.RoutineId);
            routine.ExercisesNumber--;

            if(routine == null) return NotFound();

            await _routineService.UpdateRoutineAsync(routine);
            await _exerciseService.DeleteExerciseAsync(exercise);
        
            return NoContent();
        }

        [HttpPatch(ApiRoutes.Exercise.Update)]
        public async Task<ActionResult> UpdateExercise([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateExerciseRequest> input) {
            var exercise = await _exerciseService.GetExerciseAsync(id);
            if(exercise == null) return NotFound();

            var exerciseToPatch = _mapper.Map<UpdateExerciseRequest>(exercise);

            input.ApplyTo(exerciseToPatch, ModelState);
            _mapper.Map(exerciseToPatch, exercise);
        
            await _exerciseService.UpdateExerciseAsync(exercise);

            return Ok();
        }
    }
}