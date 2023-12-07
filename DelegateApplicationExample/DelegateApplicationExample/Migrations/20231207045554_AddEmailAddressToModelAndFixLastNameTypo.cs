using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelegateApplicationExample.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAddressToModelAndFixLastNameTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LaastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "LaastName");
        }
    }
}
