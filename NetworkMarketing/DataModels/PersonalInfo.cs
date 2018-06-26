using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("PersonalInfos", Schema = "nm")]
    public class PersonalInfo 
    {
        [Key]
        public int Id { get; set; }
        public int DocTypeId { get; set; }
        public string DocSeries { get; set; }
        public string DocNumber { get; set; }
        public DateTime DocIssueDate { get; set; }
        public DateTime DocDeadline { get; set; }
        public string PersonalNumber { get; set; }
        public string IssuingAgency { get; set; }
        public int DistributorId { get; set; }

        [ForeignKey("DocTypeId")]
        public InfoType InfoType { get; set; }

        [ForeignKey("DistributorId")]
        public Distributor Distributor { get; set; }
    }
}