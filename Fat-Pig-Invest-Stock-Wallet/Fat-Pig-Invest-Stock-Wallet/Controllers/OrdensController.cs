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
    public class OrdensController : Controller
    {
        private readonly FatPigInvestContext _context;

        public OrdensController(FatPigInvestContext context)
        {
            _context = context;
        }

        // GET: Ordens/CreateOrder/OriginReceiptId
        public IActionResult CreateOrder(int id)
        {            
            ViewData["AcaoId"] = new SelectList(_context.Acoes, "Id", "Ticker");
            ViewData["NotaId"] = new SelectList(_context.Notas, "Id", "Id");

            var nota = _context.Notas.Where<Nota>(n => n.Id == id).First();
            var corretora = _context.Corretoras.Where<Corretora>(c => c.Id == nota.CorretoraId).First();
            //var ordens = _context.Ordens.ToList();
            var ordens = _context.Ordens.Where(o => o.NotaId == id).ToList();
            
            ViewData["DataPregao"] = nota.DataPregao;
            ViewData["Corretora"] = corretora.Nome;
            ViewData["NotaOrigemId"] = id;
            ViewData["Ordens"] = ordens;

            return View("Create");
        }

        // POST: Ordens/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NotaId,TipoOrdem,AcaoId,Quantidade,PrecoUnitario")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordem);
                await _context.SaveChangesAsync();                
                return RedirectToAction("CreateOrder", "Ordens", new { id = ordem.NotaId });
            }
            ViewData["AcaoId"] = new SelectList(_context.Acoes, "Id", "Ticker", ordem.AcaoId);
            ViewData["NotaId"] = new SelectList(_context.Notas, "Id", "Id", ordem.NotaId);
            return RedirectToAction("CreateOrder", "Ordens", new { id = ordem.NotaId });            
        }

        // GET: Ordens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordens
                .Include(o => o.Acao)
                .Include(o => o.Nota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordem == null)
            {
                return NotFound();
            }

            return View(ordem);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordens == null)
            {
                return Problem("Não há ordem para ser excluída!");
            }
            var ordem = await _context.Ordens.FindAsync(id);
            if (ordem != null)
            {
                _context.Ordens.Remove(ordem);
            }

            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("CreateOrder", "Ordens", new { id = ordem.NotaId });
        }


    }
}
