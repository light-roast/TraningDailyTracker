using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingDailyTracker.Data;
using TrainingDailyTracker.Entities;

namespace TrainingDailyTracker.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExerciseController : ControllerBase
	{
		private readonly DataContext _context;

		public ExerciseController(DataContext context)
		{
			_context = context;
		}

		// GET: api/Exercise
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Exercise>>> GetExercise()
		{
			return await _context.Exercise.ToListAsync();
		}

		// GET: api/Exercise/muscle/1
		[HttpGet("muscle/{muscleId}")]
		public async Task<ActionResult<IEnumerable<Exercise>>> GetExercisesByMuscle(int muscleId)
		{
			if (!Enum.IsDefined(typeof(Muscle), muscleId))
			{
				return BadRequest("Invalid muscle ID");
			}

			var muscle = (Muscle)muscleId;
			var exercises = await _context.Exercise
				.Where(e => e.MuscleId == muscle)
				.ToListAsync();

			return exercises;
		}

		// GET: api/Exercise/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Exercise>> GetExercise(int id)
		{
			var exercise = await _context.Exercise.FindAsync(id);

			if (exercise == null)
			{
				return NotFound();
			}

			return exercise;
		}

		// PUT: api/Exercise/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutExercise(int id, Exercise exercise)
		{
			if (id != exercise.Id)
			{
				return BadRequest();
			}

			_context.Entry(exercise).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ExerciseExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Exercise
		[HttpPost]
		public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
		{
			_context.Exercise.Add(exercise);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exercise);
		}

		// DELETE: api/Exercise/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteExercise(int id)
		{
			var exercise = await _context.Exercise.FindAsync(id);
			if (exercise == null)
			{
				return NotFound();
			}

			_context.Exercise.Remove(exercise);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ExerciseExists(int id)
		{
			return _context.Exercise.Any(e => e.Id == id);
		}
	}
}
