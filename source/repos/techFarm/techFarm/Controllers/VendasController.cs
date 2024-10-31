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
    public class VendasController : Controller
    {
        private readonly TechFarmContext _context;

        public VendasController(TechFarmContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var techFarmContext = _context.Vendas.Include(v => v.Funcionario).Include(v => v.LoteGrao);
            return View(await techFarmContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Funcionario)
                .Include(v => v.LoteGrao)
                .FirstOrDefaultAsync(m => m.ID_Vendas == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["ID_Funcionarios"] = new SelectList(_context.Funcionarios, "ID_Funcionarios", "Nome");
            ViewData["ID_LotesGraos"] = new SelectList(_context.LotesGraos, "ID_LotesGraos", "TipoDeGrao");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Vendas,DataDaVenda,QuantidadeKGVendida,ID_LotesGraos,ID_Funcionarios, Preco")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Funcionarios"] = new SelectList(_context.Funcionarios, "ID_Funcionarios", "Nome", venda.ID_Funcionarios);
            ViewData["ID_LotesGraos"] = new SelectList(_context.LotesGraos, "ID_LotesGraos", "TipoDeGrao", venda.ID_LotesGraos);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ID_Funcionarios"] = new SelectList(_context.Funcionarios, "ID_Funcionarios", "Funcao", venda.ID_Funcionarios);
            ViewData["ID_LotesGraos"] = new SelectList(_context.LotesGraos, "ID_LotesGraos", "TipoDeGrao", venda.ID_LotesGraos);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Vendas,DataDaVenda,QuantidadeKGVendida,ID_LotesGraos,ID_Funcionarios, Preco")] Venda venda)
        {
            if (id != venda.ID_Vendas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.ID_Vendas))
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
            ViewData["ID_Funcionarios"] = new SelectList(_context.Funcionarios, "ID_Funcionarios", "Funcao", venda.ID_Funcionarios);
            ViewData["ID_LotesGraos"] = new SelectList(_context.LotesGraos, "ID_LotesGraos", "TipoDeGrao", venda.ID_LotesGraos);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Funcionario)
                .Include(v => v.LoteGrao)
                .FirstOrDefaultAsync(m => m.ID_Vendas == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.ID_Vendas == id);
        }
    }
}
