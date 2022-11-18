using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Downstream.Data.Migrations
{
    public partial class AddedResolvedpropertytoticketmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Ticket",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Ticket");
        }
    }
}
