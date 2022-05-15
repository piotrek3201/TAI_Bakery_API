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
    [Migration("20220515114807_test2")]
    partial class test2
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

            modelBuilder.Entity("WebApp.Model.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductId"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsByWeight")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCustomizable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1L,
                            CategoryId = 1L,
                            Description = "Sam skomponuj swój wymarzony tort!",
                            IsByWeight = false,
                            IsCustomizable = true,
                            Name = "Tort własny",
                            Price = 50.0
                        },
                        new
                        {
                            ProductId = 2L,
                            CategoryId = 2L,
                            Description = "Pyszne czekoladowe ciasto, lepsze niż we Władysławowie!",
                            IsByWeight = false,
                            IsCustomizable = false,
                            Name = "Brownie",
                            Price = 20.0
                        },
                        new
                        {
                            ProductId = 3L,
                            CategoryId = 4L,
                            Description = "Klasyczne ciasto ze świeżymi jabłkami",
                            IsByWeight = false,
                            IsCustomizable = false,
                            Name = "Szarlotka",
                            Price = 15.0
                        },
                        new
                        {
                            ProductId = 4L,
                            CategoryId = 4L,
                            Description = "Kultowe karmelki",
                            IsByWeight = true,
                            IsCustomizable = false,
                            Name = "Kukułki",
                            Price = 17.0
                        });
                });

            modelBuilder.Entity("WebApp.Model.Product", b =>
                {
                    b.HasOne("WebApp.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApp.Model.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
