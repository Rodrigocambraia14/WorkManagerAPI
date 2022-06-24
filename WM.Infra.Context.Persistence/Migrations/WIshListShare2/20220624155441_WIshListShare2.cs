using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WM.Infra.Context.Persistence.Migrations.WIshListShare2
{
    public partial class WIshListShare2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "WishListUsers",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "WishListUsers");
        }
    }
}
