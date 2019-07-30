using NaturaDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace NaturaData
{
    public class NaturaContext : DbContext
    {
        public NaturaContext(DbContextOptions<NaturaContext> options): base(options){

        }
        public DbSet <Category> categories {get;set;}
        public DbSet <Product> products {get;set;}
    }
}