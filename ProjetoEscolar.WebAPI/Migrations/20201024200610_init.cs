using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEscolar.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    DateBirth = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nilson" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Bianca" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateBirth", "Lastname", "Name", "ProfessorId" },
                values: new object[] { 1, "13/02/2000", "Lima", "Maria", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateBirth", "Lastname", "Name", "ProfessorId" },
                values: new object[] { 2, "13/02/2005", "Pereira", "Diogo", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateBirth", "Lastname", "Name", "ProfessorId" },
                values: new object[] { 3, "13/02/1998", "Xavier", "Lucas", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProfessorId",
                table: "Students",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
