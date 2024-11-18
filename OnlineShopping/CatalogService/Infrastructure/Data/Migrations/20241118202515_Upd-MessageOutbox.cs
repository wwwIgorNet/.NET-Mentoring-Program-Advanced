using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.CatalogService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdMessageOutbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntetyId",
                table: "OutboxMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntetyId",
                table: "OutboxMessages");
        }
    }
}
