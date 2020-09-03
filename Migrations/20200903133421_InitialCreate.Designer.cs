﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using air_ticket_cashier;

namespace air_ticket_cashier.Migrations
{
    [DbContext(typeof(CashierContext))]
    [Migration("20200903133421_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Enum:direction_type", "regular,charter")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("air_ticket_cashier.Direction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Avaliable")
                        .HasColumnName("avaliable")
                        .HasColumnType("boolean");

                    b.Property<int>("DirectionType")
                        .HasColumnName("direction_type")
                        .HasColumnType("integer");

                    b.Property<string>("FromCountry")
                        .HasColumnName("from_country")
                        .HasColumnType("text");

                    b.Property<int>("MaxSeats")
                        .HasColumnName("max_seats")
                        .HasColumnType("integer");

                    b.Property<string>("PlaneCode")
                        .HasColumnName("plane_code")
                        .HasColumnType("text");

                    b.Property<string>("ToCountry")
                        .HasColumnName("to_country")
                        .HasColumnType("text");

                    b.HasKey("ID")
                        .HasName("pk_directions");

                    b.ToTable("direction");
                });

            modelBuilder.Entity("air_ticket_cashier.Flight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime>("ArriveAt")
                        .HasColumnName("arrive_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Avaliable")
                        .HasColumnName("avaliable")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DeparureAt")
                        .HasColumnName("deparure_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DirectionID")
                        .HasColumnName("direction_id")
                        .HasColumnType("integer");

                    b.HasKey("ID")
                        .HasName("pk_flights");

                    b.HasIndex("DirectionID")
                        .HasName("ix_flights_direction_id");

                    b.ToTable("flight");
                });

            modelBuilder.Entity("air_ticket_cashier.Flight", b =>
                {
                    b.HasOne("air_ticket_cashier.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionID")
                        .HasConstraintName("fk_flights_directions_direction_id");
                });
#pragma warning restore 612, 618
        }
    }
}
