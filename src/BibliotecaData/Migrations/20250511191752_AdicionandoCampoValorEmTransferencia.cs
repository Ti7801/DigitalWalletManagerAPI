using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaData.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoValorEmTransferencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Transferencia",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Transferencia");
        }
    }
}
