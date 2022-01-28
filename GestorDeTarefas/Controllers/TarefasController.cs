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
        [Authorize(Roles = "gestor,colaborador,admin")]
        public async Task<IActionResult> Index(string nome,int page = 1)
        {
            var tarefaSearch = _context.Tarefas
               .Where(b => nome == null || b.Nome.Contains(nome) || b.EstadoTarefa.Contains(nome)
               || b.Colaborador.Name.Contains(nome) || b.ProjetoSprintDesign.NomeProjeto.Contains(nome) ||
               b.SistemaProdutividade.NomeProjeto.Contains(nome));
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
                            .Include(b => b.ProjetoSprintDesign)
                            .Include(b=> b.SistemaProdutividade)
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
        [Authorize(Roles = "gestor,colaborador,admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Colaborador)
                .Include(t => t.ProjetoSprintDesign)
                .Include(t => t.SistemaProdutividade)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // GET: Tarefas/Create
       [Authorize (Roles = "gestor")]
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador.OrderBy(b=>b.Name), "ColaboradorId", "Name");
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign.OrderBy(b => b.NomeProjeto), "ProjetoSprintDesignID", "NomeProjeto");
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade.OrderBy(b => b.NomeProjeto), "SistemaProdutividadeId", "NomeProjeto");

            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "gestor")]
        public async Task<IActionResult> Create([Bind("Id, Nome, DataPrevistaInicio, DataDefinitivaInicio, DataPrevistaFim, DataDefinitivaFim, ColaboradorId,ProjetoSprintDesignID,SistemaProdutividadeId")] Tarefas tarefas)
        {


            if (tarefas.DataPrevistaFim < tarefas.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista de inicio");
            }
            if(tarefas.SistemaProdutividadeId == null && tarefas.ProjetoSprintDesignID == null)
            {
                ModelState.AddModelError("", "Por favor adicione um projeto para esta tarefa!!");
                
            }
            if(tarefas.SistemaProdutividadeId != null && tarefas.ProjetoSprintDesignID != null)
            {
                ModelState.AddModelError("", "Por favor adicione apenas um projeto para esta tarefa!!");
                
            }

            if (ModelState.IsValid)
            {
                if(tarefas.DataDefinitivaInicio==null && tarefas.DataDefinitivaFim == null)
                {
                    tarefas.EstadoTarefa = "";
                }
                _context.Add(tarefas);
                await _context.SaveChangesAsync();
             //   return RedirectToAction(nameof(Index));

                ViewBag.Title = "Tarefa adicionada";
                ViewBag.Message = "Tarefa adicionada com sucesso!!!";
                return View("Success");
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Name", tarefas.ColaboradorId);
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign, "ProjetoSprintDesignID", "NomeProjeto", tarefas.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade, "SistemaProdutividadeId", "NomeProjeto", tarefas.SistemaProdutividadeId);

            return View(tarefas);

            
        }

        // GET: Tarefas/Edit/5
        [Authorize(Roles = "gestor,colaborador")]
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
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign, "ProjetoSprintDesignID", "NomeProjeto", tarefas.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade, "SistemaProdutividadeId", "NomeProjeto", tarefas.SistemaProdutividadeId);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "gestor,colaborador")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataPrevistaInicio,DataDefinitivaInicio," +
            "DataPrevistaFim,DataDefinitivaFim,ColaboradorId,ProjetoSprintDesignID,SistemaProdutividadeId")] Tarefas tarefas)
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
            if (tarefas.DataDefinitivaInicio ==null && tarefas.DataDefinitivaFim != null)
            {
                ModelState.AddModelError("DataDefinitivaInicio", "Por favor, adicione a data definitiva de inicio");
                    
            }

            if (tarefas.DataDefinitivaFim < tarefas.DataDefinitivaInicio)
            {
                ModelState.AddModelError("DataDefinitivaFim", "Data Efetiva de fim não deve ser " +
                    "menor do que a data efetiva de inicio");
            }
            if (tarefas.SistemaProdutividadeId == null && tarefas.ProjetoSprintDesignID == null)
            {
                ModelState.AddModelError("", "Por favor adicione a tarefa a pelo menos um projeto!!");
            }
            if (tarefas.SistemaProdutividadeId == null && tarefas.ProjetoSprintDesignID == null ||
                tarefas.SistemaProdutividadeId != null && tarefas.ProjetoSprintDesignID != null)
            {
                ModelState.AddModelError("", "Por favor adicione esta tarefa a um projeto!!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tarefas.DataPrevistaInicio < tarefas.DataDefinitivaInicio)
                    {
                        tarefas.EstadoTarefa = "Em atraso";
                        
                    }
                    if (tarefas.DataPrevistaInicio >= tarefas.DataDefinitivaInicio)
                    {
                        tarefas.EstadoTarefa = "Dentro do prazo";
                    }

                    if (tarefas.DataPrevistaFim < tarefas.DataDefinitivaFim)
                    {
                        tarefas.EstadoTarefa = "Concluído fora do prazo";
                    }
                    if (tarefas.DataPrevistaFim >= tarefas.DataDefinitivaFim)
                    {
                        tarefas.EstadoTarefa = "Concluído dentro do prazo";
                    }
                    if (tarefas.DataDefinitivaInicio == null && tarefas.DataDefinitivaFim == null)
                    {
                        tarefas.EstadoTarefa = "";
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
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign, "ProjetoSprintDesignID", "NomeProjeto", tarefas.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade, "SistemaProdutividadeId", "NomeProjeto", tarefas.SistemaProdutividadeId);
           
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        [Authorize(Roles = "gestor")]
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
                .Include(t => t.ProjetoSprintDesign)
                .Include(t => t.SistemaProdutividade)
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
        [Authorize(Roles = "gestor")]
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

        [Authorize(Roles = "cliente")]
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
