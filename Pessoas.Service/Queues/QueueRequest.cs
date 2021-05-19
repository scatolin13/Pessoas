namespace Pessoas.Service.Queues
{
    public class QueueRequest<Entity>
    {
        public string Exchange { get; set; } = "";
        public string QueueName { get; set; }
        public Entity Value { get; set; }
    }
}
