using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingDailyTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddWeeklyScheduleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeekNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeeklyScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayOfWeek = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MuscleIds = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySchedule_WeeklySchedule_WeeklyScheduleId",
                        column: x => x.WeeklyScheduleId,
                        principalTable: "WeeklySchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WeeklySchedule",
                columns: new[] { "Id", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "DailySchedule",
                columns: new[] { "Id", "DayOfWeek", "MuscleIds", "WeeklyScheduleId" },
                values: new object[,]
                {
                    { 1, "Lunes", "1", 1 },
                    { 2, "Martes", "2", 1 },
                    { 3, "Miércoles", "5", 1 },
                    { 4, "Jueves", "3,4", 1 },
                    { 5, "Viernes", "6", 1 },
                    { 6, "Sábado", "2", 1 },
                    { 7, "Domingo", "7", 1 },
                    { 8, "Lunes", "6", 2 },
                    { 9, "Martes", "2", 2 },
                    { 10, "Miércoles", "1", 2 },
                    { 11, "Jueves", "5,3", 2 },
                    { 12, "Viernes", "4", 2 },
                    { 13, "Sábado", "2", 2 },
                    { 14, "Domingo", "8", 2 },
                    { 15, "Lunes", "4", 3 },
                    { 16, "Martes", "2", 3 },
                    { 17, "Miércoles", "6", 3 },
                    { 18, "Jueves", "1,5", 3 },
                    { 19, "Viernes", "3", 3 },
                    { 20, "Sábado", "2", 3 },
                    { 21, "Domingo", "7", 3 },
                    { 22, "Lunes", "3", 4 },
                    { 23, "Martes", "2", 4 },
                    { 24, "Miércoles", "4", 4 },
                    { 25, "Jueves", "6,1", 4 },
                    { 26, "Viernes", "5", 4 },
                    { 27, "Sábado", "2", 4 },
                    { 28, "Domingo", "8", 4 },
                    { 29, "Lunes", "5", 5 },
                    { 30, "Martes", "2", 5 },
                    { 31, "Miércoles", "3", 5 },
                    { 32, "Jueves", "4,6", 5 },
                    { 33, "Viernes", "1", 5 },
                    { 34, "Sábado", "2", 5 },
                    { 35, "Domingo", "7", 5 },
                    { 36, "Lunes", "1", 6 },
                    { 37, "Martes", "2", 6 },
                    { 38, "Miércoles", "5", 6 },
                    { 39, "Jueves", "3,4", 6 },
                    { 40, "Viernes", "6", 6 },
                    { 41, "Sábado", "2", 6 },
                    { 42, "Domingo", "8", 6 },
                    { 43, "Lunes", "6", 7 },
                    { 44, "Martes", "2", 7 },
                    { 45, "Miércoles", "1", 7 },
                    { 46, "Jueves", "5,3", 7 },
                    { 47, "Viernes", "4", 7 },
                    { 48, "Sábado", "2", 7 },
                    { 49, "Domingo", "7", 7 },
                    { 50, "Lunes", "4", 8 },
                    { 51, "Martes", "2", 8 },
                    { 52, "Miércoles", "6", 8 },
                    { 53, "Jueves", "1,5", 8 },
                    { 54, "Viernes", "3", 8 },
                    { 55, "Sábado", "2", 8 },
                    { 56, "Domingo", "8", 8 },
                    { 57, "Lunes", "3", 9 },
                    { 58, "Martes", "2", 9 },
                    { 59, "Miércoles", "4", 9 },
                    { 60, "Jueves", "6,1", 9 },
                    { 61, "Viernes", "5", 9 },
                    { 62, "Sábado", "2", 9 },
                    { 63, "Domingo", "7", 9 },
                    { 64, "Lunes", "5", 10 },
                    { 65, "Martes", "2", 10 },
                    { 66, "Miércoles", "3", 10 },
                    { 67, "Jueves", "4,6", 10 },
                    { 68, "Viernes", "1", 10 },
                    { 69, "Sábado", "2", 10 },
                    { 70, "Domingo", "8", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedule_WeeklyScheduleId",
                table: "DailySchedule",
                column: "WeeklyScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySchedule");

            migrationBuilder.DropTable(
                name: "WeeklySchedule");
        }
    }
}
