using Microsoft.EntityFrameworkCore.Migrations;

namespace Hastprogrammet.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Height = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    BirthYear = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Economy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    HorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Economy", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Book__AuthorID__29572725",
                        column: x => x.HorseId,
                        principalTable: "Horse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Economy_HorseId",
                table: "Economy",
                column: "HorseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Economy");

            migrationBuilder.DropTable(
                name: "Horse");
        }
    }
}
