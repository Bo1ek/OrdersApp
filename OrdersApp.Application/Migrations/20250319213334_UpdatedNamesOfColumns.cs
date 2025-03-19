using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApp.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNamesOfColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adress",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Orders",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Orders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "paymentMethod",
                table: "Orders",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "orderStatus",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "clientType",
                table: "Orders",
                newName: "ClientType");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Orders",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Orders",
                newName: "paymentMethod");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "orderStatus");

            migrationBuilder.RenameColumn(
                name: "ClientType",
                table: "Orders",
                newName: "clientType");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
