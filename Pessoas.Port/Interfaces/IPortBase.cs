using FluntValidation.Validations;
using RequestResponse;
using System.Threading.Tasks;

namespace Pessoas.Port.Interfaces
{
    public interface IPortBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        Task<ResponseBase<EntityResult>> Inserir(params Entity[] entities);
        Task<ResponseBase<EntityResult>> Atualizar(params Entity[] entities);
        Task<ResponseBase<EntityResult>> Excluir(params Entity[] entities);
    }
}
