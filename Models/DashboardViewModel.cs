using System.Collections.Generic;

namespace Practica5Web3.Models
{
    public class DashboardViewModel
    {
        public int TotalMedicamentos { get; set; }
        public int TotalCategorias { get; set; }
        public int TotalEstantes { get; set; }
        public int TotalClientes { get; set; }
        public int TotalPedidos { get; set; }
        public decimal TotalVentasEstimadas { get; set; }

        public List<Medicamento> StockBajo { get; set; } = new();
        public List<Medicamento> PorVencer { get; set; } = new();
        public List<Medicamento> Vencidos { get; set; } = new();
        public List<Medicamento> Disponibles { get; set; } = new();
        public List<Pedido> PedidosRecientes { get; set; } = new();
    }
}
