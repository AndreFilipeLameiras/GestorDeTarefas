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
    public class ColaboradorProjetoSprintsController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public ColaboradorProjetoSprintsController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: ColaboradorProjetoSprints
        public async Task<IActionResult> Index()
        {
            var gestorDeTarefasContext = _context.ColaboradorProjetoSprint.Include(c => c.Colaborador).Include(c => c.ProjetoSprintDesign);
            return View(await gestorDeTarefasContext.ToListAsync());
        }

        // GET: ColaboradorProjetoSprints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorProjetoSprint = await _context.ColaboradorProjetoSprint
                .Include(c => c.Colaborador)
                .Include(c => c.ProjetoSprintDesign)
                .FirstOrDefaultAsync(m => m.ID_P_Design == id);
            if (colaboradorProjetoSprint == null)
            {
                return NotFound();
            }

            return View(colaboradorProjetoSprint);
        }

        // GET: ColaboradorProjetoSprints/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Contacto");
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto");
            return View();
        }

        // POST: ColaboradorProjetoSprints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_P_Design,ColaboradorId")] ColaboradorProjetoSprint colaboradorProjetoSprint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradorProjetoSprint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Contacto", colaboradorProjetoSprint.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", colaboradorProjetoSprint.ID_P_Design);
            return View(colaboradorProjetoSprint);
        }

        // GET: ColaboradorProjetoSprints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorProjetoSprint = await _context.ColaboradorProjetoSprint.FindAsync(id);
            if (colaboradorProjetoSprint == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Contacto", colaboradorProjetoSprint.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", colaboradorProjetoSprint.ID_P_Design);
            return View(colaboradorProjetoSprint);
        }

        // POST: ColaboradorProjetoSprints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_P_Design,ColaboradorId")] ColaboradorProjetoSprint colaboradorProjetoSprint)
        {
            if (id != colaboradorProjetoSprint.ID_P_Design)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorProjetoSprint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorProjetoSprintExists(colaboradorProjetoSprint.ID_P_Design))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Contacto", colaboradorProjetoSprint.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", colaboradorProjetoSprint.ID_P_Design);
            return View(colaboradorProjetoSprint);
        }

        // GET: ColaboradorProjetoSprints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorProjetoSprint = await _context.ColaboradorProjetoSprint
                .Include(c => c.Colaborador)
                .Include(c => c.ProjetoSprintDesign)
                .FirstOrDefaultAsync(m => m.ID_P_Design == id);
            if (colaboradorProjetoSprint == null)
            {
                return NotFound();
            }

            return View(colaboradorProjetoSprint);
        }

        // POST: ColaboradorProjetoSprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradorProjetoSprint = await _context.ColaboradorProjetoSprint.FindAsync(id);
            _context.ColaboradorProjetoSprint.Remove(colaboradorProjetoSprint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorProjetoSprintExists(int id)
        {
            return _context.ColaboradorProjetoSprint.Any(e => e.ID_P_Design == id);
        }
    }
}
