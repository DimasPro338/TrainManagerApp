using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainManagerApp.Migrations
{
    public partial class TrainDateOfArrival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Trains",
                newName: "DateOfDeparture");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfArrival",
                table: "Trains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfArrival",
                table: "Trains");

            migrationBuilder.RenameColumn(
                name: "DateOfDeparture",
                table: "Trains",
                newName: "Date");
        }
    }
}
