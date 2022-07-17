using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoLogistica.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferirCarga_Produtos_ProdutoId1",
                table: "ConferirCarga");

            migrationBuilder.DropIndex(
                name: "IX_ConferirCarga_ProdutoId1",
                table: "ConferirCarga");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ConferirCarga");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "ConferirCarga");

            migrationBuilder.AddColumn<Guid>(
                name: "ConferirCargaId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ConferirCargaId",
                table: "Produtos",
                column: "ConferirCargaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ConferirCarga_ConferirCargaId",
                table: "Produtos",
                column: "ConferirCargaId",
                principalTable: "ConferirCarga",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ConferirCarga_ConferirCargaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ConferirCargaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ConferirCargaId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ConferirCarga",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId1",
                table: "ConferirCarga",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ConferirCarga_ProdutoId1",
                table: "ConferirCarga",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferirCarga_Produtos_ProdutoId1",
                table: "ConferirCarga",
                column: "ProdutoId1",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
