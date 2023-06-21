using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Data.Migrations
{
    public partial class AddUsageDataToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlUsageData_Urls_UrlDataId",
                table: "UrlUsageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrlUsageData",
                table: "UrlUsageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.RenameTable(
                name: "UrlUsageData",
                newName: "UrlUsageDatas");

            migrationBuilder.RenameTable(
                name: "Urls",
                newName: "UrlDatas");

            migrationBuilder.RenameIndex(
                name: "IX_UrlUsageData_UrlDataId",
                table: "UrlUsageDatas",
                newName: "IX_UrlUsageDatas_UrlDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrlUsageDatas",
                table: "UrlUsageDatas",
                column: "UrlUsageDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrlDatas",
                table: "UrlDatas",
                column: "UrlDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlUsageDatas_UrlDatas_UrlDataId",
                table: "UrlUsageDatas",
                column: "UrlDataId",
                principalTable: "UrlDatas",
                principalColumn: "UrlDataId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlUsageDatas_UrlDatas_UrlDataId",
                table: "UrlUsageDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrlUsageDatas",
                table: "UrlUsageDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrlDatas",
                table: "UrlDatas");

            migrationBuilder.RenameTable(
                name: "UrlUsageDatas",
                newName: "UrlUsageData");

            migrationBuilder.RenameTable(
                name: "UrlDatas",
                newName: "Urls");

            migrationBuilder.RenameIndex(
                name: "IX_UrlUsageDatas_UrlDataId",
                table: "UrlUsageData",
                newName: "IX_UrlUsageData_UrlDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrlUsageData",
                table: "UrlUsageData",
                column: "UrlUsageDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "UrlDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlUsageData_Urls_UrlDataId",
                table: "UrlUsageData",
                column: "UrlDataId",
                principalTable: "Urls",
                principalColumn: "UrlDataId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
