using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Data.Migrations
{
    public partial class RemoveDbSetForUrlUsageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlUsage_Urls_UrlDataId",
                table: "UrlUsage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrlUsage",
                table: "UrlUsage");

            migrationBuilder.RenameTable(
                name: "UrlUsage",
                newName: "UrlUsageData");

            migrationBuilder.RenameIndex(
                name: "IX_UrlUsage_UrlDataId",
                table: "UrlUsageData",
                newName: "IX_UrlUsageData_UrlDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrlUsageData",
                table: "UrlUsageData",
                column: "UrlUsageDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlUsageData_Urls_UrlDataId",
                table: "UrlUsageData",
                column: "UrlDataId",
                principalTable: "Urls",
                principalColumn: "UrlDataId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlUsageData_Urls_UrlDataId",
                table: "UrlUsageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrlUsageData",
                table: "UrlUsageData");

            migrationBuilder.RenameTable(
                name: "UrlUsageData",
                newName: "UrlUsage");

            migrationBuilder.RenameIndex(
                name: "IX_UrlUsageData_UrlDataId",
                table: "UrlUsage",
                newName: "IX_UrlUsage_UrlDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrlUsage",
                table: "UrlUsage",
                column: "UrlUsageDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlUsage_Urls_UrlDataId",
                table: "UrlUsage",
                column: "UrlDataId",
                principalTable: "Urls",
                principalColumn: "UrlDataId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
