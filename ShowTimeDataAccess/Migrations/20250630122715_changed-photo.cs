using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://cdn.adh.reperio.news/image-1/1e800e06-0d90-43aa-b8a2-62abb4e3b4dc/index.jpeg?p=f%3Dpng%26w%3D1400%26r%3Dcontain");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://untold-universe-public-resources-prod.s3.eu-west-1.amazonaws.com/metroboomin.png");
        }
    }
}
