using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica5Web3.Models
{
    public class Perfil
    {
        [Key]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; } // Esta será la PK y la FK al mismo tiempo

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Phone(ErrorMessage = "Teléfono inválido")]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        // Propiedad de navegación inversa
        public virtual Usuario? Usuario { get; set; }
    }
}