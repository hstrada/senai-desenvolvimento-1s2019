using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    public class LocalizacaoDomain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("latitude")]
        [BsonRequired]
        public string Latitude { get; set; }

        [BsonElement("longitude")]
        [BsonRequired]
        public string Longitude { get; set; }

        //[BsonElement("usuario")]
        //public int UsuarioId { get; set; }

    }
}
