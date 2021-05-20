namespace Pessoas.DTO.Request
{
    public class NoSqlRequest<Entity>
    {
        public Entity[] Entities { get; set; }
        public string Document { get; set; }
    }
}
