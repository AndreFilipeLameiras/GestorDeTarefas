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








        public async Task<IActionResult> DetailsColaboradorProjeto(int? id)
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

            var Results = from b in _context.Colaborador
                          select new
                          {
                              b.ColaboradorId,
                              b.Name,
                              Checked = ((from ab in _context.ColaboradorProjetoSprint
                                          where (ab.ID_P_Design == id) & (ab.ColaboradorId == b.ColaboradorId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new ProjetoSprintListViewModel();
            MyViewModel.ID_P_Design = id.Value;
            MyViewModel.NomeProjeto = projetoSprintDesign.NomeProjeto;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ColaboradorId, Name = item.Name, Checked = item.Checked });

                MyViewModel.Colaboradores = MyCheckBoxList;
            }
            return View(MyViewModel);
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
        public async Task<IActionResult> Create([Bind("ID_P_Design,NomeProjeto,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim")] ProjetoSprintDesign projetoSprintDesign)
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

        // POST: aaa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_P_Design,NomeProjeto,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim")] ProjetoSprintDesign projetoSprintDesign)
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


        public async Task<IActionResult> AdicionarColaboradores(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjetoSprintDesign projetoSprintDesign = _context.ProjetoSprintDesign.Find(id);

           // var projetoSprintDesign = await _context.ProjetoSprintDesign.FindAsync(id);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }

            var Results = from b in _context.Colaborador
                          select new
                          {
                              b.ColaboradorId,
                              b.Name,
                              Checked = ((from ab in _context.ColaboradorProjetoSprint
                                          where (ab.ID_P_Design == id) & (ab.ColaboradorId == b.ColaboradorId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new ProjetoSprintListViewModel();
            MyViewModel.ID_P_Design = id.Value;
            MyViewModel.NomeProjeto = projetoSprintDesign.NomeProjeto;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel {Id=item.ColaboradorId, Name = item.Name,Checked = item.Checked });

                MyViewModel.Colaboradores = MyCheckBoxList;
            }
            return View(MyViewModel);
        }

        // POST: ProjetoSprintDesigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarColaboradores(ProjetoSprintListViewModel projetoSprint)
        {
            var MyProjet = _context.ProjetoSprintDesign.Find(projetoSprint.ID_P_Design);
            MyProjet.NomeProjeto = projetoSprint.NomeProjeto;

            foreach( var item in _context.ColaboradorProjetoSprint)
            {
                if(item.ID_P_Design == projetoSprint.ID_P_Design)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                  
                }
            }

            foreach (var item in projetoSprint.Colaboradores)
            {
                if (item.Checked)
                {
                    _context.ColaboradorProjetoSprint.Add(new
                        ColaboradorProjetoSprint()
                    { ID_P_Design = projetoSprint.ID_P_Design, ColaboradorId = item.Id });
                }
            }
              
                _context.SaveChanges();
                return RedirectToAction("Index");
              
            return View(projetoSprint);
        }

        // GET: ProjetoSprintDesigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
           
            
            try
            {
                var projetoSprintDesign = await _context.ProjetoSprintDesign
               .FirstOrDefaultAsync(m => m.ID_P_Design == id);

                if (projetoSprintDesign == null)
                {
                    return NotFound();
                }
                return View(projetoSprintDesign);
                
            }
            catch (DbUpdateException /* ex */)
            {
                
                return View("MensagemErro");
            }

            
        }

        // POST: ProjetoSprintDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            

            try
            {
                var projetoSprintDesign = await _context.ProjetoSprintDesign.FindAsync(id);
                _context.ProjetoSprintDesign.Remove(projetoSprintDesign);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Projeto apagado";
                ViewBag.Message = "Projeto apagado com sucesso!!!";
                return View("Sucess");

            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Ups! Este projeto não pode ser apagado.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        }

        private bool ProjetoSprintDesignExists(int id)
        {
            return _context.ProjetoSprintDesign.Any(e => e.ID_P_Design == id);
        }


       
    }
}
