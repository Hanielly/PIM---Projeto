using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using techFarm.Data;
using techFarm.Models;

namespace techFarm.Controllers
{
    public class LoteGraosController : Controller
    {
        private readonly TechFarmContext _context;

        public LoteGraosController(TechFarmContext context)
        {
            _context = context;
        }

        // GET: LoteGraos
        public async Task<IActionResult> Index()
        {
            var techFarmContext = _context.LotesGraos.Include(l => l.Semente);
            return View(await techFarmContext.ToListAsync());
        }

        // GET: LoteGraos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loteGrao = await _context.LotesGraos
                .Include(l => l.Semente)
                .FirstOrDefaultAsync(m => m.ID_LotesGraos == id);
            if (loteGrao == null)
            {
                return NotFound();
            }

            return View(loteGrao);
        }

        // GET: LoteGraos/Create
        public IActionResult Create()
        {
            ViewData["ID_Sementes"] = new SelectList(_context.Sementes, "ID_Sementes", "TipoDeGrao");
            return View();
        }

        // POST: LoteGraos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_LotesGraos,TipoDeGrao,QuantidadeKG,ID_Sementes")] LoteGrao loteGrao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loteGrao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Sementes"] = new SelectList(_context.Sementes, "ID_Sementes", "TipoDeGrao", loteGrao.ID_Sementes);
            return View(loteGrao);
        }

        // GET: LoteGraos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loteGrao = await _context.LotesGraos.FindAsync(id);
            if (loteGrao == null)
            {
                return NotFound();
            }
            ViewData["ID_Sementes"] = new SelectList(_context.Sementes, "ID_Sementes", "TipoDeGrao", loteGrao.ID_Sementes);
            return View(loteGrao);
        }

        // POST: LoteGraos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_LotesGraos,TipoDeGrao,QuantidadeKG,ID_Sementes")] LoteGrao loteGrao)
        {
            if (id != loteGrao.ID_LotesGraos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loteGrao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteGraoExists(loteGrao.ID_LotesGraos))
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
            ViewData["ID_Sementes"] = new SelectList(_context.Sementes, "ID_Sementes", "TipoDeGrao", loteGrao.ID_Sementes);
            return View(loteGrao);
        }

        // GET: LoteGraos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loteGrao = await _context.LotesGraos
                .Include(l => l.Semente)
                .FirstOrDefaultAsync(m => m.ID_LotesGraos == id);
            if (loteGrao == null)
            {
                return NotFound();
            }

            return View(loteGrao);
        }

        // POST: LoteGraos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loteGrao = await _context.LotesGraos.FindAsync(id);
            if (loteGrao != null)
            {
                _context.LotesGraos.Remove(loteGrao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteGraoExists(int id)
        {
            return _context.LotesGraos.Any(e => e.ID_LotesGraos == id);
        }
    }
}
