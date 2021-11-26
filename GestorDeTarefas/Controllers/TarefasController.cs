using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeTarefas.Data;
using GestorDeTarefas.Models;
using GestorDeTarefas.ViewModels;

namespace GestorDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public TarefasController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = _context.Tarefas.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var tarefa = await _context.Tarefas
                            .Include(b => b.Colaborador)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new TarefaListViewModel
                {
                    Tarefass = tarefa,
                    PagingInfo = pagingInfo
                }
            );
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Colaborador)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataInicio,DataFim,ColaboradorId")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefas);
                await _context.SaveChangesAsync();
             //   return RedirectToAction(nameof(Index));

                ViewBag.Name = "Tarefa added";
                ViewBag.Message = "Tarefa sucessfully added.";
                return View("Success");
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", tarefas.ColaboradorId);
            return View(tarefas);

            
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", tarefas.ColaboradorId);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataInicio,DataFim,ColaboradorId")] Tarefas tarefas)
        {
            if (id != tarefas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasExists(tarefas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));

                ViewBag.Name = "Tarefa adited";
                ViewBag.Message = "Tarefa sucessfully altered.";
                return View("Success");
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", tarefas.ColaboradorId);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Colaborador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefasExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
