using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciamento.Domain.Migrations
{
    /// <inheritdoc />
    public partial class migration41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Despesas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Despesas");
        }
    }
}
