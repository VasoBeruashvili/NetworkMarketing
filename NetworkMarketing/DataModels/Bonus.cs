using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("Bonuses", Schema = "nm")]
    public class Bonus
    {
        [Key]
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public DateTime CalculationDate { get; set; }
        public decimal Amount { get; set; }
    }
}