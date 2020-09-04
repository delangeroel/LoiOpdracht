﻿// <auto-generated />
using System;
using LoiOpdracht.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoiOpdracht.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200904184754_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoiOpdracht.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoachId");

                    b.ToTable("Coach");

                    b.HasData(
                        new
                        {
                            CoachId = 1,
                            Active = true,
                            Naam = "Coach1",
                            Voornaam = "S1"
                        },
                        new
                        {
                            CoachId = 2,
                            Active = true,
                            Naam = "Coach2",
                            Voornaam = "S2"
                        },
                        new
                        {
                            CoachId = 3,
                            Active = true,
                            Naam = "Coach3",
                            Voornaam = "S3"
                        },
                        new
                        {
                            CoachId = 4,
                            Active = true,
                            Naam = "Coach4",
                            Voornaam = "S4"
                        });
                });

            modelBuilder.Entity("LoiOpdracht.Models.Speler", b =>
                {
                    b.Property<int>("SpelerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktief")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straatnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Woonplaats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpelerId");

                    b.ToTable("Speler");

                    b.HasData(
                        new
                        {
                            SpelerId = 1,
                            Aktief = true,
                            Naam = "Speler1",
                            Straatnaam = "S1",
                            Woonplaats = "W1"
                        },
                        new
                        {
                            SpelerId = 2,
                            Aktief = true,
                            Naam = "Speler2",
                            Straatnaam = "S2",
                            Woonplaats = "W2"
                        },
                        new
                        {
                            SpelerId = 3,
                            Aktief = true,
                            Naam = "Speler3",
                            Straatnaam = "S3",
                            Woonplaats = "W3"
                        },
                        new
                        {
                            SpelerId = 4,
                            Aktief = true,
                            Naam = "Speler4",
                            Straatnaam = "S4",
                            Woonplaats = "W4"
                        },
                        new
                        {
                            SpelerId = 5,
                            Aktief = true,
                            Naam = "Speler5",
                            Straatnaam = "S5",
                            Woonplaats = "W5"
                        },
                        new
                        {
                            SpelerId = 6,
                            Aktief = true,
                            Naam = "Speler6",
                            Straatnaam = "S6",
                            Woonplaats = "W6"
                        },
                        new
                        {
                            SpelerId = 7,
                            Aktief = true,
                            Naam = "Speler7",
                            Straatnaam = "S7",
                            Woonplaats = "W7"
                        });
                });

            modelBuilder.Entity("LoiOpdracht.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoortSport")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("Speler2Id")
                        .HasColumnType("int");

                    b.Property<int?>("SpelerId")
                        .HasColumnType("int");

                    b.Property<string>("TeamNaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.HasIndex("CoachId");

                    b.HasIndex("Speler2Id");

                    b.HasIndex("SpelerId");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            CoachId = 2,
                            Naam = "t1",
                            SoortSport = "Tennis",
                            Speler2Id = 2,
                            SpelerId = 1,
                            TeamNaam = "Team1"
                        },
                        new
                        {
                            TeamId = 2,
                            CoachId = 2,
                            Naam = "t2",
                            SoortSport = "Schaken",
                            Speler2Id = 3,
                            SpelerId = 2,
                            TeamNaam = "Team2"
                        },
                        new
                        {
                            TeamId = 3,
                            CoachId = 2,
                            Naam = "t3",
                            SoortSport = "Vissen",
                            Speler2Id = 4,
                            SpelerId = 3,
                            TeamNaam = "Team3"
                        },
                        new
                        {
                            TeamId = 4,
                            CoachId = 2,
                            Naam = "t4",
                            SoortSport = "Hardlopen",
                            Speler2Id = 5,
                            SpelerId = 4,
                            TeamNaam = "Team4"
                        });
                });

            modelBuilder.Entity("LoiOpdracht.Models.Team", b =>
                {
                    b.HasOne("LoiOpdracht.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.HasOne("LoiOpdracht.Models.Speler", "Speler2")
                        .WithMany()
                        .HasForeignKey("Speler2Id");

                    b.HasOne("LoiOpdracht.Models.Speler", "Speler1")
                        .WithMany()
                        .HasForeignKey("SpelerId");
                });
#pragma warning restore 612, 618
        }
    }
}
