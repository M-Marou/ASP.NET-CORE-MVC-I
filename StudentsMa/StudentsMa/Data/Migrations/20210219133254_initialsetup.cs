using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsManagement_III.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentViewModel",
                columns: table => new
                {
                    studentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentCIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentViewModel", x => x.studentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentViewModel");
        }
    }
}
