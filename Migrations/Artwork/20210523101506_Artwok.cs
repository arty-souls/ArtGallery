using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.Migrations.Artwork
{
    public partial class Artwok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ArtworkDesc = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ArtistIg = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Collection = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.ArtworkId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks");
        }
    }
}
