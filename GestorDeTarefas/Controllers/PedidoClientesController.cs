using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeTarefas.Data;
using GestorDeTarefas.Models;

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
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // GET: PedidoClientes/Create
        public IActionResult EnviarPedido()
        {
            return View();
        }

        // POST: PedidoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnviarPedido([Bind("PedidoClienteID,Mensagem,Resposta")] PedidoCliente pedidoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
            return View(pedidoCliente);
        }

        // POST: PedidoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResponderPedido(int id, [Bind("PedidoClienteID,Mensagem,Resposta")] PedidoCliente pedidoCliente)
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
                return RedirectToAction(nameof(Index));
            }
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
