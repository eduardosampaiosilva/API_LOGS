using Microsoft.EntityFrameworkCore.Migrations;

namespace API_LOGS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogEmails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EventType = table.Column<string>(nullable: false),
                    IdExame = table.Column<string>(nullable: false),
                    IdEmpresa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEmails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEmails");
        }
    }
}
