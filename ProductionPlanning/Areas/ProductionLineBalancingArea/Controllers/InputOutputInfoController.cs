using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMCore;
namespace CRM.Areas.ProductionLineBalancingArea.Controllers
{
    public class InputOutputInfoController : Controller
    {
        public ProductionLineBalancing.Models.InputOutputInfo.InputOutputInfo InputOutput_rep = new ProductionLineBalancing.Models.InputOutputInfo.InputOutputInfo();
        DataLayer.MRPDataContext context = new DataLayer.MRPDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllDetailCanban(int? parentIID)
        {
            var result = InputOutput_rep.GetAllDetailCanban(parentIID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDetailCanbanView(int? parentIID)
        {
            var InputID = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == parentIID).FirstOrDefault().InputOutputID;
            var result = InputOutput_rep.GetAllDetailCanban(InputID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDetailWaste(int? WasteMasterID)
        {
            var result =InputOutput_rep.GetAllDetailWaste(WasteMasterID);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDetailWasteView(int? WasteMasterID)
        {
            var InputIDWaste = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == WasteMasterID).FirstOrDefault().InputOutputID;
            var result = InputOutput_rep.GetAllDetailWaste(InputIDWaste);
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Canban()
        {
            return View();
        }
        public ActionResult WasteCanban()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(InputOutput_rep.GetByID(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST:Create
        [HttpPost]
        public ActionResult Create(ProductionLineBalancing.Models.InputOutputInfo.InputOutputInfoModel collection, int SchID)
        {
            try
            {
                int parentID = 0;

                if (context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == SchID).FirstOrDefault() != null)
                {
                    collection.ScheduleProductionLineID = SchID;
                    collection.FaultID = collection.WasteFaultID;
                    InputOutput_rep.Edit(collection);
                    parentID = InputOutput_rep.Save();
                }
                else
                {
                    // TODO: Add insert logic here
                    if (collection.InputOutputID == 0)
                    {
                        collection.ScheduleProductionLineID = SchID;
                        collection.FaultID = collection.WasteFaultID;
                        InputOutput_rep.Add(collection);
                        parentID = InputOutput_rep.Save();
                    }
                    else
                    {
                        //var c_type = InputOutput_rep.GetByID(collection.GroupID);
                        //c_type.GroupName = collection.GroupName;     
                        collection.ScheduleProductionLineID = SchID;
                        collection.FaultID = collection.WasteFaultID;
                        InputOutput_rep.Edit(collection);
                        parentID = InputOutput_rep.Save();
                    }
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
        [HttpPost]
        public ActionResult CreateDetailCanban(int inputoutpotid, string data)
        {
            try
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionLineBalancing.Models.InputOutputInfo.CanbanInfoModel>>(data);
               
                if (list[0].CanbanID == 0)
                {
                    //var inputoutpotid = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == SchID).FirstOrDefault().InputOutputID;
                    InputOutput_rep.SaveAllDetail(list, inputoutpotid);
                }
                else
                {
                    InputOutput_rep.EditAllDetail(list);
                }
                ResultType result = new ResultType();
                result.Massage = "ثبت کانبان";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return View();
            }
        }
        public ActionResult CreateDetailWasteCanban(int inputoutpotid, string data)
        {
            try
            {
                var List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductionLineBalancing.Models.InputOutputInfo.WasteCanbanInfoModel>>(data);
                if (List[0].WasteCanbanID == 0)
                {
                InputOutput_rep.SaveAllDetail2(List, inputoutpotid);
                }
                else
                {
                    InputOutput_rep.EditAllDetail2(List);
                }
                ResultType result = new ResultType();
                result.Massage = "ثبت کانبان";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
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
        public ActionResult Delete(ProductionLineBalancing.Models.InputOutputInfo.InputOutputInfoModel collection)
        {
            try
            {
                // TODO: Add delete logic here
                InputOutput_rep.Delete(collection.InputOutputID);
                InputOutput_rep.DeleteAllDetail(collection.InputOutputID);
                InputOutput_rep.DeleteAllDetail2(collection.InputOutputID);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult DeleteCanban(int Schedulid)
        {
            try
            {
                context.ExecuteCommand("DELETE PP_CanbanInfo where CanbanID=" + Schedulid);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }


        public JsonResult GetAll()
        {
            var result = InputOutput_rep.GetAll();
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllBySCIDS(int? MasterSchid)
        {
            var result =new List<DataLayer.PP_InputOutputInfo>();

            if(context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == MasterSchid).FirstOrDefault() != null)
            {
                result = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == MasterSchid).ToList();
            }
           
            return Json(new
            {
                //sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = 3,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Deletewaste(int wasteid)
        {
            var result = context.ExecuteQuery<int>("DELETE FROM PP_WasteCanbanInfo where WasteCanbanID="+ wasteid);

            return Content("ok");
        }
    }
}
