using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMQuota.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quotaBody",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createDate = table.Column<DateTime>(nullable: false),
                    quotaString = table.Column<string>(nullable: true),
                    quotaString1 = table.Column<string>(nullable: true),
                    quotaString2 = table.Column<string>(nullable: true),
                    quotaString3 = table.Column<string>(nullable: true),
                    quotaString4 = table.Column<string>(nullable: true),
                    quotaString5 = table.Column<string>(nullable: true),
                    quotaString6 = table.Column<string>(nullable: true),
                    quotaString7 = table.Column<string>(nullable: true),
                    quotaString8 = table.Column<string>(nullable: true),
                    quotaString9 = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<DateTime>(nullable: false),
                    headerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotaBody", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quotaHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createDate = table.Column<DateTime>(nullable: false),
                    quotaName = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<DateTime>(nullable: false),
                    index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotaHeaders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quotaBody");

            migrationBuilder.DropTable(
                name: "quotaHeaders");
        }
    }
}
