using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SolutionTestTaskFromMansur.Migrations
{
    public partial class FirstMigrationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "main");

            migrationBuilder.CreateTable(
                name: "personal_records",
                schema: "main",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    payroll_number = table.Column<string>(type: "text", nullable: true),
                    forenames = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    telephone = table.Column<string>(type: "text", nullable: true),
                    mobile = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    address_2 = table.Column<string>(type: "text", nullable: true),
                    postcode = table.Column<string>(type: "text", nullable: true),
                    email_home = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_records", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personal_records",
                schema: "main");
        }
    }
}
