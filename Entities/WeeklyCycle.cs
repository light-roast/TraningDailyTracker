using System.ComponentModel.DataAnnotations;

namespace TrainingDailyTracker.Entities
{
	public class WeeklyCycle
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int WeekNumber { get; set; }
	}
}
