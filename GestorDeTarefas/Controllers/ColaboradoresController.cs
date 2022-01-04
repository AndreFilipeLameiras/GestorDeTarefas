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
    public class ColaboradoresController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public ColaboradoresController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: Colaboradors
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var colaboradorSearch = _context.Colaborador
                .Where(b => nome == null || b.Name.Contains(nome));
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = colaboradorSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var colaboradors = await colaboradorSearch
                             .Include(b => b.Cargo)
                            .OrderBy(b => b.Name)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new ColaboradorListViewModel
                {
                    Colaboradors = colaboradors,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome
                }
            );
        }

        public async Task<IActionResult> AdicionarIdiomaColaborador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador colaborador = _context.Colaborador.Find(id);

            // var projetoSprintDesign = await _context.ProjetoSprintDesign.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            var Results = from b in _context.Idioma
                          select new
                          {
                              b.IdiomaId,
                              b.NomeIdioma,
                              Checked = ((from ab in _context.ColaboradorIdioma
                                          where (ab.ColaboradorId == id) & (ab.IdiomaId == b.IdiomaId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new ColaboradorListViewModel();
            MyViewModel.ColaboradorId = id.Value;
            MyViewModel.NomeColaborador = colaborador.Name;

            var MyCheckBoxList = new List<CheckBoxViewModelColaboradorIdioma>();

            foreach (var item in Results)
            {
               MyCheckBoxList.Add(new CheckBoxViewModelColaboradorIdioma { Id = item.IdiomaId, Name = item.NomeIdioma, Checked = item.Checked });

                MyViewModel.Idiomas = MyCheckBoxList;
            }
            return View(MyViewModel);
        }


            // GET: Colaboradors/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(b => b.Cargo)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradors/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Nome_Cargo");
            return View();
        }

        // POST: Colaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,Name,Email,Contacto,CargoId")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                ViewBag.Title = "Colaborador adicionado";
                ViewBag.Message = "Colaborador adicionado com sucesso.";
                return View("Success");
            }
            return View(colaborador);
        }

        // GET: Colaboradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return View(colaborador);
        }

        // POST: Colaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,Name,Email,Contacto,Cargo")] Colaborador colaborador)
        {
            if (id != colaborador.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.ColaboradorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Title = "Colaborador editado";
                ViewBag.Message = "Colaborador alterado com sucesso.";
                return View("Success");
            }
            return View(colaborador);
        }

        // GET: Colaboradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .SingleOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();
            ViewBag.Title = "Colaboradores apagado";
            ViewBag.Message = "Colaborador apagado com sucesso.";
            return View("Success");
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.ColaboradorId == id);
        }
    }
}

