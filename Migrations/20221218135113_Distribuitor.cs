using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriEchipamenteAlpine.Migrations
{
    public partial class Distribuitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistribuitorID",
                table: "EchipamentAlpin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distribuitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDistribuitor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuitor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipamentAlpin_DistribuitorID",
                table: "EchipamentAlpin",
                column: "DistribuitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_EchipamentAlpin_Distribuitor_DistribuitorID",
                table: "EchipamentAlpin",
                column: "DistribuitorID",
                principalTable: "Distribuitor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchipamentAlpin_Distribuitor_DistribuitorID",
                table: "EchipamentAlpin");

            migrationBuilder.DropTable(
                name: "Distribuitor");

            migrationBuilder.DropIndex(
                name: "IX_EchipamentAlpin_DistribuitorID",
                table: "EchipamentAlpin");

            migrationBuilder.DropColumn(
                name: "DistribuitorID",
                table: "EchipamentAlpin");
        }
    }
}
