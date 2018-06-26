using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("ContactInfos", Schema = "nm")]
    public class ContactInfo 
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Comment { get; set; }
        public int DistributorId { get; set; }

        [ForeignKey("TypeId")]
        public InfoType InfoType { get; set; }

        [ForeignKey("DistributorId")]
        public Distributor Distributor { get; set; }
    }
}