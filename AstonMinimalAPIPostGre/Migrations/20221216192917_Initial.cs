using Microsoft.EntityFrameworkCore.Migrations;

namespace AstonMinimalAPIPostGre.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "text", nullable: false),
                    Name_Item = table.Column<string>(type: "text", nullable: false),
                    Price_Item = table.Column<double>(type: "double precision", nullable: false),
                    Description_Item = table.Column<string>(type: "text", nullable: true),
                    CategoryName_Item = table.Column<string>(type: "text", nullable: true),
                    ImageUrl_Item = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
