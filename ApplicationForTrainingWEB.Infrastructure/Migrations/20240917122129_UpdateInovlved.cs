using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationForTrainingWEB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInovlved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoledParties",
                table: "Exercises",
                newName: "InvolvedParties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvolvedParties",
                table: "Exercises",
                newName: "InvoledParties");
        }
    }
}
