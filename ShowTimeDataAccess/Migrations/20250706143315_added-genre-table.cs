using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedgenretable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Artists");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(265)", maxLength: 265, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistGenre",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenre", x => new { x.ArtistId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hip-Hop" },
                    { 2, "Trap" },
                    { 3, "Rock" },
                    { 4, "Pop" }
                });

            migrationBuilder.InsertData(
                table: "ArtistGenre",
                columns: new[] { "ArtistId", "GenreId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 4, 2 },
                    { 6, 4 },
                    { 12, 1 },
                    { 13, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenre_GenreId",
                table: "ArtistGenre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistGenre");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Genre",
                value: "Hip-Hop/Trap");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                column: "Genre",
                value: "Pop/R&B");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 12,
                column: "Genre",
                value: "Hip-Hop/Electronic");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 13,
                column: "Genre",
                value: "Etno/Alternative/Hip-Hop");
        }
    }
}
