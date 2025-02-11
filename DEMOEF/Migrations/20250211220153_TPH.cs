using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOEF.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_partTimeEmployees",
                table: "partTimeEmployees");

            migrationBuilder.RenameTable(
                name: "partTimeEmployees",
                newName: "Employee2");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourRate",
                table: "Employee2",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHours",
                table: "Employee2",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Employee2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employee2",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Employee2",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee2",
                table: "Employee2",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee2",
                table: "Employee2");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employee2");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employee2");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Employee2");

            migrationBuilder.RenameTable(
                name: "Employee2",
                newName: "partTimeEmployees");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourRate",
                table: "partTimeEmployees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHours",
                table: "partTimeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_partTimeEmployees",
                table: "partTimeEmployees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullTimeEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeEmployees", x => x.Id);
                });
        }
    }
}
