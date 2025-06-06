﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System.Security.Policy;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Author,Genre,PublishedYear,AvailabilityStatus")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);

        }
        public async Task<IActionResult> Borrow()
        {
            return View(await _context.Books.ToListAsync());
        }

        //public IActionResult Borrow()
        //{
        //    return View(_context.Books.ToListAsync());
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrowBook(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var userModel = _context.Members.FirstOrDefault(m => m.Email == model.Email);
            var book = _context.Books.FirstOrDefault(m => m.BookId == id);
            if (book != null)
            {
              
                if (book.AvailabilityStatus == "Borrowed")
                {
                    ModelState.AddModelError(string.Empty, "The book is already borrowed.");
                    
                    return RedirectToAction("Borrow");
                }

                book.AvailabilityStatus = "Borrowed";
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(book);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BookExists(book.BookId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Borrow");
                }
                return RedirectToAction("Borrow");
            }
            return RedirectToAction("Borrow");
        }
        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Author,Genre,PublishedYear,AvailabilityStatus")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

        ////Action to borrow a book
        //public async Task<IActionResult> Borrow(int id, int memberId)
        //{
        //    var book = await _context.Books.FindAsync(id);
        //    if (book == null || book.AvailabilityStatus == "Borrowed")
        //    {
        //        return NotFound();
        //    }

        //    book.BorrowedById = memberId;
        //    book.AvailabilityStatus = "Borrowed";
        //    _context.Update(book);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //// Action to return a book
        //public async Task<IActionResult> Return(int id)
        //{
        //    var book = await _context.Books.FindAsync(id);
        //    if (book == null || book.AvailabilityStatus == "Available")
        //    {
        //        return NotFound();
        //    }

        //    book.BorrowedById = null;
        //    book.AvailabilityStatus = "Available";
        //    _context.Update(book);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
