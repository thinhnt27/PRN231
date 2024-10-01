using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab3_PRN231.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    accountid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_pkey", x => x.accountid);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    unitsinstock = table.Column<int>(type: "int", nullable: false),
                    unitprice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_pkey", x => x.productid);
                    table.ForeignKey(
                        name: "FK_product_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[,]
                {
                    { 1, "Beverages" },
                    { 2, "Condiments" },
                    { 3, "Confections" },
                    { 4, "Dairy Products" },
                    { 5, "Grains/Cereals" },
                    { 6, "Meat/Poultry" },
                    { 7, "Produce" },
                    { 8, "Seafood" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productid", "categoryid", "productname", "unitprice", "unitsinstock" },
                values: new object[,]
                {
                    { 1, 1, "Chai", 18.00m, 39 },
                    { 2, 1, "Chang", 19.00m, 17 },
                    { 3, 2, "Aniseed Syrup", 10.00m, 13 },
                    { 4, 2, "Chef Anton's Cajun Seasoning", 22.00m, 53 },
                    { 5, 2, "Chef Anton's Gumbo Mix", 21.35m, 0 },
                    { 6, 2, "Grandma's Boysenberry Spread", 25.00m, 120 },
                    { 7, 7, "Uncle Bob's Organic Dried Pears", 30.00m, 15 },
                    { 8, 2, "Northwoods Cranberry Sauce", 40.00m, 6 },
                    { 9, 6, "Mishi Kobe Niku", 97.00m, 29 },
                    { 10, 8, "Ikura", 31.00m, 31 },
                    { 11, 4, "Queso Cabrales", 21.00m, 22 },
                    { 12, 4, "Queso Manchego La Pastora", 38.00m, 86 },
                    { 13, 8, "Konbu", 6.00m, 24 },
                    { 14, 7, "Tofu", 23.25m, 35 },
                    { 15, 2, "Genen Shouyu", 15.50m, 39 },
                    { 16, 3, "Pavlova", 17.45m, 29 },
                    { 17, 6, "Alice Mutton", 39.00m, 0 },
                    { 18, 8, "Carnarvon Tigers", 62.50m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_categoryid",
                table: "product",
                column: "categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
