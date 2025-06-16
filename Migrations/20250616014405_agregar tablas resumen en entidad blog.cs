using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fachaMotos.Migrations
{
    /// <inheritdoc />
    public partial class agregartablasresumenenentidadblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Blogs",
                newName: "Resumen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resumen",
                table: "Blogs",
                newName: "Categoria");
        }
    }
}
