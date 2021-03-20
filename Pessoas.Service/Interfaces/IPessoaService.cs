using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using System.Collections.Generic;

namespace Pessoas.Service.Interfaces
{
    public interface IPessoaService : IServiceBase<PessoaDTO, PessoaResponse>
    {
        IEnumerable<PessoaDTO> RetornarPorId(params int[] id);
        IEnumerable<PessoaDTO> RetornarPorCpf(params string[] cpf);
    }
}
