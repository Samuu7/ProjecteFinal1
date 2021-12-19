using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Projecte.Entity
{
    class Responsable
    {
       /* public int ID { get; set; }
        public string Name { get; set; }*/
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        

    }
}
