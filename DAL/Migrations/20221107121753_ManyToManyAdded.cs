using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Projects_ProjectId",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_WorkerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_ProjectId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Divisions");

            migrationBuilder.CreateTable(
                name: "DivisionProjects",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionProjects", x => new { x.DivisionId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_DivisionProjects_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivisionProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionProjects_ProjectId",
                table: "DivisionProjects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivisionProjects");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Divisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_WorkerId",
                table: "Projects",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ProjectId",
                table: "Divisions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Projects_ProjectId",
                table: "Divisions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id");
        }
    }
}
