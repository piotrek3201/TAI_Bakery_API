﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.Data;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220513172151_TestDatabase")]
    partial class TestDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Model.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1L,
                            CategoryName = "Torty"
                        },
                        new
                        {
                            CategoryId = 2L,
                            CategoryName = "Ciasta"
                        },
                        new
                        {
                            CategoryId = 3L,
                            CategoryName = "Ciastka"
                        },
                        new
                        {
                            CategoryId = 4L,
                            CategoryName = "Cukierki"
                        },
                        new
                        {
                            CategoryId = 5L,
                            CategoryName = "Lody"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}