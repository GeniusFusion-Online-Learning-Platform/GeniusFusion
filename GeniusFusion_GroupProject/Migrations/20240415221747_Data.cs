using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusFusion_GroupProject.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentCredentials",
                newName: "StudentCredentialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentCredentialsId",
                table: "StudentCredentials",
                newName: "Id");
        }
    }
}
