using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciamento.Domain.Migrations
{
    /// <inheritdoc />
    public partial class migration20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vencimento",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "DataCompra",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "AnoVencimento",
                table: "Parcelas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaVencimento",
                table: "Parcelas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MesVencimento",
                table: "Parcelas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnoCompra",
                table: "Despesas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaCompra",
                table: "Despesas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MesCompra",
                table: "Despesas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoVencimento",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "DiaVencimento",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "MesVencimento",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "AnoCompra",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "DiaCompra",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "MesCompra",
                table: "Despesas");

            migrationBuilder.AddColumn<DateTime>(
                name: "Vencimento",
                table: "Parcelas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCompra",
                table: "Despesas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
