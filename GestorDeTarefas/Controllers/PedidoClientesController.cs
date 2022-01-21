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
    public class PedidoClientesController : Controller
    {
        private readonly GestorDeTarefasContext _context;

        public PedidoClientesController(GestorDeTarefasContext context)
        {
            _context = context;
        }

        // GET: PedidoClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PedidoCliente.ToListAsync());
        }

        // GET: PedidoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Cliente)
                .Include(p => p.ProjetoSprintDesign)
                .Include(p => p.SistemaProdutividade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        public async Task<IActionResult> AbrirMensagem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Cliente)
                .Include(p => p.ProjetoSprintDesign)
                .Include(p => p.SistemaProdutividade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }


        public async Task<IActionResult> ListaMensagem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projetoSprint = _context.ProjetoSprintDesign.Find(id);
            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Cliente)
                .Include(p => p.ProjetoSprintDesign)
                .Include(p => p.SistemaProdutividade)
                .Where(b=>b.ProjetoSprintDesignID == projetoSprint.ProjetoSprintDesignID)
                .ToListAsync();
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(new ListaPedidoClienteViewModel { 
                  PedidoCliente= pedidoCliente
            });
        }


        // GET: PedidoClientes/Create
        public IActionResult EnviarPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjetoSprintDesign projetoSprint = _context.ProjetoSprintDesign.Find(id);
            PedidoCliente pedidoCliente = new PedidoCliente();

           

            if (projetoSprint == null)
            {
                return NotFound();
            }

            
            return View(new PedidoClienteListViewModel
            {
                NomeProjeto = projetoSprint.NomeProjeto,              
                ProjetoSprintDesignID = id.Value,               
                Mensagem = pedidoCliente.Mensagem,
                DataRealizarPedido = pedidoCliente.DataRealizarPedido,
                Cliente = new SelectList(_context.Cliente
                .Where(b => b.ClienteId == projetoSprint.ClienteId), "ClienteId", "Nome"),
                Colaborador = new SelectList(_context.Colaborador
                .Where(b => b.ColaboradorId == projetoSprint.ColaboradorId), "ColaboradorId", "Name")

            }
                
                );
        }

        // POST: PedidoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnviarPedido(PedidoClienteListViewModel pedidoCliente)
        {
            ProjetoSprintDesign projeto = _context.ProjetoSprintDesign.Find(pedidoCliente.ClienteId);

            


            if (ModelState.IsValid)
            {

            
                _context.Add(new PedidoCliente() {
                
                    ClienteId = pedidoCliente.ClienteId, 
                    Mensagem = pedidoCliente.Mensagem,
                    DataPedido = DateTime.Today, 
                    DataRealizarPedido = pedidoCliente.DataRealizarPedido,
                    ProjetoSprintDesignID=pedidoCliente.ProjetoSprintDesignID,
                    ColaboradorId = pedidoCliente.ColaboradorId
                    
                
                });
                
                await _context.SaveChangesAsync();
                ViewBag.Title = "Pedido enviado!!";
                ViewBag.Message = "O seu pedido foi enviado com sucesso!!!";
                ViewBag.redirect = "/ProjetoSprintDesigns/Index";

                return View("Success");
               
            }
            return View(pedidoCliente);
        }

        // GET: PedidoClientes/Edit/5
        public async Task<IActionResult> ResponderPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente.FindAsync(id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(_context.Cliente.Where(b=>b.ClienteId==pedidoCliente.ClienteId), "ClienteId", "Nome", pedidoCliente.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador.Where(b => b.ColaboradorId == pedidoCliente.ColaboradorId), "ColaboradorId", "Name", pedidoCliente.ClienteId);
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign.Where(b => b.ProjetoSprintDesignID == pedidoCliente.ClienteId), "ProjetoSprintDesignID", "NomeProjeto", pedidoCliente.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade.Where(b => b.SistemaProdutividadeId == pedidoCliente.ClienteId), "SistemaProdutividadeId", "NomeProjeto", pedidoCliente.SistemaProdutividadeId);
            return View(pedidoCliente);
        }

        // POST: PedidoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResponderPedido(int id, [Bind("ID,Mensagem,Resposta,DataRealizarPedido,DataPedido,DataResposta,ProjetoSprintDesignID,SistemaProdutividadeId,ClienteId,ColaboradorId")] PedidoCliente pedidoCliente)
        {
            if (id != pedidoCliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pedidoCliente.DataResposta = DateTime.Today;
                    _context.Update(pedidoCliente);
                    await _context.SaveChangesAsync();
                    ViewBag.Title = "Resposta enviada!!";
                    ViewBag.Message = "A sus resposta foi enviado com sucesso!!!";
                    ViewBag.redirect = "/ProjetoSprintDesigns/Index";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoClienteExists(pedidoCliente.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", pedidoCliente.ClienteId);
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign, "ProjetoSprintDesignID", "NomeProjeto", pedidoCliente.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade, "SistemaProdutividadeId", "NomeProjeto", pedidoCliente.SistemaProdutividadeId);
            return View("Success");

          
        }

        // GET: PedidoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // POST: PedidoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoCliente = await _context.PedidoCliente.FindAsync(id);
            _context.PedidoCliente.Remove(pedidoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoClienteExists(int id)
        {
            return _context.PedidoCliente.Any(e => e.ID == id);
        }
    }
}
