using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Dollar.Authentication.Data.Models
{
    public class IdentityModel
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public string UserId { get; set; }

        [BsonElement("resourceName")]
        public string ResourceName { get; set; }

        [BsonElement("last_successful_login")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastSuccessfulLogin { get; set; }

        [BsonElement("account_locked")]
        public bool AccountLocked { get; set; }

        [BsonElement("created_on")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedOn { get; set; }

        [BsonElement("failed_login_attempts")]
        public IEnumerable<DateTime> FailedLoginAttempts { get; set; }

        [BsonElement("passwords")]
        public IEnumerable<PasswordModel> Passwords { get; set; }

        [BsonElement("security_checks")]
        public IEnumerable<SecurityCheckModel> SecurityChecks { get; set; }
    }
}