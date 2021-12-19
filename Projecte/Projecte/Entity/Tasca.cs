using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Projecte.Entity
{
   public class Tasca
    {
       /* public int ID { get; set; }
        public string Name { get; set; }
        //public string ResponsableTasca { get; set; }
        public string Descripcio { get; set; }
        public DateTime Data { get; set; }
        public DateTime Data1 { get; set; }

        public string Estat { get; set; }
       */
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("Descripcio")]
        public string Descripcio { get; set; }

        [BsonElement("data")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Data { get; set; }

        [BsonElement("data1")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Data1 { get; set; }

        [BsonElement("Estat")]
        public string Estat { get; set; }

    }
}
