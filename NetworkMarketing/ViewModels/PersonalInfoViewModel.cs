using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class PersonalInfoViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("docTypeId")]
        public int DocTypeId { get; set; }

        [JsonProperty("docSeries")]
        public string DocSeries { get; set; }

        [JsonProperty("docNumber")]
        public string DocNumber { get; set; }

        [JsonProperty("docIssueDate")]
        public DateTime DocIssueDate { get; set; }

        [JsonProperty("docDeadline")]
        public DateTime DocDeadline { get; set; }

        [JsonProperty("personalNumber")]
        public string PersonalNumber { get; set; }

        [JsonProperty("issuingAgency")]
        public string IssuingAgency { get; set; }

        [JsonProperty("distributorId")]
        public int DistributorId { get; set; }

        [JsonProperty("docTypeName")]
        public string DocTypeName { get; set; }

        [JsonProperty("InfoTypes")]
        public List<InfoTypeViewModel> InfoTypes { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}