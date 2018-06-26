using NetworkMarketing.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Repositories
{
    public class Entities : DbContext
    {
        public Entities() : base("NetworkMarketingConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<AddressInfo> AddressInfos { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<InfoType> InfoTypes { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFlow> ProductFlows { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
    }
}