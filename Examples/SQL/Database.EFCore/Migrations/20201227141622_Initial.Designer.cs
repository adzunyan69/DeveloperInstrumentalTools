﻿// <auto-generated />
using Database.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EFCore.Migrations
{
    [DbContext(typeof(ExampleContext))]
    [Migration("20201227141622_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Database.EFCore.Entities.MoviesEntity", b =>
                {
                    b.Property<int>("MoviesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("MoviesId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MoviesId = 1,
                            Name = "First Title",
                            Year = 1990
                        },
                        new
                        {
                            MoviesId = 2,
                            Name = "Second Title",
                            Year = 2000
                        },
                        new
                        {
                            MoviesId = 3,
                            Name = "Third Title",
                            Year = 2020
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
