using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica5Web3.Areas.Identity.Data;
using Practica5Web3.Models;

namespace Practica5Web3.Controllers
{
    [Authorize(Roles = "Administrador,Farmaceutico")]
    public class MedicamentoesController : Controller
    {
        private readonly Practica5Web3Context _context;

        public MedicamentoesController(Practica5Web3Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var practica5Web3Context = _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante);

            return View(await practica5Web3Context.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre");
            ViewData["EstanteId"] = new SelectList(_context.Estante, "Id", "Nombre");
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Stock,FechaVencimiento,CategoriaId,EstanteId,Descripcion,Estado")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre", medicamento.CategoriaId);
            ViewData["EstanteId"] = new SelectList(_context.Estante, "Id", "Nombre", medicamento.EstanteId);
            return View(medicamento);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre", medicamento.CategoriaId);
            ViewData["EstanteId"] = new SelectList(_context.Estante, "Id", "Nombre", medicamento.EstanteId);
            return View(medicamento);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Stock,FechaVencimiento,CategoriaId,EstanteId,Descripcion,Estado")] Medicamento medicamento)
        {
            if (id != medicamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre", medicamento.CategoriaId);
            ViewData["EstanteId"] = new SelectList(_context.Estante, "Id", "Nombre", medicamento.EstanteId);
            return View(medicamento);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .Include(m => m.Categoria)
                .Include(m => m.Estante)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento != null)
            {
                _context.Medicamento.Remove(medicamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
            return _context.Medicamento.Any(e => e.Id == id);
        }
    }
}