// <auto-generated />
using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArtGallery.Migrations.Artwork
{
    [DbContext(typeof(ArtworkContext))]
    [Migration("20210523101506_Artwok")]
    partial class Artwok
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtGallery.Models.Artwork", b =>
                {
                    b.Property<int>("ArtworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistIg")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArtworkDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ArtworkName")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Collection")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ArtworkId");

                    b.ToTable("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
