using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeTarefas.Data;
using GestorDeTarefas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GestorDeTarefas.ViewModels;

namespace GestorDeTarefas.Controllers {
    public class GestorsController : Controller {
        private readonly GestorDeTarefasContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public GestorsController(
            GestorDeTarefasContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            ){
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Gestors
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gestor.ToListAsync());
        }

        // GET: Gestors/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .FirstOrDefaultAsync(m => m.GestorId == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // GET: Gestors/Registo
        public IActionResult Registo()
        {
            return View();
        }

        // POST: Gestors/Registo
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo(RegistarClienteViewModel gestor)
        {
            if (ModelState.IsValid)
            {
                // Register customer (user)
                var user = new IdentityUser { UserName = gestor.Email, Email = gestor.Email };
                var result = await _userManager.CreateAsync(user, gestor.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    _context.Add(gestor);
                await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(gestor);
        }

        // GET: Gestors/Edit/5
        [Authorize(Roles = "gestor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor.FindAsync(id);
            if (gestor == null)
            {
                return NotFound();
            }
            return View(gestor);
        }

        // POST: Gestors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "gestor")]
        public async Task<IActionResult> Edit(int id, [Bind("GestorId,Nome,Endereço,Email,Telemóvel")] Gestor gestor)
        {
            if (id != gestor.GestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestorExists(gestor.GestorId))
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
            return View(gestor);
        }

        // GET: Gestors/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .FirstOrDefaultAsync(m => m.GestorId == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // POST: Gestors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestor = await _context.Gestor.FindAsync(id);
            _context.Gestor.Remove(gestor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestorExists(int id)
        {
            return _context.Gestor.Any(e => e.GestorId == id);
        }
    }
}
