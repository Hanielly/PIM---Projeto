using techFarm.Interfaces;
using techFarm.Models;
using techFarm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace techFarm.Services
{    public class RelatorioDeVendasService : IRelatorioDeVendasService
    {
        private readonly TechFarmContext _context;

        public RelatorioDeVendasService(TechFarmContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>>? GerarRelatorioDeVendasAsync(DateTime? dataInicio, DateTime? dataFim)
        {
            return await _context.Vendas
            .Include(v => v.LoteGrao) // Carrega os dados de LoteGrao
            .Include(v => v.Funcionario) // Carrega os dados de Funcionario
            .Where(v => v.DataDaVenda >= dataInicio && v.DataDaVenda <= dataFim)
            .ToListAsync();
        }
    }
}
