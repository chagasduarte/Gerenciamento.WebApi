using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gerenciamento.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Gerenciamento10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Credito = table.Column<decimal>(type: "numeric", nullable: false),
                    Debito = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    TipoDespesa = table.Column<int>(type: "integer", nullable: false),
                    IsParcelada = table.Column<bool>(type: "boolean", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPaga = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    ContaId = table.Column<int>(type: "integer", nullable: false),
                    DataDebito = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    IsFixo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DespesaId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPaga = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Parcelas");
        }
    }
}
