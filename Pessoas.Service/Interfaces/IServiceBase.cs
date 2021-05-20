using FluntValidation.Validations;
using RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Service.Interfaces
{
    public interface IServiceBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        Task<ResponseBase<EntityResult>> Inserir(params Entity[] entities);
        Task<ResponseBase<EntityResult>> Atualizar(params Entity[] entities);
        Task<ResponseBase<EntityResult>> Excluir(params Entity[] entities);
        ResponseBase<IEnumerable<Entity>> InserirNoSql(string document, params Entity[] entities);
    }
}
