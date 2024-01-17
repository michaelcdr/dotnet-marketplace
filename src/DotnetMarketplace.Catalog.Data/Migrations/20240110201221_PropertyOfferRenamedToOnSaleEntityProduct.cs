using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetMarketplace.Catalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertyOfferRenamedToOnSaleEntityProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Offer",
                table: "Products",
                newName: "OnSale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnSale",
                table: "Products",
                newName: "Offer");
        }
    }
}
