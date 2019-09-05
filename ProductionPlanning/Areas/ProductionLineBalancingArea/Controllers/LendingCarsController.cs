using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Automation;
using Core.Core.Types;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Base;
namespace AmicoIntegratedSystem.Controllers
{
    public class LendingCarsController : Controller
    {
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public ActionResult LendingCarsOption()
        {
            return View();
        }
        public ActionResult LendingCarsFlow()
        {
            return View();
        }
        public JsonResult GetLendingCarsFlow()
        {
            Sell.LendingCars.LendingCars option = new Sell.LendingCars.LendingCars();
            var model = option.GetLendingCarsFlow(0);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLendingCarsOption(int SelectedDetailRequest)
        {
            Sell.CarsOption.CarsOption option = new Sell.CarsOption.CarsOption();
            var model = option.GetAmaniByContractId(SelectedDetailRequest);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        //
        // GET: /LendingCars/
        public ActionResult Index()
        {
            return View();
        }
        [Framework.Security.CoreAuthorize]
        [Framework.Security.LogsRequests]
        public JsonResult ContractDetailFillCombosNotSaved(string DetailItem)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var model = serializer.Deserialize<Sell.LendingCars.LendingCarsDetailViewSModel>(DetailItem);
            var ProductUsage = new Sell.Products.Products().GetProductUsageByProductTypeId((int)model.F_IDCar).Where(p => p.F_pyprmtflID == model.F_UsageType).FirstOrDefault();
            var ProductType = context.T00050016s.Where(p => p.CarId == (int)model.F_IDCar).FirstOrDefault();
            var Delivery = new Sell.Agents.Agents().GetByID((int)model.F_Deliver);
            var ProductGroup = context.T00020002s.Where(p => p.pyprmtflID == ProductType.CarGroup).FirstOrDefault();
            return Json(new
            {
                ProductGroup = ProductGroup.pt_desc,
                ProductType = ProductType.CarName,
                ProductUsage = (ProductUsage == null) ? "انتخاب کنید" : ProductUsage.pt_desc,
                DeliveryAddress = Delivery.Agent_AGNDesc,
                ProductGroupId = ProductType.CarGroup,
                ProductTypeId = ProductType.CarId,
                ProductUsageId = (ProductUsage == null) ? 0 : model.F_UsageType,
                DeliveryAddressId = model.F_Deliver,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAgentName(int agentId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var agn = context.T00050002s.Where(p => p.AGNID == agentId).FirstOrDefault();
            return Content(agn.AGNCode + " , " + agn.AGNDesc);
        }
        public ActionResult LendingCarsDetail(int? IDRequestAmani, int? RowId)
        {
            Sell.LendingCars.LendingCarsDetailModel model = new Sell.LendingCars.LendingCarsDetailModel();
            if (IDRequestAmani == null && RowId == null)
            {
                model.Days = 30;
                model.num = 1;
                ViewBag.AmaniDetailId = 0;
                ViewBag.RowID = 0;
            }
            else
            {
                if (RowId == 0 || RowId == null)
                {
                    //amani 
                    ViewBag.AmaniDetailId = IDRequestAmani;
                    ViewBag.RowID = 0;
                }
                else
                {
                    ViewBag.AmaniDetailId = 0;
                    ViewBag.RowID = RowId;
                }
            }
            return View(model);
        }
        public ActionResult LendingCarsPrint()
        {
            return View();
        }
        [HttpPost]
        public JsonResult searchLendingCars(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            Sell.LendingCars.LendingCars LendingCarsRepo = new Sell.LendingCars.LendingCars();
            var data = LendingCarsRepo.GetAllComboBox(0, Name).Select(p => new { id = p.Value, text = p.Text });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        //60 detail
        //61 master
        [HttpPost]
        public JsonResult SearchBarbari(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            Sell.LendingCars.LendingCars LendingCarsRepo = new Sell.LendingCars.LendingCars();
            var data = LendingCarsRepo.GetAllBarbariComboBox().Select(p => new { id = p.Value, text = p.Text });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SearchKargozaran(FormCollection frm)
        {
            var Name = frm.Get("data[q]");
            Sell.LendingCars.LendingCars LendingCarsRepo = new Sell.LendingCars.LendingCars();
            var data = LendingCarsRepo.GetAllKargozranComboBox().Select(p => new { id = p.Value, text = p.Text });
            return Json(new { q = Name, results = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLendingCarsMasterById(int LendingCarsId)
        {
            Sell.LendingCars.LendingCars LendingCarsRepo = new Sell.LendingCars.LendingCars();
            var model = LendingCarsRepo.GetById(LendingCarsId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckEbtal(int IdRequestId)
        {
            Sell.LendingCars.LendingCars cars = new Sell.LendingCars.LendingCars();
            return Content(cars.CheckEbtal(IdRequestId).ToString());
        }
        public ActionResult CheckForEdit(int IdRequestId)
        {
            Sell.LendingCars.LendingCars cars = new Sell.LendingCars.LendingCars();
            return Content(cars.CheckForEdit(IdRequestId).ToString());
        }
        [HttpPost]
        public ActionResult CreateDetail(string model, string IdMaster)
        {
            List<Sell.LendingCars.LendingCarsDetailViewSModel> DetailList = new List<Sell.LendingCars.LendingCarsDetailViewSModel>();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            DetailList = serializer.Deserialize<List<Sell.LendingCars.LendingCarsDetailViewSModel>>(model);
            Sell.LendingCars.LendingCarsDetail LendingCarsRepo = new Sell.LendingCars.LendingCarsDetail();
            foreach (var a in DetailList)
            {
                if (a.IsDelete)
                {
                    LendingCarsRepo.DeleteByMaster(a.IDDetailReqAmani);
                }
                if (a.IDDetailReqAmani == 0)
                {
                    LendingCarsRepo.Insert(new Sell.LendingCars.LendingCarsDetailModel
                    {
                        F_IDrequstAmani = Convert.ToInt32(IdMaster),
                        F_IDCar = (int)a.F_IDCar,
                        AcceptanceType = 1,
                        F_color = 0,// (int)a.F_color,
                        num = (int)a.num,
                        radif = (int)a.radif,
                        Days = (int)a.Days,
                        DelivType = (int)a.DelivType,
                        F_Deliver = (int)a.F_Deliver,
                        NameDeliv = a.nameDliv,
                        F_UsageType = (int)a.F_UsageType,
                    });
                }
                else
                {
                    LendingCarsRepo.Update(new Sell.LendingCars.LendingCarsDetailModel
                    {
                        IDDetailReqAmani = a.IDDetailReqAmani,
                        F_IDrequstAmani = Convert.ToInt32(IdMaster),
                        F_IDCar = (int)a.F_IDCar,
                        AcceptanceType = 1,
                        F_color = 0,// (int)a.F_color,
                        num = (int)a.num,
                        radif = (int)a.radif,
                        Days = (int)a.Days,
                        DelivType = (int)a.DelivType,
                        F_Deliver = (int)a.F_Deliver,
                        NameDeliv = a.nameDliv,
                        F_UsageType = (int)a.F_UsageType,
                    });
                }
            }
            return Content("ok");
        }
        [HttpPost]
        public ActionResult Create(Sell.LendingCars.LendingCarsModel model)
        {
            try
            {
                Sell.LendingCars.LendingCars LendingCarsRepo = new Sell.LendingCars.LendingCars();
                DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
                if (!LendingCarsRepo.CheckForEdit(model.IDrequstAmani))
                {
                    ResultType result = new ResultType();
                    result.Status = -1;
                    result.ReturnType = 1;
                    result.Message = "وضعیت درخواست تغییر کرده و امکان ویرایش درخواست وجود ندارد  ";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                if (model.IDrequstAmani == 0)
                {
                    var id = LendingCarsRepo.Insert(model);
                    var Code = context.T00050061s.Where(p => p.IDrequstAmani == id).FirstOrDefault().code;
                    ResultType result = new ResultType();
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Message = "درخواست امانی ثبت شد";
                    result.Parameters = new List<Tuple<string, string>>();
                    result.Parameters.Add(new Tuple<string, string>("Id", id.ToString()));
                    result.Parameters.Add(new Tuple<string, string>("Code", Code));
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    LendingCarsRepo.Update(model);
                    //edit contract
                    ResultType result = new ResultType();
                    result.Parameters = new List<Tuple<string, string>>();
                    result.Parameters.Add(new Tuple<string, string>("Id", model.IDrequstAmani.ToString()));
                    result.Parameters.Add(new Tuple<string, string>("Code", model.code));
                    result.Status = 0;
                    result.ReturnType = 1;
                    result.Message = "درخواست امانی ویرایش شد";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = 0;
                result.ReturnType = 1;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Sell.LendingCars.LendingCars LendingCarsRepo = new Sell.LendingCars.LendingCars();
                DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
                LendingCarsRepo.Delete(id);
                ResultType result = new ResultType();
                result.Status = 0;
                result.ReturnType = 1;
                result.Message = "درخواست ابطال  شد";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultType result = new ResultType();
                result.Status = 0;
                result.ReturnType = 1;
                result.Message = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GenerateDetailListView(string DetailStr)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Sell.LendingCars.LendingCarsDetailViewSModel> List = serializer.Deserialize<List<Sell.LendingCars.LendingCarsDetailViewSModel>>(DetailStr);
            foreach (var aa in List)
            {
                if (aa.IsDelete)
                    if (aa.IDDetailReqAmani != 0)
                    {
                        Sell.LendingCars.LendingCarsDetail LendingCarsRepo = new Sell.LendingCars.LendingCarsDetail();
                        LendingCarsRepo.DeleteByMaster(aa.IDDetailReqAmani);
                    }
            }
            List = List.Where(p => p.IsDelete == false).ToList();
            foreach (var a in List)
            {
                //        "data": "radif",
                //        "title": "ردیف",
                //"data": "CarName",
                //"title": "خودرو",
                // "data": "num",
                // "title": "تعداد",
                //                "data": "Days",
                //                "title": "مدت",
                //"data": "typeDliv",
                //"title": "نوع تحویل گیرنده",
                //  "data": "nameDliv",
                //  "title": "تحویل گیرنده",
                //  "data": "StatusDesc",
                //  "title": "وضعیت",
                //  "data": "pt_desc",
                //  "title": " کاربری",
                Sell.Products.Products product = new Sell.Products.Products();
                var model = product.GetProductType().Where(p => p.Id == a.F_IDCar);
                a.CarName = model.FirstOrDefault().Name;
                if (a.DelivType == 1)
                {
                    a.typeDliv = "نمایندگی";
                    a.nameDliv = new Sell.Agents.Agents().GetByID(Convert.ToInt32(a.F_Deliver)).Agent_AGNDesc;
                }
                var Usage = product.GetProductUsageByProductTypeId(Convert.ToInt32(a.F_IDCar));
                a.pt_desc = Usage.Where(p => p.F_pyprmtflID == a.F_UsageType).FirstOrDefault().pt_desc;
                a.StatusDesc = "آماده تایید امانی";
            }
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLendingCarsDetailByRequestId(int IdRequest)
        {
            Sell.LendingCars.LendingCarsDetail LendingCarsDetailRepo = new Sell.LendingCars.LendingCarsDetail();
            var model = LendingCarsDetailRepo.GetByAmaniID(IdRequest);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLendingCarsDetailByagnId(int AgentId)
        {
            Sell.LendingCars.LendingCarsDetail LendingCarsDetailRepo = new Sell.LendingCars.LendingCarsDetail();
            var model = LendingCarsDetailRepo.GetAmaniDeliveredReport(AgentId);
            return Json(new
            {
                sEcho = "",
                iTotalRecords = model.Count(),
                iTotalDisplayRecords = 3,
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLendingCarsDetail(int LEndingCarsId)
        {
            List<Sell.LendingCars.LendingCarsDetailViewSModel> List = new List<Sell.LendingCars.LendingCarsDetailViewSModel>();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDeliverCars(int Delivf, int TypeDeliver, string NameDelivF, string FromDate, string ToDate, int AGNID)
        {
            Sell.Contract.Report r = new Sell.Contract.Report();
            var model = r.GetGhateiDeliveredReport(Delivf, TypeDeliver, NameDelivF, FromDate, ToDate, AGNID);
            JsonResult result = Json(new
             {
                 sEcho = "",
                 iTotalRecords = model.Count(),
                 iTotalDisplayRecords = 3,
                 aaData = model
             }, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = Int32.MaxValue;
            return result;
        }
        public ActionResult TahvilAmani()
        {
            return View();
        }
        public ActionResult Viewer()
        {
            Session["TA_FromDate"] = Request.QueryString["TA_FromDate"];
            Session["TA_ToDate"] = Request.QueryString["TA_ToDate"];
            Session["TA_Recevier"] = Request.QueryString["TA_Recevier"];
            Session["TA_RecevierType"] = Request.QueryString["TA_RecevierType"];
            Session["TA_TahvilType"] = Request.QueryString["TA_TahvilType"];
            return View();
        }
        public ActionResult getsnapshotviwer()
        {
            if (Convert.ToInt32(Session["TA_TahvilType"]) == 1)
            {
                DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
                Sell.Contract.Report repo = new Sell.Contract.Report();
                var TA_Recevier = Convert.ToInt32(Session["TA_Recevier"]);
                var model = repo.GetGhateiDeliveredReport(1, Convert.ToInt32(Session["TA_RecevierType"]), "", Session["TA_FromDate"].ToString(), Session["TA_ToDate"].ToString(), TA_Recevier);
                StiReport stireport2 = new StiReport();
                stireport2.RegBusinessObject("AmaniDeliverdCar", model);
                stireport2.Load(Server.MapPath("/Content/report/AmaniDeliverdCar.mrt"));
                stireport2.Dictionary.Variables["FRomDate"].Value = BAL.StaticData.DateNow.Date;
                stireport2.Dictionary.Variables["FromTime"].Value = BAL.StaticData.DateNow.Time;
                return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
            }
            else
            {
                DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
                Sell.Contract.Report repo = new Sell.Contract.Report();
                var TA_Recevier = Convert.ToInt32(Session["TA_Recevier"]);
                var model = repo.GetGhateiDeliveredReport(0, Convert.ToInt32(Session["TA_RecevierType"]), "", Session["TA_FromDate"].ToString(), Session["TA_ToDate"].ToString(), TA_Recevier);
                StiReport stireport2 = new StiReport();
                stireport2.RegBusinessObject("GhatiDeliveredReport", model);
                stireport2.Load(Server.MapPath("/Content/report/ghatii.mrt"));
                stireport2.Dictionary.Variables["FRomDate"].Value = BAL.StaticData.DateNow.Date;
                //stireport2.Dictionary.Variables["FromTime"].Value = BAL.StaticData.DateNow.Time;
                return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
            }
        }
        public ActionResult ViewerEvent()
        {
            //Automation.Reciever.Reciever reciv = new Automation.Reciever.Reciever();
            //var reciv2 = reciv.GetAllList();
            //StiReport stireport2 = new StiReport();
            //stireport2.RegBusinessObject("RecieverModel", reciv2);
            //stireport2.Load("Content\report\bReport.mrt");
            return StiMvcViewer.ViewerEventResult(HttpContext);
        }
        public ActionResult PrintReport()
        {
            return StiMvcViewer.PrintReportResult(HttpContext);
        }
        public ActionResult ExportReport()
        {
            return StiMvcViewer.ExportReportResult(HttpContext);
        }
        public ActionResult Interactiom()
        {
            return StiMvcViewer.InteractionResult(HttpContext);
        }
    }
}
