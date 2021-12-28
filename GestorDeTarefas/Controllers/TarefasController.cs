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
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index(string nome,int page = 1)
        {
            var tarefaSearch = _context.Tarefas
               .Where(b => nome == null || b.Nome.Contains(nome));
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems =tarefaSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var tarefa = await tarefaSearch
                            .Include(b => b.Colaborador)
                            .Include(b => b.ProjetoSprint)
                            .Include(b => b.EstadoProjeto)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new TarefaListViewModel
                {
                    Tarefass = tarefa,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome
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
                .Include(t => t.ProjetoSprint)
                .Include(t => t.EstadoProjeto)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // GET: Tarefas/Create
       // [Authorize (Roles = "product_manager")]
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name");
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto");
         
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome, DataPrevistaInicio, DataDefinitivaInicio, DataPrevistaFim, DataDefinitivaFim, ColaboradorId,ID_P_Design,Id_Estado")] Tarefas tarefas)
        {

            if (tarefas.DataPrevistaFim < tarefas.DataDefinitivaInicio || tarefas.DataPrevistaFim < tarefas.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }
            if (ModelState.IsValid)
            {
                if(tarefas.DataPrevistaInicio < tarefas.DataDefinitivaInicio)
                {
                    tarefas.Id_Estado=1;
                }
                if (tarefas.DataPrevistaInicio >= tarefas.DataDefinitivaInicio)
                {
                    tarefas.Id_Estado = 2;
                }
                _context.Add(tarefas);
                await _context.SaveChangesAsync();
             //   return RedirectToAction(nameof(Index));

                ViewBag.Title = "Tarefa adicionada";
                ViewBag.Message = "Tarefa adicionada com sucesso!!!";
                return View("Success");
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", tarefas.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", tarefas.ID_P_Design);
          
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
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", tarefas.ID_P_Design);
            ViewData["Id_Estado"] = new SelectList(_context.EstadoProjeto, "Id_Estado", "NomeEstado", tarefas.Id_Estado);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim,ColaboradorId,ID_P_Design,Id_Estado")] Tarefas tarefas)
        {
            if (id != tarefas.Id)
            {
                return NotFound();
            }

            if (tarefas.DataPrevistaFim < tarefas.DataDefinitivaInicio || tarefas.DataPrevistaFim < tarefas.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }

            if (tarefas.DataDefinitivaFim < tarefas.DataDefinitivaInicio)
            {
                ModelState.AddModelError("DataDefinitivaFim", "Data Efetiva de fim não deve ser " +
                    "menor do que a data efetiva de inicio");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tarefas.DataPrevistaInicio < tarefas.DataDefinitivaInicio)
                    {
                        tarefas.Id_Estado = 1;
                    }
                    if (tarefas.DataPrevistaInicio >= tarefas.DataDefinitivaInicio)
                    {
                        tarefas.Id_Estado = 2;
                    }

                    if (tarefas.DataDefinitivaFim !=null)
                    {
                        tarefas.Id_Estado = 3;
                    }
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

                ViewBag.Title = "Tarefa Alterada";
                ViewBag.Message = "Tarefa alterada com sucesso!!!.";
                return View("Success");
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", tarefas.ColaboradorId);
            ViewData["ID_P_Design"] = new SelectList(_context.ProjetoSprintDesign, "ID_P_Design", "NomeProjeto", tarefas.ID_P_Design);
            ViewData["Id_Estado"] = new SelectList(_context.EstadoProjeto, "Id_Estado", "NomeEstado", tarefas.Id_Estado);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tarefas = await _context.Tarefas
                .Include(t => t.Colaborador)
                .Include(t => t.ProjetoSprint)
                .Include(t => t.EstadoProjeto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
            }
            catch (DbUpdateException /* ex */)
            {

                return View("MensagemErro");
            }
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tarefas = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefas);
            await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            ViewBag.Title = "Tarefa Apagada";
            ViewBag.Message = "Tarefa apagada com sucesso!!!";
            return View("Success");
            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Ups! Esta tarefa não pode ser apagada.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }


        public IActionResult Success()
        {
            return View();
        }

        public IActionResult MensagemErro()
        {
            return View();
        }

        [Authorize(Roles = "customer")]
        public string Buy(int id)
        {
            var username = User.Identity.Name;

            //var customer = _context.Customer.SingleOrDefault(c => c.Email == username);
            //if (customer == null) return NotFound();

            // ...

            return "The option for customers to buy books will be added soon !!!";
        }

        private bool TarefasExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
