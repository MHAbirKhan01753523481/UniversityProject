using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WorkAppp.Data.Migrations
{
    public partial class Script06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStautas",
                table: "OrderR");

            migrationBuilder.AlterColumn<string>(
                name: "TableNo",
                table: "OrderR",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "OrderR",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TableNo",
                table: "OrderR",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "OrderR",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PaymentStautas",
                table: "OrderR",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
