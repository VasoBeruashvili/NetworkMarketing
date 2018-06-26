using NetworkMarketing.DataModels;
using NetworkMarketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Repositories
{
    public class ProductFlowsRepository : IRepository<ProductFlow>
    {
        private Entities _entities;

        public ProductFlowsRepository(Entities entities)
        {
            _entities = entities;
        }

        public void Add(ProductFlow productFlow)
        {
            _entities.ProductFlows.Add(productFlow);
        }

        public ProductFlow GetById(int id)
        {
            return _entities.ProductFlows.FirstOrDefault(pf => pf.Id == id);
        }

        public void Update(ProductFlow productFlow)
        {
            _entities.Entry(productFlow).State = EntityState.Modified;
        }

        public void Delete(ProductFlow productFlow)
        {
            _entities.Entry(productFlow).State = EntityState.Deleted;
        }

        public bool Commit()
        {
            return _entities.SaveChanges() > 0;
        }

        public IEnumerable<ProductFlow> GetAll()
        {
            return _entities.ProductFlows.AsQueryable();
        }

        public IEnumerable<ProductFlowViewModel> GetAllWithDependencies()
        {
            return from pf in _entities.ProductFlows
                   join d in _entities.Distributors on pf.DistributorId equals d.Id
                   join p in _entities.Products on pf.ProductId equals p.Id
                   select new ProductFlowViewModel
                   {
                       Id = pf.Id,
                       DistributorId = d.Id,
                       DistributorFirstName = d.FirstName,
                       DistributorLastName = d.LastName,
                       OperationDate = pf.SellingDate,
                       ProductId = p.Id,
                       ProductUnitPrice = p.UnitPrice,
                       ProductCode = p.Code,
                       ProductName = p.Name,
                       Quantity = pf.Quantity,
                       Amount = pf.Amount
                   };
        }
    }
}