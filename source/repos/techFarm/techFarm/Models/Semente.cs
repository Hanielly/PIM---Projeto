using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techFarm.Models
{
	public class Semente
	{
		[Required]
		public int ID_Sementes { get; set; }

		[Required(ErrorMessage = "O tipo de grão da semente é obrigatório.")]
		public string TipoDeGrao { get; set; }

		[Required(ErrorMessage = "A quantidade em KG da semente é obrigatória.")]
		public double KG { get; set; }

		public int ID_Fornecedores { get; set; }
		public Fornecedor? Fornecedor { get; set; }

		public ICollection<LoteGrao>? LotesGraos { get; set; }
	}
}
