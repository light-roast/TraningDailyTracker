using Microsoft.EntityFrameworkCore;
using TrainingDailyTracker.Entities;

namespace TrainingDailyTracker.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Exercise> Exercise { get; set; } = null!;
		public DbSet<WeeklyCycle> WeeklyCycle { get; set; } = null!;
		public DbSet<User> User { get; set; } = null!;
		public DbSet<WeeklySchedule> WeeklySchedule { get; set; } = null!;
		public DbSet<DailySchedule> DailySchedule { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Exercise>().HasData(
				new Exercise { Id = 1, Name = "Press Banca", MuscleId = Muscle.Pecho, MaxReps = 10, Weight = 80},
				new Exercise { Id = 2, Name = "Sentadilla", MuscleId = Muscle.Pierna, MaxReps = 11, Weight = 80 },
				new Exercise { Id = 3, Name = "Press Militar", MuscleId = Muscle.Hombro, MaxReps = 12, Weight = 30 },
				new Exercise { Id = 4, Name = "21", MuscleId = Muscle.Biceps, MaxReps = 21, Weight = 30 },
				new Exercise { Id = 5, Name = "Dominadas", MuscleId = Muscle.Espalda, MaxReps = 10, Weight = 20 },
				new Exercise { Id = 6, Name = "Fondos", MuscleId = Muscle.Triceps, MaxReps = 8, Weight = 20 },
				new Exercise { Id = 7, Name = "Crunch polea", MuscleId = Muscle.Abs, MaxReps = 10, Weight = 90 },
				new Exercise { Id = 8, Name = "Encogimientos", MuscleId = Muscle.Traps, MaxReps = 10, Weight = 50 }
			);

			modelBuilder.Entity<WeeklyCycle>().HasData(
				new WeeklyCycle { Id = 1, WeekNumber = 1 }
			);

			modelBuilder.Entity<User>().HasData(
				new User { Id = 1, Username = "admin(this would be diff in production)", Password = "1234 (this would be diff in production", Name="me"}
			);

			modelBuilder.Entity<WeeklySchedule>().HasData(
				new WeeklySchedule { Id = 1, WeekNumber = 1 },
				new WeeklySchedule { Id = 2, WeekNumber = 2 },
				new WeeklySchedule { Id = 3, WeekNumber = 3 },
				new WeeklySchedule { Id = 4, WeekNumber = 4 },
				new WeeklySchedule { Id = 5, WeekNumber = 5 },
				new WeeklySchedule { Id = 6, WeekNumber = 6 },
				new WeeklySchedule { Id = 7, WeekNumber = 7 },
				new WeeklySchedule { Id = 8, WeekNumber = 8 },
				new WeeklySchedule { Id = 9, WeekNumber = 9 },
				new WeeklySchedule { Id = 10, WeekNumber = 10 }
			);

			var dailyScheduleId = 1;
			var scheduleData = new Dictionary<int, Dictionary<string, string>>
			{
				{ 1, new Dictionary<string, string> { { "Lunes", "1" }, { "Martes", "2" }, { "Miércoles", "5" }, { "Jueves", "3,4" }, { "Viernes", "6" }, { "Sábado", "2" }, { "Domingo", "7" } } },
				{ 2, new Dictionary<string, string> { { "Lunes", "6" }, { "Martes", "2" }, { "Miércoles", "1" }, { "Jueves", "5,3" }, { "Viernes", "4" }, { "Sábado", "2" }, { "Domingo", "8" } } },
				{ 3, new Dictionary<string, string> { { "Lunes", "4" }, { "Martes", "2" }, { "Miércoles", "6" }, { "Jueves", "1,5" }, { "Viernes", "3" }, { "Sábado", "2" }, { "Domingo", "7" } } },
				{ 4, new Dictionary<string, string> { { "Lunes", "3" }, { "Martes", "2" }, { "Miércoles", "4" }, { "Jueves", "6,1" }, { "Viernes", "5" }, { "Sábado", "2" }, { "Domingo", "8" } } },
				{ 5, new Dictionary<string, string> { { "Lunes", "5" }, { "Martes", "2" }, { "Miércoles", "3" }, { "Jueves", "4,6" }, { "Viernes", "1" }, { "Sábado", "2" }, { "Domingo", "7" } } },
				{ 6, new Dictionary<string, string> { { "Lunes", "1" }, { "Martes", "2" }, { "Miércoles", "5" }, { "Jueves", "3,4" }, { "Viernes", "6" }, { "Sábado", "2" }, { "Domingo", "8" } } },
				{ 7, new Dictionary<string, string> { { "Lunes", "6" }, { "Martes", "2" }, { "Miércoles", "1" }, { "Jueves", "5,3" }, { "Viernes", "4" }, { "Sábado", "2" }, { "Domingo", "7" } } },
				{ 8, new Dictionary<string, string> { { "Lunes", "4" }, { "Martes", "2" }, { "Miércoles", "6" }, { "Jueves", "1,5" }, { "Viernes", "3" }, { "Sábado", "2" }, { "Domingo", "8" } } },
				{ 9, new Dictionary<string, string> { { "Lunes", "3" }, { "Martes", "2" }, { "Miércoles", "4" }, { "Jueves", "6,1" }, { "Viernes", "5" }, { "Sábado", "2" }, { "Domingo", "7" } } },
				{ 10, new Dictionary<string, string> { { "Lunes", "5" }, { "Martes", "2" }, { "Miércoles", "3" }, { "Jueves", "4,6" }, { "Viernes", "1" }, { "Sábado", "2" }, { "Domingo", "8" } } }
			};

			foreach (var week in scheduleData)
			{
				foreach (var day in week.Value)
				{
					modelBuilder.Entity<DailySchedule>().HasData(
						new DailySchedule
						{
							Id = dailyScheduleId++,
							WeeklyScheduleId = week.Key,
							DayOfWeek = day.Key,
							MuscleIds = day.Value
						}
					);
				}
			}
		}
	}
}
