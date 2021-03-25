using System;
using System.Collections.Generic;

namespace Pessoas.Service.Services
{
    public class ResponseBase2<Entity> where Entity : class
    {
        //private Entity entity;

        //public ResponseBase2()
        //{
        //    var foo = typeof(Entity);

        //    Entities = entity ?? (entity = (Entity)Activator.CreateInstance(typeof(List<>).MakeGenericType(foo)));
        //}

        public Entity Entities { get; set; }
        public List<string> Message { get; set; } = new List<string>();
        public List<string> Exceptions { get; set; } = new List<string>();
    }
}
