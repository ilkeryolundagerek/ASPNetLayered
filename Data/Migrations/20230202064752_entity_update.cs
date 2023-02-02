using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class entity_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "HR",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                schema: "HR",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                schema: "HR",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "HR",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                schema: "HR",
                table: "Person",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                schema: "HR",
                table: "Person",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                schema: "HR",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "HR",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                schema: "HR",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                schema: "HR",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "HR",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                schema: "HR",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "HR",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "HR",
                table: "Address",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "HR",
                table: "Address",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                schema: "HR",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                schema: "HR",
                table: "Address",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "HR",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                schema: "HR",
                table: "Address",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "HR",
                table: "Address",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                schema: "HR",
                table: "Address",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Prefix",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Suffix",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                schema: "HR",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "HR",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                schema: "HR",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                schema: "HR",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "HR",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                schema: "HR",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Detail",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "HR",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                schema: "HR",
                table: "Address");
        }
    }
}
