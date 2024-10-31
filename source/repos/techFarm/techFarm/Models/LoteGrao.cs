using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace techFarm.Models
{
	public class LoteGrao
	{
		public int ID_LotesGraos { get; set; }

		[Required(ErrorMessage = "O tipo de grão é obrigatório.")]
		public string TipoDeGrao { get; set; }

		[Required(ErrorMessage = "A quantidade em KG do lote de grãos é obrigatória.")]
		public double QuantidadeKG { get; set; }

		public int ID_Sementes { get; set; }
		public Semente? Semente { get; set; }

		public ICollection<Venda>? Vendas { get; set; }
	}
}
