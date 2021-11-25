using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainManagerApp.Migrations
{
    public partial class UpdatedRelarionTrainCar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
