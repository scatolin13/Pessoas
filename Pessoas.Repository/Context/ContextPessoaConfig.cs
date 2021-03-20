using Microsoft.EntityFrameworkCore;
using System;

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

    }
}
