using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class AdminModelsController : Controller
    {
        private readonly LibraryContext _context;

        public AdminModelsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: AdminModels
        public async Task<IActionResult> Login()
        {
            //return View(await _context.AdminModel.ToListAsync());
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you would typically check the user's credentials against a database
                // For demonstration purposes, we'll assume the login is successful if the email is "admin@example.com" and the password is "password"
                if (model.Email == "Admin@gmail.com" && model.Password == "Admin@123")
                {
                    // Redirect to the home page or another action
                    return RedirectToAction("AdminHome", "AdminModels");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }
        public IActionResult AdminHome()
        {
            return View();
        }


        // GET: AdminModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModel = await _context.AdminModel
                .FirstOrDefaultAsync(m => m.Email == id);
            if (adminModel == null)
            {
                return NotFound();
            }

            return View(adminModel);
        }

        // GET: AdminModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Password")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminModel);
        }

        // GET: AdminModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModel = await _context.AdminModel.FindAsync(id);
            if (adminModel == null)
            {
                return NotFound();
            }
            return View(adminModel);
        }

        // POST: AdminModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Password")] AdminModel adminModel)
        {
            if (id != adminModel.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminModelExists(adminModel.Email))
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
            return View(adminModel);
        }

        // GET: AdminModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModel = await _context.AdminModel
                .FirstOrDefaultAsync(m => m.Email == id);
            if (adminModel == null)
            {
                return NotFound();
            }

            return View(adminModel);
        }

        // POST: AdminModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adminModel = await _context.AdminModel.FindAsync(id);
            if (adminModel != null)
            {
                _context.AdminModel.Remove(adminModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminModelExists(string id)
        {
            return _context.AdminModel.Any(e => e.Email == id);
        }
    }
}
