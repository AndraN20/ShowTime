using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(265)", maxLength: 265, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SplashArt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lineups",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineups", x => new { x.FestivalId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_Lineups_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineups_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FestivalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MaxQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => new { x.FestivalId, x.UserId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_Bookings_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Genre", "Image", "Name" },
                values: new object[,]
                {
                    { 4, "Hip-Hop", "https://cdn.adh.reperio.news/image-1/1e800e06-0d90-43aa-b8a2-62abb4e3b4dc/index.jpeg?p=f%3Dpng%26w%3D1400%26r%3Dcontain", "Metro Boomin" },
                    { 6, "Pop", "https://s-cache.s3.cloudworks.ro/kissfm/cache/1280/0/0/articole/2024/10/08/whatsapp-image-2024-10-08-at-193121_331c8603d9cdc5309b400d2527adf99a.jpeg", "Justin Timberlake" },
                    { 12, "Hip-Hop", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8Kgru8ASEuswZMx_U3iE-_T_XQhU_MYGDRQ&s", "Deliric x Silent Strike" },
                    { 13, "Hip-Hop", "https://timisoara2023.eu/images/8HkvQPwMOnusyl155l1FOQJu-EU=/3465/width-1600%7Cformat-webp/6c62437f-d838-42f3-9bee-8084619d1734", "Subcarpați" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TicketId",
                table: "Bookings",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_ArtistId",
                table: "Lineups",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FestivalId",
                table: "Tickets",
                column: "FestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Lineups");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Festivals");
        }
    }
}
