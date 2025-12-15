using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingDailyTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MaxReps = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    MuscleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyCycle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeekNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyCycle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "MaxReps", "MuscleId", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 10, 1, "Press Banca", 80 },
                    { 2, 11, 2, "Sentadilla", 80 },
                    { 3, 12, 3, "Press Militar", 30 },
                    { 4, 21, 4, "21", 30 },
                    { 5, 10, 5, "Dominadas", 20 },
                    { 6, 8, 6, "Fondos", 20 },
                    { 7, 10, 7, "Crunch polea", 90 },
                    { 8, 10, 8, "Encogimientos", 50 }
                });

            migrationBuilder.InsertData(
                table: "WeeklyCycle",
                columns: new[] { "Id", "WeekNumber" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "WeeklyCycle");
        }
    }
}
