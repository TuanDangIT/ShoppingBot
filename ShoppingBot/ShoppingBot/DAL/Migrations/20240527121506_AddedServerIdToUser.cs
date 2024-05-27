using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingBot.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedServerIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServerId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Users");
        }
    }
}
