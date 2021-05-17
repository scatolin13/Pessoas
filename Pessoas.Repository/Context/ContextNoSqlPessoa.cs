using MongoDB.Driver;
using System.Collections.Generic;

namespace Pessoas.Repository.Context
{
    public class ContextNoSqlPessoa
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase dBase;

        public ContextNoSqlPessoa(string connectionString, string dataBase)
        {
            client = new MongoClient(connectionString);
            dBase = client.GetDatabase(dataBase);
        }

        public IMongoCollection<Entity> Get<Entity>(string document)
        {
            var collection = dBase.GetCollection<Entity>(document);

            return collection;
        }

        public void Insert<Entity>(string document, IEnumerable<Entity> entities)
        {
            var collection = dBase.GetCollection<Entity>(document);

            collection.InsertMany(entities);
        }
    }
}
