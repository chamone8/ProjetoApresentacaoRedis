using Microsoft.EntityFrameworkCore;
using Projeto.Redis.Domain.Entities;
using Projeto.Redis.Infra.Data.Map;

namespace Projeto.Redis.Infra.Data.Context
{
    public class ContextBase : Microsoft.EntityFrameworkCore.DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}