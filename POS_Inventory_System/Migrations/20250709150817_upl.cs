using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Inventory_System.Migrations
{
    /// <inheritdoc />
    public partial class upl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMaster_Item_ItemId",
                table: "StockMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Item",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMaster_Item_ItemId",
                table: "StockMaster",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMaster_Item_ItemId",
                table: "StockMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Item",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMaster_Item_ItemId",
                table: "StockMaster",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
