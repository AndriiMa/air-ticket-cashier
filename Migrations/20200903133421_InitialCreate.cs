using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace air_ticket_cashier.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:direction_type", "regular,charter");

            migrationBuilder.CreateTable(
                name: "direction",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    from_country = table.Column<string>(nullable: true),
                    to_country = table.Column<string>(nullable: true),
                    avaliable = table.Column<bool>(nullable: false),
                    max_seats = table.Column<int>(nullable: false),
                    plane_code = table.Column<string>(nullable: true),
                    direction_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_directions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    deparure_at = table.Column<DateTime>(nullable: false),
                    arrive_at = table.Column<DateTime>(nullable: false),
                    avaliable = table.Column<bool>(nullable: false),
                    direction_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flights", x => x.id);
                    table.ForeignKey(
                        name: "fk_flights_directions_direction_id",
                        column: x => x.direction_id,
                        principalTable: "direction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_flights_direction_id",
                table: "flight",
                column: "direction_id");
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
