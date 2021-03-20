using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using System.Collections.Generic;

namespace Pessoas.Port.Interfaces
{
    public interface IPessoaPort : IPortBase<PessoaDTO, PessoaResponse>
    {
        IEnumerable<PessoaDTO> RetornarPorId(params int[] id);
        IEnumerable<PessoaDTO> RetornarPorCpf(params string[] cpf);
    }
}
