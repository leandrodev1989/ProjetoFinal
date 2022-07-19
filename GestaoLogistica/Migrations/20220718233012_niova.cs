using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoLogistica.Migrations
{
    public partial class niova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TipoEntSai",
                table: "ConferirCarga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConferirCargaId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoEntSai",
                table: "ConferirCarga",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
