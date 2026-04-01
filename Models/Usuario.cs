using System.ComponentModel.DataAnnotations;

namespace Practica5Web3.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Email { get; set; }

        // Propiedad de navegación: Un usuario tiene UN perfil
        public virtual Perfil? Perfil { get; set; }
    }
}