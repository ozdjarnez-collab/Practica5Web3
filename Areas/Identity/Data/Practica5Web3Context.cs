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

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Estante> Estante { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
    }
}