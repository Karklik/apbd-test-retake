﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apbd_test_retake.Models;

namespace apbd_test_retake.Migrations
{
    [DbContext(typeof(FireBrigadeDbContext))]
    [Migration("20200705133913_AddedTables")]
    partial class AddedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("apbd_test_retake.Models.Action", b =>
                {
                    b.Property<int>("IdAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("NeedSpecialEquipment")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdAction");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("apbd_test_retake.Models.FireTruck", b =>
                {
                    b.Property<int>("IdFireTruck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("OperationalNumber")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<bool>("SpecialEquipment")
                        .HasColumnType("boolean");

                    b.HasKey("IdFireTruck");

                    b.ToTable("FireTruck");
                });

            modelBuilder.Entity("apbd_test_retake.Models.FireTruckAction", b =>
                {
                    b.Property<int>("IdFireTruckAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("AssigmentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdAction")
                        .HasColumnType("integer");

                    b.Property<int>("IdFireTruck")
                        .HasColumnType("integer");

                    b.HasKey("IdFireTruckAction");

                    b.HasIndex("IdAction");

                    b.HasIndex("IdFireTruck");

                    b.ToTable("FireTruck_Action");
                });

            modelBuilder.Entity("apbd_test_retake.Models.Firefighter", b =>
                {
                    b.Property<int>("IdFirefighter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdFirefighter");

                    b.ToTable("Firefighter");
                });

            modelBuilder.Entity("apbd_test_retake.Models.FirefighterAction", b =>
                {
                    b.Property<int>("IdFirefighter")
                        .HasColumnType("integer");

                    b.Property<int>("IdAction")
                        .HasColumnType("integer");

                    b.HasKey("IdFirefighter", "IdAction");

                    b.HasIndex("IdAction");

                    b.ToTable("Firefighter_Action");
                });

            modelBuilder.Entity("apbd_test_retake.Models.FireTruckAction", b =>
                {
                    b.HasOne("apbd_test_retake.Models.Action", "Action")
                        .WithMany("FireTruckActions")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apbd_test_retake.Models.FireTruck", "FireTruck")
                        .WithMany("FireTruckActions")
                        .HasForeignKey("IdFireTruck")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apbd_test_retake.Models.FirefighterAction", b =>
                {
                    b.HasOne("apbd_test_retake.Models.Action", "Action")
                        .WithMany("FirefighterActions")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apbd_test_retake.Models.Firefighter", "Firefighter")
                        .WithMany("FirefighterActions")
                        .HasForeignKey("IdFirefighter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
