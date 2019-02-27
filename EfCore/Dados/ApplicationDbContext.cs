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
            modelBuilder.Entity<Pedido>().HasKey(p =>p.Numero);
            //Define que o banco de dados obterá a data atual e populará o campo Data resultante do mapeamento da entidade Pedido
            modelBuilder.Entity<Pedido>().Property(p => p.Data)
                .IsRequired()
                .HasDefaultValueSql("getDate();");
        }
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Pedido> Pedido {get; set;}
    }
}