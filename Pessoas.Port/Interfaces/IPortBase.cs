using FluntValidation.Validations;

namespace Pessoas.Port.Interfaces
{
    public interface IPortBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        EntityResult Inserir(params Entity[] entities);
        EntityResult Atualizar(params Entity[] entities);
        EntityResult Excluir(params Entity[] entities);
    }
}
