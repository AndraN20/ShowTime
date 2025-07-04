using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class photochanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://s-cache.s3.cloudworks.ro/kissfm/cache/1280/0/0/articole/2024/10/08/whatsapp-image-2024-10-08-at-193121_331c8603d9cdc5309b400d2527adf99a.jpeg");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 12,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8Kgru8ASEuswZMx_U3iE-_T_XQhU_MYGDRQ&s");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 13,
                column: "Image",
                value: "https://timisoara2023.eu/images/8HkvQPwMOnusyl155l1FOQJu-EU=/3465/width-1600%7Cformat-webp/6c62437f-d838-42f3-9bee-8084619d1734");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://electriccastle-assets.s3.amazonaws.com/justin_timberlake.png");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 12,
                column: "Image",
                value: "https://codru-festival.com/img/deliricsilentstrike.png");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 13,
                column: "Image",
                value: "https://subcarpati.com/img/logo.jpg");
        }
    }
}
