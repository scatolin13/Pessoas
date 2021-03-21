using FluntValidation.Validations;
using System.Threading.Tasks;

namespace Pessoas.Repository.Interfaces
{
    public interface IRepositoryBase<Entity> where Entity : EntityBase
    {
        void Inserir(params Entity[] entities);
        void Atualizar(params Entity[] entities);
        void Excluir(params Entity[] entities);
        Task<bool> SaveChanges();
    }
}
