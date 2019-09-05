using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProductionLineBalancing.Models.ProductionLineInfo
{
    public class ProductionLineInfo
    {
        public ProductionLineInfoModel _model = new ProductionLineInfoModel();
        DataLayer.MRPDataContext context = new DataLayer.MRPDataContext();
        Boolean IsEdit;
        /// <summary>
        /// to find the max ID for save new one
        /// </summary>
        /// <returns></returns> the ID for new one
        private int GetMaxID()
        {
            int ID = 1;
            try
            {
                var query = (from t in context.PP_ProductionLineInfos
                             select t).Max(p => p.ProductionLineID);
                ID = query + 1;
            }
            catch (Exception ex)
            {
            }
            return ID;
        }
        /// <summary>
        /// this function copy the models to save
        /// </summary>
        /// <param name="model"></param> the copyable model
        /// <returns></returns> returns if the copy is successfull
        public Boolean Add(ProductionLineInfoModel model)
        {
            Boolean result = true;
            try
            {
                _model = model;
                _model.BranchID = CRMStaticData.StaticData.getBranchID;
                _model.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                _model.UserID = CRMStaticData.StaticData.getUserID;
                _model.YearID = CRMStaticData.StaticData.getYearID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// this function copy the model for edit
        /// </summary>
        /// <param name="model"></param> the model should be edited
        /// <returns></returns> returns if the copy is successfull
        public Boolean Edit(ProductionLineInfoModel model)
        {
            Boolean result = true;
            try
            {
                IsEdit = true;
                _model = model;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// this function saves the model
        /// </summary>
        /// <returns></returns> returns if the save function is successfull
        public int Save()
        {
            var Result = 0;
            try
            {
                if (IsEdit)
                {
                    var query = (from t in context.PP_ProductionLineInfos
                                 where
                                    t.ProductionLineID == _model.ProductionLineID
                                    &&
                                    t.BranchID == CRMStaticData.StaticData.getBranchID
                                 select t).FirstOrDefault();
                    query.ProductionLineID = _model.ProductionLineID;
                    query.Shift = _model.Shift;
                    query.ProductionLineStop = _model.ProductionLineStop;
                    query.WorkStationID = _model.WorkStationID;
                    query.LineAcceptance = _model.LineAcceptance;
                    query.LineEfficiency = _model.LineEfficiency;
                    query.LineGoal = _model.LineGoal;
                    query.RoutID = _model.RoutID;
                    query.BranchID = CRMStaticData.StaticData.getBranchID;
                    query.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                    query.UserID = CRMStaticData.StaticData.getUserID;
                    query.YearID = CRMStaticData.StaticData.getYearID;
                    query.ResponsibleID = _model.ResponsibleID;
                    context.SubmitChanges();
                }
                else
                {
                    var temp = ConvertToTable(_model);
                    context.PP_ProductionLineInfos.InsertOnSubmit(temp);
                    context.SubmitChanges();
                    Result = temp.ProductionLineID;
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Result = -1;
            }
            return Result;
        }
        /// <summary>
        /// this function convert the model to table form
        /// </summary>
        /// <param name="model"></param> the convertable model
        /// <returns></returns> returns the converted table
        public DataLayer.PP_ProductionLineInfo ConvertToTable(ProductionLineInfoModel model)
        {
            DataLayer.PP_ProductionLineInfo tbl = new DataLayer.PP_ProductionLineInfo();
            tbl.ProductionLineID = model.ProductionLineID;
            tbl.ProductionLineStop = model.ProductionLineStop;
            tbl.WorkStationID = model.WorkStationID;
            tbl.LineAcceptance = model.LineAcceptance;
            tbl.LineEfficiency = model.LineEfficiency;
            tbl.LineGoal = model.LineGoal;
            tbl.Shift = model.Shift;
            tbl.RoutID = model.RoutID;
            tbl.YearID = model.YearID;
            tbl.UserID = model.UserID;
            tbl.RegisteredDate = model.RegisteredDate;
            tbl.BranchID = model.BranchID;
            tbl.ResponsibleID = model.ResponsibleID;
            return tbl;
        }
        /// <summary>
        /// this function conver the table form to model
        /// </summary>
        /// <param name="tbl"></param> the covertable table
        /// <returns></returns>the converted model
        public ProductionLineInfoModel ConvertToModel(DataLayer.PP_ProductionLineInfo tbl)
        {
            ProductionLineInfoModel model = new ProductionLineInfoModel();
            var res = context.PP_WorkersInfos.Where(q => q.WorkersID == tbl.ResponsibleID).FirstOrDefault();
            var sche = context.PP_ScheduleProductionLineInfos.Where(q => q.ProductionLineID == tbl.ProductionLineID).FirstOrDefault();
            var shiftstatus = context.PP_ProductionLineInfos.Where(q => q.Shift == tbl.Shift).FirstOrDefault();
            model.ProductionLineID = tbl.ProductionLineID;
           // model.ProductionLineStop = tbl.ProductionLineStop;
            model.ResponsibleID = tbl.ResponsibleID;
            model.ResponsibleName = (res==null)?"-":res.WorkersSurname;
             model.WorkStationID = tbl.WorkStationID;
            model.Shift = tbl.Shift;
            if (shiftstatus != null)
            {
                if (tbl.Shift == 1)
                {
                    model.ShiftName = "شب";
                }
                if (tbl.Shift == 2)
                {
                    model.ShiftName = "روز";
                }
            }
           // model.LineAcceptance = tbl.LineAcceptance;
           // model.LineEfficiency = tbl.LineEfficiency;
          //model.LineGoal = tbl.LineGoal;
            model.RoutID = tbl.RoutID;
            model.YearID = tbl.YearID;
            model.UserID = tbl.UserID;
            if (sche != null)
            {
                model.RegisteredDate = sche.Date;
            }
            else
            {
                model.RegisteredDate = tbl.RegisteredDate;
            }
            model.BranchID = tbl.BranchID;
          //  model.RoutName = context.PP_RoutInfos.Where(q => q.RoutID == tbl.RoutID).FirstOrDefault().RoutName;
            if (context.PP_WorkStationInfos.Where(q => q.WorkStationID == tbl.WorkStationID).FirstOrDefault() != null)
            {
                model.WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == tbl.WorkStationID).FirstOrDefault().WorkStationName;
            }
            if (sche != null)
            {
                model.ScheduleProductionLineID = sche.ScheduleProductionLineID;
            } return model;
        }
        /// <summary>
        /// the function finds from table by ID
        /// </summary>
        /// <param name="id"></param> the ID u wnt to find the table form
        /// <returns></returns> returns the the converted table to model
        public ProductionLineInfoModel GetByID(int id)
        {
            var query = (from t in context.PP_ProductionLineInfos
                         where
                            t.ProductionLineID == id
                            &&
                            t.BranchID == CRMStaticData.StaticData.getBranchID
                         select t).FirstOrDefault();
            return ConvertToModel(query);
        }
        /// <summary>
        /// this function deletes the table
        /// </summary>
        /// <param name="id"></param> the ID u want to delete it's table
        /// <returns></returns> true if the delete was successfull
        public Boolean Delete(int id)
        {
            Boolean Result = false;
            try
            {
                var query = (from t in context.PP_ProductionLineInfos
                             where
                                t.ProductionLineID == id
                               // &&
                                //t.BranchID == CRMStaticData.StaticData.getBranchID
                             select t).FirstOrDefault();
                //if (query != null)
                //{
                //    deleteDetail(id);
                //}
                context.PP_ProductionLineInfos.DeleteOnSubmit(query);
                context.SubmitChanges();
                Result = true;
            }
            catch (Exception ex)
            {
                Result = false;
            }
            return Result;
        }
        /// <summary>
        /// this function returns all the saved data in sql
        /// </summary>
        /// <returns></returns> the query list
        public List<ProductionLineInfoModel> GetAll()
        {
            var result = new List<ProductionLineInfoModel>();
            var ss = context.PP_ScheduleProductionLineInfos.ToList();
            if (CRMStaticData.StaticData.User.UserTypeID == 5)
            {
               var aa = context.PP_WorkersInfos.Where(q => q.WorkersCode == CRMStaticData.StaticData.User.NationalCode).FirstOrDefault().WorkersID;
                var query = context.ExecuteQuery<ProductionLineInfoModel>("exec dbo.PICS_Report;140 ").Where(q => q.ResponsibleID == aa).ToList();
                foreach(var c in query)
                {
                    var sche = ss.Where(q => q.ProductionLineID == c.ProductionLineID).FirstOrDefault();
                    if (c.Shift == 1)
                    {
                        c.ShiftName = "شب";
                    }
                    if (c.Shift == 2)
                    {
                        c.ShiftName = "روز";
                    }
                    if (sche != null)
                    {
                        c.RegisteredDate = sche.Date;
                    }
                    result.Add(c);
                }
                return result;
            }
            else
            {
                //var query = from t in context.PP_ProductionLineInfos
                //                where t.BranchID == CRMStaticData.StaticData.getBranchID
                //                select ConvertToModel(t);
                var query = context.ExecuteQuery<ProductionLineInfoModel>("exec dbo.PICS_Report;140 ").ToList();
                foreach (var c in query)
                {
                    var sche = ss.Where(q => q.ProductionLineID == c.ProductionLineID).FirstOrDefault();
                    if (c.Shift == 1)
                    {
                        c.ShiftName = "شب";
                    }
                    if (c.Shift == 2)
                    {
                        c.ShiftName = "روز";
                    }
                    if (sche != null)
                    {
                        c.RegisteredDate = sche.Date;
                    }
                    result.Add(c);
                }
                return result;
            }
        }
        // Detail
        private int GetMaxIDDetail()
        {
            int ID = 1;
            try
            {
                var query = (from t in context.PP_ScheduleProductionLineInfos
                             select t).Max(p => p.ScheduleProductionLineID);
                ID = query + 1;
            }
            catch (Exception ex)
            {
            }
            return ID;
        }
        public void saveDetail(ProductionLineInfoModel item, int MasterID)
        {
                DataLayer.PP_ScheduleProductionLineInfo tbl = new DataLayer.PP_ScheduleProductionLineInfo();
                tbl.ProductionLineID = MasterID;
                tbl.ScheduleID = item.ScheduleID;
                tbl.CycleTime = item.CycleTime;
                tbl.ScheduleStartTime = item.ScheduleStartTime;
                tbl.DurationTime = item.DurationTime;
                tbl.Date = item.Date;
                tbl.ScheduleFinishTime = item.ScheduleFinishTime;
                tbl.Year = returnYear(item.Date);
                tbl.Month = returnMonth(item.Date);
                tbl.Day = returnDay(item.Date);
                tbl.RoutID = item.RoutID;
                tbl.InputID = item.InputID;
                tbl.YearID = CRMStaticData.StaticData.getYearID;
                tbl.UserID = CRMStaticData.StaticData.getUserID;
                tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                tbl.RegisteredDate = CRMStaticData.StaticData.DateNow(0).Date;
                context.PP_ScheduleProductionLineInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
        }
        public List<ProductionLineInfoModel> GetAllScheduale(int? MasterID)
        { var partlist = context.MRP_PartInfos.ToList();
            var routlist = context.PP_RoutInfos.ToList();
            var query = (from t in context.PP_ScheduleProductionLineInfos
                         join v in context.PP_RoutInfos
                         on t.RoutID equals v.RoutID
                         join b in context.MRP_PartInfos
                         on v.PartID equals b.PartID
                          where t.ProductionLineID == MasterID
                         select new ProductionLineInfoModel
                         {
                             Date=t.Date,
                             RegisteredDate=t.RegisteredDate,
                             DurationTime=t.DurationTime,
                             RoutID=t.RoutID,
                             RoutName= b.TechnicalNumber +"-"+ v.RoutName ,
                             ScheduleProductionLineID=t.ScheduleProductionLineID,
                         CycleTime=t.CycleTime
                         }).ToList();
            return query;
        }
        public List<WorkersScheduleInfoModel> GetAllPersonel(int? SchedulePID)
        {
            var query = (from t in context.PP_WorkersScheduleInfos
                         where t.ScheduleProductionLineID == SchedulePID
                         select new WorkersScheduleInfoModel
                         {
                             W_FacilityID = t.FacilityID,
                             WorkersAssociationName = context.PP_WorkersAssociationInfos.Where(q => q.WorkersAssociationID == t.WorkersAssociationID).FirstOrDefault().WorkersAssociationName,
                             FacilityName = context.PP_FacilityInfos.Where(q => q.FacilityID == t.FacilityID).FirstOrDefault().FacilityName,
                             //ProductionLineID2 = t.ProductionLineID,
                             ScheduleProductionLineID2 = t.ScheduleProductionLineID,
                             RegisteredDate = t.RegisteredDate,
                             WorkersAssociationID = t.WorkersAssociationID,
                             W_WorkersID = t.WorkersID,
                             WorkersName = context.PP_WorkersInfos.Where(q => q.WorkersID == t.WorkersID).FirstOrDefault().WorkersSurname,
                             WorkersScheduleID = t.WorkersScheduleID,
                         }).ToList();
            return query;
        }
       public List<FacilityStopInfo.FacilityStopInfoModel> GetAllFacstop(int? SchedulePID)
        {
            var query = (from t in context.PP_FacilityStopInfos
                         where t.ScheduleProductionLineID == SchedulePID
                         select new FacilityStopInfo.FacilityStopInfoModel {
                             FacilityName = context.PP_FacilityInfos.Where(q => q.FacilityID == t.FacilityID).FirstOrDefault().FacilityName,
                             WorkerName=(context.PP_WorkersInfos.Where(q=>q.WorkersID==t.WorkerID).FirstOrDefault()==null)?"-": context.PP_WorkersInfos.Where(q => q.WorkersID == t.WorkerID).FirstOrDefault().WorkersSurname,
                            StopName = (context.PP_StopInfos.Where(q => q.StopID == t.StopID).FirstOrDefault() == null) ? "0" : context.PP_StopInfos.Where(q => q.StopID == t.StopID).FirstOrDefault().StopName,
                             StopReasonName =( context.PP_StopReasons.Where(q => q.StopReasonID == t.StopReasonID).FirstOrDefault()==null)? "-": context.PP_StopReasons.Where(q => q.StopReasonID == t.StopReasonID).FirstOrDefault().StopReasonName,
                             FacilityStopDesc=t.FacilityStopDesc,
                             FacilityStopDuration=t.FacilityStopDuration
                         }).ToList();
            return query;
        }
        public bool editDetail(ProductionLineInfoModel detail,int prid)
        {
            bool result = false;
            var tbl = (from t in context.PP_ScheduleProductionLineInfos
                         where
                            t.ScheduleProductionLineID == detail.ScheduleProductionLineID
                         select t).FirstOrDefault();
            //DataLayer.PP_ScheduleProductionLineInfo tbl = new DataLayer.PP_ScheduleProductionLineInfo();
            tbl.ProductionLineID = prid;
            tbl.ScheduleID = detail.ScheduleID;
            tbl.ScheduleProductionLineID =(int) detail.ScheduleProductionLineID;
            tbl.CycleTime = detail.CycleTime;
            tbl.ScheduleStartTime = detail.ScheduleStartTime;
            tbl.DurationTime = detail.DurationTime;
            tbl.Date = detail.Date;
            tbl.ScheduleFinishTime = detail.ScheduleFinishTime;
            tbl.Year = returnYear(detail.Date);
            tbl.Month = returnMonth(detail.Date);
            tbl.Day = returnDay(detail.Date);
            tbl.RoutID = detail.RoutID;
            tbl.InputID = detail.InputID;
            tbl.YearID = CRMStaticData.StaticData.getYearID;
            tbl.UserID = CRMStaticData.StaticData.getUserID;
            tbl.BranchID = CRMStaticData.StaticData.getBranchID;
            tbl.RegisteredDate = CRMStaticData.StaticData.DateNow(0).Date;
           // context.PP_ScheduleProductionLineInfos.InsertOnSubmit(tbl);
            context.SubmitChanges();
            result = true;
            return result;
        }
        public bool deleteDetail(int masterID)
        {
            bool result = false;
            var query = (from t in context.PP_ScheduleProductionLineInfos
                         where t.ProductionLineID == masterID
                         select t).ToList();
            foreach (var item in query)
            {
                deleteDetailDetail(item.ScheduleProductionLineID);
                context.PP_ScheduleProductionLineInfos.DeleteOnSubmit(item);
            }
            context.SubmitChanges();
            result = true;
            return result;
        }
        // Detail Detail
        public bool saveDetailDetail(WorkersScheduleInfoModel model,List<WorkersScheduleInfoModel> peronlist)
        {
            var scid = model.ScheduleProductionLineID2;
          //  var cycletime = calculateCycleTimeForSchedule(peronlist);
           // var ff = context.ExecuteQuery<WorkersScheduleInfoModel>("UPDATE PP_ScheduleProductionLineInfo set CycleTime =" + cycletime + " where ScheduleProductionLineID=" + scid);
                       bool result = false;
                DataLayer.PP_WorkersScheduleInfo tbl = new DataLayer.PP_WorkersScheduleInfo();
                tbl.ScheduleProductionLineID = model.ScheduleProductionLineID2;
                tbl.ProductionLineID = 0;
                tbl.FacilityID = model.W_FacilityID;
                tbl.WorkersID = model.W_WorkersID;
                tbl.WorkersScheduleID = model.WorkersScheduleID;
                tbl.YearID = CRMStaticData.StaticData.getYearID;
                tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                tbl.RegisteredDate = CRMStaticData.StaticData.DateNow(0).Date;
                tbl.WorkersAssociationID = model.WorkersAssociationID;
                context.PP_WorkersScheduleInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
                result = true;
            return result;
        }
        public bool editDetailDetail(WorkersScheduleInfoModel model, List<WorkersScheduleInfoModel> peronlist)
        {
            var scid = model.ScheduleProductionLineID2;
            var cycletime = calculateCycleTimeForSchedule(peronlist);
            var ff = context.ExecuteQuery<WorkersScheduleInfoModel>("UPDATE PP_ScheduleProductionLineInfo set CycleTime =" + cycletime + " where ScheduleProductionLineID=" + scid);
            DataLayer.PP_WorkersScheduleInfo tbl = new DataLayer.PP_WorkersScheduleInfo();
                tbl.ScheduleProductionLineID = model.ScheduleProductionLineID2;
                tbl.ProductionLineID = 0;
                tbl.FacilityID = model.W_FacilityID;
                tbl.WorkersID = model.W_WorkersID;
                tbl.WorkersScheduleID = model.WorkersScheduleID;
                tbl.YearID = CRMStaticData.StaticData.getYearID;
                tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                tbl.RegisteredDate = CRMStaticData.StaticData.DateNow(0).Date;
                tbl.WorkersAssociationID = model.WorkersAssociationID;
                //context.PP_WorkersScheduleInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
              var  result = true;
            return result;
        }
        public bool deleteDetailDetail(int detailID)
        {
            bool result = false;
            var query = (from t in context.PP_WorkersScheduleInfos
                         where t.WorkersScheduleID == detailID
                         select t).ToList();
            foreach (var item in query)
            {
                context.PP_WorkersScheduleInfos.DeleteOnSubmit(item);
            }
            context.SubmitChanges();
            result = true;
            return result;
        }
        // yyyy/mm/dd  => yyyy=0 1 2 3 mm=5 6 dd=8 9
        public int returnMonth(string yyyymmdd)
        {
            if (yyyymmdd == "" && yyyymmdd.Length != 10)
            {
                return 0;
            }
            string mm = yyyymmdd.Substring(5, 2);
            int month = Convert.ToInt32(mm);
            return month;
        }
        public int returnDay(string yyyymmdd)
        {
            if (yyyymmdd == "" && yyyymmdd.Length != 10)
            {
                return 0;
            }
            string dd = yyyymmdd.Substring(8,2);
            int day = Convert.ToInt32(dd);
            return day;
        }
        public int returnYear(string yyyymmdd)
        {
            if (yyyymmdd == "" && yyyymmdd.Length != 10)
            {
                return 0;
            }
            string yy = yyyymmdd.Substring(0, 4);
            int year = Convert.ToInt32(yy);
            return year;
        }
        public List<General.GeneralModels.Combo.ComboModel> AssociationCombo()
        {
            var query = from t in context.PP_WorkersAssociationInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.WorkersAssociationID,
                            Name = t.WorkersAssociationName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> WorkersCombo()
        {
            var query = from t in context.PP_WorkersInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.WorkersID,
                            Name = t.WorkersName+" "+t.WorkersSurname,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> WorkerStationCombo()
        {
            var query = from t in context.PP_WorkStationInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.WorkStationID,
                            Name = t.WorkStationName,
                        };
            return query.ToList();
        }
        public List<System.Web.Mvc.SelectListItem> FacilityCombo(int WorkStationID)
        {
            var query = context.PP_FacilityInfos.Where(q => q.WorkStationID == WorkStationID).Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Selected = false,
                    Text = p.FacilityName,
                    Value = p.FacilityID.ToString(),
                });
            var Result = query.ToList();
            Result.Add(new System.Web.Mvc.SelectListItem { Selected = true, Text = "انتخاب کنید", Value = "0" });
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> RoutCombo(int? WorkStationID)
        {
            var query = context.PP_RoutInfos.Where(q => q.WorkStationID == WorkStationID).Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Selected = false,
                    Text = p.RoutName,
                    Value = p.RoutID.ToString(),
                });
            var Result = query.ToList();
            Result.Add(new System.Web.Mvc.SelectListItem { Selected = true, Text = "انتخاب کنید", Value = "0" });
            return Result;
        }
        // محاسبه زمان سیکل calculet cycle time
        /// <summary>
        /// calcute cycle time in fellowshop design
        /// </summary>
        /// <param name="Personel">list of assigned personel</param>
        /// <returns>cycle time for specified schedule</returns>
        public double calculateCycleTimeForSchedule(List<WorkersScheduleInfoModel> Personel) 
        {
            double cycletime = 0;
            List<double> FacilityCycleTime = new List<double>();
            int scheduleID =(int) Personel.FirstOrDefault().ScheduleProductionLineID2;
            //firs find schdule and rout
            var schdule = (from t in context.PP_ScheduleProductionLineInfos
                           where t.ScheduleProductionLineID == scheduleID
                           select t).FirstOrDefault();
            if (schdule != null)
            {
                //find the time for each machine
                var routFacility = (from t in context.PP_WorkersScheduleInfos
                                    where t.ScheduleProductionLineID == schdule.ScheduleProductionLineID
                                    select t).ToList();
                foreach (var item in routFacility)
                {
                    var facil = context.PP_RoutFacilityInfos.Where(q => q.FaciltiyID == item.FacilityID).FirstOrDefault();
                    double tmpCycle = (double)facil.TimeDurationMin;
                    tmpCycle /= returnAssociateNumberForFacility(Personel,(int)facil.FaciltiyID);
                    FacilityCycleTime.Add(tmpCycle);
                }
            }
            foreach (var item in FacilityCycleTime)
            {
                if (cycletime < item)
                {
                    cycletime = item;
                }
            }
            return cycletime;
        }
        /// <summary>
        /// returns assigned workers to one facility
        /// </summary>
        /// <param name="Personel">assigned personel</param>
        /// <param name="FacilityID">facility</param>
        /// <returns>number of assigned workers</returns>
        public int returnAssociateNumberForFacility(List<WorkersScheduleInfoModel> Personel,int FacilityID) 
        {
            int associate_number = 1;
            int counter = 0;
            foreach (var item in Personel)
            {
                if (item.W_FacilityID == FacilityID)
                {
                    counter++;   
                }
            }
            if (counter > 0)
            {
                return counter;
            }
            return associate_number;
        }
        public int returnTotalCalculetatedFIninshedGoods(int duration, int cycleTime) 
        {
            int finishedGoods = 0;
            if (cycleTime != 0)
            {
                finishedGoods = (int)(duration / cycleTime);
            }
            return finishedGoods;
        }
    }
}
