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
    public class Colaborador_SprintDesignController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public Colaborador_SprintDesignController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Colaborador_SprintDesign
        public async Task<IActionResult> Index()
        {
            var gestorDeTarefasContext = _context.Colaborador_SprintDesign.Include(c => c.Colaborador).Include(c => c.ProjetoSprintDesign);
            return View(await gestorDeTarefasContext.ToListAsync());
        }

        // GET: Colaborador_SprintDesign/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador_SprintDesign = await _context.Colaborador_SprintDesign
                .Include(c => c.Colaborador)
                .Include(c => c.ProjetoSprintDesign)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador_SprintDesign == null)
            {
                return NotFound();
            }

            return View(colaborador_SprintDesign);
        }

        // GET: Colaborador_SprintDesign/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name");
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto");
            return View();
        }

        // POST: Colaborador_SprintDesign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,ID_P_Design,DataInicio,DataFim")] Colaborador_SprintDesign colaborador_SprintDesign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador_SprintDesign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", colaborador_SprintDesign.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", colaborador_SprintDesign.ID_P_Design);
            return View(colaborador_SprintDesign);
        }

        // GET: Colaborador_SprintDesign/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador_SprintDesign = await _context.Colaborador_SprintDesign.FindAsync(id);
            if (colaborador_SprintDesign == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", colaborador_SprintDesign.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", colaborador_SprintDesign.ID_P_Design);
            return View(colaborador_SprintDesign);
        }

        // POST: Colaborador_SprintDesign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,ID_P_Design,DataInicio,DataFim")] Colaborador_SprintDesign colaborador_SprintDesign)
        {
            if (id != colaborador_SprintDesign.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador_SprintDesign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Colaborador_SprintDesignExists(colaborador_SprintDesign.ColaboradorId))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", colaborador_SprintDesign.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", colaborador_SprintDesign.ID_P_Design);
            return View(colaborador_SprintDesign);
        }

        // GET: Colaborador_SprintDesign/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador_SprintDesign = await _context.Colaborador_SprintDesign
                .Include(c => c.Colaborador)
                .Include(c => c.ProjetoSprintDesign)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador_SprintDesign == null)
            {
                return NotFound();
            }

            return View(colaborador_SprintDesign);
        }

        // POST: Colaborador_SprintDesign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaborador_SprintDesign = await _context.Colaborador_SprintDesign.FindAsync(id);
            _context.Colaborador_SprintDesign.Remove(colaborador_SprintDesign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Colaborador_SprintDesignExists(int id)
        {
            return _context.Colaborador_SprintDesign.Any(e => e.ColaboradorId == id);
        }
    }
}
