using System.ComponentModel.DataAnnotations;

namespace techFarm.Models
{
	public class Funcionario
	{
		public int ID_Funcionarios { get; set; }

		[Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "A função do funcionário é obrigatória.")]
		public string Funcao { get; set; }

		[Required(ErrorMessage = "O salário do funcionário é obrigatório.")]
		public decimal Salario { get; set; }

		public ICollection<Venda>? Vendas { get; set; }
	}
}
