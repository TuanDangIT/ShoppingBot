using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingBot.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeservernametoserverid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerName",
                table: "Products",
                newName: "ServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerId",
                table: "Products",
                newName: "ServerName");
        }
    }
}
