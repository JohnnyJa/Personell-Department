using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ManyToManyFixed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Projects_ProjectsId",
                table: "ProjectWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Workers_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker");

            migrationBuilder.RenameTable(
                name: "ProjectWorker",
                newName: "ProjectWorkers");

            migrationBuilder.RenameColumn(
                name: "WorkersId",
                table: "ProjectWorkers",
                newName: "WorkerId");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectWorkers",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorkers",
                newName: "IX_ProjectWorkers_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorkers",
                table: "ProjectWorkers",
                columns: new[] { "ProjectId", "WorkerId" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Projects",
                table: "ProjectWorkers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Workers",
                table: "ProjectWorkers",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Projects",
                table: "ProjectWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Workers",
                table: "ProjectWorkers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorkers",
                table: "ProjectWorkers");

            migrationBuilder.RenameTable(
                name: "ProjectWorkers",
                newName: "ProjectWorker");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "ProjectWorker",
                newName: "WorkersId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectWorker",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectWorkers_WorkerId",
                table: "ProjectWorker",
                newName: "IX_ProjectWorker_WorkersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker",
                columns: new[] { "ProjectsId", "WorkersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Projects_ProjectsId",
                table: "ProjectWorker",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Workers_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
