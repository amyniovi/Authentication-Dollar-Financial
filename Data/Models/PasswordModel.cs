using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Dollar.Authentication.Data.Models
{
    public class PasswordModel
    {
        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("salt")]
        public string Salt { get; set; }

        [BsonElement("version")]
        public string Version { get; set; }

        [BsonElement("created_on")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedOn { get; set; }
    }
}