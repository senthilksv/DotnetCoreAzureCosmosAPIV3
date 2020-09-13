using Application.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Policy : AuditableBaseEntity
    {
        public Policy()
        {
            Id = Guid.NewGuid();
            PolicyNumber = DateTime.Now.Ticks.ToString();
        }

        [JsonProperty(PropertyName = "policyNumber")]
        public string PolicyNumber { get; set; }

        [JsonProperty(PropertyName = "monthlyPremium")]
        public decimal MonthlyPremium { get; set; }
             
        [JsonProperty(PropertyName = "sumAssured")]
        public decimal SumAssured { get; set; }
                
        [JsonProperty(PropertyName = "coverType")]
        public CoverType CoverType { get; set; }
                
        [JsonProperty(PropertyName = "productType")]
        public ProductType ProductType { get; set; }

        [JsonProperty(PropertyName = "productCategory")]
        public string ProductCategory => ProductType.ToString();

        [JsonProperty(PropertyName = "customerDetails")]
        public Customer CustomerDetails { get; set; }

        [JsonProperty(PropertyName = "isSmoker")]
        public bool IsSmoker { get; set; }

        [JsonProperty(PropertyName = "hasMedicalHistory")]
        public bool HasMedicalHistory { get; set; }
    }
}
