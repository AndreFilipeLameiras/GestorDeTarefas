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
    public class ProjetoSprintDesignsController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public ProjetoSprintDesignsController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: ProjetoSprintDesigns
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var projetoSearch = _context.ProjetoSprintDesign
               .Where(b => nome == null || b.NomeProjeto.Contains(nome));
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = projetoSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var projeto = await projetoSearch
                            .Include(b => b.ProjetoSprintColaboradores)
                            .OrderBy(b => b.NomeProjeto)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new ProjetoSprintListViewModel
                {
                    ProjetoSprints = projeto,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome
                }
            );
        }

        // GET: ProjetoSprintDesigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetoSprintDesign = await _context.ProjetoSprintDesign
                .FirstOrDefaultAsync(m => m.ID_P_Design == id);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }

            return View(projetoSprintDesign);
        }

        // GET: ProjetoSprintDesigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjetoSprintDesigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_P_Design,NomeProjeto")] ProjetoSprintDesign projetoSprintDesign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projetoSprintDesign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projetoSprintDesign);
        }

        // GET: ProjetoSprintDesigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetoSprintDesign = await _context.ProjetoSprintDesign.FindAsync(id);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }
            return View(projetoSprintDesign);
        }

        // POST: ProjetoSprintDesigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_P_Design,NomeProjeto")] ProjetoSprintDesign projetoSprintDesign)
        {
            if (id != projetoSprintDesign.ID_P_Design)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projetoSprintDesign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoSprintDesignExists(projetoSprintDesign.ID_P_Design))
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
            return View(projetoSprintDesign);
        }

        // GET: ProjetoSprintDesigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetoSprintDesign = await _context.ProjetoSprintDesign
                .FirstOrDefaultAsync(m => m.ID_P_Design == id);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }

            return View(projetoSprintDesign);
        }

        // POST: ProjetoSprintDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetoSprintDesign = await _context.ProjetoSprintDesign.FindAsync(id);
            _context.ProjetoSprintDesign.Remove(projetoSprintDesign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoSprintDesignExists(int id)
        {
            return _context.ProjetoSprintDesign.Any(e => e.ID_P_Design == id);
        }


        /////////////////////Adicionar Colaborador/////////////////////

        public async Task<IActionResult> AdicionarColaborador()
        {
            int id=0;
            int id2 = 0;
            ColaboradorProjetoSprint colaboradorProjetoSprint = new ColaboradorProjetoSprint();
            id = colaboradorProjetoSprint.ID_P_Design;
            id2 = colaboradorProjetoSprint.ColaboradorId;

            if (id == null)
            {
                return NotFound();
            }

            var projetoSprintDesign = await _context.ColaboradorProjetoSprint.FindAsync(id,id2);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }

            
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name");
            
            return View(colaboradorProjetoSprint);
        }

        // POST: ProjetoSprintDesigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarColaborador(int id, [Bind("ID_P_Design,ColaboradorId")] ColaboradorProjetoSprint projetoSprintDesign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projetoSprintDesign);
                await _context.SaveChangesAsync();
                //   return RedirectToAction(nameof(Index));

                ViewBag.Name = "Colaborador Adicionado";
                ViewBag.Message = "Colaborador sucessfully added.";
                return View("Success");
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", projetoSprintDesign.ColaboradorId);
            return View(projetoSprintDesign);
        }

    }
}
