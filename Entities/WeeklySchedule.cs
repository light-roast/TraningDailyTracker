using System.ComponentModel.DataAnnotations;

namespace TrainingDailyTracker.Entities
{
	public class WeeklySchedule
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int WeekNumber { get; set; }

		public ICollection<DailySchedule> DailySchedules { get; set; } = new List<DailySchedule>();
	}
}
