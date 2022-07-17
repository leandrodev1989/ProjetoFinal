using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoLogistica.Migrations
{
    public partial class saida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Saida",
                table: "ConferirCarga",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saida",
                table: "ConferirCarga");
        }
    }
}
