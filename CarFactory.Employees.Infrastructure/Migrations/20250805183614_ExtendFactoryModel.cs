using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarFactory.Employees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtendFactoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "FACTORIES",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "FACTORIES");
        }
    }
}
