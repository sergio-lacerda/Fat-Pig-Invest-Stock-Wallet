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
    public class AcoesController : Controller
    {
        private readonly FatPigInvestContext _context;

        public AcoesController(FatPigInvestContext context)
        {
            _context = context;
        }

        // GET: Acoes
        public async Task<IActionResult> Index()
        {
            var fatPigInvestContext = _context.Acoes.Include(a => a.Empresa);
            return View(await fatPigInvestContext.ToListAsync());
        }

        // GET: Acoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acoes == null)
            {
                return NotFound();
            }

            var acao = await _context.Acoes
                .Include(a => a.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // GET: Acoes/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome");
            return View();
        }

        // POST: Acoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ticker,EmpresaId")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", acao.EmpresaId);
            return View(acao);
        }

        // GET: Acoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acoes == null)
            {
                return NotFound();
            }

            var acao = await _context.Acoes.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", acao.EmpresaId);
            return View(acao);
        }

        // POST: Acoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ticker,EmpresaId")] Acao acao)
        {
            if (id != acao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoExists(acao.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", acao.EmpresaId);
            return View(acao);
        }

        // GET: Acoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acoes == null)
            {
                return NotFound();
            }

            var acao = await _context.Acoes
                .Include(a => a.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // POST: Acoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Acoes == null)
            {
                return Problem("Entity set 'FatPigInvestContext.Acoes'  is null.");
            }
            var acao = await _context.Acoes.FindAsync(id);
            if (acao != null)
            {
                _context.Acoes.Remove(acao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoExists(int id)
        {
          return (_context.Acoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
