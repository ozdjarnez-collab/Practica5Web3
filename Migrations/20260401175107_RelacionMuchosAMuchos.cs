using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica5Web3.Migrations
{
    /// <inheritdoc />
    public partial class RelacionMuchosAMuchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidoMedicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoMedicamento_Medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoMedicamento_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoMedicamento_MedicamentoId",
                table: "PedidoMedicamento",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoMedicamento_PedidoId",
                table: "PedidoMedicamento",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoMedicamento");
        }
    }
}
