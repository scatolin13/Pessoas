using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Port.Interfaces;
using Pessoas.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Port.Ports
{
    public class PessoaPort : PortBase<PessoaDTO, PessoaResponse>, IPessoaPort
    {
        private readonly IPessoaService service;

        public PessoaPort(IPessoaService service) : base(service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<PessoaDTO>> RetornarPorId(params int[] id)
        {
            var res = await service.RetornarPorId(id);

            return res;
        }
        
        public IEnumerable<PessoaDTO> RetornarPorCpf(params string[] cpf)
        {
            var res = service.RetornarPorCpf(cpf);

            return res;
        }

    }
}
