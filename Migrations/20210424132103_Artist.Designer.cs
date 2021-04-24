﻿// <auto-generated />
using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArtGallery.Migrations
{
    [DbContext(typeof(ArtistContext))]
    [Migration("20210424132103_Artist")]
    partial class Artist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtGallery.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArtistDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ArtistIg")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArtworkName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}