using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Dollar.Authentication.Data.Models
{
    public class ActiveSecurityCheckModel
    {
        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("created_on")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedOn { get; set; }
    }
}