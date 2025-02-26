﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13e02595-f92e-48d5-b3f2-690ccdf32bc1"),
                            Credits = 3,
                            Name = "Matemáticas",
                            TeacherId = new Guid("ae9a6102-0905-4bf1-8d2f-72e74e820b0c")
                        },
                        new
                        {
                            Id = new Guid("40bdb71d-ee7c-470e-aec1-e05f17df9ba6"),
                            Credits = 3,
                            Name = "Física",
                            TeacherId = new Guid("ae9a6102-0905-4bf1-8d2f-72e74e820b0c")
                        },
                        new
                        {
                            Id = new Guid("7f7b440f-baef-4d9f-b18a-609c38677571"),
                            Credits = 3,
                            Name = "Química",
                            TeacherId = new Guid("8a9a9af4-2afe-42f4-97dc-60122239279b")
                        },
                        new
                        {
                            Id = new Guid("1c930008-353a-4ae4-a6f0-987603cb68c5"),
                            Credits = 3,
                            Name = "Biología",
                            TeacherId = new Guid("8a9a9af4-2afe-42f4-97dc-60122239279b")
                        },
                        new
                        {
                            Id = new Guid("ce9e4d5c-f4ca-4f3b-92f0-94e9573f1007"),
                            Credits = 3,
                            Name = "Programación",
                            TeacherId = new Guid("a9976d54-fedb-43f9-9015-25a960704818")
                        },
                        new
                        {
                            Id = new Guid("db5076b2-31fc-4562-afc5-8c6ab833033f"),
                            Credits = 3,
                            Name = "Bases de Datos",
                            TeacherId = new Guid("a9976d54-fedb-43f9-9015-25a960704818")
                        },
                        new
                        {
                            Id = new Guid("fe336441-9557-4170-aa43-ebc0ee483783"),
                            Credits = 3,
                            Name = "Economía",
                            TeacherId = new Guid("5639e743-26bf-4e1e-bc99-a075ee33b30f")
                        },
                        new
                        {
                            Id = new Guid("ac1a1770-e185-4a1c-85ed-74ba3f3c85db"),
                            Credits = 3,
                            Name = "Contabilidad",
                            TeacherId = new Guid("5639e743-26bf-4e1e-bc99-a075ee33b30f")
                        },
                        new
                        {
                            Id = new Guid("015028d8-8e9a-4175-a56c-9df28e44fce4"),
                            Credits = 3,
                            Name = "Psicología",
                            TeacherId = new Guid("fb038367-2884-45cd-b1ff-a9f1d1308f7a")
                        },
                        new
                        {
                            Id = new Guid("c081a086-5b8f-469a-bdbf-ddbecc5fba59"),
                            Credits = 3,
                            Name = "Derecho",
                            TeacherId = new Guid("fb038367-2884-45cd-b1ff-a9f1d1308f7a")
                        });
                });

            modelBuilder.Entity("Core.Models.Program", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCredits")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Program");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03911b56-3375-489a-a60f-e7aa7ffbd045"),
                            Name = "Ingeniería de Sistemas",
                            TotalCredits = 60
                        },
                        new
                        {
                            Id = new Guid("ac4a1f8d-7b99-4708-9e00-0807dfff45cd"),
                            Name = "Medicina",
                            TotalCredits = 70
                        },
                        new
                        {
                            Id = new Guid("5e9ee734-61a9-4bd8-9298-d0d0f5f67d3f"),
                            Name = "Derecho",
                            TotalCredits = 50
                        });
                });

            modelBuilder.Entity("Core.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableCredits")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Core.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae9a6102-0905-4bf1-8d2f-72e74e820b0c"),
                            Name = "Profesor A",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("8a9a9af4-2afe-42f4-97dc-60122239279b"),
                            Name = "Profesor B",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("a9976d54-fedb-43f9-9015-25a960704818"),
                            Name = "Profesor C",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("5639e743-26bf-4e1e-bc99-a075ee33b30f"),
                            Name = "Profesor D",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("fb038367-2884-45cd-b1ff-a9f1d1308f7a"),
                            Name = "Profesor E",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.Course", b =>
                {
                    b.HasOne("Core.Models.Student", null)
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");

                    b.HasOne("Core.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Core.Models.Student", b =>
                {
                    b.HasOne("Core.Models.Program", "Program")
                        .WithMany("Students")
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Core.Models.Program", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Core.Models.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Core.Models.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
