using Microsoft.EntityFrameworkCore;
using Pessoas.Models;
using Pessoas.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Repository.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        
        public PessoaRepository(string connectionString) : base(connectionString)
        {
        }

        public Task<bool> ExistePorId(int id)
        {
            var res = context.Pessoas
                .AsNoTracking()
                .AnyAsync(o => o.Id == id);

            return res;
        }

        public Task<bool> ExistePorCpf(string cpf)
        {
            var res = context.Pessoas
                .AsNoTracking()
                .AnyAsync(o => o.Cpf == cpf);

            return res;
        }

        public async Task<IEnumerable<Pessoa>> RetornarPorId(params int[] id)
        {
            var res = await context.Pessoas
                .AsNoTracking()
                .Where(o => id.Contains(o.Id))
                .ToListAsync();

            return res;
        }

        public async Task<IEnumerable<Pessoa>> RetornarPorCpf(params string[] cpf)
        {
            var res = await context.Pessoas
                .AsNoTracking()
                .Where(o => cpf.Contains(o.Cpf))
                .ToListAsync();

            return res;
        }
    }
}
