using System.ComponentModel.DataAnnotations;

namespace Practica5Web3.Models
{
    public class Estante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria")]
        public string Ubicacion { get; set; }

        public string? Descripcion { get; set; }
    }
}