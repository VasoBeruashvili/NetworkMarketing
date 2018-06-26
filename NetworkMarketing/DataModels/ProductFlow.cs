using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("ProductFlows", Schema = "nm")]
    public class ProductFlow 
    {
        [Key]
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public DateTime SellingDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}