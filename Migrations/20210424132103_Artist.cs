using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations
{
    public partial class Artist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ArtistDesc = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    ArtistCity = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ArtistIg = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ArtworkName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
