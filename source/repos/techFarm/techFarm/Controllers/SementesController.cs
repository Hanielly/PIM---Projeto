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
    public class SementesController : Controller
    {
        private readonly TechFarmContext _context;

        public SementesController(TechFarmContext context)
        {
            _context = context;
        }

        // GET: Sementes
        public async Task<IActionResult> Index()
        {
            var techFarmContext = _context.Sementes.Include(s => s.Fornecedor);
            return View(await techFarmContext.ToListAsync());
        }

        // GET: Sementes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semente = await _context.Sementes
                .Include(s => s.Fornecedor)
                .FirstOrDefaultAsync(m => m.ID_Sementes == id);
            if (semente == null)
            {
                return NotFound();
            }

            return View(semente);
        }

        // GET: Sementes/Create
        public IActionResult Create()
        {
          var fornecedores = _context.Fornecedores
                .Select(f => new 
                {
                    f.ID_Fornecedores,
                    DisplayText = $"Fornecedor {f.Nome} - CNPJ {f.CNPJ}" // Concatenando Nome e CNPJ
                }).ToList();

          ViewData["ID_Fornecedores"] = new SelectList(fornecedores, "ID_Fornecedores", "DisplayText");
          return View();
        }

        // POST: Sementes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Sementes,TipoDeGrao,KG,ID_Fornecedores")] Semente semente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Fornecedores"] = new SelectList(_context.Fornecedores, "ID_Fornecedores", "CNPJ", semente.ID_Fornecedores);
            return View(semente);
        }

        // GET: Sementes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semente = await _context.Sementes.FindAsync(id);
            if (semente == null)
            {
                return NotFound();
            }
            ViewData["ID_Fornecedores"] = new SelectList(_context.Fornecedores, "ID_Fornecedores", "CNPJ", semente.ID_Fornecedores);
            return View(semente);
        }

        // POST: Sementes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Sementes,TipoDeGrao,KG,ID_Fornecedores")] Semente semente)
        {
            if (id != semente.ID_Sementes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SementeExists(semente.ID_Sementes))
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
            ViewData["ID_Fornecedores"] = new SelectList(_context.Fornecedores, "ID_Fornecedores", "CNPJ", semente.ID_Fornecedores);
            return View(semente);
        }

        // GET: Sementes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semente = await _context.Sementes
                .Include(s => s.Fornecedor)
                .FirstOrDefaultAsync(m => m.ID_Sementes == id);
            if (semente == null)
            {
                return NotFound();
            }

            return View(semente);
        }

        // POST: Sementes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semente = await _context.Sementes.FindAsync(id);
            if (semente != null)
            {
                _context.Sementes.Remove(semente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SementeExists(int id)
        {
            return _context.Sementes.Any(e => e.ID_Sementes == id);
        }
    }
}
