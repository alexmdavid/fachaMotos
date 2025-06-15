using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fachaMotos.Migrations
{
    /// <inheritdoc />
    public partial class agregartablasreviewreaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentariosMoto");

            migrationBuilder.AddColumn<string>(
                name: "ImagenPerfilUrl",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComentariosBlogReaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComentarioId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosBlogReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosBlogReaction_ComentariosBlog_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "ComentariosBlog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentariosBlogReaction_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewReactions_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosBlogReaction_ComentarioId",
                table: "ComentariosBlogReaction",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosBlogReaction_UserId",
                table: "ComentariosBlogReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReactions_ReviewId",
                table: "ReviewReactions",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReactions_UserId",
                table: "ReviewReactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentariosBlogReaction");

            migrationBuilder.DropTable(
                name: "ReviewReactions");

            migrationBuilder.DropColumn(
                name: "ImagenPerfilUrl",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "ComentariosMoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BikeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Contenido = table.Column<string>(type: "text", nullable: false),
                    FechaComentario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UnLinkes = table.Column<int>(type: "integer", nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosMoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosMoto_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentariosMoto_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosMoto_BikeId",
                table: "ComentariosMoto",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosMoto_UserId",
                table: "ComentariosMoto",
                column: "UserId");
        }
    }
}
