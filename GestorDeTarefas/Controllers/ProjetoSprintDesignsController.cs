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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GestorDeTarefas.Controllers
{
    public class ProjetoSprintDesignsController : Controller
    {
        private readonly GestorDeTarefasContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProjetoSprintDesignsController(GestorDeTarefasContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: ProjetoSprintDesigns
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var projetoSearch = _context.ProjetoSprintDesign
               .Where(b => nome == null || b.NomeProjeto.Contains(nome) || b.EstadoProjeto.Contains(nome)
              );
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
                .FirstOrDefaultAsync(m => m.ProjetoSprintDesignID == id);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }

            return View(projetoSprintDesign);
        }




        public IActionResult Success()
        {
            return View();
        }

        public IActionResult MensagemErro()
        {
            return View();
        }

       
        public async Task<IActionResult> DetailsColaboradorProjeto(string nome, int? id, int page = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetoSprintDesign = await _context.ProjetoSprintDesign
                .FirstOrDefaultAsync(m => m.ProjetoSprintDesignID == id);
            if (projetoSprintDesign == null)
            {
                return NotFound();
            }

            

            var ResultadoSearch = from b in _context.ColaboradorProjetoSprint
                          select new
                          {
                              b.ColaboradorId,
                              b.Colaborador.Name,
                              b.DataInicio,
                              b.DataFim,
                              Checked = ((from ab in _context.ColaboradorProjetoSprint
                                          where (ab.ProjetoSprintDesignID == id) & (ab.ColaboradorId == b.ColaboradorId) 
                                          select ab).Count() > 0)
                          };

            


            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = ResultadoSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)

            {
                pagingInfo.CurrentPage = 1;
            }



            var Resultado = await ResultadoSearch    
                            .OrderBy(b => b.Name)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();


            var MyViewModel = new ProjetoSprintListViewModel();           
            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Resultado)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ColaboradorId, Name = item.Name, Checked = item.Checked,
                DataInicio = item.DataInicio, DataFim = item.DataFim});

                MyViewModel.Colaboradores = MyCheckBoxList;
            }
            
            return View(new ProjetoSprintListViewModel { 
            ProjetoSprintDesignID = id.Value,
            NomeProjeto = projetoSprintDesign.NomeProjeto,
            Colaboradores = MyCheckBoxList,
            PagingInfo = pagingInfo
        });
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
        public async Task<IActionResult> Create([Bind("ProjetoSprintDesignID,NomeProjeto,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim,CarregarImagemProjeto")] ProjetoSprintDesign projetoSprintDesign)
        {
            if (projetoSprintDesign.DataPrevistaFim < projetoSprintDesign.DataDefinitivaInicio || projetoSprintDesign.DataPrevistaFim < projetoSprintDesign.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }
            if (ModelState.IsValid)
            {
                if (projetoSprintDesign.DataPrevistaInicio < projetoSprintDesign.DataDefinitivaInicio)
                {
                    projetoSprintDesign.EstadoProjeto = "Em atraso";
                }
                if (projetoSprintDesign.DataPrevistaInicio >= projetoSprintDesign.DataDefinitivaInicio)
                {
                    projetoSprintDesign.EstadoProjeto = "Dentro do prazo";
                }

                //Guardar imagem no wwwroot/imagens
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(projetoSprintDesign.CarregarImagemProjeto.FileName);
                string extension = Path.GetExtension(projetoSprintDesign.CarregarImagemProjeto.FileName);
                projetoSprintDesign.ImagemProjeto =  fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Imagens/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await projetoSprintDesign.CarregarImagemProjeto.CopyToAsync(fileStream);
                }


                _context.Add(projetoSprintDesign);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Projeto adicionado";
                ViewBag.Message = "Projeto adicionado com sucesso!!!";
                return View("Success");
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
        public async Task<IActionResult> Edit(int id, [Bind("ProjetoSprintDesignID,NomeProjeto,DataPrevistaInicio,DataDefinitivaInicio,DataPrevistaFim,DataDefinitivaFim")] ProjetoSprintDesign projetoSprintDesign)
        {
            if (id != projetoSprintDesign.ProjetoSprintDesignID)
            {
                return NotFound();
            }
            if (projetoSprintDesign.DataPrevistaFim < projetoSprintDesign.DataDefinitivaInicio || projetoSprintDesign.DataPrevistaFim < projetoSprintDesign.DataPrevistaInicio)
            {
                ModelState.AddModelError("DataPrevistaFim", "Data prevista de fim não deve ser " +
                    "menor do que a data prevista ou efetiva de inicio");
            }

            if (projetoSprintDesign.DataDefinitivaFim < projetoSprintDesign.DataDefinitivaInicio)
            {
                ModelState.AddModelError("DataDefinitivaFim", "Data Efetiva de fim não deve ser " +
                    "menor do que a data efetiva de inicio");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (projetoSprintDesign.DataPrevistaInicio < projetoSprintDesign.DataDefinitivaInicio)
                    {
                        projetoSprintDesign.EstadoProjeto = "Em atraso";

                    }
                    if (projetoSprintDesign.DataPrevistaInicio >= projetoSprintDesign.DataDefinitivaInicio)
                    {
                        projetoSprintDesign.EstadoProjeto = "Dentro do prazo";
                    }

                    if (projetoSprintDesign.DataDefinitivaFim != null)
                    {
                        projetoSprintDesign.EstadoProjeto = "Concluído"; 
                    }
                    _context.Update(projetoSprintDesign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoSprintDesignExists(projetoSprintDesign.ProjetoSprintDesignID))
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
            return View(projetoSprintDesign);
        }


        public async Task<IActionResult> RemoverColaboradores(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetoSprintDesign = await _context.ProjetoSprintDesign
                .FirstOrDefaultAsync(m => m.ProjetoSprintDesignID == id);
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
                                          where (ab.ProjetoSprintDesignID == id) & (ab.ColaboradorId == b.ColaboradorId)
                                          select ab).Count() > 0)
                          };

            var Resultado = from b in _context.ColaboradorProjetoSprint
                            select new
                            {
                                b.ColaboradorId,
                                b.Colaborador.Name,
                                b.DataInicio,
                                b.DataFim,
                                Checked = ((from ab in _context.ColaboradorProjetoSprint
                                            where (ab.ProjetoSprintDesignID == id) & (ab.ColaboradorId == b.ColaboradorId)
                                            select ab).Count() > 0)
                            };


            var MyViewModel = new ProjetoSprintListViewModel();
            MyViewModel.ProjetoSprintDesignID = id.Value;
            MyViewModel.NomeProjeto = projetoSprintDesign.NomeProjeto;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Resultado)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = item.ColaboradorId,
                    Name = item.Name,
                    Checked = item.Checked,
                    DataInicio = item.DataInicio,
                    DataFim = item.DataFim
                });

                MyViewModel.Colaboradores = MyCheckBoxList;
            }
            return View(MyViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverColaboradores(ProjetoSprintListViewModel projetoSprint)
        {
            
            foreach (var item in projetoSprint.Colaboradores)
            {
            
                if (item.Checked==false)
                {
                    foreach (var itemm in _context.ColaboradorProjetoSprint)
                    {
                        if (itemm.ProjetoSprintDesignID == projetoSprint.ProjetoSprintDesignID && itemm.ColaboradorId == item.Id )
                        {
                            
                            _context.Entry(itemm).State = EntityState.Deleted;

                            ViewBag.Title = "Colaborador removido";
                            ViewBag.Message = "Colaborador removido no projeto com sucesso!!!";
                        }
                            
                    }
                }
            }

            _context.SaveChanges();


            return View("Success");
            
            
            //  return View(projetoSprint);
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
                                          where (ab.ProjetoSprintDesignID == id) & (ab.ColaboradorId == b.ColaboradorId)
                                          select ab).Count() > 0)
                          };




            var MyViewModel = new ProjetoSprintListViewModel();
            MyViewModel.ProjetoSprintDesignID = id.Value;
            MyViewModel.NomeProjeto = projetoSprintDesign.NomeProjeto;

            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var colaborador in Results)
            {
                if (colaborador.Checked == false) { 

                MyCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = colaborador.ColaboradorId,
                    Name = colaborador.Name,
                    Checked = colaborador.Checked

                });



                MyViewModel.Colaboradores = MyCheckBoxList;
                }
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
            var MyProjet = _context.ProjetoSprintDesign.Find(projetoSprint.ProjetoSprintDesignID);
            MyProjet.NomeProjeto = projetoSprint.NomeProjeto;

            

            foreach (var item in projetoSprint.Colaboradores)
            {
                if (item.Checked && item.ColaboradorProjetoSprintss.DataInicio==null)
                {
                    ModelState.AddModelError("", "Data de inicio é Obrigatória");
                    return View(projetoSprint);
                }
                if (item.Checked && item.ColaboradorProjetoSprintss.DataFim == null)
                {
                    ModelState.AddModelError("", "Data de fim é Obrigatória");
                    return View(projetoSprint);
                }
                if (item.Checked && item.ColaboradorProjetoSprintss.DataFim.Value< item.ColaboradorProjetoSprintss.DataInicio.Value)
                {
                    ModelState.AddModelError("", "Data de fim deve ser maior ou igual a data de inicio");
                    return View(projetoSprint);
                }

                if (item.Checked)
                {
                   
                    _context.ColaboradorProjetoSprint.Add(new
                        ColaboradorProjetoSprint()
                    { ProjetoSprintDesignID = projetoSprint.ProjetoSprintDesignID, ColaboradorId = item.Id,
                        DataInicio = item.ColaboradorProjetoSprintss.DataInicio, DataFim = item.ColaboradorProjetoSprintss.DataFim});

                    
                    ViewBag.Title = "Colaborador adicionado ao projeto";
                    ViewBag.Message = "Colaborador adicionado ao projeto com sucesso!!!";
                    // return View("Success");

              
                }

                
            }
              
                _context.SaveChanges();

            
            return View("Success");
          //  return View(projetoSprint);
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
               .FirstOrDefaultAsync(m => m.ProjetoSprintDesignID == id);

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
                //apagar imagem wwwroot
                var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Imagens", projetoSprintDesign.ImagemProjeto);

                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);


                _context.ProjetoSprintDesign.Remove(projetoSprintDesign);
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

        private bool ProjetoSprintDesignExists(int id)
        {
            return _context.ProjetoSprintDesign.Any(e => e.ProjetoSprintDesignID == id);
        }


       
    }
}
