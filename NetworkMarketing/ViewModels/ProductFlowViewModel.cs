using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class ProductFlowViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("distributorFirstName")]
        public string DistributorFirstName { get; set; }

        [JsonProperty("distributorLastName")]
        public string DistributorLastName { get; set; }

        [JsonProperty("operationDate")]
        public DateTime OperationDate { get; set; }

        [JsonProperty("productUnitPrice")]
        public decimal ProductUnitPrice { get; set; }

        [JsonProperty("productCode")]
        public string ProductCode { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("distributorId")]
        public int DistributorId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }
    }
}