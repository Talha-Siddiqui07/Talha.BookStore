using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talha.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class added2columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedon",
                table: "Books",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdon",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "updatedon",
                table: "Books");
        }
    }
}
