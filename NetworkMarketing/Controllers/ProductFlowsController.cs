using NetworkMarketing.DataModels;
using NetworkMarketing.Repositories;
using NetworkMarketing.Utilities;
using NetworkMarketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetworkMarketing.Controllers
{
    public class ProductFlowsController : BaseController
    {
        private UnitOfWork _uow;
        private DataMapper _dataMapper;
        public ProductFlowsController()
        {
            _uow = new UnitOfWork(new Entities());
            _dataMapper = new DataMapper();
        }


        public ActionResult Index()
        {
            ViewBag.Title = "გაყიდვები";
            return View();
        }

        public JsonResult GetAll()
        {
            return Json(_uow.ProductFlowsRepo.GetAllWithDependencies());
        }

        public JsonResult Save(ProductFlowViewModel productFlow)
        {
            var _productFlow = _dataMapper.MapData(productFlow);

            if (productFlow.Id == 0)
                _uow.ProductFlowsRepo.Add(_productFlow);
            else
                _uow.ProductFlowsRepo.Update(_productFlow);

            return Json(_uow.ProductFlowsRepo.Commit());
        }

        public JsonResult Delete(int id)
        {
            var productFlow = _uow.ProductFlowsRepo.GetById(id);

            _uow.ProductFlowsRepo.Delete(productFlow);

            return Json(_uow.ProductFlowsRepo.Commit());
        }
    }
}