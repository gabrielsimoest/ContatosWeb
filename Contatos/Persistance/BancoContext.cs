using Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Persistance
{
    public class BancoContext : DbContext
    {
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Contato> Contato { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }
    }
}
