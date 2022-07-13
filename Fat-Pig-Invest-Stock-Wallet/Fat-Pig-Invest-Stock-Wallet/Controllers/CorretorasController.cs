using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fat_Pig_Invest_Stock_Wallet.Data;
using Fat_Pig_Invest_Stock_Wallet.Models;

namespace Fat_Pig_Invest_Stock_Wallet.Controllers
{
    public class CorretorasController : Controller
    {
        private readonly FatPigInvestContext _context;

        public CorretorasController(FatPigInvestContext context)
        {
            _context = context;
        }

        // GET: Corretoras
        public async Task<IActionResult> Index()
        {
              return _context.Corretoras != null ? 
                          View(await _context.Corretoras.ToListAsync()) :
                          Problem("Entity set 'FatPigInvestContext.Corretoras'  is null.");
        }

        // GET: Corretoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Corretoras == null)
            {
                return NotFound();
            }

            var corretora = await _context.Corretoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corretora == null)
            {
                return NotFound();
            }

            return View(corretora);
        }

        // GET: Corretoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corretoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Corretora corretora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corretora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corretora);
        }

        // GET: Corretoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Corretoras == null)
            {
                return NotFound();
            }

            var corretora = await _context.Corretoras.FindAsync(id);
            if (corretora == null)
            {
                return NotFound();
            }
            return View(corretora);
        }

        // POST: Corretoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Corretora corretora)
        {
            if (id != corretora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corretora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorretoraExists(corretora.Id))
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
            return View(corretora);
        }

        // GET: Corretoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Corretoras == null)
            {
                return NotFound();
            }

            var corretora = await _context.Corretoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corretora == null)
            {
                return NotFound();
            }

            return View(corretora);
        }

        // POST: Corretoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Corretoras == null)
            {
                return Problem("Entity set 'FatPigInvestContext.Corretoras'  is null.");
            }
            var corretora = await _context.Corretoras.FindAsync(id);
            if (corretora != null)
            {
                _context.Corretoras.Remove(corretora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorretoraExists(int id)
        {
          return (_context.Corretoras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
