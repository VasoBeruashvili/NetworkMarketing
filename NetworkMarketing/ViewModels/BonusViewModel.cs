using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class BonusViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("distributorId")]
        public int DistributorId { get; set; }

        [JsonProperty("calculationDate")]
        public DateTime CalculationDate { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("distributorFirstName")]
        public string DistributorFirstName { get; set; }

        [JsonProperty("distributorLastName")]
        public string DistributorLastName { get; set; }
    }
}