using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class _102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Divisions_AttachedToDivisionId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "AttachedToDivisionId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Divisions_AttachedToDivisionId",
                table: "Workers",
                column: "AttachedToDivisionId",
                principalTable: "Divisions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Divisions_AttachedToDivisionId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "AttachedToDivisionId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Divisions_AttachedToDivisionId",
                table: "Workers",
                column: "AttachedToDivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
