using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fachaMotos.Migrations
{
    /// <inheritdoc />
    public partial class modeladoRelaciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotosFavoritas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListasDeFavoritos",
                table: "ListasDeFavoritos");

            migrationBuilder.DropIndex(
                name: "IX_ListasDeFavoritos_UserId",
                table: "ListasDeFavoritos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ListasDeFavoritos",
                newName: "BikeId");

            migrationBuilder.AlterColumn<int>(
                name: "BikeId",
                table: "ListasDeFavoritos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListasDeFavoritos",
                table: "ListasDeFavoritos",
                columns: new[] { "UserId", "BikeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ListasDeFavoritos_BikeId",
                table: "ListasDeFavoritos",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListasDeFavoritos_Bikes_BikeId",
                table: "ListasDeFavoritos",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListasDeFavoritos_Bikes_BikeId",
                table: "ListasDeFavoritos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListasDeFavoritos",
                table: "ListasDeFavoritos");

            migrationBuilder.DropIndex(
                name: "IX_ListasDeFavoritos_BikeId",
                table: "ListasDeFavoritos");

            migrationBuilder.RenameColumn(
                name: "BikeId",
                table: "ListasDeFavoritos",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ListasDeFavoritos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListasDeFavoritos",
                table: "ListasDeFavoritos",
                column: "Id");

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
    }
}
