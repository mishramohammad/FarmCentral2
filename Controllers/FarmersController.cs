﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmCentral2.Models;

namespace FarmCentral2.Controllers
{
    public class FarmersController : Controller
    {
        private readonly FarmCentral2Context _context;

        public FarmersController(FarmCentral2Context context)
        {
            _context = context;
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmers.ToListAsync());
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FId == id);
            if (farmers == null)
            {
                return NotFound();
            }

            return View(farmers);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FId,Fname,Fsurname,Femail,Fusername,Fpassword")] Farmers farmers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmers);
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.Farmers.FindAsync(id);
            if (farmers == null)
            {
                return NotFound();
            }
            return View(farmers);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FId,Fname,Fsurname,Femail,Fusername,Fpassword")] Farmers farmers)
        {
            if (id != farmers.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmersExists(farmers.FId))
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
            return View(farmers);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FId == id);
            if (farmers == null)
            {
                return NotFound();
            }

            return View(farmers);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmers = await _context.Farmers.FindAsync(id);
            _context.Farmers.Remove(farmers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmersExists(int id)
        {
            return _context.Farmers.Any(e => e.FId == id);
        }
    }
}
