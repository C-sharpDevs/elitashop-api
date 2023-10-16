using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElitaShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "Users",
                newName: "UserAvatar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAvatar",
                table: "Users",
                newName: "UserImage");
        }
    }
}
