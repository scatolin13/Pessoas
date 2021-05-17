using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pessoas.Repository.Context
{
    public partial class ContextPessoa : DbContext
    {
        private readonly string connectionString;
        public ContextPessoa(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(o => o.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(o => o.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

    }
}
