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
    public class EstantesController : Controller
    {
        private readonly Practica5Web3Context _context;

        public EstantesController(Practica5Web3Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Estante.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estante = await _context.Estante
                .FirstOrDefaultAsync(m => m.Id == id);

            if (estante == null)
            {
                return NotFound();
            }

            return View(estante);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ubicacion,Descripcion")] Estante estante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estante);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estante = await _context.Estante.FindAsync(id);
            if (estante == null)
            {
                return NotFound();
            }
            return View(estante);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ubicacion,Descripcion")] Estante estante)
        {
            if (id != estante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstanteExists(estante.Id))
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
            return View(estante);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estante = await _context.Estante
                .FirstOrDefaultAsync(m => m.Id == id);

            if (estante == null)
            {
                return NotFound();
            }

            return View(estante);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estante = await _context.Estante.FindAsync(id);
            if (estante != null)
            {
                _context.Estante.Remove(estante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstanteExists(int id)
        {
            return _context.Estante.Any(e => e.Id == id);
        }
    }
}