using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){

        }
        //Esse método configura a opção de Lazy Loading 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        //Esse método configura a Fluent API permitindo alterar as definições padrões do mapeamento Objeto-relacional
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //Define que a tabela resultante do mapeamento da entidade produto se chamará Produto
            modelBuilder.Entity<Produto>().ToTable("Produto");
            //Define que a propriedade nome da tabela que mapeia a Entidade produto possuirá no máximo 50 caracteres
            modelBuilder.Entity<Produto>().Property(p=>p.Nome).HasMaxLength(50);
            //Define a propriedade Numero como chave primária da tabela resultante do mapeamento da entidade Produto
            //modelBuilder.Entity<Produto>().HasKey(p=>p.Numero);
        }
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Produto> Produtos {get; set;}   
    }
}