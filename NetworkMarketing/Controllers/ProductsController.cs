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
    public class ProductsController : BaseController
    {
        private UnitOfWork _uow;
        private DataMapper _dataMapper;
        public ProductsController()
        {
            _uow = new UnitOfWork(new Entities());
            _dataMapper = new DataMapper();
        }


        public ActionResult Index()
        {
            ViewBag.Title = "პროდუქცია";
            return View();
        }

        public JsonResult GetAll()
        {
            return Json(_uow.ProductsRepo.GetAll().Select(p => _dataMapper.MapData(p)));
        }

        public JsonResult Save(ProductViewModel product)
        {
            var _product = _dataMapper.MapData(product);

            if (product.Id == 0)
                _uow.ProductsRepo.Add(_product);
            else
                _uow.ProductsRepo.Update(_product);

            return Json(_uow.ProductsRepo.Commit());
        }

        public JsonResult Delete(int id)
        {
            var product = _uow.ProductsRepo.GetById(id);

            _uow.ProductsRepo.Delete(product);

            return Json(_uow.ProductsRepo.Commit());
        }

        public JsonResult Search(string value)
        {
            return Json(_uow.ProductsRepo.Search(value).Select(p => _dataMapper.MapData(p)));
        }
    }
}