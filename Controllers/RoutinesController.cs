using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Services;
using WorkoutPlanner.Contracts;
using AutoMapper;
using System.Collections.Generic;
using WorkoutPlanner.Contracts.Responses;
using WorkoutPlanner.Contracts.Requests;
using System;
using System.Threading.Tasks;
using WorkoutPlanner.Database.Models;
using Microsoft.AspNetCore.JsonPatch;
using WorkoutPlanner.Utils;
using WorkoutPlanner.Database.Validators;
using WorkoutPlanner.Errors.Routine;

namespace WorkoutPlanner.Controllers {

    [ApiController]
    public class RoutinesController : ControllerBase {
        private readonly IRoutineService _routineService;
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;
        private readonly RoutineValidator _routineValidator = new RoutineValidator();

        public RoutinesController(IRoutineService routineService, IExerciseService exerciseService, IMapper mapper) {
            _routineService = routineService;
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Routine.Get)]
        public async Task<ActionResult> GetRoutine([FromRoute] Guid id) {
            var routine = await _routineService.GetRoutineAsync(id);

            if(routine == null) throw new RoutineNotFoundError();

            var output = _mapper.Map<RoutineResponse>(routine);

            return Ok(output);
        }

        [HttpGet(ApiRoutes.Routine.GetAll)]
        public async Task<ActionResult> GetAllRoutines() {
            var routines = await _routineService.GetAllRoutinesAsync();
            var output = _mapper.Map<List<RoutineResponse>>(routines);

            return Ok(output);
        }

        [HttpPost(ApiRoutes.Routine.Create)]
        public async Task<ActionResult> CreateRoutine([FromBody] CreateRoutineRequest input) {
            var routine = _mapper.Map<Routine>(input);
            routine.CreatedAt = DateUtils.GetCurrentDate();

            _routineValidator.Validate(routine);
            await _routineService.CreateRoutineAsync(routine);

            var output = _mapper.Map<RoutineResponse>(routine);
            var locationUrl = ApiRoutes.GenerateBaseUrl(HttpContext) + "/" + ApiRoutes.Routine.Get.Replace("{id}", routine.Id.ToString());

            return Created(locationUrl, output);
        }

        [HttpDelete(ApiRoutes.Routine.Delete)]
        public async Task<ActionResult> DeleteRoutine([FromRoute] Guid id) {
            var routine = await _routineService.GetRoutineAsync(id);

            if(routine == null) throw new RoutineNotFoundError();

            var exercises = await _exerciseService.GetAllExercisesAsync(id);

            foreach(Exercise exercise in exercises) {
                await _exerciseService.DeleteExerciseAsync(exercise);
            }

            await _routineService.DeleteRoutineAsync(routine);

            return NoContent();
        }

        [HttpPatch(ApiRoutes.Routine.Update)]
        public async Task<ActionResult> UpdateRoutine([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateRoutineRequest> input) {
            var routine = await _routineService.GetRoutineAsync(id);

            if(routine == null) throw new RoutineNotFoundError();

            var routineToPatch = _mapper.Map<UpdateRoutineRequest>(routine);

            input.ApplyTo(routineToPatch, ModelState);
            _mapper.Map(routineToPatch, routine);
            
           _routineValidator.Validate(routine);
            await _routineService.UpdateRoutineAsync(routine);
            
            return Ok();
        }
    }
}