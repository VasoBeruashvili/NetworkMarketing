using NetworkMarketing.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetworkMarketing.DataModels
{
    [Table("Genders", Schema = "nm")]
    public class Gender
    {
        [Key]
        public byte Id { get; set; }
        public string Name { get; set; }

        public ICollection<Distributor> Distributors { get; set; }
    }
}