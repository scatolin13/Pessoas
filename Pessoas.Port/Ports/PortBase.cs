using FluntValidation.Validations;
using Pessoas.Port.Interfaces;
using Pessoas.Service.Interfaces;
using RequestResponse;
using System.Threading.Tasks;

namespace Pessoas.Port.Ports
{
    public abstract class PortBase<Entity, EntityResult> : IPortBase<Entity, EntityResult> where Entity : class where EntityResult : EntityBase
    {
        private readonly IServiceBase<Entity, EntityResult> service;

        public PortBase(IServiceBase<Entity, EntityResult> service)
        {
            this.service = service;
        }

        public async Task<ResponseBase<EntityResult>> Inserir(params Entity[] entities)
        {
            var res = await service.Inserir(entities);

            return res;
        }

        public async Task<ResponseBase<EntityResult>> Atualizar(params Entity[] entities)
        {
            var res = await service.Atualizar(entities);

            return res;
        }

        public async Task<ResponseBase<EntityResult>> Excluir(params Entity[] entities)
        {
            var res = await service .Excluir(entities);

            return res;
        }
    }
}
