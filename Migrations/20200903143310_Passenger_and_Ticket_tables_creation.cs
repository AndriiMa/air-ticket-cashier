using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace air_ticket_cashier.Migrations
{
    public partial class Passenger_and_Ticket_tables_creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:direction_type", "regular,charter")
                .Annotation("Npgsql:Enum:passenger_sex", "female,male")
                .OldAnnotation("Npgsql:Enum:direction_type", "regular,charter");

            migrationBuilder.CreateTable(
                name: "passenger",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    passport_no = table.Column<string>(nullable: true),
                    country_code = table.Column<string>(nullable: true),
                    nationality = table.Column<string>(nullable: true),
                    date_of_birth = table.Column<DateTime>(nullable: false),
                    passenger_sex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_passengers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cost = table.Column<decimal>(nullable: false),
                    flight_id = table.Column<int>(nullable: true),
                    seat_no = table.Column<int>(nullable: false),
                    passenger_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tickets", x => x.id);
                    table.ForeignKey(
                        name: "fk_tickets_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flight",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tickets_passengers_passenger_id",
                        column: x => x.passenger_id,
                        principalTable: "passenger",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tickets_flight_id",
                table: "ticket",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "ix_tickets_passenger_id",
                table: "ticket",
                column: "passenger_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "passenger");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:direction_type", "regular,charter")
                .OldAnnotation("Npgsql:Enum:direction_type", "regular,charter")
                .OldAnnotation("Npgsql:Enum:passenger_sex", "female,male");
        }
    }
}
