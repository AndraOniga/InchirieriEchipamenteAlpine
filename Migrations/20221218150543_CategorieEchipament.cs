using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriEchipamenteAlpine.Migrations
{
    public partial class CategorieEchipament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieEchipament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipamentAlpinID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieEchipament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieEchipament_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieEchipament_EchipamentAlpin_EchipamentAlpinID",
                        column: x => x.EchipamentAlpinID,
                        principalTable: "EchipamentAlpin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieEchipament_CategorieID",
                table: "CategorieEchipament",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieEchipament_EchipamentAlpinID",
                table: "CategorieEchipament",
                column: "EchipamentAlpinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieEchipament");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
