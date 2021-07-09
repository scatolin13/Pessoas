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
    [Route("api/[controller]/[action]/{id:int}")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaPort pessoa;

        public PessoaController(IPessoaPort pessoa)
        {
            this.pessoa = pessoa;
        }

        [HttpGet]
        public async Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorId(int id)
        {
            var res = await pessoa.RetornarPorId(id);

            return res;
        }

        [HttpPost]
        public async Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorListaId([FromBody] params int[] id)
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

        [HttpPut]
        public ResponseBase<IEnumerable<PessoaDTO>> InserirNoSql([FromBody] NoSqlRequest<PessoaDTO> pessoas)
        {
            var res = pessoa.InserirNoSql(pessoas.Document, pessoas.Entities);

            return res;
        }
    }
}
