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
    public class IdiomasController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public IdiomasController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Idiomas
        public async Task<IActionResult> Index(string name, int page = 1)
        {
            var idiomaSearch = _context.Idioma
                .Where(b => name == null || b.NomeIdioma.Contains(name));

            var pagingInfo = new PagingInfo 
            {
                CurrentPage = page,
                TotalItems = idiomaSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }


            var idiomas = await idiomaSearch
                            .OrderBy(b => b.NomeIdioma)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new IdiomaListViewModel
                {
                    Idiomas = idiomas,
                    PagingInfo = pagingInfo,
                    TitleSearched = name
                }
                );
        }

        // GET: Idiomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idioma
                .FirstOrDefaultAsync(m => m.IdiomaId == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // GET: Idiomas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Idiomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdiomaId,NomeIdioma")] Idioma idioma)
        {
            var memberUnique = _context.Idioma.Where(m => m.NomeIdioma.Equals(idioma.NomeIdioma)).Count();

            if (memberUnique != 0)
            {
                ModelState.AddModelError("NomeIdioma", "Este idioma já existe");
            }

            if (ModelState.IsValid)
            {
                _context.Add(idioma);
                await _context.SaveChangesAsync();
                

                ViewBag.Title = "Idioma adicionado";
                ViewBag.Message = "Idioma adicionado com sucesso.";
                return View("Success");

            }
            return View(idioma);
        }

        // GET: Idiomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idioma.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }
            return View(idioma);
        }

        // POST: Idiomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdiomaId,NomeIdioma")] Idioma idioma)
        {
            var memberUnique = _context.Idioma.Where(m => m.NomeIdioma.Equals(idioma.NomeIdioma) && m.IdiomaId != idioma.IdiomaId).Count();

            if (memberUnique != 0)
            {
                ModelState.AddModelError("NomeIdioma", "Este idioma já existe");
            }

            if (id != idioma.IdiomaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idioma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaExists(idioma.IdiomaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Title = "Idioma editado";
                ViewBag.Message = "Idioma editado com sucesso.";
                return View("Success");
            }
            return View(idioma);
        }

        // GET: Idiomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idioma
                .FirstOrDefaultAsync(m => m.IdiomaId == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
            }
            catch (DbUpdateException /* ex */)
            {

                return View("MensagemErro");
            }
        }

        // POST: Idiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var idioma = await _context.Idioma.FindAsync(id);
            _context.Idioma.Remove(idioma);
            await _context.SaveChangesAsync();

            ViewBag.Title = "Idioma eliminado";
            ViewBag.Message = "Idioma elimindo com sucesso.";
            return View("Success");
            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Ups! Este idioma não pode ser apagado.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }

        private bool IdiomaExists(int id)
        {
            return _context.Idioma.Any(e => e.IdiomaId == id);
        }
    }
}
