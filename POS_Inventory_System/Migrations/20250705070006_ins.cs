using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Inventory_System.Migrations
{
    /// <inheritdoc />
    public partial class ins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInfos",
                table: "CompanyInfos");

            migrationBuilder.RenameTable(
                name: "CompanyInfos",
                newName: "CompanyInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInfo",
                table: "CompanyInfo",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInfo",
                table: "CompanyInfo");

            migrationBuilder.RenameTable(
                name: "CompanyInfo",
                newName: "CompanyInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInfos",
                table: "CompanyInfos",
                column: "ID");
        }
    }
}
