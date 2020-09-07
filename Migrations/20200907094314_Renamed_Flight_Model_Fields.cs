using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace air_ticket_cashier.Migrations
{
    public partial class Renamed_Flight_Model_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deparure_at",
                table: "flight");

            migrationBuilder.AddColumn<DateTime>(
                name: "departure_at",
                table: "flight",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departure_at",
                table: "flight");

            migrationBuilder.AddColumn<DateTime>(
                name: "deparure_at",
                table: "flight",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
