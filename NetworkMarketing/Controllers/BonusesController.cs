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
    public class BonusesController : BaseController
    {
        private UnitOfWork _uow;
        private DataMapper _dataMapper;
        public BonusesController()
        {
            _uow = new UnitOfWork(new Entities());
            _dataMapper = new DataMapper();
        }


        public ActionResult Index()
        {
            ViewBag.Title = "ბონუსები";
            return View();
        }

        public JsonResult GetAll(DateTime fromDate, DateTime toDate)
        {
            return Json(_uow.BonusesRepo.GetAllWithDependencies(fromDate, toDate));
        }

        public JsonResult Calculate(DateTime fromDate, DateTime toDate)
        {
            return Json(_uow.BonusesRepo.Calculate(fromDate, toDate));
        }
    }
}