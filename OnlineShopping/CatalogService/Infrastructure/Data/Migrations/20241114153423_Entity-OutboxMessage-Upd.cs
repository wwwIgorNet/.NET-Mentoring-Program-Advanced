using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.CatalogService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntityOutboxMessageUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entity",
                table: "OutboxMessages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Entity",
                table: "OutboxMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
