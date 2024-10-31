using Microsoft.EntityFrameworkCore;
using techFarm.Models;

namespace techFarm.Data
{
	public class TechFarmContext : DbContext
	{
		public DbSet<Fornecedor> Fornecedores { get; set; }
		public DbSet<Semente> Sementes { get; set; }
		public DbSet<LoteGrao> LotesGraos { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<Venda> Vendas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configuração da entidade Fornecedor
			modelBuilder.Entity<Fornecedor>()
				.HasKey(f => f.ID_Fornecedores);

			// Um Fornecedor pode fornecer muitas Sementes (1:N)
			modelBuilder.Entity<Fornecedor>()
				.HasMany(f => f.Sementes)
				.WithOne(s => s.Fornecedor)
				.HasForeignKey(s => s.ID_Fornecedores)
				.OnDelete(DeleteBehavior.Cascade); // Se um Fornecedor for excluído, as Sementes associadas também serão excluídas.

			// Configuração da entidade Semente
			modelBuilder.Entity<Semente>()
				.HasKey(s => s.ID_Sementes);

			// Uma Semente pode gerar muitos Lotes de Grãos (1:N)
			modelBuilder.Entity<Semente>()
				.HasMany(s => s.LotesGraos)
				.WithOne(l => l.Semente)
				.HasForeignKey(l => l.ID_Sementes)
				.OnDelete(DeleteBehavior.Cascade); // Se uma Semente for excluída, os Lotes de Grãos associados também serão excluídos.

			// Configuração da entidade LoteGrao
			modelBuilder.Entity<LoteGrao>()
				.HasKey(l => l.ID_LotesGraos);

			// Um Lote de Grãos pode estar presente em várias Vendas (1:N)
			modelBuilder.Entity<LoteGrao>()
				.HasMany(l => l.Vendas)
				.WithOne(v => v.LoteGrao)
				.HasForeignKey(v => v.ID_LotesGraos)
				.OnDelete(DeleteBehavior.Cascade); // Se um Lote de Grãos for excluído, as Vendas associadas também serão excluídas.

			// Configuração da entidade Funcionario
			modelBuilder.Entity<Funcionario>()
				.HasKey(f => f.ID_Funcionarios);

			// Um Funcionário pode realizar várias Vendas (1:N)
			modelBuilder.Entity<Funcionario>()
				.HasMany(f => f.Vendas)
				.WithOne(v => v.Funcionario)
				.HasForeignKey(v => v.ID_Funcionarios)
				.OnDelete(DeleteBehavior.SetNull); // Se um Funcionário for excluído, o campo do funcionário em Venda é definido como nulo.

			// Configuração da entidade Venda
			modelBuilder.Entity<Venda>()
				.HasKey(v => v.ID_Vendas);

			// Definição de propriedades obrigatórias para chaves estrangeiras
			modelBuilder.Entity<Semente>()
				.Property(s => s.ID_Fornecedores)
				.IsRequired();

			modelBuilder.Entity<LoteGrao>()
				.Property(l => l.ID_Sementes)
				.IsRequired();

			modelBuilder.Entity<Venda>()
				.Property(v => v.ID_LotesGraos)
				.IsRequired();

			modelBuilder.Entity<Venda>()
				.Property(v => v.ID_Funcionarios)
				.IsRequired();
		}

		public TechFarmContext(DbContextOptions<TechFarmContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite("Data Source=database.db"); // Altere o caminho conforme necessário
			}
		}
	}
}
