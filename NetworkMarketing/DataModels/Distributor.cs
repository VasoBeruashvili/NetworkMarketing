using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("Distributors", Schema = "nm")]
    public class Distributor 
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte GenderId { get; set; }
        public string ProfileImage { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Distributor ParentDistributor { get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public ICollection<PersonalInfo> PersonalInfos { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }
        public ICollection<AddressInfo> AddressInfos { get; set; }
    }
}