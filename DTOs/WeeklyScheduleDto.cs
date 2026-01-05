namespace TrainingDailyTracker.DTOs
{
	public class WeeklyScheduleDto
	{
		public int Id { get; set; }
		public int WeekNumber { get; set; }
		public Dictionary<string, List<int>> Schedule { get; set; } = new Dictionary<string, List<int>>();
	}

	public class CreateWeeklyScheduleDto
	{
		public int WeekNumber { get; set; }
		public Dictionary<string, List<int>> Schedule { get; set; } = new Dictionary<string, List<int>>();
	}

	public class UpdateWeeklyScheduleDto
	{
		public int WeekNumber { get; set; }
		public Dictionary<string, List<int>> Schedule { get; set; } = new Dictionary<string, List<int>>();
	}
}
