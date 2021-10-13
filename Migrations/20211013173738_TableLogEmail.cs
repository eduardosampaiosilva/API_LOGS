using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_LOGS.Migrations
{
    public partial class TableLogEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodAnamnese = table.Column<int>(nullable: false),
                    CodEmpresa = table.Column<int>(nullable: false),
                    DataLeitura = table.Column<DateTime>(nullable: false)
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
