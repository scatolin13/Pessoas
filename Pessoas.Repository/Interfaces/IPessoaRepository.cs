using Pessoas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Repository.Interfaces
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Task<bool> ExistePorId(int id);
        Task<bool> ExistePorCpf(string cpf);
        Task<IEnumerable<Pessoa>> RetornarPorId(params int[] id);
        Task<IEnumerable<Pessoa>> RetornarPorCpf(params string[] cpf);
    }
}
