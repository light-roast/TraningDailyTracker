using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingDailyTracker.Data;
using TrainingDailyTracker.DTOs;
using TrainingDailyTracker.Entities;

namespace TrainingDailyTracker.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class WeeklyScheduleController : ControllerBase
	{
		private readonly DataContext _context;

		public WeeklyScheduleController(DataContext context)
		{
			_context = context;
		}

		// GET: api/WeeklySchedule
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<WeeklyScheduleDto>>> GetAllWeeklySchedules()
		{
			var schedules = await _context.WeeklySchedule
				.Include(ws => ws.DailySchedules)
				.ToListAsync();

			var result = schedules.Select(ws => MapToDto(ws)).ToList();
			return Ok(result);
		}

		// GET: api/WeeklySchedule/5
		//Not used in front
		[HttpGet("{weekNumber}")]
		public async Task<ActionResult<WeeklyScheduleDto>> GetWeeklySchedule(int weekNumber)
		{
			var schedule = await _context.WeeklySchedule
				.Include(ws => ws.DailySchedules)
				.FirstOrDefaultAsync(ws => ws.WeekNumber == weekNumber);

			if (schedule == null)
			{
				return NotFound();
			}

			return Ok(MapToDto(schedule));
		}

		// POST: api/WeeklySchedule
		[HttpPost]
		public async Task<ActionResult<WeeklyScheduleDto>> CreateWeeklySchedule(CreateWeeklyScheduleDto dto)
		{
			var existingSchedule = await _context.WeeklySchedule
				.FirstOrDefaultAsync(ws => ws.WeekNumber == dto.WeekNumber);

			if (existingSchedule != null)
			{
				return Conflict($"A schedule for week {dto.WeekNumber} already exists.");
			}

			var weeklySchedule = new WeeklySchedule
			{
				WeekNumber = dto.WeekNumber,
				DailySchedules = dto.Schedule.Select(kvp => new DailySchedule
				{
					DayOfWeek = kvp.Key,
					MuscleIds = string.Join(",", kvp.Value)
				}).ToList()
			};

			_context.WeeklySchedule.Add(weeklySchedule);
			await _context.SaveChangesAsync();

			var result = MapToDto(weeklySchedule);
			return CreatedAtAction(nameof(GetWeeklySchedule), new { weekNumber = result.WeekNumber }, result);
		}

		// PUT: api/WeeklySchedule/5
		[HttpPut("{weekNumber}")]
		public async Task<IActionResult> UpdateWeeklySchedule(int weekNumber, UpdateWeeklyScheduleDto dto)
		{
			var schedule = await _context.WeeklySchedule
				.Include(ws => ws.DailySchedules)
				.FirstOrDefaultAsync(ws => ws.WeekNumber == weekNumber);

			if (schedule == null)
			{
				return NotFound();
			}

			schedule.WeekNumber = dto.WeekNumber;

			// Remove old daily schedules
			_context.DailySchedule.RemoveRange(schedule.DailySchedules);

			// Add new daily schedules
			schedule.DailySchedules = dto.Schedule.Select(kvp => new DailySchedule
			{
				WeeklyScheduleId = schedule.Id,
				DayOfWeek = kvp.Key,
				MuscleIds = string.Join(",", kvp.Value)
			}).ToList();

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/WeeklySchedule/5
		[HttpDelete("{weekNumber}")]
		public async Task<IActionResult> DeleteWeeklySchedule(int weekNumber)
		{
			var schedule = await _context.WeeklySchedule
				.Include(ws => ws.DailySchedules)
				.FirstOrDefaultAsync(ws => ws.WeekNumber == weekNumber);

			if (schedule == null)
			{
				return NotFound();
			}

			_context.WeeklySchedule.Remove(schedule);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// Helper method to map entity to DTO
		private WeeklyScheduleDto MapToDto(WeeklySchedule schedule)
		{
			var dto = new WeeklyScheduleDto
			{
				Id = schedule.Id,
				WeekNumber = schedule.WeekNumber,
				Schedule = new Dictionary<string, List<int>>()
			};

			foreach (var daily in schedule.DailySchedules)
			{
				var muscleIds = daily.MuscleIds
					.Split(',', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToList();

				dto.Schedule[daily.DayOfWeek] = muscleIds;
			}

			return dto;
		}
	}
}
