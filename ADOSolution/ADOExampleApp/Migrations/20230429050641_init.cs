using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADOExampleApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Dep_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Department",
                        column: x => x.Dep_Id,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "Name" },
                values: new object[] { 101, "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "Name" },
                values: new object[] { 102, "Ops" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Dep_Id", "Name", "Salary" },
                values: new object[] { 1000, 101, "Ramu", 124434.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dep_Id",
                table: "Employees",
                column: "Dep_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
