using FluntValidation.Validations;
using System;

namespace Pessoas.Repository.Interfaces
{
    public interface IRepositoryBase<Entity> where Entity : EntityBase
    {
        void Inserir(params Entity[] entities);
        void Atualizar(params Entity[] entities);
        void Excluir(params Entity[] entities);
        void SaveChanges();
    }
}
