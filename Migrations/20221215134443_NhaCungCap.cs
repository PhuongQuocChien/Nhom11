using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class NhaCungCap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    Mancc = table.Column<string>(type: "TEXT", nullable: false),
                    Tenncc = table.Column<string>(type: "TEXT", nullable: false),
                    Diachincc = table.Column<string>(type: "TEXT", nullable: false),
                    Sdtncc = table.Column<string>(type: "TEXT", nullable: true),
                    Emailncc = table.Column<string>(type: "TEXT", nullable: true),
                    ngayncc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.Mancc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhaCungCap");
        }
    }
}
