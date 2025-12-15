using Microsoft.EntityFrameworkCore;
using TrainingDailyTracker.Entities;

namespace TrainingDailyTracker.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Exercise> Exercise { get; set; } = null!;
		public DbSet<WeeklyCycle> WeeklyCycle { get; set; } = null!;
		public DbSet<User> User { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlite("Data Source=Database.db");
		}

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
		}
	}
}
