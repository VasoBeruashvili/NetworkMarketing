using NetworkMarketing.DataModels;
using NetworkMarketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Repositories
{
    public class BonusesRepository : IRepository<Bonus>
    {
        private Entities _entities;

        public BonusesRepository(Entities entities)
        {
            _entities = entities;
        }

        public void Add(Bonus bonus)
        {
            _entities.Bonuses.Add(bonus);
        }

        public Bonus GetById(int id)
        {
            return _entities.Bonuses.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Bonus bonus)
        {
            _entities.Entry(bonus).State = EntityState.Modified;
        }

        public void Delete(Bonus bonus)
        {
            _entities.Entry(bonus).State = EntityState.Deleted;
        }

        public bool Commit()
        {
            return _entities.SaveChanges() > 0;
        }

        public IEnumerable<Bonus> GetAll()
        {
            return _entities.Bonuses.AsQueryable();
        }

        public IEnumerable<BonusViewModel> GetAllWithDependencies(DateTime fromDate, DateTime toDate)
        {
            return from b in _entities.Bonuses
                   join d in _entities.Distributors on b.DistributorId equals d.Id
                   where b.CalculationDate >= fromDate && b.CalculationDate <= toDate
                   select new BonusViewModel
                   {
                       Id = b.Id,
                       CalculationDate = b.CalculationDate,
                       DistributorId = d.Id,
                       DistributorFirstName = d.FirstName,
                       DistributorLastName = d.LastName,
                       Amount = b.Amount
                   };               
        }

        public bool Calculate(DateTime fromDate, DateTime toDate)
        {
            // ყველა დისტრიბუტორის Id და ბონუსის თანხა, რომელთაც უკვე გადათვლილი აქვთ ბონუსი მითითებულ პერიოდში
            var calculatedBonuses = _entities.Bonuses.Where(b => b.CalculationDate >= fromDate && b.CalculationDate <= toDate).ToList();

            // მითითებულ პერიოდში ყველა გაყიდვა დაჯგუფებული დისტრიბუტორის Id -ით
            var productFlows = _entities.ProductFlows.Where(pf => pf.SellingDate >= fromDate && pf.SellingDate <= toDate).GroupBy(pf => pf.DistributorId).ToList();

            foreach (var groupedFlow in productFlows)
            {
                decimal privateFlowSum = groupedFlow.Sum(gf => gf.Amount) * 0.1M; // დისტრიბუტორის პირადი გაყიდვების 10%
                var distBonus = calculatedBonuses.FirstOrDefault(cb => cb.DistributorId == groupedFlow.Key); // ჩანაწერი გადათვლილი ბონუსებიდან მოცემულ დისტრიბუტორზე
                
                // კონკრეტული დისტრიბუტორის მიერ მოყვანილი დისტრიბუტორების გაყიდვების ჯამის 5% -ის გამოთვლა
                decimal flowSum = 0;
                GetSecondAndThirdLevelFlowSum(groupedFlow.Key, productFlows, ref flowSum, 0.05M, 1);

                if (distBonus == null) // თუ მითითებულ დისტრიბუტორს გადათვლილი არ აქვს ბონუსი, იქმნება ახალი ჩანაწერი ბონუსებში
                {                    
                    Add(new Bonus
                    {
                        DistributorId = groupedFlow.Key,
                        Amount = privateFlowSum + flowSum,
                        CalculationDate = DateTime.Now
                    });
                }
                else // წინააღმდეგ შემთხვევაში მოწმდება თანხები, რათა შეიძლება გაყიდვები დაემატა და უნდა იყოს ახალი დამატებული გაყიდვებიც გათვალისწინებული უკვე გადათვლილ ბონუსში
                {
                    if(privateFlowSum > distBonus.Amount) // თუ პირადი ჯამური გაყიდვების 10% მეტია უკვე გადათვლილ ბონუსზე, რაც იმას ნიშნავს, რომ მოცემულ პერიოდში მოხდა ახალი გაყიდვა, რომელიც არაა გადათვლილი
                    {
                        distBonus.CalculationDate = DateTime.Now;
                        distBonus.Amount = privateFlowSum + flowSum;
                        Update(distBonus);
                    }
                }
            }

            return Commit();
        }


        // მუშაობს ასევე N დონიან მოდელთან შეზღუდვების გარეშე
        private void GetSecondAndThirdLevelFlowSum(int parentDistributorId, List<IGrouping<int, ProductFlow>> flows, ref decimal flowSum, decimal percent, int level)
        {
            // ამოწმებს თუ რომელ დონეზეა დონეებს
            if (level < 3)
            {
                level++;

                // გადმოცემული დისტრიბუტორისმიერ მოყვანილი დისტრიბუტორების Id -ები
                var childDistributorIds = _entities.Distributors.Where(d => d.ParentId == parentDistributorId).Select(d => d.Id).ToList();

                // აჯამებს გაფილტრული დისტრიბუტორების მიერ გაყიდვებს
                flowSum += flows.Where(f => childDistributorIds.Contains(f.Key)).Sum(ff => ff.Sum(fff => fff.Amount)) * percent;

                foreach (var cdi in childDistributorIds)
                {
                    // რეკურსიულად იძახებს იგივე მეთოდს ყოველი child დისტრიბუტორისთვის
                    GetSecondAndThirdLevelFlowSum(cdi, flows, ref flowSum, 0.01M, level);
                }
            }
        }
    }
}