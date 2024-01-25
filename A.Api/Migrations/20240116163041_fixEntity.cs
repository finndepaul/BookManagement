using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Api.Migrations
{
    /// <inheritdoc />
    public partial class fixEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Products",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Products",
                newName: "status");
        }
    }
}
