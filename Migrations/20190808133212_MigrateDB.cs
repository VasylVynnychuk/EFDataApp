using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataApp.Migrations
{
    public partial class MigrateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterModel",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterModel", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id_student = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Kod_pocztowy = table.Column<string>(nullable: true),
                    Miejscowosc = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id_student);
                });

            migrationBuilder.CreateTable(
                name: "Student_Oceny",
                columns: table => new
                {
                    Id_oceny = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ocena = table.Column<int>(nullable: false),
                    Ocena_slownie = table.Column<string>(nullable: true),
                    Id_student = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Oceny", x => x.Id_oceny);
                    table.ForeignKey(
                        name: "FK_Student_Oceny_Students_Id_student",
                        column: x => x.Id_student,
                        principalTable: "Students",
                        principalColumn: "Id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Oceny_Id_student",
                table: "Student_Oceny",
                column: "Id_student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterModel");

            migrationBuilder.DropTable(
                name: "Student_Oceny");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
