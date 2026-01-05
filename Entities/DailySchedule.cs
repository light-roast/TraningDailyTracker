using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingDailyTracker.Entities
{
	public class DailySchedule
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int WeeklyScheduleId { get; set; }

		[ForeignKey("WeeklyScheduleId")]
		public WeeklySchedule WeeklySchedule { get; set; } = null!;

		[Required]
		[MaxLength(20)]
		public string DayOfWeek { get; set; } = string.Empty;

		[Required]
		public string MuscleIds { get; set; } = string.Empty; // Stored as comma-separated values: "1,2,3"
	}
}
