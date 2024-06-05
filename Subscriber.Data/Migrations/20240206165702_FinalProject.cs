using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subscriber_Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscriber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Open = table.Column<DateTime>(type: "date", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    update_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Table_subscriber_Id",
                        column: x => x.Id,
                        principalTable: "subscriber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card_Table");

            migrationBuilder.DropTable(
                name: "subscriber");
        }
    }
}
