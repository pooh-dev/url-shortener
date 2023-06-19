using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Data.Migrations
{
    public partial class AddUrlUsageDataToUrlData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Urls",
                newName: "UrlDataId");

            migrationBuilder.CreateTable(
                name: "UrlUsageData",
                columns: table => new
                {
                    UrlUsageDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlDataId = table.Column<int>(type: "int", nullable: false),
                    Accept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlUsageData", x => x.UrlUsageDataId);
                    table.ForeignKey(
                        name: "FK_UrlUsageData_Urls_UrlDataId",
                        column: x => x.UrlDataId,
                        principalTable: "Urls",
                        principalColumn: "UrlDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlUsageData_UrlDataId",
                table: "UrlUsageData",
                column: "UrlDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlUsageData");

            migrationBuilder.RenameColumn(
                name: "UrlDataId",
                table: "Urls",
                newName: "Id");
        }
    }
}
