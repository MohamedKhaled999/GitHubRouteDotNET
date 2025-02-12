using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOEF.Migrations
{
    /// <inheritdoc />
    public partial class TPCC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee2",
                table: "Employee2");

            migrationBuilder.RenameTable(
                name: "Employee2",
                newName: "Employee2s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee2s",
                table: "Employee2s",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee2s",
                table: "Employee2s");

            migrationBuilder.RenameTable(
                name: "Employee2s",
                newName: "Employee2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee2",
                table: "Employee2",
                column: "Id");
        }
    }
}
