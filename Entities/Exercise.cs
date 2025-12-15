using System.ComponentModel.DataAnnotations;

namespace TrainingDailyTracker.Entities
{
	public class Exercise
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Value must be greater than or equal to 0.")]
		public int MaxReps { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Value must be greater than or equal to 0.")]
		public int Weight { get; set; }

		[Required]
		public Muscle MuscleId { get; set; }
	}
}
