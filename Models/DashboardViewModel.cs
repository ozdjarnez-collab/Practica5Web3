using System.Collections.Generic;

namespace Practica5Web3.Models
{
    public class DashboardViewModel
    {
        public int TotalMedicamentos { get; set; }
        public int TotalCategorias { get; set; }
        public int TotalEstantes { get; set; }

        public List<Medicamento> StockBajo { get; set; } = new List<Medicamento>();
        public List<Medicamento> PorVencer { get; set; } = new List<Medicamento>();
        public List<Medicamento> Vencidos { get; set; } = new List<Medicamento>();
    }
}