using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriEchipamenteAlpine.Migrations
{
    public partial class Producatori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producator",
                table: "EchipamentAlpin");

            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "EchipamentAlpin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaraOrigine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipamentAlpin_ProducatorID",
                table: "EchipamentAlpin",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_EchipamentAlpin_Producator_ProducatorID",
                table: "EchipamentAlpin",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchipamentAlpin_Producator_ProducatorID",
                table: "EchipamentAlpin");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_EchipamentAlpin_ProducatorID",
                table: "EchipamentAlpin");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "EchipamentAlpin");

            migrationBuilder.AddColumn<string>(
                name: "Producator",
                table: "EchipamentAlpin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
