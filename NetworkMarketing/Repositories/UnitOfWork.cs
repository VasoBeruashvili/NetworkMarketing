using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Repositories
{
    public class UnitOfWork
    {
        private Entities _entities;

        private DistributorsRepository _distributorsRepo;
        private ProductsRepository _productsRepo;
        private ProductFlowsRepository _productFlowsRepo;
        private BonusesRepository _bonusesRepo;

        public UnitOfWork(Entities entities)
        {
            _entities = entities;
        }

        public Entities GetEntities()
        {
            return _entities;
        }

        public DistributorsRepository DistributorsRepo
        {
            get
            {
                if (_distributorsRepo == null)
                {
                    _distributorsRepo = new DistributorsRepository(_entities);
                }
                return _distributorsRepo;
            }
        }

        public ProductsRepository ProductsRepo
        {
            get
            {
                if (_productsRepo == null)
                {
                    _productsRepo = new ProductsRepository(_entities);
                }
                return _productsRepo;
            }
        }

        public ProductFlowsRepository ProductFlowsRepo
        {
            get
            {
                if (_productFlowsRepo == null)
                {
                    _productFlowsRepo = new ProductFlowsRepository(_entities);
                }
                return _productFlowsRepo;
            }
        }

        public BonusesRepository BonusesRepo
        {
            get
            {
                if (_bonusesRepo == null)
                {
                    _bonusesRepo = new BonusesRepository(_entities);
                }
                return _bonusesRepo;
            }
        }
    }
}