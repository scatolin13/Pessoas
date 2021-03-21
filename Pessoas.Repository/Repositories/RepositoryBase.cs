using FluntValidation.Validations;
using Pessoas.Repository.Context;
using Pessoas.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Pessoas.Repository.Repositories
{
    public abstract class RepositoryBase<Entity> : IDisposable, IRepositoryBase<Entity> where Entity : EntityBase
    {
        protected readonly ContextPessoa context;
        private bool disposedValue = false;

        public RepositoryBase(string connectionString)
        {
            context = new ContextPessoa(connectionString);
        }

        public void Inserir(params Entity[] entities)
        {
            context.AddRange(entities);
        }

        public void Atualizar(params Entity[] entities)
        {
            context.UpdateRange(entities);
        }

        public void Excluir(params Entity[] entities)
        {
            context.RemoveRange(entities);
        }

        public async Task<bool> SaveChanges()
        {
            await context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing) { }
                disposedValue = true;
            }
        }
    }
}
