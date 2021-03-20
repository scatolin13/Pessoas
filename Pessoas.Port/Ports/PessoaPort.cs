using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Port.Interfaces;
using Pessoas.Service.Interfaces;
using System.Collections.Generic;

namespace Pessoas.Port.Ports
{
    public class PessoaPort : PortBase<PessoaDTO, PessoaResponse>, IPessoaPort
    {
        private readonly IPessoaService service;

        public PessoaPort(IPessoaService service) : base(service)
        {
            this.service = service;
        }

        public IEnumerable<PessoaDTO> RetornarPorId(params int[] id)
        {
            var res = service.RetornarPorId(id);

            return res;
        }
        
        public IEnumerable<PessoaDTO> RetornarPorCpf(params string[] cpf)
        {
            var res = service.RetornarPorCpf(cpf);

            return res;
        }

    }
}
