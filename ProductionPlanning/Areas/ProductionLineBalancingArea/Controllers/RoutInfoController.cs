using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMCore;
namespace CRM.Areas.ProductionLineBalancingArea.Controllers
{
    public class RoutInfoController : Controller
    {
        public ProductionLineBalancing.Models.RoutInfo.RoutInfo Rout_rep = new ProductionLineBalancing.Models.RoutInfo.RoutInfo();
        DataLayer.MRPDataContext context = new DataLayer.MRPDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(Rout_rep.GetByID(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult RoutActivity(string Activity, string RoutID)
        {
            if (Activity == "غیر فعال")
                Activity = "0";
            if (Activity == "فعال")
                Activity = "1";
            context.ExecuteCommand("UPDATE PP_RoutInfo set IsActived=" + Activity + " WHERE RoutID=" + RoutID);
            return Json(Activity, JsonRequestBehavior.AllowGet);
        }
        //
        // POST:Create
        [HttpPost]
        public ActionResult Create(ProductionLineBalancing.Models.RoutInfo.RoutInfoModel collection)
        {
            try
            {
                int parentID = 0;
                // TODO: Add insert logic here
                if (collection.RoutID == 0)
                {
                    Rout_rep.Add(collection);
                   parentID = Rout_rep.Save();
                }
                else
                {
                    //var c_type = Rout_rep.GetByID(collection.GroupID);
                    //c_type.GroupName = collection.GroupName; 
                    Rout_rep.Edit(collection);
                    parentID = Rout_rep.Save();
                }
                ResultType result = new ResultType();
                result.Status = 0;
                result.ReturnType = 1;
                result.Parameters = new List<Tuple<string, string>>();
                result.Parameters.Add(new Tuple<string, string>("parentID", parentID.ToString()));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
        public JsonResult CheckRoutUsed(int? RoutID)
        {
            var a = "0";
            var rproduction = context.PP_ScheduleProductionLineInfos.Where(q => q.RoutID == RoutID).FirstOrDefault();
            if (rproduction != null )
            {
                a = "برای این روت برنامه زمانبندی ثبت شده است و امکان حذف نیست";
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateDetail1()
        {
            return View();
        }
        public ActionResult CreateDetail2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDetail2(string data)
        {
            try
            {
                var List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionLineBalancing.Models.RoutInfo.RoutChildParentInfoModel>>(data);
                Rout_rep.SaveAllDetail2(List);
                ResultType result = new ResultType();
                result.Massage = "ثبت رده سازمانی";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateDetail1(string data)
        {
            try
            {
                var List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionLineBalancing.Models.RoutInfo.RoutFacilityInfoModel>>(data);
                Rout_rep.SaveAllDetail1(List);
                ResultType result = new ResultType();
                result.Massage = "ثبت جریان تولید";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        //
        // GET
        public ActionResult Edit(int id)
        {
            return View();
        }
        //
        // POST: /Parvande/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Parvande/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        //
        // POST: /Parvande/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductionLineBalancing.Models.RoutInfo.RoutInfoModel collection)
        {
            try
            {
                // TODO: Add delete logic here
                Rout_rep.Delete(collection.RoutID);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeleteDetail1(int RoutFacilityID)
        {
            try
            {
                // TODO: Add delete logic here
                Rout_rep.DeleteDetail1(RoutFacilityID);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetAll()
        {
            var result = Rout_rep.GetAll();
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDetail1(int parentIID)
        {
            var result = Rout_rep.GetAllDetail1(parentIID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDetail2(int parentIID)
        {
            var result = Rout_rep.GetAllDetail2(parentIID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllFacility(int WorkStationID)
        {
            var result = Rout_rep.FacilityCombo(WorkStationID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
