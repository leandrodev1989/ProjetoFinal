using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoLogistica.Migrations
{
    public partial class sempre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_Id",
                table: "Enderecos");

            migrationBuilder.AddColumn<Guid>(
                name: "LogAuditoriaId",
                table: "Conferentes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnderecoFornecedor",
                columns: table => new
                {
                    EndereçoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoFornecedor", x => new { x.EndereçoId, x.FornecedorId });
                    table.ForeignKey(
                        name: "FK_EnderecoFornecedor_Enderecos_EndereçoId",
                        column: x => x.EndereçoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoFornecedor_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conferentes_LogAuditoriaId",
                table: "Conferentes",
                column: "LogAuditoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoFornecedor_FornecedorId",
                table: "EnderecoFornecedor",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferentes_LogAuditoria_LogAuditoriaId",
                table: "Conferentes",
                column: "LogAuditoriaId",
                principalTable: "LogAuditoria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferentes_LogAuditoria_LogAuditoriaId",
                table: "Conferentes");

            migrationBuilder.DropTable(
                name: "EnderecoFornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Conferentes_LogAuditoriaId",
                table: "Conferentes");

            migrationBuilder.DropColumn(
                name: "LogAuditoriaId",
                table: "Conferentes");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_Id",
                table: "Enderecos",
                column: "Id",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
