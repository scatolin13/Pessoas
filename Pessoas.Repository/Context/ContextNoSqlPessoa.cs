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

        public IEnumerable<Entity> Get<Entity>(string document)
        {
            var collection = dBase.GetCollection<Entity>(document);

            return collection.Find(o => true).ToList();
        }

        public IEnumerable<Entity> Insert<Entity>(string document, IEnumerable<Entity> entities)
        {
            var collection = dBase.GetCollection<Entity>(document);

            collection.InsertMany(entities);

            return entities;
        }
    }
}
