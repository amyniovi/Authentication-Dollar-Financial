using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Dollar.Authentication.Data.Models
{
    public class ResourceModel
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("maximum_failed_login_attempts")]
        public int MaximumFailedLoginAttempts { get; set; }

        [BsonElement("active_security_checks")]
        public IEnumerable<ActiveSecurityCheckModel> ActiveSecurityChecks { get; set; }
    }
}