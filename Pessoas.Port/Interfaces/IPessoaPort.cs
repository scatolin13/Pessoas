using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Port.Interfaces
{
    public interface IPessoaPort : IPortBase<PessoaDTO, PessoaResponse>
    {
        Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorId(params int[] id);
        Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorCpf(params string[] cpf);
    }
}
