using Microsoft.AspNetCore.Mvc;
using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Port.Interfaces;
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
        public async Task<IEnumerable<PessoaDTO>> RetornarPorId([FromBody] params int[] id)
        {
            var res = await pessoa.RetornarPorId(id);
            
            return res;
        }

        [HttpPut]
        public async Task<PessoaResponse> Inserir([FromBody] params PessoaDTO[] pessoas)
        {
            var res = new PessoaResponse();

            try
            {
                res = await pessoa.Inserir(pessoas);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return res;
        }
    }
}
