using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingDailyTracker.Data;
using TrainingDailyTracker.Entities;

namespace TrainingDailyTracker.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeeklyCycleController : ControllerBase
	{
		private readonly DataContext _context;

		public WeeklyCycleController(DataContext context)
		{
			_context = context;
		}

		// GET: api/WeeklyCycle
		[HttpGet]
		public async Task<ActionResult<WeeklyCycle>> GetWeeklyCycle()
		{
			var weeklyCycle = await _context.WeeklyCycle.FindAsync(1);

			if (weeklyCycle == null)
			{
				return NotFound();
			}

			return weeklyCycle;
		}

		// PUT: api/WeeklyCycle/next
		[HttpPut("next")]
		public async Task<IActionResult> NextWeeklyCycle()
		{
			var weeklyCycle = await _context.WeeklyCycle.FindAsync(1);
			var number = weeklyCycle.WeekNumber + 1;
			if(number < 5)
			{
				weeklyCycle.WeekNumber = number;
			}
			else
			{
				weeklyCycle.WeekNumber = 1;
			}
				
			_context.Entry(weeklyCycle).State = EntityState.Modified;

			return NoContent();
		}

		[HttpPut("back")]
		public async Task<IActionResult> PreviousWeeklyCycle()
		{
			var weeklyCycle = await _context.WeeklyCycle.FindAsync(1);
			var number = weeklyCycle.WeekNumber - 1;
			if (number > 1)
			{
				weeklyCycle.WeekNumber = number;
			}
			else
			{
				weeklyCycle.WeekNumber = 5;
			}

			_context.Entry(weeklyCycle).State = EntityState.Modified;

			return NoContent();
		}

	}
}
