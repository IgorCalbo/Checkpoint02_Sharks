using Microsoft.EntityFrameworkCore;
using Sharks.Checkpoint02.Models;


namespace Sharks.Checkpoint02.Persistencias
{
    public class SharksContext : DbContext
    {
        // Construtor que recebe DbContextOptions (string de conexão)
        public SharksContext(DbContextOptions options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Escritor> Escritores { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<LivroEscritor> LivrosEscritores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a chave composta da tabela associativa
            modelBuilder.Entity<LivroEscritor>().HasKey(m => new { m.EscritorId, m.LivroId });

            // Configurar o relacionamento entre a tabela associativa e o escritor
            modelBuilder.Entity<LivroEscritor>()
                .HasOne(m => m.Escritor)
                .WithMany(m => m.LivrosEscritores)
                .HasForeignKey(m => m.EscritorId);

            // Configurar o relacionamento entre a tabela associativa e o livro
            modelBuilder.Entity<LivroEscritor>()
                .HasOne(m => m.Livro)
                .WithMany(m => m.LivrosEscritores)
                .HasForeignKey(m => m.LivroId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
