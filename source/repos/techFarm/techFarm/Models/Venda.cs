using System.ComponentModel.DataAnnotations;

namespace techFarm.Models
{
	public class Venda
	{
		public int ID_Vendas { get; set; }

		[Required(ErrorMessage = "A data da venda é obrigatória.")]
		public DateTime DataDaVenda { get; set; }

		[Required(ErrorMessage = "A quantidade vendida em KG é obrigatória.")]
		public double QuantidadeKGVendida { get; set; }

		[Required(ErrorMessage = "Favor inserir o valor da venda!")]
		public decimal Preco { get; set; }

		public int ID_LotesGraos { get; set; }
		public LoteGrao? LoteGrao { get; set; }

		public int ID_Funcionarios { get; set; }
		public Funcionario? Funcionario { get; set; }
	}
}
