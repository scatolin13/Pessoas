using Pessoas.Models;
using System.Collections.Generic;

namespace Pessoas.Repository.Interfaces
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        IEnumerable<Pessoa> RetornarPorId(params int[] id);
        IEnumerable<Pessoa> RetornarPorCpf(params string[] cpf);
        
    }
}
