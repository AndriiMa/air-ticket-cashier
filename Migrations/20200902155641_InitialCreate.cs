using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace air_ticket_cashier.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "direction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromCountry = table.Column<string>(nullable: true),
                    ToCountry = table.Column<string>(nullable: true),
                    Avaliable = table.Column<bool>(nullable: false),
                    MaxSeats = table.Column<int>(nullable: false),
                    PlaneCode = table.Column<string>(nullable: true),
                    DirectionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeparureAt = table.Column<DateTime>(nullable: false),
                    ArriveAt = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    DirectionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_flight_direction_DirectionID",
                        column: x => x.DirectionID,
                        principalTable: "direction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flight_DirectionID",
                table: "flight",
                column: "DirectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flight");

            migrationBuilder.DropTable(
                name: "direction");
        }
    }
}
