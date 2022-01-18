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
                .Include(p => p.Gestor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // GET: PedidoClientes/Create
        public IActionResult EnviarPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = _context.Cliente.Find(id);
            PedidoCliente pedidoCliente = new PedidoCliente();

           

            if (cliente == null)
            {
                return NotFound();
            }

            
            return View(new PedidoClienteListViewModel
            {
                
                ClienteId = id.Value,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cidade = cliente.Cidade,
                Telefone = cliente.Phone,
                Mensagem = pedidoCliente.Mensagem,
                DataRealizarPedido = pedidoCliente.DataRealizarPedido,
                ProjetoSprintDesign = new SelectList(_context.ProjetoSprintDesign.OrderBy(b => b.NomeProjeto)
                .Where(b => b.ClienteId == id.Value), "ProjetoSprintDesignID", "NomeProjeto")
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
            Cliente cliente = _context.Cliente.Find(pedidoCliente.ClienteId);

            


            if (ModelState.IsValid)
            {

            
                _context.Add(new PedidoCliente() {
                
                
                    ClienteId = pedidoCliente.ClienteId, Mensagem = pedidoCliente.Mensagem,
                    DataPedido = DateTime.Today, DataRealizarPedido = pedidoCliente.DataRealizarPedido,
                    ProjetoSprintDesignID=pedidoCliente.ProjetoSprintDesignID
                
                });
                
                await _context.SaveChangesAsync();
                ViewBag.Title = "Pedido enviado!!";
                ViewBag.Message = "O seu pedido foi enviado com sucesso!!!";
                ViewBag.redirect = "/Clientes/Index";

                return View("Success");
                new SelectList(_context.ProjetoSprintDesign.Where(b => b.ClienteId == pedidoCliente.ClienteId), "ProjetoSprintDesignID", "NomeProjeto");
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", pedidoCliente.ClienteId);
            ViewData["GestorId"] = new SelectList(_context.Gestor, "GestorId", "Nome", pedidoCliente.GestorId);
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign, "ProjetoSprintDesignID", "NomeProjeto", pedidoCliente.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade, "SistemaProdutividadeId", "NomeProjeto", pedidoCliente.SistemaProdutividadeId);
            return View(pedidoCliente);
        }

        // POST: PedidoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResponderPedido(int id, [Bind("ID,Mensagem,Resposta,DataRealizarPedido,DataPedido,DataResposta,ProjetoSprintDesignID,SistemaProdutividadeId,ClienteId,GestorId")] PedidoCliente pedidoCliente)
        {
            if (id != pedidoCliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoCliente);
                    await _context.SaveChangesAsync();
                    ViewBag.Title = "Resposta enviada!!";
                    ViewBag.Message = "A sus resposta foi enviado com sucesso!!!";
                    ViewBag.redirect = "/Clientes/Index";
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
              //  return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", pedidoCliente.ClienteId);
            ViewData["GestorId"] = new SelectList(_context.Gestor, "GestorId", "Nome", pedidoCliente.GestorId);
            ViewData["ProjetoSprintDesignID"] = new SelectList(_context.ProjetoSprintDesign, "ProjetoSprintDesignID", "NomeProjeto", pedidoCliente.ProjetoSprintDesignID);
            ViewData["SistemaProdutividadeId"] = new SelectList(_context.SistemaProdutividade, "SistemaProdutividadeId", "NomeProjeto", pedidoCliente.SistemaProdutividadeId);
            return View(pedidoCliente);

          
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
