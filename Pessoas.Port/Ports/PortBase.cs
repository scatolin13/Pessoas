using FluntValidation.Validations;
using Pessoas.Port.Interfaces;
using Pessoas.Service.Interfaces;

namespace Pessoas.Port.Ports
{
    public abstract class PortBase<Entity, EntityResult> : IPortBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        private readonly IServiceBase<Entity, EntityResult> service;

        public PortBase(IServiceBase<Entity, EntityResult> service)
        {
            this.service = service;
        }

        public EntityResult Inserir(params Entity[] entities)
        {
            var res = service.Inserir(entities);

            return res;
        }

        public EntityResult Atualizar(params Entity[] entities)
        {
            var res = service.Atualizar(entities);

            return res;
        }

        public EntityResult Excluir(params Entity[] entities)
        {
            var res = service.Excluir(entities);

            return res;
        }
    }
}
