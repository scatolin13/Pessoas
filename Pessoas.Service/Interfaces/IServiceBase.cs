using FluntValidation.Validations;

namespace Pessoas.Service.Interfaces
{
    public interface IServiceBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        EntityResult Inserir(params Entity[] entities);
        EntityResult Atualizar(params Entity[] entities);
        EntityResult Excluir(params Entity[] entities);
    }
}
