using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public abstract class AuditableBaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
