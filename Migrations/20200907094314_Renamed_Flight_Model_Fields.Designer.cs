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
    [Migration("20200907094314_Renamed_Flight_Model_Fields")]
    partial class Renamed_Flight_Model_Fields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Enum:direction_type", "regular,charter")
                .HasAnnotation("Npgsql:Enum:passenger_sex", "female,male")
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

                    b.Property<DateTime>("DepartureAt")
                        .HasColumnName("departure_at")
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

            modelBuilder.Entity("air_ticket_cashier.Passenger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnName("country_code")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("date_of_birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnName("nationality")
                        .HasColumnType("text");

                    b.Property<int>("PassengerSex")
                        .HasColumnName("passenger_sex")
                        .HasColumnType("integer");

                    b.Property<string>("PassportNo")
                        .HasColumnName("passport_no")
                        .HasColumnType("text");

                    b.HasKey("ID")
                        .HasName("pk_passengers");

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("air_ticket_cashier.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnName("cost")
                        .HasColumnType("numeric");

                    b.Property<int>("SeatNo")
                        .HasColumnName("seat_no")
                        .HasColumnType("integer");

                    b.Property<int?>("flightID")
                        .HasColumnName("flight_id")
                        .HasColumnType("integer");

                    b.Property<int?>("passengerID")
                        .HasColumnName("passenger_id")
                        .HasColumnType("integer");

                    b.HasKey("ID")
                        .HasName("pk_tickets");

                    b.HasIndex("flightID")
                        .HasName("ix_tickets_flight_id");

                    b.HasIndex("passengerID")
                        .HasName("ix_tickets_passenger_id");

                    b.ToTable("ticket");
                });

            modelBuilder.Entity("air_ticket_cashier.Flight", b =>
                {
                    b.HasOne("air_ticket_cashier.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionID")
                        .HasConstraintName("fk_flights_directions_direction_id");
                });

            modelBuilder.Entity("air_ticket_cashier.Ticket", b =>
                {
                    b.HasOne("air_ticket_cashier.Flight", "flight")
                        .WithMany()
                        .HasForeignKey("flightID")
                        .HasConstraintName("fk_tickets_flights_flight_id");

                    b.HasOne("air_ticket_cashier.Passenger", "passenger")
                        .WithMany()
                        .HasForeignKey("passengerID")
                        .HasConstraintName("fk_tickets_passengers_passenger_id");
                });
#pragma warning restore 612, 618
        }
    }
}
