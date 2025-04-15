using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarFactory.Employees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableNamesToPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRequestCandidate_EmployeeRequests_EmployeeRequestId",
                table: "EmployeeRequestCandidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRequestCandidate",
                table: "EmployeeRequestCandidate");

            migrationBuilder.RenameTable(
                name: "EmployeeRequestCandidate",
                newName: "EmployeeRequestCandidates");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRequestCandidate_EmployeeRequestId",
                table: "EmployeeRequestCandidates",
                newName: "IX_EmployeeRequestCandidates_EmployeeRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRequestCandidates",
                table: "EmployeeRequestCandidates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRequestCandidates_EmployeeRequests_EmployeeRequestId",
                table: "EmployeeRequestCandidates",
                column: "EmployeeRequestId",
                principalTable: "EmployeeRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRequestCandidates_EmployeeRequests_EmployeeRequestId",
                table: "EmployeeRequestCandidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRequestCandidates",
                table: "EmployeeRequestCandidates");

            migrationBuilder.RenameTable(
                name: "EmployeeRequestCandidates",
                newName: "EmployeeRequestCandidate");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRequestCandidates_EmployeeRequestId",
                table: "EmployeeRequestCandidate",
                newName: "IX_EmployeeRequestCandidate_EmployeeRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRequestCandidate",
                table: "EmployeeRequestCandidate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRequestCandidate_EmployeeRequests_EmployeeRequestId",
                table: "EmployeeRequestCandidate",
                column: "EmployeeRequestId",
                principalTable: "EmployeeRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
