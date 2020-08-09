using Microsoft.EntityFrameworkCore.Migrations;

namespace BMES.Migrations
{
    public partial class AddSalesPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Sale_price",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sale_price",
                table: "Products");
        }
    }
}
