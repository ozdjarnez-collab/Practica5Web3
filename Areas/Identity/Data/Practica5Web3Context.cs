using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practica5Web3.Models;

namespace Practica5Web3.Areas.Identity.Data
{
    public class Practica5Web3Context : IdentityDbContext
    {
        public Practica5Web3Context(DbContextOptions<Practica5Web3Context> options)
            : base(options)
        {
        }

        // Tus tablas anteriores
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Estante> Estante { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }

        // NUEVAS tablas para la Parte 2
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración Relación 1:1 (Usuario - Perfil)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Perfil)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Perfil>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Esto quita la advertencia del Precio del medicamento
            modelBuilder.Entity<Medicamento>()
                .Property(m => m.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}