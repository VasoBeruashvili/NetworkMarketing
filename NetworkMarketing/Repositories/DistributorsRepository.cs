using NetworkMarketing.DataModels;
using NetworkMarketing.Utilities;
using NetworkMarketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Repositories
{
    public class DistributorsRepository : IRepository<Distributor>
    {
        private Entities _entities;

        public DistributorsRepository(Entities entities)
        {
            _entities = entities;
        }

        public void Add(Distributor entity)
        {
            _entities.Distributors.Add(entity);
        }

        public Distributor GetById(int id)
        {
            return _entities.Distributors.FirstOrDefault(d => d.Id == id);
        }

        public bool Commit()
        {
            return _entities.SaveChanges() > 0;
        }

        public void Update(Distributor distributor)
        {
            _entities.Entry(distributor).State = EntityState.Modified;
        }

        public void Delete(Distributor distributor)
        {
            _entities.Entry(distributor).State = EntityState.Deleted;
        }

        public IEnumerable<Distributor> GetAll()
        {
            return _entities.Distributors.AsQueryable();
        }





        #region Custom Logic
        public IEnumerable<Distributor> Search(string value)
        {
            return _entities.Distributors.Where(d => d.FirstName.Contains(value) || d.LastName.Contains(value)).AsQueryable();
        }


        public IEnumerable<DistributorViewModel> GetAllWithPersonalInfos()
        {
            return from d in _entities.Distributors
                   join pi in _entities.PersonalInfos on d.Id equals pi.DistributorId
                   join g in _entities.Genders on d.GenderId equals g.Id
                   join pd in _entities.Distributors on d.ParentId equals pd.Id into pds
                   from _pd in pds.DefaultIfEmpty()
                   select new DistributorViewModel
                   {
                       Id = d.Id,
                       FirstName = d.FirstName,
                       LastName = d.LastName,
                       BirthDate = d.BirthDate,
                       GenderId = g.Id,
                       Gender = g.Name,
                       PersonalNumber = pi.PersonalNumber,
                       ParentId = d.ParentId,
                       ParentFirstName = _pd.FirstName,
                       ParentLastName = _pd.LastName
                   };
        }

        public IEnumerable<PersonalInfoViewModel> GetPersonalInfos(int id)
        {
            return from pi in _entities.PersonalInfos
                   join it in _entities.InfoTypes on pi.DocTypeId equals it.Id
                   where pi.DistributorId == id
                   select new PersonalInfoViewModel
                   {
                       Id = pi.Id,
                       DocTypeId = pi.DocTypeId,
                       DocSeries = pi.DocSeries,
                       DocNumber = pi.DocNumber,
                       DocIssueDate = pi.DocIssueDate,
                       DocDeadline = pi.DocDeadline,
                       PersonalNumber = pi.PersonalNumber,
                       IssuingAgency = pi.IssuingAgency,
                       DistributorId = pi.DistributorId,
                       DocTypeName = it.Name
                   };
        }

        public IEnumerable<ContactInfoViewModel> GetContactInfos(int id)
        {
            return from ci in _entities.ContactInfos
                   join it in _entities.InfoTypes on ci.TypeId equals it.Id
                   where ci.DistributorId == id
                   select new ContactInfoViewModel
                   {
                       Id = ci.Id,
                       TypeId = ci.TypeId,
                       TypeName = it.Name,
                       Comment = ci.Comment,
                       DistributorId = ci.DistributorId
                   };
        }

        public IEnumerable<AddressInfoViewModel> GetAddressInfos(int id)
        {
            return from ai in _entities.AddressInfos
                   join it in _entities.InfoTypes on ai.TypeId equals it.Id
                   where ai.DistributorId == id
                   select new AddressInfoViewModel
                   {
                       Id = ai.Id,
                       TypeId = ai.TypeId,
                       TypeName = it.Name,
                       Address = ai.Address,
                       DistributorId = ai.DistributorId
                   };
        }

        public IEnumerable<InfoTypeViewModel> GetInfoTypes(int id)
        {
            return _entities.InfoTypes.Where(it => it.TypeId == id).Select(it => new InfoTypeViewModel
            {
                Id = it.Id,
                TypeId = it.TypeId,
                Name = it.Name
            });
        }

        public IEnumerable<PersonalInfo> GetPersonalInfosByDistributorId(int id)
        {
            return _entities.PersonalInfos.Where(pi => pi.DistributorId == id);
        }
        public void AddPersonalInfo(PersonalInfo entity)
        {
            _entities.PersonalInfos.Add(entity);
        }
        public void UpdatePersonalInfo(PersonalInfo entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
        public void DeletePersonalInfo(PersonalInfo entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }


        public IEnumerable<ContactInfo> GetContactInfosByDistributorId(int id)
        {
            return _entities.ContactInfos.Where(ci => ci.DistributorId == id);
        }
        public void AddContactInfo(ContactInfo entity)
        {
            _entities.ContactInfos.Add(entity);
        }
        public void UpdateContactInfo(ContactInfo entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
        public void DeleteContactInfo(ContactInfo entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }


        public IEnumerable<AddressInfo> GetAddressInfosByDistributorId(int id)
        {
            return _entities.AddressInfos.Where(ai => ai.DistributorId == id);
        }
        public void AddAddressInfo(AddressInfo entity)
        {
            _entities.AddressInfos.Add(entity);
        }
        public void UpdateAddressInfo(AddressInfo entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
        public void DeleteAddressInfo(AddressInfo entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
        }

        public PersonalInfo GetPersonalInfoById(int id)
        {
            return _entities.PersonalInfos.FirstOrDefault(pi => pi.Id == id);
        }
        public ContactInfo GetContactInfoById(int id)
        {
            return _entities.ContactInfos.FirstOrDefault(ci => ci.Id == id);
        }
        public AddressInfo GetAddressInfoById(int id)
        {
            return _entities.AddressInfos.FirstOrDefault(ai => ai.Id == id);
        }







        public bool CheckForFourthLevel(int id)
        {
            return _entities.Distributors.Count(d => d.ParentId == id) < 3;
        }

        public bool CheckForFifthRootLevel(int id)
        {
            int globalLevelsCount = 0;
            GetChildLevelsCount(id, ref globalLevelsCount);

            return globalLevelsCount < 5;
        }
        private void GetChildLevelsCount(int id, ref int levelsCount)
        {
            var children = _entities.Distributors.Where(d => d.ParentId == id).ToList();
            if(children.Count() > 0)
            {
                if (levelsCount < 5)
                {
                    levelsCount++;                    
                }

                foreach (var child in children)
                {
                    GetChildLevelsCount(child.Id, ref levelsCount);
                }                
            }
        }
        #endregion
    }
}