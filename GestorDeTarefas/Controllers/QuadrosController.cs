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
    public class QuadrosController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public QuadrosController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Quadros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quadros.ToListAsync());
        }

        // GET: Quadros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadros = await _context.Quadros
                .FirstOrDefaultAsync(m => m.QuadrosId == id);
            if (quadros == null)
            {
                return NotFound();
            }

            return View(quadros);
        }

        // GET: Quadros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quadros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuadrosId,Name")] Quadros quadros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quadros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quadros);
        }

        // GET: Quadros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadros = await _context.Quadros.FindAsync(id);
            if (quadros == null)
            {
                return NotFound();
            }
            return View(quadros);
        }

        // POST: Quadros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuadrosId,Name")] Quadros quadros)
        {
            if (id != quadros.QuadrosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quadros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuadrosExists(quadros.QuadrosId))
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
            return View(quadros);
        }

        // GET: Quadros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadros = await _context.Quadros
                .FirstOrDefaultAsync(m => m.QuadrosId == id);
            if (quadros == null)
            {
                return NotFound();
            }

            return View(quadros);
        }

        // POST: Quadros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quadros = await _context.Quadros.FindAsync(id);
            _context.Quadros.Remove(quadros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuadrosExists(int id)
        {
            return _context.Quadros.Any(e => e.QuadrosId == id);
        }
    }
}
