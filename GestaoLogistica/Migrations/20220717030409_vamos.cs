using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoLogistica.Migrations
{
    public partial class vamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoProduto",
                table: "ConferirCarga",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProduto",
                table: "ConferirCarga");
        }
    }
}
