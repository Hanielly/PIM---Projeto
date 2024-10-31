using System.ComponentModel.DataAnnotations;

namespace techFarm.Models
{
	public class Fornecedor
	{
		public int ID_Fornecedores { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O Nome não pode ter mais de 100 caracteres.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
		public string CNPJ { get; set; }

		[Required(ErrorMessage = "O campo Email é obrigatório.")]
		[EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
		public string Email { get; set; }

		public ICollection<Semente>? Sementes { get; set; }
	}

}
