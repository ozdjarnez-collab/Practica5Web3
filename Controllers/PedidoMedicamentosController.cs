using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica5Web3.Areas.Identity.Data;
using Practica5Web3.Models;

namespace Practica5Web3.Controllers
{
    public class PedidoMedicamentosController : Controller
    {
        private readonly Practica5Web3Context _context;

        public PedidoMedicamentosController(Practica5Web3Context context)
        {
            _context = context;
        }

        // GET: PedidoMedicamentos
        public async Task<IActionResult> Index()
        {
            var practica5Web3Context = _context.PedidoMedicamento.Include(p => p.Medicamento).Include(p => p.Pedido);
            return View(await practica5Web3Context.ToListAsync());
        }

        // GET: PedidoMedicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pedidoMedicamento = await _context.PedidoMedicamento
                .Include(p => p.Medicamento)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoMedicamento == null) return NotFound();

            return View(pedidoMedicamento);
        }

        // GET: PedidoMedicamentos/Create
        // AJUSTE: Ahora recibe pedidoId para pre-seleccionarlo
        public IActionResult Create(int? pedidoId)
        {
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "Id", "Nombre");

            if (pedidoId != null)
            {
                ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoId);
            }
            else
            {
                ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id");
            }

            return View();
        }

        // POST: PedidoMedicamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,MedicamentoId,Cantidad")] PedidoMedicamento pedidoMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoMedicamento);
                await _context.SaveChangesAsync();

                // Redirige al detalle del Pedido para ver el "carrito" actualizado
                return RedirectToAction("Details", "Pedidos", new { id = pedidoMedicamento.PedidoId });
            }
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "Id", "Nombre", pedidoMedicamento.MedicamentoId);
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoMedicamento.PedidoId);
            return View(pedidoMedicamento);
        }

        // GET: PedidoMedicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pedidoMedicamento = await _context.PedidoMedicamento.FindAsync(id);
            if (pedidoMedicamento == null) return NotFound();
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "Id", "Nombre", pedidoMedicamento.MedicamentoId);
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoMedicamento.PedidoId);
            return View(pedidoMedicamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,MedicamentoId,Cantidad")] PedidoMedicamento pedidoMedicamento)
        {
            if (id != pedidoMedicamento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoMedicamentoExists(pedidoMedicamento.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction("Details", "Pedidos", new { id = pedidoMedicamento.PedidoId });
            }
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamento, "Id", "Nombre", pedidoMedicamento.MedicamentoId);
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", pedidoMedicamento.PedidoId);
            return View(pedidoMedicamento);
        }

        // GET: PedidoMedicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pedidoMedicamento = await _context.PedidoMedicamento
                .Include(p => p.Medicamento)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoMedicamento == null) return NotFound();

            return View(pedidoMedicamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoMedicamento = await _context.PedidoMedicamento.FindAsync(id);
            if (pedidoMedicamento != null)
            {
                int pedidoId = pedidoMedicamento.PedidoId; // Guardamos el ID para regresar
                _context.PedidoMedicamento.Remove(pedidoMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Pedidos", new { id = pedidoId });
            }

            return RedirectToAction("Index", "Pedidos");
        }

        private bool PedidoMedicamentoExists(int id)
        {
            return _context.PedidoMedicamento.Any(e => e.Id == id);
        }
    }
}