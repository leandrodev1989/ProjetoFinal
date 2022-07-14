using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoLogistica.Migrations
{
    public partial class Retirando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Conferentes_ConferenteId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ConferentId",
                table: "Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConferenteId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Conferentes_ConferenteId",
                table: "Produtos",
                column: "ConferenteId",
                principalTable: "Conferentes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Conferentes_ConferenteId",
                table: "Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConferenteId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConferentId",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Conferentes_ConferenteId",
                table: "Produtos",
                column: "ConferenteId",
                principalTable: "Conferentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
