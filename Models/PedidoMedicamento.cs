namespace Practica5Web3.Models
{
    public class PedidoMedicamento
    {
        public int Id { get; set; }

        // Clave foránea Pedido
        public int PedidoId { get; set; }
        public virtual Pedido? Pedido { get; set; }

        // Clave foránea Medicamento
        public int MedicamentoId { get; set; }
        public virtual Medicamento? Medicamento { get; set; }

        public int Cantidad { get; set; }
    }
}