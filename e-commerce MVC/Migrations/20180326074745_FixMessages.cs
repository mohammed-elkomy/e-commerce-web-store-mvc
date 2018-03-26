using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ECommerce.Migrations
{
    public partial class FixMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "readed",
                table: "messages");

            migrationBuilder.AddColumn<bool>(
                name: "read",
                table: "messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "read",
                table: "messages");

            migrationBuilder.AddColumn<byte[]>(
                name: "readed",
                table: "messages",
                type: "binary(1)",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
