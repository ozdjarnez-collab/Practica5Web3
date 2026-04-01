using System.ComponentModel.DataAnnotations;

namespace Practica5Web3.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        // Un cliente tiene muchos pedidos
        public virtual ICollection<Pedido>? Pedidos { get; set; }
    }
}