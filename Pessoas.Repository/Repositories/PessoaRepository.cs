using Pessoas.Models;
using Pessoas.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Pessoas.Repository.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        
        public PessoaRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Pessoa> RetornarPorId(params int[] id)
        {
            var res = context.Pessoas
                .Where(o => id.Contains(o.Id))
                .ToList();

            return res;
        }

        public IEnumerable<Pessoa> RetornarPorCpf(params string[] cpf)
        {
            var res = context.Pessoas
                .Where(o => cpf.Contains(o.Cpf))
                .ToList();

            return res;
        }
    }
}
