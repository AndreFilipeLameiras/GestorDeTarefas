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
    public class CargosController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public CargosController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Cargos
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var cargoSearch = _context.Cargo
              .Where(b => nome == null || b.Nome_Cargo.Contains(nome));
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = cargoSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var cargos = await cargoSearch
                            .OrderBy(b => b.Nome_Cargo)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new CargoListViewModel
                {
                    Cargos = cargos,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome
                }
            );
        }

        // GET: Cargos/Details/5
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .SingleOrDefaultAsync(b => b.CargoId == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargos/Create
        [Authorize(Roles = "admin, gestor")]
        public IActionResult Create()
        {
            
            return View();
            
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Create([Bind("CargoId,Nome_Cargo")] Cargo cargo)
        {
            var memberUnique = _context.Cargo.Where(m => m.Nome_Cargo.Equals(cargo.Nome_Cargo)).Count();

            if (memberUnique != 0)
            {
                ModelState.AddModelError("Nome_Cargo", "Este cargo já existe");
            }

            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Cargo Adicionado";
                ViewBag.Message = "Cargo adicionado com sucesso.";
                return View("Success");
            }
            return View(cargo);
        }


        // GET: Cargos/Edit/5
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Edit(int id, [Bind("CargoId,Nome_Cargo")] Cargo cargo)
        {
            var memberUnique = _context.Cargo.Where(m => m.Nome_Cargo.Equals(cargo.Nome_Cargo) && m.CargoId != cargo.CargoId).Count();

            if (memberUnique != 0)
            {
                ModelState.AddModelError("Nome_Cargo", "Este cargo já existe");
            }
            if (id != cargo.CargoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.CargoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Title = "Cargo editado";
                ViewBag.Message = "Cargo alterado com sucesso.";
                return View("Success");
            }

            return View(cargo);
        }

        // GET: Cargos/Delete/5
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .FirstOrDefaultAsync(m => m.CargoId == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
            }
            catch (DbUpdateException /* ex */)
            {

                return View("MensagemErro");
            }
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cargo = await _context.Cargo.FindAsync(id);
            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();

            ViewBag.Title = "Cargo Apagado";
            ViewBag.Message = "Cargo apagado com sucesso.";
            return View("Success");
            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Ups! Este Cargo não pode ser apagado.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }

        private bool CargoExists(int id)
        {
            return _context.Cargo.Any(e => e.CargoId == id);
        }
    }
}
