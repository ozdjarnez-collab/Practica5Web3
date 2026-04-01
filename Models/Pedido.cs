using System.ComponentModel.DataAnnotations;

namespace Practica5Web3.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Display(Name = "Fecha del Pedido")]
        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [DataType(DataType.Currency)]
        public decimal Total { get; set; } // Se calculará automático

        // Relación con Cliente
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}