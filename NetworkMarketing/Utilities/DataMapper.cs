using NetworkMarketing.DataModels;
using NetworkMarketing.Repositories;
using NetworkMarketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkMarketing.Utilities
{
    public class DataMapper
    {
        #region Distributors
        public DistributorViewModel MapData(Distributor model)
        {
            return new DistributorViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public Distributor MapData(DistributorViewModel viewModel)
        {
            return new Distributor
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                BirthDate = viewModel.BirthDate,
                GenderId = viewModel.GenderId,
                ParentId = viewModel.ParentId                
            };
        }
        #endregion






        #region Products
        public ProductViewModel MapData(Product model)
        {
            return new ProductViewModel
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                UnitPrice = model.UnitPrice
            };
        }

        public Product MapData(ProductViewModel viewModel)
        {
            return new Product
            {
                Id = viewModel.Id,
                Code = viewModel.Code,
                Name = viewModel.Name,
                UnitPrice = viewModel.UnitPrice
            };
        }
        #endregion






        #region ProductFlows
        public ProductFlow MapData(ProductFlowViewModel viewModel)
        {
            return new ProductFlow
            {
                Id = viewModel.Id,
                DistributorId = viewModel.DistributorId,
                ProductId = viewModel.ProductId,
                SellingDate = viewModel.OperationDate,
                Quantity = viewModel.Quantity,
                Amount = viewModel.Amount
            };
        }
        #endregion





        #region PersonalInfos
        public PersonalInfo MapData(PersonalInfoViewModel viewModel)
        {
            return new PersonalInfo
            {
                Id = viewModel.Id,
                DocTypeId = viewModel.DocTypeId,
                DocSeries = viewModel.DocSeries,
                DocNumber = viewModel.DocNumber,
                DocIssueDate = viewModel.DocIssueDate,
                DocDeadline = viewModel.DocDeadline,
                PersonalNumber = viewModel.PersonalNumber,
                IssuingAgency = viewModel.IssuingAgency,
                DistributorId = viewModel.DistributorId
            };
        }
        #endregion





        #region ContactInfos
        public ContactInfo MapData(ContactInfoViewModel viewModel)
        {
            return new ContactInfo
            {
                Id = viewModel.Id,
                TypeId = viewModel.TypeId,
                Comment = viewModel.Comment,
                DistributorId = viewModel.DistributorId
            };
        }
        #endregion




        #region AddressInfos
        public AddressInfo MapData(AddressInfoViewModel viewModel)
        {
            return new AddressInfo
            {
                Id = viewModel.Id,
                TypeId = viewModel.TypeId,
                Address = viewModel.Address,
                DistributorId = viewModel.DistributorId
            };
        }
        #endregion
    }
}