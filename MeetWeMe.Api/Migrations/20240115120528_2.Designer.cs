﻿// <auto-generated />
using System;
using MeetWeMe.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetWeMe.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240115120528_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeetWeMe.Model.Categories", b =>
                {
                    b.Property<int>("CategoriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriesId"));

                    b.Property<string>("CategoriesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriesId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoriesId = 6,
                            CategoriesName = "Glasses"
                        },
                        new
                        {
                            CategoriesId = 4,
                            CategoriesName = "Disable"
                        },
                        new
                        {
                            CategoriesId = 5,
                            CategoriesName = "Shy"
                        });
                });

            modelBuilder.Entity("MeetWeMe.Model.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfMeeting")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeetWeMe.Model.Users", b =>
                {
                    b.HasOne("MeetWeMe.Model.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesId");

                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
