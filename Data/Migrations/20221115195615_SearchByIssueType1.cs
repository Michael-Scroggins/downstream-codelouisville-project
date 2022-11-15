using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Downstream.Data.Migrations
{
    public partial class SearchByIssueType1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requiredResolutionTime",
                table: "Ticket",
                newName: "RequiredResolutionTime");

            migrationBuilder.RenameColumn(
                name: "issueType",
                table: "Ticket",
                newName: "IssueType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredResolutionTime",
                table: "Ticket",
                newName: "requiredResolutionTime");

            migrationBuilder.RenameColumn(
                name: "IssueType",
                table: "Ticket",
                newName: "issueType");
        }
    }
}
