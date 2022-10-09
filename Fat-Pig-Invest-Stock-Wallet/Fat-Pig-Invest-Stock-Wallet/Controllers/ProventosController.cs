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
    public class ProventosController : Controller
    {
        private readonly FatPigInvestContext _context;

        public ProventosController(FatPigInvestContext context)
        {
            _context = context;
        }

        // GET: Proventos
        public async Task<IActionResult> Index()
        {
            var fatPigInvestContext = _context.Proventos
                .Include(p => p.TipoProvento)
                .Include(a => a.Acao);
            return View(await fatPigInvestContext.ToListAsync());
        }

        // GET: Proventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proventos == null)
            {
                return NotFound();
            }

            var provento = await _context.Proventos
                .Include(p => p.TipoProvento)
                .Include(a => a.Acao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provento == null)
            {
                return NotFound();
            }

            return View(provento);
        }

        // GET: Proventos/Create
        public IActionResult Create()
        {
            ViewData["TipoProventoId"] = new SelectList(_context.TiposProvento, "Id", "Nome");
            ViewData["AcaoId"] = new SelectList(_context.Acoes, "Id", "Ticker");
            return View();
        }

        // POST: Proventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoProventoId,DataProvento,AcaoId,ValorProvento")] Provento provento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProventoId"] = new SelectList(_context.TiposProvento, "Id", "Nome", provento.TipoProventoId);
            ViewData["AcaoId"] = new SelectList(_context.Acoes, "Id", "Ticker", provento.AcaoId);
            return View(provento);
        }

        // GET: Proventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proventos == null)
            {
                return NotFound();
            }

            var provento = await _context.Proventos.FindAsync(id);
            if (provento == null)
            {
                return NotFound();
            }
            ViewData["TipoProventoId"] = new SelectList(_context.TiposProvento, "Id", "Nome", provento.TipoProventoId);
            ViewData["AcaoId"] = new SelectList(_context.Acoes, "Id", "Ticker", provento.AcaoId);
            return View(provento);
        }

        // POST: Proventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoProventoId,DataProvento,AcaoId,ValorProvento")] Provento provento)
        {
            if (id != provento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProventoExists(provento.Id))
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
            ViewData["TipoProventoId"] = new SelectList(_context.TiposProvento, "Id", "Nome", provento.TipoProventoId);
            ViewData["AcaoId"] = new SelectList(_context.Acoes, "Id", "Ticker", provento.AcaoId);
            return View(provento);
        }

        // GET: Proventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proventos == null)
            {
                return NotFound();
            }

            var provento = await _context.Proventos
                .Include(p => p.TipoProvento)
                .Include(a => a.Acao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provento == null)
            {
                return NotFound();
            }

            return View(provento);
        }

        // POST: Proventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proventos == null)
            {
                return Problem("Entity set 'FatPigInvestContext.Proventos'  is null.");
            }
            var provento = await _context.Proventos.FindAsync(id);
            if (provento != null)
            {
                _context.Proventos.Remove(provento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProventoExists(int id)
        {
          return _context.Proventos.Any(e => e.Id == id);
        }
    }
}
