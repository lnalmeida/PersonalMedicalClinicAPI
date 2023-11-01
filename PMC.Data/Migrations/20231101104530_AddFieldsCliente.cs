using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Clientes",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Clientes");
        }
    }
}
