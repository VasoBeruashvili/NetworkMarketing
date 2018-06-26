using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.ViewModels
{
    public class DistributorViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("genderId")]
        public byte GenderId { get; set; }

        [JsonProperty("profileImage")]
        public string ProfileImage { get; set; }

        [JsonProperty("parentId")]
        public int? ParentId { get; set; }

        [JsonProperty("parentFirstName")]
        public string ParentFirstName { get; set; }

        [JsonProperty("parentLastName")]
        public string ParentLastName { get; set; }


        [JsonProperty("personalNumber")]
        public string PersonalNumber { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }


        [JsonProperty("parentDistributors")]
        public List<DistributorViewModel> ParentDistributors { get; set; }

        [JsonProperty("personalInfos")]
        public List<PersonalInfoViewModel> PersonalInfos { get; set; }

        [JsonProperty("contactInfos")]
        public List<ContactInfoViewModel> ContactInfos { get; set; }

        [JsonProperty("addressInfos")]
        public List<AddressInfoViewModel> AddressInfos { get; set; }
    }
}