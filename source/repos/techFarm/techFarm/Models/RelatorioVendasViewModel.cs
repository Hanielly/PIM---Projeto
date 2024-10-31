namespace techFarm.Models
{
    public class RelatorioVendasViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<Venda> Vendas { get; set; }
    }
}
