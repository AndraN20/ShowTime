using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Genre", "Image", "Name" },
                values: new object[,]
                {
                    { 4, "Hip-Hop/Trap", "https://untold-universe-public-resources-prod.s3.eu-west-1.amazonaws.com/metroboomin.png", "Metro Boomin" },
                    { 6, "Pop/R&B", "https://electriccastle-assets.s3.amazonaws.com/justin_timberlake.png", "Justin Timberlake" },
                    { 12, "Hip-Hop/Electronic", "https://codru-festival.com/img/deliricsilentstrike.png", "Deliric x Silent Strike" },
                    { 13, "Etno/Alternative/Hip-Hop", "https://subcarpati.com/img/logo.jpg", "Subcarpați" }
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "Capacity", "EndDate", "Location", "Name", "SplashArt", "StartDate" },
                values: new object[,]
                {
                    { 1, 427000, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cluj-Napoca", "Untold", "https://tse1.mm.bing.net/th/id/OIP.7tpAeTwiDDKJu2r-v5h1bwHaE7", new DateTime(2025, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 274000, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonțida", "Electric Castle", "https://tse4.mm.bing.net/th/id/OIP.PKUQAr-s6irxfdcy6QJ-mAAAAA", new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 30000, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timișoara (Pădurea Verde)", "Codru Festival", "https://www.codrufestival.ro/wp-content/uploads/2024/06/codrufestival-facebook-thumbnail.png", new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
