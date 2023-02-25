using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mynewapp.Migrations
{
    /// <inheritdoc />
    public partial class AddLastNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "People",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "People",
                newName: "Name");
        }
    }
}
