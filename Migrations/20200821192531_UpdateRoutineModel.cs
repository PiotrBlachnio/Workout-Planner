using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutPlanner.Migrations
{
    public partial class UpdateRoutineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExercisesNumber",
                table: "Routines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExercisesNumber",
                table: "Routines");
        }
    }
}
