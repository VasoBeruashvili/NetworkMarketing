using NetworkMarketing.DataModels;
using NetworkMarketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private Entities _entities;

        public ProductsRepository(Entities entities)
        {
            _entities = entities;
        }

        public void Add(Product product)
        {
            _entities.Products.Add(product);
        }

        public Product GetById(int id)
        {
            return _entities.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            _entities.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Product product)
        {
            _entities.Entry(product).State = EntityState.Deleted;
        }

        public bool Commit()
        {
            return _entities.SaveChanges() > 0;
        }

        public IEnumerable<Product> GetAll()
        {
            return _entities.Products.AsQueryable();
        }

        public IEnumerable<Product> Search(string value)
        {
            return _entities.Products.Where(p => p.Code.Contains(value) || p.Name.Contains(value)).AsQueryable();
        }
    }
}