namespace Pessoas.Service.Queues
{
    public interface IServiceBus
    {
        void SendQueue<Entity>(QueueRequest<Entity> queueRequest);
    }
}
