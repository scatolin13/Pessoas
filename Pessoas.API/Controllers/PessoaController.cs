using Microsoft.AspNetCore.Mvc;
using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Port.Interfaces;
using RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaPort pessoa;

        public PessoaController(IPessoaPort pessoa)
        {
            this.pessoa = pessoa;
        }

        [HttpPost]
        public async Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorId([FromBody] params int[] id)
        {
            var res = await pessoa.RetornarPorId(id);

            return res;
        }

        [HttpPut]
        public async Task<ResponseBase<PessoaResponse>> Inserir([FromBody] params PessoaDTO[] pessoas)
        {
            var res = await pessoa.Inserir(pessoas);
    
            return res;
        }

        [HttpPut]
        public async Task<ResponseBase<PessoaResponse>> Atualizar([FromBody] params PessoaDTO[] pessoas)
        {
            var res = await pessoa.Atualizar(pessoas);

            return res;
        }
    }
}
