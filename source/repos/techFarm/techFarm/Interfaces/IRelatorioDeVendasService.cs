using techFarm.Models;

namespace techFarm.Interfaces
{
    public interface IRelatorioDeVendasService
    {
        Task<List<Venda>>? GerarRelatorioDeVendasAsync(DateTime? dataInicio, DateTime? dataFim);
    }

}
