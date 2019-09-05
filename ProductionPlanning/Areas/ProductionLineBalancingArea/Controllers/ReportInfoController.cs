using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Base;
namespace CRM.Areas.ProductionLineBalancingArea.Controllers
{
    public class ReportInfoController : Controller
    {
        ProductionLineBalancing.Models.ReportInfo.ReportInfo rep = new ProductionLineBalancing.Models.ReportInfo.ReportInfo();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST:Create
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
        public ActionResult ViewerAccessibilityRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotviwerAccessibilityRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityRoutDaily(Convert.ToInt32(RoutID), FDate, TDate, 1);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotviwerAccessibilityRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityRoutDaily(Convert.ToInt32(RoutID), FDate, TDate, 2);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotviwerAccessibilityRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityRoutDaily(0, FDate, TDate, 3);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerAccessibilityWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 4);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerAccessibilityWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 5);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerAccessibilityWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityByWorkStation(0, FDate, TDate, 6);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// /////////////////report accessibility facility ////////////
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        //public ActionResult ViewerAccessibilityFacilityDaily(int FacilityID, string FDate, string TDate)
        //{
        //    Session["FacilityID"] = FacilityID;
        //    Session["FDate"] = FDate;
        //    Session["TDate"] = TDate;
        //    return View();
        //}
        //public ActionResult getsnapshotViewerAccessibilityFacilityDaily()
        //{
        //    var FacilityID = Session["FacilityID"].ToString();
        //    var FDate = Session["FDate"].ToString();
        //    var TDate = Session["TDate"].ToString();
        //    var model = rep.GetAllAccessibilityByFacility(Convert.ToInt32(FacilityID), FDate, TDate, 7);
        //    StiReport stireport2 = new StiReport();
        //    stireport2.RegBusinessObject("ReportInfoModel", model);
        //    stireport2.Load(Server.MapPath("/Report/AccessibilityFacilityDaily.mrt"));
        //    return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        //}
        //public ActionResult ViewerAccessibilityFacilityMonthly(int FacilityID, string FDate, string TDate)
        //{
        //    Session["FacilityID"] = FacilityID;
        //    Session["FDate"] = FDate;
        //    Session["TDate"] = TDate;
        //    return View();
        //}
        //public ActionResult getsnapshotViewerAccessibilityFacilityMonthly()
        //{
        //    var FacilityID = Session["FacilityID"].ToString();
        //    var FDate = Session["FDate"].ToString();
        //    var TDate = Session["TDate"].ToString();
        //    var model = rep.GetAllAccessibilityByFacility(Convert.ToInt32(FacilityID), FDate, TDate, 8);
        //    StiReport stireport2 = new StiReport();
        //    stireport2.RegBusinessObject("ReportInfoModel", model);
        //    stireport2.Load(Server.MapPath("/Report/AccessibilityFacilityMonthly.mrt"));
        //    return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        //}
        //public ActionResult ViewerAccessibilityFacilityByYear(string FDate, string TDate)
        //{
        //    if (TDate == "")
        //        TDate = FDate;
        //    Session["FDate"] = FDate;
        //    Session["TDate"] = TDate;
        //    return View();
        //}
        //public ActionResult getsnapshotViewerAccessibilityFacilityByYear()
        //{
        //    //var RoutID = Session["RoutID"].ToString();
        //    var FDate = Session["FDate"].ToString();
        //    var TDate = Session["TDate"].ToString();
        //    var model = rep.GetAllAccessibilityByFacility(0, FDate, TDate, 9);
        //    StiReport stireport2 = new StiReport();
        //    stireport2.RegBusinessObject("ReportInfoModel", model);
        //    stireport2.Load(Server.MapPath("/Report/AccessibilityFacilityByYear.mrt"));
        //    return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        //}
        /// <summary>
        /// accessibility by worker ////////
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerAccessibilityWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerAccessibilityWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 10);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerAccessibilityWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 11);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerAccessibilityWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerAccessibilityWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllAccessibilityByWorker(0, FDate, TDate, 12);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AccessibilityWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// eficiency by rout //////
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerEfficiencyRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByRout(Convert.ToInt32(RoutID), FDate, TDate, 13);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotviwerEfficiencyRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByRout(Convert.ToInt32(RoutID), FDate, TDate, 14);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotviwerEfficiencyRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByRout(0, FDate, TDate,15);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// efficiency by workstation
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewerEfficiencyWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerEfficiencyWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 16);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 17);
             StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByWorkStation(0, FDate, TDate, 18);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// efficiency by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerEfficiencyWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 19);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyResponsibleDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyResponsibleDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByResponsible(Convert.ToInt32(WorkerID), FDate, TDate, 19);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyResponsibleDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 20);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEfficiencyWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllEfficiencyByWorker(0, FDate, TDate, 21);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// quality by rout
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerQualityRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByRout(Convert.ToInt32(RoutID), FDate, TDate, 22);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerQualityRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByRout(Convert.ToInt32(RoutID), FDate, TDate, 23);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerQualityRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByRout(0, FDate, TDate, 24);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// quality by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerQualityWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerQualityWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 25);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerQualityWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 26);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerQualityWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByWorkStation(0, FDate, TDate, 27);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// quality by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerQualityWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 28);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerQualityWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 29);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerQualityWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQualityWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQualityByWorker(0, FDate, TDate, 30);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QualityWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// production count by rout
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerProductionCountRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerProductionCountRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByRout(Convert.ToInt32(RoutID), FDate, TDate, 31);
            foreach(var c in model)
            {
                c.ALL = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerProductionCountRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerProductionCountRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByRout(Convert.ToInt32(RoutID), FDate, TDate, 32);
            foreach (var c in model)
            {
                c.ALL = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerProductionCountRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerProductionCountRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByRout(0, FDate, TDate, 33);
            foreach (var c in model)
            {
                c.ALL = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// production count workstation
        /// </summary>
        /// <returns></returns>
        /// 
        /// <summary>
        public ActionResult ViewerProductionCountWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerProductionCountWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 34);
            foreach (var c in model)
            {
                c.ALL = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerProductionCountWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerProductionCountWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 35);
            foreach (var c in model)
            {
                c.ALL = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerProductionCountWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerProductionCountWorkStationByYear()
        {
            //var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByWorkStation(0, FDate, TDate, 36);
            foreach(var c in model)
            {
                c.AVRWasteQuantity = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// production count worker
        /// </summary>
        /// <returns></returns>
        ///   
        public ActionResult ViewerProductionCountWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerProductionCountWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 37);
            foreach (var c in model)
            {
                c.AVRWasteQuantity = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerProductionCountWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerProductionCountWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 38);
            foreach (var c in model)
            {
                c.AVRWasteQuantity = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerProductionCountWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerProductionCountWorkerByYear()
        {
            //var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllProductionCountByWorker(0, FDate, TDate, 39);
            foreach (var c in model)
            {
                c.AVRWasteQuantity = model.Sum(q => q.AVRQuantity);
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ProductionCountWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// oee by rout
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerOEECountRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerOEECountRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEECountByRout(Convert.ToInt32(RoutID), FDate, TDate, 40);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECountRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECountRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECountRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEECountByRout(Convert.ToInt32(RoutID), FDate, TDate, 41);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECountRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECountRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECountRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEECountByRout(0, FDate, TDate, 42);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECountRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// oee by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerOEECountWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerOEECountWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 43);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECountWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECountWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECountWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 44);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEEWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECountWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECountWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(0, FDate, TDate, 45);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEEWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// oee by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerOEEWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEEWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 46);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEEWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEEWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEEWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 47);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEEWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEEWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEEWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(0, FDate, TDate, 48);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEEWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ppm report
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerPPMReport(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerPPMReport()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllPPM(0, FDate, TDate, 49);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/PPMReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerPPMParetoReport(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerPPMParetoReport()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllPPM(0, FDate, TDate, 100);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/PPMParetoReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// WastageCostReport by rout
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerWastageCostRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerWastageCostRout()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllWastageCostByRout(Convert.ToInt32(RoutID), FDate, TDate, 50);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/WastageCostRout.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// WastageCost by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerWastageCostWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerWastageCostWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllWastageCostByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 51);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/WastageCostWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// WastageCost by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerWastageCostWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerWastageCostWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllWastageCostByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 52);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/WastageCostWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// FaultList by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerFaultListWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerFaultListWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllFaultListByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 51);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/FaultListWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// FaultDescParetoReport by rout
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerFaultDescParetoRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerFaultDescParetoRout()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllFaultDescParetoByRout(Convert.ToInt32(RoutID), FDate, TDate, 54);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/FaultDescParetoRout.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// FaultDescPareto by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerFaultDescParetoWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerFaultDescParetoWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllFaultDescParetoByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 55);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/FaultDescParetoWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// FaultDescPareto by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerFaultDescParetoWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerFaultDescParetoWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllFaultDescParetoByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 56);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/FaultDescParetoWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// StopListReport
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerStopListReport(string FDate, string TDate)
        {
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopListReport()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllStopListReport(FDate, TDate, 57);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopListReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// UnitStopPercent
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerUnitStopPercent(string FDate, string TDate)
        {
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerUnitStopPercent()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllUnitStopPercent(FDate, TDate, 58);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/UnitStopPercent.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// CumulativeStopDuration by rout
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerCumulativeStopDurationRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByRout(Convert.ToInt32(RoutID), FDate, TDate, 59);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerCumulativeStopDurationRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByRout(Convert.ToInt32(RoutID), FDate, TDate, 60);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerCumulativeStopDurationRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByRout(0, FDate, TDate, 61);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// CumulativeStopDuration by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerCumulativeStopDurationWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerCumulativeStopDurationWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 62);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerCumulativeStopDurationWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 63);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerCumulativeStopDurationWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByWorkStation(0, FDate, TDate, 64);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// CumulativeStopDuration by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerCumulativeStopDurationWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 65);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerCumulativeStopDurationWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 66);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerCumulativeStopDurationWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerCumulativeStopDurationWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllCumulativeStopDurationByWorker(0, FDate, TDate, 67);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/CumulativeStopDurationWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// SplitPartReport
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerSplitPartReport(int RoutID,string FDate, string TDate)
        {
          Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerSplitPartReport()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var RoutID = Session["RoutID"].ToString();
            var model = rep.GetAllRepairPartReport(Convert.ToInt32( RoutID), FDate, TDate, 68);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/SplitPartReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerSplitPartParetoReport(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerSplitPartParetoReport()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var WorkStationID = Session["WorkStationID"].ToString();
            var model = rep.GetAllRepairPartPAretoReport(Convert.ToInt32(WorkStationID), FDate, TDate, 68);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/SplitPartParetoReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ReworkPartReport
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerReworkPartReport(string FDate, string TDate)
        {
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerReworkPartReportt()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllReworkPartReport(FDate, TDate, 68);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ReworkPartReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ZayeaatPartReport
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerZayeaatPartReport(string FDate, string TDate)
        {
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerZayeaatPartReport()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllZayeaatPartReport(FDate, TDate, 95);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ZayeaatPartReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// MTTR
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerMTTRWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerMTTRWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllMTTRByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 70);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/MTTRWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerMTTRWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerMTTRWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllMTTRByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 71);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/MTTRWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerMTTRWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerMTTRWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllMTTRByWorkStation(0, FDate, TDate, 72);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/MTTRWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// MTBF
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerMTBFWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerMTBFWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllMTBFByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 73);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/MTBFWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerMTBFWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerMTBFWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllMTBFByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 74);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/MTBFWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerMTBFWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerMTBFWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllMTBFByWorkStation(0, FDate, TDate, 75);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/MTBFWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// stop matchin
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerStopMatchinWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopMatchinWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllStopMatchinByWorkStation(0, FDate, TDate, 75);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopMatchinWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// oee complete
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerOEECompleteCountRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerOEECompleteCountRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEECountByRout(Convert.ToInt32(RoutID), FDate, TDate, 40);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteCountRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECompleteCountRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteCountRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEECountByRout(Convert.ToInt32(RoutID), FDate, TDate, 41);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteCountRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECompleteCountRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteCountRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEECountByRout(0, FDate, TDate, 42);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteCountRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// OEEComplete by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerOEECompleteCountWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerOEECompleteCountWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 43);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteCoutWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECompleteCountWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteCountWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 44);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECompleteCountWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteCountWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(0, FDate, TDate, 45);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// OEEComplete by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerOEECompleteWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 46);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECompleteWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 47);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerOEECompleteWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerOEECompleteWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(0, FDate, TDate, 48);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/OEECompleteWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// oee complete
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerStopReasonCountRoutDaily(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerStopReasonCountRoutDaily()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllStopReasonByRout(Convert.ToInt32(RoutID), FDate, TDate, 86);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonCountRoutDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerStopReasonCountRoutMonthly(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonCountRoutMonthly()
        {
            var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllStopReasonByRout(Convert.ToInt32(RoutID), FDate, TDate, 87);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonCountRoutMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerStopReasonCountRoutByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonCountRoutByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllStopReasonByRout(0, FDate, TDate, 88);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonCountRoutByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// StopReason by workstation
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerStopReasonCountWorkStationDaily(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshoViewerStopReasonCountWorkStationDaily()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 43);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonCoutWorkStationDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerStopReasonCountWorkStationMonthly(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonCountWorkStationMonthly()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 44);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonWorkStationMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerStopReasonCountWorkStationByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonCountWorkStationByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorkStation(0, FDate, TDate, 45);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonWorkStationByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// StopReason by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerStopReasonWorkerDaily(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonWorkerDaily()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 46);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonWorkerDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerStopReasonWorkerMonthly(int WorkerID, string FDate, string TDate)
        {
            Session["WorkerID"] = WorkerID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonWorkerMonthly()
        {
            var WorkerID = Session["WorkerID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(Convert.ToInt32(WorkerID), FDate, TDate, 47);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonWorkerMonthly.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerStopReasonWorkerByYear(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerStopReasonWorkerByYear()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllOEEByWorker(0, FDate, TDate, 48);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/StopReasonWorkerByYear.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// /////////////////report quantity facility ////////////
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerQuantityFacilityDaily(int FacilityID, string FDate, string TDate)
        {
            Session["FacilityID"] = FacilityID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerQuantityFacilityDaily()
        {
            var FacilityID = Session["FacilityID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllQuantityByFacility(Convert.ToInt32(FacilityID), FDate, TDate, 96);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/QuantityFacilityDaily.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// /send to warehouse
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerSendToWareHouseReport(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerSendToWareHouseReport()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var RoutID = Session["RoutID"].ToString();
            var model = rep.GetAllSendToWareHouse(Convert.ToInt32(RoutID), FDate, TDate, 102);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/SendToWareHouseReport.mrt"));
            stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerSendToWareHouseReportByWorkstation(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerSendToWareHouseReportByWorkstation()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var WorkStationID = Session["WorkStationID"].ToString();
            var model = rep.GetAllSendToWareHouseByWorkStation(Convert.ToInt32(WorkStationID), FDate, TDate, 102);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/SendToWareHouseReportByWorkstation.mrt"));
            stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerZayeatPareto(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerZayeatPareto()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllZayeatPareto(Convert.ToInt32(WorkStationID), FDate, TDate, 103);
            foreach(var c in model)
            {
                c.FDate = FDate;
                c.TDate = TDate;
            }
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ZayeatPareto.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerReworkPartParetoReport(int WorkStationID, string FDate, string TDate)
        {
            Session["WorkStationID"] = WorkStationID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerReworkPartParetoReport()
        {
            var WorkStationID = Session["WorkStationID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllReworkPartParetoReport(Convert.ToInt32(WorkStationID), FDate, TDate, 104);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/ReworkPartParetoReport.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// none balencing rout
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewerNoneBalancingRout(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerNoneBalancingRout()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var RoutID = Session["RoutID"].ToString();
            var model = rep.GetAllNoneBalencingRout(Convert.ToInt32(RoutID), FDate, TDate, 108);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyNoneBalencedRoutDaily.mrt"));
          //  stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerNoneBalancingRoutByMonth(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerNoneBalancingRoutBymonth()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var RoutID = Session["RoutID"].ToString();
            var model = rep.GetAllNoneBalencingRout(Convert.ToInt32(RoutID), FDate, TDate, 109);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyNoneBalancedRoutMonthly.mrt"));
          //  stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerNoneBalancingRoutByYear( string FDate, string TDate)
        {
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerNoneBalancingRoutByYear()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllNoneBalencingRout(0, FDate, TDate, 110);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyNoneBalancedRoutByYear.mrt"));
           // stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ///rework and durationtime by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerDurationTimeAndReworkByWorker(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerDurationTimeAndReworkByWorker()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllDurationTimeAndReworkByWorker(FDate, TDate,111);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/DurationTimeAndReworkByWorker.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ///tolid
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerTolid(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerTolid()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllTolid(FDate, TDate, 112);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/Tolid.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerTolidPersonel(string FDate, string TDate)
        {
            if (TDate == "")
                TDate = FDate;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerTolidPersonel()
        {
            //var RoutID = Session["RoutID"].ToString();
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllTolidPersonel(FDate, TDate, 113);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/TolidPersonel.mrt"));
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ///efficiency rout by worker
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerEfficiencyRoutByWorker(int RoutID, string FDate, string TDate)
        {
            Session["RoutID"] = RoutID;
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotViewerEfficiencyRoutByWorker()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var RoutID = Session["RoutID"].ToString();
            var model = rep.GetAllEfficiencyRoutByWorker(Convert.ToInt32(RoutID), FDate, TDate);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/EfficiencyRoutByWorker.mrt"));
            //  stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        /// <summary>
        /// ///QS
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ViewerAllFactor( string FDate, string TDate)
        {
            Session["FDate"] = FDate;
            Session["TDate"] = TDate;
            return View();
        }
        public ActionResult getsnapshotAllFactor()
        {
            var FDate = Session["FDate"].ToString();
            var TDate = Session["TDate"].ToString();
            var model = rep.GetAllFactor( FDate, TDate);
            StiReport stireport2 = new StiReport();
            stireport2.RegBusinessObject("ReportInfoModel", model);
            stireport2.Load(Server.MapPath("/Report/AllFactorReport.mrt"));
            //  stireport2.Dictionary.Variables["DateN"].Value = CRMStaticData.StaticData.getRegisteredDate;
            return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, stireport2);
        }
        public ActionResult ViewerEvent()
        {
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
