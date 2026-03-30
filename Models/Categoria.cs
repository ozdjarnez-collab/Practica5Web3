using System.ComponentModel.DataAnnotations;

namespace Practica5Web3.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }
    }
}