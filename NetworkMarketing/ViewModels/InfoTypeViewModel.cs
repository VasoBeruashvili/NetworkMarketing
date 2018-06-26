using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class InfoTypeViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("typeId")]
        public int TypeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}