using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica5Web3.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Range(0, 999999, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }

        [Display(Name = "Estante")]
        public int EstanteId { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }

        [ForeignKey("EstanteId")]
        public Estante? Estante { get; set; }
    }
}