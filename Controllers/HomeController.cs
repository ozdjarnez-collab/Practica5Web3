using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica5Web3.Areas.Identity.Data;
using Practica5Web3.Models;

namespace Practica5Web3.Controllers
{
    [Authorize(Roles = "Administrador,Farmaceutico,Cliente")]
    public class HomeController : Controller
    {
        private readonly Practica5Web3Context _context;

        public HomeController(Practica5Web3Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hoy = DateTime.Now.Date;
            var limite30 = hoy.AddDays(30);

            var medicamentosStockBajo = await _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante)
                .Where(m => m.Stock <= 5)
                .OrderBy(m => m.Stock)
                .ToListAsync();

            var medicamentosPorVencer = await _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante)
                .Where(m => m.FechaVencimiento > hoy && m.FechaVencimiento <= limite30)
                .OrderBy(m => m.FechaVencimiento)
                .ToListAsync();

            var medicamentosVencidos = await _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante)
                .Where(m => m.FechaVencimiento < hoy)
                .OrderBy(m => m.FechaVencimiento)
                .ToListAsync();

            var medicamentosDisponibles = await _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante)
                .Where(m => m.Estado == true && m.Stock > 0)
                .OrderBy(m => m.Nombre)
                .ToListAsync();

            var pedidosRecientes = await _context.Pedido
                .Include(p => p.Cliente)
                .OrderByDescending(p => p.Id)
                .Take(5)
                .ToListAsync();

            var dashboard = new DashboardViewModel
            {
                TotalMedicamentos = await _context.Medicamento.CountAsync(),
                TotalCategorias = await _context.Categoria.CountAsync(),
                TotalEstantes = await _context.Estante.CountAsync(),
                TotalClientes = await _context.Cliente.CountAsync(),
                TotalPedidos = await _context.Pedido.CountAsync(),
                TotalVentasEstimadas = await _context.Medicamento
                    .Where(m => m.Stock > 0)
                    .SumAsync(m => m.Precio * m.Stock),

                StockBajo = medicamentosStockBajo,
                PorVencer = medicamentosPorVencer,
                Vencidos = medicamentosVencidos,
                Disponibles = medicamentosDisponibles,
                PedidosRecientes = pedidosRecientes
            };

            return View(dashboard);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}