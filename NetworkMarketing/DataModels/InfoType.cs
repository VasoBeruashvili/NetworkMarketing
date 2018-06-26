using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("InfoTypes", Schema = "nm")]
    public class InfoType 
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public ICollection<AddressInfo> AddressInfos { get; set; }
        public ICollection<PersonalInfo> PersonalInfos { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}