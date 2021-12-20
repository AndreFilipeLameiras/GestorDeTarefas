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
    public class SistemaProdutividadesController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public SistemaProdutividadesController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: SistemaProdutividades
        public async Task<IActionResult> Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = _context.SistemaProdutividade.Count()
            };

            var project = await _context.SistemaProdutividade
                            .OrderBy(b => b.NomeProjeto)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new SistemProdListViewmodel
                {
                    ProjetoProdutividade = project,
                    PagingInfo = pagingInfo
                }
            );


            
        }

        // GET: SistemaProdutividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaProdutividade = await _context.SistemaProdutividade
                .FirstOrDefaultAsync(m => m.SistemaProdutividadeId == id);
            if (sistemaProdutividade == null)
            {
                return NotFound();
            }

            return View(sistemaProdutividade);
        }

        // GET: SistemaProdutividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SistemaProdutividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SistemaProdutividadeId,NomeProjeto,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim")] SistemaProdutividade sistemaProdutividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistemaProdutividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistemaProdutividade);
        }

        // GET: SistemaProdutividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaProdutividade = await _context.SistemaProdutividade.FindAsync(id);
            if (sistemaProdutividade == null)
            {
                return NotFound();
            }
            return View(sistemaProdutividade);
        }

        // POST: SistemaProdutividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SistemaProdutividadeId,NomeProjeto,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim")] SistemaProdutividade sistemaProdutividade)
        {
            if (id != sistemaProdutividade.SistemaProdutividadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistemaProdutividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemaProdutividadeExists(sistemaProdutividade.SistemaProdutividadeId))
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
            return View(sistemaProdutividade);
        }

        // GET: SistemaProdutividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaProdutividade = await _context.SistemaProdutividade
                .FirstOrDefaultAsync(m => m.SistemaProdutividadeId == id);
            if (sistemaProdutividade == null)
            {
                return NotFound();
            }

            return View(sistemaProdutividade);
        }

        // POST: SistemaProdutividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sistemaProdutividade = await _context.SistemaProdutividade.FindAsync(id);
            _context.SistemaProdutividade.Remove(sistemaProdutividade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemaProdutividadeExists(int id)
        {
            return _context.SistemaProdutividade.Any(e => e.SistemaProdutividadeId == id);
        }
    }
}
