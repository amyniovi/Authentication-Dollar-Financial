using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Dollar.Authentication.Data.Models
{
    public class SecurityCheckModel
    {
        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("value")]
        public string Value { get; set; }

        [BsonElement("created_on")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedOn { get; set; }
    }
}