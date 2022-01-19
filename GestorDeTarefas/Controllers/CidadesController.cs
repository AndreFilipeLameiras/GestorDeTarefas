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
    public class CidadesController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public CidadesController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Cidade
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var cidadeSearch = _context.Cidade
              .Where(b => nome == null || b.Nome_Cidade.Contains(nome));
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = cidadeSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var cidades = await cidadeSearch
                            .OrderBy(b => b.Nome_Cidade)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new CidadeListViewModel
                {
                    Cidades = cidades,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome
                }
            );
        }

        // GET: Cidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .SingleOrDefaultAsync(b => b.CidadeId == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidade/Create
        public IActionResult Create()
        {

            return View();

        }

        // POST: Cidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CidadeId,Nome_Cidade")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Cidade Adicionada";
                ViewBag.Message = "Cidade adicionada com sucesso.";
                return View("Success");
            }
            return View(cidade);
        }

        // GET: Cidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }

        // POST: Cidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CidadeId,Nome_Cidade")] Cidade cidade)
        {
            if (id != cidade.CidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.CidadeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Title = "Cidade editada";
                ViewBag.Message = "Cidade alterada com sucesso.";
                return View("Success");
            }
            return View(cidade);
        }

        // GET: Cidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cidade = await _context.Cidade
                    .FirstOrDefaultAsync(m => m.CidadeId == id);
                if (cidade == null)
                {
                    return NotFound();
                }

                return View(cidade);
            }
            catch (DbUpdateException /* ex */)
            {

                return View("MensagemErro");
            }
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cidade = await _context.Cidade.FindAsync(id);
                _context.Cidade.Remove(cidade);
                await _context.SaveChangesAsync();

                ViewBag.Title = "Cidade Apagada";
                ViewBag.Message = "Cidade apagada com sucesso.";
                return View("Success");
            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Ups! Esta Cidade não pode ser apagada.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidade.Any(e => e.CidadeId == id);
        }
    }
}
