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
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var projetoSearch = _context.SistemaProdutividade
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

            var project = await projetoSearch
                            .Include(b => b.ProdutividadeColaborador)
                            .OrderBy(b => b.NomeProjeto)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new SistemProdListViewmodel
                {
                    ProjetoProdutividade = project,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome
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


        public IActionResult Success()
        {
            return View();
        }

        public IActionResult MensagemErro()
        {
            return View();
        }


        public async Task<IActionResult> DetailsColaboradorProjeto(int? id)
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

            var Results = from b in _context.Colaborador
                          select new
                          {
                              b.ColaboradorId,
                              b.Name,
                              Checked = ((from ab in _context.ColaboradorSistemaProdutividade
                                          where (ab.SistemaProdutividadeId == id) & (ab.ColaboradorId == b.ColaboradorId)
                                          select ab).Count() > 0)
                          };
            var Resultado = from b in _context.ColaboradorSistemaProdutividade
                            select new
                            {
                                b.ColaboradorId,
                                b.Colaborador.Name,
                                b.DataInicio,
                                b.DataFim,
                                Checked = ((from ab in _context.ColaboradorSistemaProdutividade
                                            where (ab.SistemaProdutividadeId == id) & (ab.ColaboradorId == b.ColaboradorId)
                                            select ab).Count() > 0)
                            };

            var MyViewModel = new SistemProdListViewmodel();
            MyViewModel.ID_SistemaProdutividade = id.Value;
            MyViewModel.NomeProjeto = sistemaProdutividade.NomeProjeto;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ColaboradorId, Name = item.Name, Checked = item.Checked });

                MyViewModel.Colaboradores = MyCheckBoxList;
            }
            return View(MyViewModel);
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
            if (sistemaProdutividade.DataPrevistaFim < sistemaProdutividade.DataDefinitivaInicio || sistemaProdutividade.DataPrevistaFim < sistemaProdutividade.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }
            if (ModelState.IsValid)
            {
                if (sistemaProdutividade.DataPrevistaInicio < sistemaProdutividade.DataDefinitivaInicio)
                {
                    sistemaProdutividade.EstadoProjeto = "Em atraso";
                }
                if (sistemaProdutividade.DataPrevistaInicio >= sistemaProdutividade.DataDefinitivaInicio)
                {
                    sistemaProdutividade.EstadoProjeto = "Dentro do prazo";
                }
                _context.Add(sistemaProdutividade);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Projeto adicionado";
                ViewBag.Message = "Projeto adicionado com sucesso!!!";
                return View("Success");
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

        // POST: aaa/Edit/5
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
            if (sistemaProdutividade.DataPrevistaFim < sistemaProdutividade.DataDefinitivaInicio || sistemaProdutividade.DataPrevistaFim < sistemaProdutividade.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }

            if (sistemaProdutividade.DataDefinitivaFim < sistemaProdutividade.DataDefinitivaInicio)
            {
                ModelState.AddModelError("DataDefinitivaFim", "Data Efetiva de fim não deve ser " +
                    "menor do que a data efetiva de inicio");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (sistemaProdutividade.DataPrevistaInicio < sistemaProdutividade.DataDefinitivaInicio)
                    {
                        sistemaProdutividade.EstadoProjeto = "Em atraso";

                    }
                    if (sistemaProdutividade.DataPrevistaInicio >= sistemaProdutividade.DataDefinitivaInicio)
                    {
                        sistemaProdutividade.EstadoProjeto = "Dentro do prazo";
                    }

                    if (sistemaProdutividade.DataDefinitivaFim != null)
                    {
                        sistemaProdutividade.EstadoProjeto = "Concluído";
                    }
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
                ViewBag.Title = "Projeto Alterado";
                ViewBag.Message = "Projeto Alterado com sucesso!!!.";
                return View("Success");
            }
            return View(sistemaProdutividade);
        }


        public async Task<IActionResult> AdicionarColaboradores(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            SistemaProdutividade sistemaProdutividade = _context.SistemaProdutividade.Find(id);

            // var sistemaProdutividade = await _context.SistemaProdutividade.FindAsync(id);
            if (sistemaProdutividade == null)
            {
                return NotFound();
            }

            var Results = from b in _context.Colaborador
                          select new
                          {
                              b.ColaboradorId,
                              b.Name,
                              Checked = ((from ab in _context.ColaboradorSistemaProdutividade
                                          where (ab.SistemaProdutividadeId == id) & (ab.ColaboradorId == b.ColaboradorId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new SistemProdListViewmodel();
            MyViewModel.ID_SistemaProdutividade = id.Value;
            MyViewModel.NomeProjeto = sistemaProdutividade.NomeProjeto;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ColaboradorId, Name = item.Name, Checked = item.Checked });

                MyViewModel.Colaboradores = MyCheckBoxList;
            }

            return View(MyViewModel);


        }



        // POST: SistemaProdutividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarColaboradores(SistemProdListViewmodel projetoPodutividade)
        {
            var MyProjet = _context.SistemaProdutividade.Find(projetoPodutividade.ID_SistemaProdutividade);
            MyProjet.NomeProjeto = projetoPodutividade.NomeProjeto;

            foreach (var item in _context.ColaboradorSistemaProdutividade)
            {
                if (item.SistemaProdutividadeId == projetoPodutividade.ID_SistemaProdutividade)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                    ViewBag.Title = "Alteração do colaborador no projeto";
                    ViewBag.Message = "Colaborador alterado no projeto com sucesso!!!";
                }
            }


            foreach (var item in projetoPodutividade.Colaboradores)
            {
                if (item.Checked && item.ColaboradorProjetoProd.DataInicio == null)
                {
                    ModelState.AddModelError("", "Data de inicio é Obrigatória");
                    return View(projetoPodutividade);
                }
                if (item.Checked && item.ColaboradorProjetoProd.DataFim == null)
                {
                    ModelState.AddModelError("", "Data de fim é Obrigatória");
                    return View(projetoPodutividade);
                }
                if (item.Checked && item.ColaboradorProjetoProd.DataFim.Value < item.ColaboradorProjetoSprintss.DataInicio.Value)
                {
                    ModelState.AddModelError("", "Data de fim deve ser maior ou igual a data de inicio");
                    return View(projetoPodutividade);
                }

                if (item.Checked)
                {
                    _context.ColaboradorSistemaProdutividade.Add(new
                        ColaboradorProdutividade()
                    {
                        SistemaProdutividadeId = projetoPodutividade.ID_SistemaProdutividade,
                        ColaboradorId = item.Id,
                        DataInicio = item.ColaboradorProjetoProd.DataInicio,
                        DataFim = item.ColaboradorProjetoProd.DataFim
                    });


                    ViewBag.Title = "Colaborador adicionado ao projeto";
                    ViewBag.Message = "Colaborador adicionado ao projeto com sucesso!!!";
                    // return View("Success");


                }
            }

            _context.SaveChanges();


            return View("Success");
            //  return View(sistemaProdutividade);
        }

        // GET: SistemaProdutividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var sistemaProdutividade = await _context.SistemaProdutividade
               .FirstOrDefaultAsync(m => m.SistemaProdutividadeId == id);
                if (sistemaProdutividade == null)
                {
                    return NotFound();
                }

                return View(sistemaProdutividade);
            }

            catch (DbUpdateException /* ex */)
            {

                return View("MensagemErro");
            }

        }

        // POST: SistemaProdutividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var projetoProdutividade = await _context.SistemaProdutividade.FindAsync(id);
                _context.SistemaProdutividade.Remove(projetoProdutividade);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Projeto apagado";
                ViewBag.Message = "Projeto apagado com sucesso!!!";
                return View("Success");

            }
            catch (DbUpdateException /* ex */)
            {
                ViewBag.Title = "Ups! Este projeto não pode ser apagado.";
                ViewBag.Message = "Verifique as ligações entre as tabelas!!!";
                return View("MensagemErro");
            }
        

        }

        private bool SistemaProdutividadeExists(int id)
        {
            return _context.SistemaProdutividade.Any(e => e.SistemaProdutividadeId == id);
        }



    }
}
