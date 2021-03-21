using FluntValidation.Validations;
using System.Threading.Tasks;

namespace Pessoas.Service.Interfaces
{
    public interface IServiceBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        Task<EntityResult> Inserir(params Entity[] entities);
        Task<EntityResult> Atualizar(params Entity[] entities);
        Task<EntityResult> Excluir(params Entity[] entities);
    }
}
