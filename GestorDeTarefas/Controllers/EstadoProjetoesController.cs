using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeTarefas.Data;
using GestorDeTarefas.Models;

namespace GestorDeTarefas.Controllers
{
    public class EstadoProjetoesController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public EstadoProjetoesController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: EstadoProjetoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoProjeto.ToListAsync());
        }

        // GET: EstadoProjetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoProjeto = await _context.EstadoProjeto
                .FirstOrDefaultAsync(m => m.Id_Estado == id);
            if (estadoProjeto == null)
            {
                return NotFound();
            }

            return View(estadoProjeto);
        }

        // GET: EstadoProjetoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoProjetoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Estado,NomeEstado")] EstadoProjeto estadoProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoProjeto);
        }

        // GET: EstadoProjetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoProjeto = await _context.EstadoProjeto.FindAsync(id);
            if (estadoProjeto == null)
            {
                return NotFound();
            }
            return View(estadoProjeto);
        }

        // POST: EstadoProjetoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Estado,NomeEstado")] EstadoProjeto estadoProjeto)
        {
            if (id != estadoProjeto.Id_Estado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoProjetoExists(estadoProjeto.Id_Estado))
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
            return View(estadoProjeto);
        }

        // GET: EstadoProjetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoProjeto = await _context.EstadoProjeto
                .FirstOrDefaultAsync(m => m.Id_Estado == id);
            if (estadoProjeto == null)
            {
                return NotFound();
            }

            return View(estadoProjeto);
        }

        // POST: EstadoProjetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoProjeto = await _context.EstadoProjeto.FindAsync(id);
            _context.EstadoProjeto.Remove(estadoProjeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoProjetoExists(int id)
        {
            return _context.EstadoProjeto.Any(e => e.Id_Estado == id);
        }
    }
}
