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
    public class DistributorsController : BaseController
    {
        private UnitOfWork _uow = null;
        private DataMapper _dataMapper = null;
        public DistributorsController()
        {
            _uow = new UnitOfWork(new Entities());
            _dataMapper = new DataMapper();
        }


        public ActionResult Index()
        {
            ViewBag.Title = "დისტრიბუტორები";
            return View();
        }

        public JsonResult GetAll()
        {
            return Json(_uow.DistributorsRepo.GetAllWithPersonalInfos());
        }

        public JsonResult Search(string value)
        {
            return Json(_uow.DistributorsRepo.Search(value).Select(d => _dataMapper.MapData(d)));
        }

        public JsonResult GetPersonalInfos(int id)
        {
            return Json(_uow.DistributorsRepo.GetPersonalInfos(id));
        }

        public JsonResult GetContactInfos(int id)
        {
            return Json(_uow.DistributorsRepo.GetContactInfos(id));
        }

        public JsonResult GetAddressInfos(int id)
        {
            return Json(_uow.DistributorsRepo.GetAddressInfos(id));
        }

        public JsonResult GetInfoTypes(int id)
        {
            return Json(_uow.DistributorsRepo.GetInfoTypes(id));
        }

        public JsonResult Save(DistributorViewModel distributor)
        {
            string errorText = "";
            bool saveResult = false;
            if(distributor.ParentId.HasValue)
            {
                if (!_uow.DistributorsRepo.CheckForFourthLevel(distributor.ParentId.Value))
                    errorText += "დისტრიბუტორს უკვე ყავს მის ქვეშ გაწევრიანებული 3 დისტიბუტორი.";

                if (!_uow.DistributorsRepo.CheckForFifthRootLevel(distributor.ParentId.Value))
                {
                    errorText += "\nრეკომენდაციის ველში მითითებული დისტრიბუტორის მიერ გაწევრიანებული დისტრიბუტორების იერარქიის დონე არ უნდა აღემატებოდეს 5 ერთეულს.";
                }
            }

            var _d = _dataMapper.MapData(distributor);
            if (distributor.Id == 0)
                _uow.DistributorsRepo.Add(_d);
            else
                _uow.DistributorsRepo.Update(_d);

            foreach (var pi in distributor.PersonalInfos)
            {
                var _pi = _dataMapper.MapData(pi);
                _pi.DistributorId = distributor.Id;
                if (pi.Id == 0)
                    _uow.DistributorsRepo.AddPersonalInfo(_pi);
                else
                {
                    if(pi.Deleted)
                        _uow.DistributorsRepo.DeletePersonalInfo(_pi);
                    else
                        _uow.DistributorsRepo.UpdatePersonalInfo(_pi);
                }
            }

            foreach (var ci in distributor.ContactInfos)
            {
                var _ci = _dataMapper.MapData(ci);
                _ci.DistributorId = distributor.Id;
                if (ci.Id == 0)
                    _uow.DistributorsRepo.AddContactInfo(_ci);
                else
                {
                    if(ci.Deleted)
                        _uow.DistributorsRepo.DeleteContactInfo(_ci);
                    else
                        _uow.DistributorsRepo.UpdateContactInfo(_ci);
                }
            }

            foreach (var ai in distributor.AddressInfos)
            {
                var _ai = _dataMapper.MapData(ai);
                _ai.DistributorId = distributor.Id;
                if (ai.Id == 0)
                    _uow.DistributorsRepo.AddAddressInfo(_ai);
                else
                {
                    if(ai.Deleted)
                        _uow.DistributorsRepo.DeleteAddressInfo(_ai);
                    else
                        _uow.DistributorsRepo.UpdateAddressInfo(_ai);
                }
            }

            if (errorText == "")
                saveResult = _uow.DistributorsRepo.Commit();

            return Json(new { saveResult = saveResult, errorText = errorText });
        }



        public JsonResult Delete(int id)
        {
            var distributor = _uow.DistributorsRepo.GetById(id);
            if(distributor != null)
            {
                var distPersonalInfos = _uow.DistributorsRepo.GetPersonalInfosByDistributorId(id).ToList();
                foreach (var pi in distPersonalInfos)
                {
                    _uow.DistributorsRepo.DeletePersonalInfo(pi);
                }

                var distContactInfos = _uow.DistributorsRepo.GetContactInfosByDistributorId(id).ToList();
                foreach (var ci in distContactInfos)
                {
                    _uow.DistributorsRepo.DeleteContactInfo(ci);
                }

                var distAddressInfos = _uow.DistributorsRepo.GetAddressInfosByDistributorId(id).ToList();
                foreach (var ai in distAddressInfos)
                {
                    _uow.DistributorsRepo.DeleteAddressInfo(ai);
                }

                _uow.DistributorsRepo.Delete(distributor);
            }

            return Json(_uow.DistributorsRepo.Commit());
        }
    }
}