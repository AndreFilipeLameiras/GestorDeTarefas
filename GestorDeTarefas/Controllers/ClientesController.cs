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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace GestorDeTarefas.Controllers
{
    public class ClientesController : Controller
    {
        private readonly GestorDeTarefasContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ClientesController(GestorDeTarefasContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Clientes
        [Authorize(Roles = "gestor")]
        public async Task<IActionResult> Index(string nome, string cidade, int page = 1)
        {
            var clienteSearch = _context.Cliente
                .Where(b => (nome == null || b.Nome.Contains(nome))
                & ( cidade == null || b.Cidade.Nome_Cidade.Contains(cidade)));


            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = clienteSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }


            var clientes = await clienteSearch
                            .Include(b => b.Cidade)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();



            return View(
                new ClienteListViewModel
                {
                    Clientes = clientes,
                    PagingInfo = pagingInfo,
                    NomeSearched = nome,
                    CidadeSearched = cidade
                }
                );
        }

        // GET: Clientes/Details/5
        [Authorize(Roles = "gestor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(b => b.Cidade)
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Register
        public IActionResult Register()
        {
            Cliente cliente = new Cliente();
            RegistarClienteViewModel r = new RegistarClienteViewModel();


            return View(new RegistarClienteViewModel
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Morada = cliente.Morada,
                Cidade = new SelectList(_context.Cidade, "CidadeId", "Nome_Cidade"),
                Telemovel = cliente.Telemovel,
                Password = r.Password,
                ConfirmPassword = r.ConfirmPassword
                

            });
        }

        // POST: Clientes/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistarClienteViewModel clienteInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteInfo);
            }

            string username = clienteInfo.Email;

            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                ModelState.AddModelError("Email", "Já existe um cliente com esse e-mail.");
                return View(clienteInfo);
            }
           
            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, clienteInfo.Password);
            await _userManager.AddToRoleAsync(user, "Cliente");

            Cliente cliente = new Cliente
            {
                Nome = clienteInfo.Nome,
                Email = clienteInfo.Email,
                Morada = clienteInfo.Morada,
                Telemovel = clienteInfo.Telemovel,             
                CidadeId = clienteInfo.CidadeId
               
            };


            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                ViewBag.Title = "Cliente Adicionado";
                ViewBag.Message = "Cliente adicionado com sucesso.";
                return View("Success");
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome_Cidade", cliente.CidadeId);
            return View(cliente);
        }

        [Authorize(Roles = "cliente")]
        public async Task<IActionResult> EditPersonalData()
        {
            string email = User.Identity.Name;

            var cliente = await _context.Cliente.SingleOrDefaultAsync(c => c.Email == email);
            if (cliente == null)
            {
                return NotFound();
            }

            EditarClienteRegistadoViewModel clienteInfo = new EditarClienteRegistadoViewModel
            {
                Nome = cliente.Nome,
                Email = cliente.Email
            };

            return View(clienteInfo);

        }

        // POST: Customers/EditLoggedInCustomerViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "cliente")]
        public async Task<IActionResult> EditPersonalData(EditarClienteRegistadoViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            string email = User.Identity.Name;

            var clienteLoggedin = await _context.Cliente.SingleOrDefaultAsync(c => c.Email == email);
            if (clienteLoggedin == null)
            {
                return NotFound();
            }

            clienteLoggedin.Nome = cliente.Nome;

            try
            {
                _context.Update(clienteLoggedin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                

                throw;
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        // GET: Clientes/Edit/5
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome_Cidade", cliente.CidadeId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, gestor")]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,Morada,CidadeId,Email,Telemovel")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                ViewBag.Title = "Cliente Editado";
                ViewBag.Message = "Cliente editado com sucesso.";
                return View("Success");
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome_Cidade", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            ViewBag.Title = "Cliente Eliminado";
            ViewBag.Message = "Cliente eliminado com sucesso.";
            return View("Success");
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }
    }
}
