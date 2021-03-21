using FluntValidation.Validations;
using System.Threading.Tasks;

namespace Pessoas.Port.Interfaces
{
    public interface IPortBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        Task<EntityResult> Inserir(params Entity[] entities);
        Task<EntityResult> Atualizar(params Entity[] entities);
        Task<EntityResult> Excluir(params Entity[] entities);
    }
}
