namespace techFarm.Models
{
    public class VendaRelatorioDto
    {
        public DateTime DataDaVenda { get; set; }
        public string NomeFuncionario { get; set; }
        public string TipoDeGrao { get; set; }
        public double QuantidadeKgVendida { get; set; }
    }
}
