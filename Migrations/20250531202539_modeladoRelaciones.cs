using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fachaMotos.Migrations
{
    /// <inheritdoc />
    public partial class modeladoRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListasDeFavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListasDeFavoritos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotosFavoritas",
                columns: table => new
                {
                    ListaDeFavoritosId = table.Column<int>(type: "integer", nullable: false),
                    MotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotosFavoritas", x => new { x.ListaDeFavoritosId, x.MotoId });
                    table.ForeignKey(
                        name: "FK_MotosFavoritas_Bikes_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotosFavoritas_ListasDeFavoritos_ListaDeFavoritosId",
                        column: x => x.ListaDeFavoritosId,
                        principalTable: "ListasDeFavoritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasDeFavoritos_UserId",
                table: "ListasDeFavoritos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MotosFavoritas_MotoId",
                table: "MotosFavoritas",
                column: "MotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotosFavoritas");

            migrationBuilder.DropTable(
                name: "ListasDeFavoritos");
        }
    }
}
