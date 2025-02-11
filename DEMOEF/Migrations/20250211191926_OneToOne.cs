using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOEF.Migrations
{
    /// <inheritdoc />
    public partial class OneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                schema: "dbo",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                schema: "dbo",
                table: "Departments",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                schema: "dbo",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                schema: "dbo",
                table: "Departments");
        }
    }
}
