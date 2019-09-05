using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMCore;
using System.Net;
namespace CRM.Areas.ProductionLineBalancingArea.Controllers
{
    public class ProductionLineInfoController : Controller
    {
        DataLayer.MRPDataContext context = new DataLayer.MRPDataContext();
        public ProductionLineBalancing.Models.ProductionLineInfo.ProductionLineInfo ProductionLine_rep = new ProductionLineBalancing.Models.ProductionLineInfo.ProductionLineInfo();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(ProductionLine_rep.GetByID(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddPersonelPerformance()
        {
            return View();
        }
        public JsonResult GetAllSuppliers(int MasterID)
        {
            var result = new List<ProductionLineBalancing.Models.FactorInfo.FactorInfoModel>();
            var ff = Convert.ToDateTime(CRMStaticData.StaticData.getRegisteredDate).Month;
            try
            {
                var aa = CRMStaticData.StaticData.getRegisteredDate.Split('-')[1];
                var SupplierList = context.ExecuteQuery<ProductionLineBalancing.Models.FactorInfo.FactorInfoModel>("exec dbo.PICS_Report;44").Where(q => q.PartID == MasterID).ToList();
                if (SupplierList.Count > 0)
                {
                    foreach (var c in SupplierList)
                    {
                        var bb = c.Date.Split('-')[1];
                        var cc = Convert.ToInt32(bb);
                        if (cc >= ff - 1)
                        {
                            result.Add(c);
                        }
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AddInputOutPut(int? SPID)
        {
            var model = new ProductionLineBalancing.Models.InputOutputInfo.InputOutputInfoModel();
            model.ScheduleProductionLineID = SPID;
            return View(model);
        }
        public ActionResult AddPersonel(int? SPID, int WorkStationID)
        {
            var model = new ProductionLineBalancing.Models.ProductionLineInfo.WorkersScheduleInfoModel();
            model.ScheduleProductionLineID2 =(int) SPID;
            return View(model);
        }
        public JsonResult GetAllFacilityByWorkStation(FormCollection frm, int WorkStationID)
        {
            var Name = frm.Get("data[q]");
            var data = ProductionLine_rep.FacilityCombo(WorkStationID).Where(p => p.Text.Contains(Name)).Select(p => new { id = p.Value, text = p.Text });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllRoutByWorkStation(int? WorkStationID)
        {
            var Result = context.PP_RoutInfos.Where(q => q.WorkStationID == WorkStationID & q.IsActived==1).ToList();
           return Json(Result, JsonRequestBehavior.AllowGet);
        }
        //
        // POST:Create
        [HttpPost]
        public ActionResult Create(ProductionLineBalancing.Models.ProductionLineInfo.ProductionLineInfoModel collection)
        {
            try
            {
                int MasterID = 0;
                // TODO: Add insert logic here
                if (collection.ProductionLineID == 0)
                {
                    ProductionLine_rep.Add(collection);
                    MasterID= ProductionLine_rep.Save();
                }
                else
                {
                    MasterID = collection.ProductionLineID;  
                    ProductionLine_rep.Edit(collection);
                    ProductionLine_rep.Save();
                }
               ResultType result = new ResultType();
               result.Status = 0;
               result.ReturnType = 1;
               result.Parameters = new List<Tuple<string, string>>();
               result.Parameters.Add(new Tuple<string, string>("MasterID", MasterID.ToString()));
               return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
       [HttpPost]
        public ActionResult CreatePersonel(string data)
        {
            try
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionLineBalancing.Models.ProductionLineInfo.WorkersScheduleInfoModel>>(data);
                foreach (var c in list)
                {
                    if (c.WorkersScheduleID == 0)
                    {
                        ProductionLine_rep.saveDetailDetail(c,list);
                    }
                    else
                    {
                        ProductionLine_rep.editDetailDetail(c,list);
                    }
                }
                var cycletime = ProductionLine_rep.calculateCycleTimeForSchedule(list);
                var scid = list[0].ScheduleProductionLineID2;
                var ff = context.ExecuteQuery<double>("UPDATE PP_ScheduleProductionLineInfo set CycleTime =" + cycletime + " where ScheduleProductionLineID=" + scid);
                //if (list[0].WorkersScheduleID == 0)
                //{
                //    ProductionLine_rep.saveDetailDetail(list);
                //}
                //else
                //{
                //    ProductionLine_rep.editDetailDetail(list);
                //}
                return Content("s");
            }
            catch(Exception e)
            {
                return View();
            }
        }
         [HttpPost]
        public ActionResult CreateSchedule(int MasterID, string data)
        {
            try
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionLineBalancing.Models.ProductionLineInfo.ProductionLineInfoModel>>(data);
                var aa = DateTime.Now;
                var bbb = DateTime.Parse("08/20/2019");
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[1];
               // if (aa < bbb)
               //{
                    //if (ipAddress.ToString() == "192.168.2.7")
                    //{
                        foreach (var item in list)
                        {
                            if (item.ScheduleProductionLineID == 0 || item.ScheduleProductionLineID == null)
                            {
                                ProductionLine_rep.saveDetail(item, MasterID);
                            }
                            else
                            {
                                if (CRMStaticData.StaticData.User.UserTypeID == 5)
                                {
                                    var tt = Convert.ToDateTime(context.PP_ScheduleProductionLineInfos.Where(q => q.ScheduleProductionLineID == item.ScheduleProductionLineID).FirstOrDefault().RegisteredDate);
                                    var yy = Convert.ToDateTime(CRMStaticData.StaticData.getRegisteredDate);
                                    var bb = (tt - yy).TotalDays;
                                    if ((yy - tt).TotalDays < 2)
                                    {
                                        ProductionLine_rep.editDetail(item, MasterID);
                                    }
                                }
                                else
                                {
                                    ProductionLine_rep.editDetail(item, MasterID);
                                }
                            }
                       // }
                   }
             //  }
                //else
                //{
                //    context.ExecuteCommand("TRUNCATE TABLE PP_ScheduleProductionLineInfo");
                //}
                ResultType result = new ResultType();
                result.Massage = ipAddress.ToString();
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
        public ActionResult Delete(ProductionLineBalancing.Models.ProductionLineInfo.ProductionLineInfoModel collection)
        {
            try
            {
                var schelist = context.PP_ScheduleProductionLineInfos.Where(q => q.ProductionLineID == collection.ProductionLineID).ToList();
                // TODO: Add delete logic here
                ProductionLine_rep.Delete(collection.ProductionLineID);
                if (schelist.Count != 0)
                {
                    ProductionLine_rep.deleteDetail(collection.ProductionLineID);
                    foreach(var c in schelist)
                    {
                        ProductionLine_rep.deleteDetailDetail((int)c.ScheduleProductionLineID);
                    }
                }
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeleteSchedule(int Schedulid)
        {
            try
            {
                context.ExecuteQuery<int>("DELETE PP_ScheduleProductionLineInfo where ScheduleProductionLineID=" + Schedulid);
                context.ExecuteQuery<int>("DELETE PP_InputOutputInfo where ScheduleProductionLineID=" + Schedulid);
                context.ExecuteQuery<int>("DELETE PP_FacilityStopInfo where ScheduleProductionLineID=" + Schedulid);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeletePersonel(ProductionLineBalancing.Models.ProductionLineInfo.WorkersScheduleInfoModel collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProductionLine_rep.deleteDetailDetail((int)collection.WorkersScheduleID);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetAll()
        {
            var result = ProductionLine_rep.GetAll();
            JsonResult result1 = Json(new
            {
                sEcho = "",
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
            result1.MaxJsonLength = Int32.MaxValue;
            return result1;
        }
        public JsonResult GetAllSchedule(int? MasterID)
        {
            var result = ProductionLine_rep.GetAllScheduale(MasterID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult checkpersonel(int? spid)
        {
            int result;
            if(context.PP_WorkersScheduleInfos.Where(q=>q.ScheduleProductionLineID==spid).FirstOrDefault() != null)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFacilitybySchedule(int? schedid)
        {
            var result = context.ExecuteQuery<ProductionLineBalancing.Models.InputOutputInfo.InputOutputInfoModel>("exec dbo.PICS_Report;45").Where(q => q.ScheduleProductionLineID == schedid).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllFaultByAction(int? MasterID)
        {
            var result = context.PP_FaultInfos.Where(q => q.ActionID == MasterID).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFacilitybyRout(int? schedid)
        {
            var routid=context.PP_ScheduleProductionLineInfos.Where(q=>q.ScheduleProductionLineID==schedid).FirstOrDefault().RoutID;
            //var result2 = new List< ProductionLineBalancing.Models.ProductionLineInfo.WorkersScheduleInfoModel>();
            //var result = context.PP_RoutFacilityInfos.Where(q => q.RoutID == routid).ToList();
            //foreach (var c in result)
            //{ var facilityfetures = context.PP_FacilityInfos.Where(q => q.FacilityID == c.FaciltiyID).FirstOrDefault();
            //    result2.Add(new ProductionLineBalancing.Models.ProductionLineInfo.WorkersScheduleInfoModel
            //    {
            //   W_FacilityID=c.FaciltiyID,
            //   FacilityName= facilityfetures.FacilityName,
            //  FacilityNumber= facilityfetures.FacilityNumber
            //    });
            //}
            var query = (from m in context.PP_RoutFacilityInfos
                         join b in context.PP_FacilityInfos
                         on m.FaciltiyID equals b.FacilityID
                         where m.RoutID == routid
                         select new ProductionLineBalancing.Models.ProductionLineInfo.WorkersScheduleInfoModel {
                             W_FacilityID = m.FaciltiyID,
                             FacilityName = b.FacilityName,
                             FacilityNumber = b.FacilityNumber
                         }).ToList();
            /// return Json(result2, JsonRequestBehavior.AllowGet);
            /// 
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllPersonel(int? SchedulePID)
        {
            var result = ProductionLine_rep.GetAllPersonel(SchedulePID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
public JsonResult GetAllFacilityStop(int? SchedulePID)
        {
            var result = ProductionLine_rep.GetAllFacstop(SchedulePID);
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
