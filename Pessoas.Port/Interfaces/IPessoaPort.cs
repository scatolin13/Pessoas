using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Port.Interfaces
{
    public interface IPessoaPort : IPortBase<PessoaDTO, PessoaResponse>
    {
        Task<IEnumerable<PessoaDTO>> RetornarPorId(params int[] id);
        Task<IEnumerable<PessoaDTO>> RetornarPorCpf(params string[] cpf);
    }
}
