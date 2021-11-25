using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainManagerApp.Migrations
{
    public partial class Cars3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TypeOfIntercity",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameColumn(
                name: "TypeOfUTCar",
                table: "Car",
                newName: "TypeOfCar");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_TrainId",
                table: "Car",
                newName: "IX_Car_TrainId");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Car",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Trains_TrainId",
                table: "Car",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Trains_TrainId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameColumn(
                name: "TypeOfCar",
                table: "Cars",
                newName: "TypeOfUTCar");

            migrationBuilder.RenameIndex(
                name: "IX_Car_TrainId",
                table: "Cars",
                newName: "IX_Cars_TrainId");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfIntercity",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
