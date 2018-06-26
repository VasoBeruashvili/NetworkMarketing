using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class AddressInfoViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("typeId")]
        public int TypeId { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

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