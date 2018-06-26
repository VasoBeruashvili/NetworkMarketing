using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class ContactInfoViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("typeId")]
        public int TypeId { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("distributorId")]
        public int DistributorId { get; set; }

        [JsonProperty("typeName")]
        public string TypeName { get; set; }

        [JsonProperty("InfoTypes")]
        public List<InfoTypeViewModel> InfoTypes { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}