using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProductionLineBalancing.Models.InputOutputInfo
{
    public class InputOutputInfo
    {
        public InputOutputInfoModel _model = new InputOutputInfoModel();
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
                var query = (from t in context.PP_InputOutputInfos
                             select t).Max(p => p.InputOutputID);
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
        public Boolean Add(InputOutputInfoModel model)
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
        public Boolean Edit(InputOutputInfoModel model)
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
        /// <returns></returns> returns Master ID
        public int Save()
        {
            int Result = 0;
            try
            {
                if (IsEdit)
                {
                    var query = (from t in context.PP_InputOutputInfos
                                 where
                                    t.InputOutputID == _model.InputOutputID
                                 select t).FirstOrDefault();
                    query.InputOutputID = _model.InputOutputID;
                    query.InputOutputCode = _model.InputOutputCode;
                    query.InputOutputIndicator = _model.InputOutputIndicator;
                    query.ScheduleProductionLineID = _model.ScheduleProductionLineID;
                    query.BranchID = CRMStaticData.StaticData.getBranchID;
                    query.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                    query.UserID = CRMStaticData.StaticData.getUserID;
                    query.YearID = CRMStaticData.StaticData.getYearID;
                    context.SubmitChanges();
                    Result = _model.InputOutputID;
                }
                else
                {
                    var modelTable = ConvertToTable(_model);
                    context.PP_InputOutputInfos.InsertOnSubmit(modelTable);
                    context.SubmitChanges();
                    Result = modelTable.InputOutputID;
                }
            }
            catch (Exception ex)
            {
                Result = 0;
            }
            return Result;
        }
        /// <summary>
        /// this function convert the model to table form
        /// </summary>
        /// <param name="model"></param> the convertable model
        /// <returns></returns> returns the converted table
        public DataLayer.PP_InputOutputInfo ConvertToTable(InputOutputInfoModel model)
        {
            DataLayer.PP_InputOutputInfo tbl = new DataLayer.PP_InputOutputInfo();
            tbl.InputOutputID = model.InputOutputID;
            tbl.InputOutputCode = model.InputOutputCode;
            tbl.InputOutputIndicator = model.InputOutputIndicator;
            tbl.ScheduleProductionLineID = model.ScheduleProductionLineID;
            tbl.UserID = model.UserID;
            tbl.YearID = model.YearID;
            tbl.BranchID = model.BranchID;
            tbl.RegisteredDate = model.RegisteredDate;
            return tbl;
        }
        /// <summary>
        /// this function conver the table form to model
        /// </summary>
        /// <param name="tbl"></param> the covertable table
        /// <returns></returns>the converted model
        public InputOutputInfoModel ConvertToModel(DataLayer.PP_InputOutputInfo tbl)
        {
            InputOutputInfoModel model = new InputOutputInfoModel();
            model.InputOutputID = tbl.InputOutputID;
            model.InputOutputCode = tbl.InputOutputCode;
            model.InputOutputIndicator = tbl.InputOutputIndicator;
            model.ScheduleProductionLineID = tbl.ScheduleProductionLineID;
            model.UserID = tbl.UserID;
            model.YearID = tbl.YearID;
            model.BranchID = tbl.BranchID;
            model.RegisteredDate = tbl.RegisteredDate;
            return model;
        }
        /// <summary>
        /// the function finds from table by ID
        /// </summary>
        /// <param name="id"></param> the ID u wnt to find the table form
        /// <returns></returns> returns the the converted table to model
        /// 
        public InputOutputInfoModel GetByID(int id)
        {
            var query = (from t in context.PP_InputOutputInfos
                         where
                            t.InputOutputID == id
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
                var query = (from t in context.PP_InputOutputInfos
                             where
                                t.InputOutputID == id
                             select t).FirstOrDefault();
                DeleteAllDetail(id);
                context.PP_InputOutputInfos.DeleteOnSubmit(query);
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
        public IQueryable<InputOutputInfoModel> GetAll()
        {
            var query = from t in context.PP_InputOutputInfos
                        select ConvertToModel(t);
            return query;
        }
        public CanbanInfoModel ConvertToModel(DataLayer.PP_CanbanInfo tbl)
        {
            CanbanInfoModel model = new CanbanInfoModel();
            model.CanbanID = tbl.CanbanID;
            model.IOTrackingCode = tbl.IOTrackingCode;
            model.IOPackageCode = tbl.IOPackageCode;
            model.IOInventoryCode = tbl.IOInventoryCode;
            model.InputOutputID = tbl.InputOutputID;
            model.CanbanPartID = tbl.CanbanPartID;
            model.UnitID = tbl.UnitID;
            model.Quantity = tbl.Quantity;
            model.UserID = tbl.UserID;
            model.YearID = tbl.YearID;
            model.BranchID = tbl.BranchID;
            model.RegisteredDate = tbl.RegisteredDate;
            model.TechnicalCode = tbl.TechnicalCode;
            model.CProcessStageID = tbl.CProcessStageID;
            if (context.PP_WarehouseTypeInfos.Where(q => q.WarehouseTypeInfoID == tbl.IOInventoryCode).FirstOrDefault() != null)
            {
                model.IOInventoryCodeName = context.PP_WarehouseTypeInfos.Where(q => q.WarehouseTypeInfoID == tbl.IOInventoryCode).FirstOrDefault().WarehouseTypeInfoName;
            }
            if(context.MRP_PartInfos.Where(q => q.PartID == tbl.CanbanPartID).FirstOrDefault() != null)
            {
                model.CanbanPartIDName = context.MRP_PartInfos.Where(q => q.PartID == tbl.CanbanPartID).FirstOrDefault().PartName;
            }
            if (context.MRP_PartInfos.Where(q => q.PartID == tbl.CanbanPartID).FirstOrDefault() != null)
            {
                model.TechnicalCodeName = context.MRP_PartInfos.Where(q => q.PartID == tbl.CanbanPartID).FirstOrDefault().TechnicalNumber;
            }
           ;
          if (context.PP_UnitInfos.Where(q => q.UnitID == tbl.UnitID).FirstOrDefault() != null)
          {
              model.UnitIDName = context.PP_UnitInfos.Where(q => q.UnitID == tbl.UnitID).FirstOrDefault().UnitName;
          }
          if (context.PP_ProcessStageInfos.Where(q => q.ProcessStageID == tbl.CProcessStageID).FirstOrDefault() != null)
          {
              model.CProcessStageIDName = context.PP_ProcessStageInfos.Where(q => q.ProcessStageID == tbl.CProcessStageID).FirstOrDefault().ProcessStageName;
          }
            if (context.PP_WorkersInfos.Where(q => q.WorkersID == tbl.CWorkerID).FirstOrDefault() != null)
            {
                model.WorkerName = context.PP_WorkersInfos.Where(q => q.WorkersID == tbl.CWorkerID).FirstOrDefault().WorkersSurname;
            }
            if (context.PP_CodeInfos.Where(q => q.CodeID == tbl.IOPackageCode).FirstOrDefault() != null)
          {
              model.IOPackageCodeName = context.PP_CodeInfos.Where(q => q.CodeID == tbl.IOPackageCode).FirstOrDefault().CodeDesc;
          }
          if (context.PP_CodeInfos.Where(q => q.CodeID == tbl.IOTrackingCode).FirstOrDefault() != null)
          {
              model.IOTrackingCodeName = context.PP_CodeInfos.Where(q => q.CodeID == tbl.IOTrackingCode).FirstOrDefault().CodeDesc;
          }
            model.CWorkerID = tbl.CWorkerID;
            return model;
        }
        public DataLayer.PP_CanbanInfo ConvertToTable(CanbanInfoModel model)
        {
            DataLayer.PP_CanbanInfo tbl = new DataLayer.PP_CanbanInfo();
            tbl.CanbanID = model.CanbanID;
            tbl.IOTrackingCode = model.IOTrackingCode;
            tbl.IOPackageCode = model.IOPackageCode;
            tbl.IOInventoryCode = model.IOInventoryCode;
            tbl.InputOutputID = model.InputOutputID;
            tbl.CanbanPartID = model.CanbanPartID;
            tbl.UnitID = model.UnitID;
            tbl.Quantity = model.Quantity;
            tbl.UserID = model.UserID;
            tbl.YearID = model.YearID;
            tbl.BranchID = model.BranchID;
            tbl.RegisteredDate = model.RegisteredDate;
            tbl.TechnicalCode = model.TechnicalCode;
            tbl.CProcessStageID = model.CProcessStageID;
            tbl.CWorkerID = model.CWorkerID;
            return tbl;
        }
        /// <summary>
        /// it returns all child for a specefic child 
        /// </summary>
        /// <param name="parentID">parent name</param>
        /// <returns></returns>
        public IQueryable<CanbanInfoModel> GetAllDetail(int parentID)
        {
            var query = from t in context.PP_CanbanInfos
                        where
                        t.InputOutputID == parentID
                        select ConvertToModel(t);
            return query;
        }
        /// <summary>
        /// it delete all child for specfic parent
        /// </summary>
        /// <param name="parentID">the paretn id</param>
        /// <returns></returns>
        public Boolean DeleteAllDetail(int parentID)
        {
            Boolean Result = false;
            try
            {
                var query = (from t in context.PP_CanbanInfos
                             where
                                t.InputOutputID == parentID
                             select t);
                foreach (var item in query)
                {
                    context.PP_CanbanInfos.DeleteOnSubmit(item);
                }
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
        /// this function saves all parent info
        /// </summary>
        /// <param name="model">parent info</param>
        public void SaveAllDetail(IEnumerable<CanbanInfoModel> model, int inputoutpotid)
        {
            if (model.Any(q => q.CProcessStageID == 4)) { 
            foreach (var item in model)
            {
                DataLayer.PP_CanbanInfo tbl = new DataLayer.PP_CanbanInfo();
                tbl = ConvertToTable(item);
                tbl.InputOutputID = inputoutpotid;
                tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                tbl.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                tbl.UserID = CRMStaticData.StaticData.getUserID;
                tbl.YearID = CRMStaticData.StaticData.getYearID;
                tbl.CanbanPartID = item.CanbanPartID;
                context.PP_CanbanInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
           else
            {
                foreach (var item in model)
                {
                    DataLayer.PP_CanbanInfo tbl = new DataLayer.PP_CanbanInfo();
                    tbl = ConvertToTable(item);
                    tbl.InputOutputID = inputoutpotid;
                    tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                    tbl.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                    tbl.UserID = CRMStaticData.StaticData.getUserID;
                    tbl.YearID = CRMStaticData.StaticData.getYearID;
                    tbl.CanbanPartID = item.CanbanPartID;
                    context.PP_CanbanInfos.InsertOnSubmit(tbl);
                    context.SubmitChanges();
                }
                var saveforworker = model.FirstOrDefault();
                var schdul = context.PP_InputOutputInfos.Where(q => q.InputOutputID == inputoutpotid).FirstOrDefault().ScheduleProductionLineID;
                var workerschedullist = context.PP_WorkersScheduleInfos.Where(q => q.ScheduleProductionLineID == schdul).ToList();
                foreach (var a in workerschedullist)
                {
                    DataLayer.PP_CanbanInfo tbl = new DataLayer.PP_CanbanInfo();
                    var workercountinfacility = workerschedullist.Where(q => q.ScheduleProductionLineID == schdul & q.FacilityID == a.FacilityID).ToList().Count();
                    tbl.IOTrackingCode = saveforworker.IOTrackingCode;
                    tbl.IOPackageCode = saveforworker.IOPackageCode;
                    tbl.IOInventoryCode = saveforworker.IOInventoryCode;
                    tbl.InputOutputID = saveforworker.InputOutputID;
                    tbl.CanbanPartID = saveforworker.CanbanPartID;
                    tbl.UnitID = saveforworker.UnitID;
                    tbl.Quantity = saveforworker.Quantity / workercountinfacility;
                    tbl.UserID = saveforworker.UserID;
                    tbl.YearID = saveforworker.YearID;
                    tbl.BranchID = saveforworker.BranchID;
                    tbl.RegisteredDate = saveforworker.RegisteredDate;
                    tbl.TechnicalCode = saveforworker.TechnicalCode;
                    tbl.CProcessStageID = 4;
                    tbl.CWorkerID = a.WorkersID;
                    tbl.InputOutputID = inputoutpotid;
                    tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                    tbl.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                    tbl.UserID = CRMStaticData.StaticData.getUserID;
                    tbl.YearID = CRMStaticData.StaticData.getYearID;
                    tbl.CanbanPartID = saveforworker.CanbanPartID;
                    context.PP_CanbanInfos.InsertOnSubmit(tbl);
                    context.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// this function edit all parent data
        /// first delete all parent id then save all sended parent info
        /// </summary>
        /// <param name="model">all parent info</param>
        public void EditAllDetail(IEnumerable<CanbanInfoModel> model)
        {
            DeleteAllDetail((int)model.First().InputOutputID);
            foreach (var item in model)
            {
                DataLayer.PP_CanbanInfo tbl = new DataLayer.PP_CanbanInfo();
                tbl = ConvertToTable(item);
                context.PP_CanbanInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
        public List<General.GeneralModels.Combo.ComboModel> InputOutputPartCombo()
        {
            var query = from t in context.MRP_PartInfos
                        where t.BranchID==CRMStaticData.StaticData.getBranchID
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.PartID,
                            Name = ((t.PartName == null) ? "0" : t.PartName) +"-"+ ((t.TechnicalNumber == null) ? "0" : t.TechnicalNumber),
                        };
            return query.ToList();
        }
        public List<CanbanInfoModel> GetAllDetailCanban(int? MasterID)
        {
            var model = new List< CanbanInfoModel>();
            if (MasterID == null)
            {
                MasterID = 0;
            }
            if(MasterID != 0)
            {
                 model = (from t in context.PP_CanbanInfos
                            where
                            t.InputOutputID == MasterID
                            select ConvertToModel(t)).ToList();
                return model ;
            }
            else
            {
                return model;
            }
        }
        public List<WasteCanbanInfoModel> GetAllDetailWaste(int? MasterWasteID)
        {
            var query = new List<WasteCanbanInfoModel>();
            if (MasterWasteID == null)
            {
                MasterWasteID = 0;
            }
            if(MasterWasteID != null)
            {
                 query = (from t in context.PP_WasteCanbanInfos
                            where
                            t.InputOutputID == MasterWasteID
                            select ConvertToModel(t)).ToList();
                return query;
            }
            else
            {
                return query;
            }
        }
        ///////// second detail
        public WasteCanbanInfoModel ConvertToModel(DataLayer.PP_WasteCanbanInfo tbl)
        {
            WasteCanbanInfoModel model = new WasteCanbanInfoModel();
            model.WasteCanbanID = tbl.WasteCanbanID;
            model.FacilityID = tbl.FacilityID;
            model.WorkerID = tbl.WorkerID;
            model.WasteSourceID = tbl.WasteSourceID;
            model.WTrackingCode = tbl.WTrackingCode;
            model.WPackageCode = tbl.WPackageCode;
            model.WInventoryCode = tbl.WInventoryCode;
            model.InputOutputID = tbl.InputOutputID;
            model.WastageQuantity = tbl.WastageQuantity;
            model.TaminID = tbl.TaminID;
            model.WasteDesc = tbl.WasteDesc;
            model.OvercomeDesc = tbl.OvercomeDesc;
            model.YearID = tbl.YearID;
            model.UserID = tbl.UserID;
            model.BranchID = tbl.BranchID;
            model.RegisteredDate = tbl.RegisteredDate;
            model.ActionID = tbl.ActionID;
            model.FaultID = tbl.FaultID;
            model.ReworkTime = tbl.ReworkTime;
            model.WasteSupplierID = tbl.WasteSupplierID;
            model.BOM = tbl.BOM;
            model.WastePartID = tbl.WastePartID;
            if (context.PP_WarehouseTypeInfos.Where(q => q.WarehouseTypeInfoID == tbl.WInventoryCode).FirstOrDefault() != null)
            {
                model.WInventoryCodeName = context.PP_WarehouseTypeInfos.Where(q => q.WarehouseTypeInfoID == tbl.WInventoryCode).FirstOrDefault().WarehouseTypeInfoName;
            }
            if (context.PP_CodeInfos.Where(q => q.CodeID == tbl.WPackageCode).FirstOrDefault() != null)
            {
                model.WPackageCodeName = context.PP_CodeInfos.Where(q => q.CodeID == tbl.WPackageCode).FirstOrDefault().CodeDesc;
            }
            if (context.PP_CodeInfos.Where(q => q.CodeID == tbl.WTrackingCode).FirstOrDefault() != null)
            {
                model.WTrackingCodeName = context.PP_CodeInfos.Where(q => q.CodeID == tbl.WTrackingCode).FirstOrDefault().CodeDesc;
            }
            if (context.PP_WasteSourceInfos.Where(q => q.WasteSourceID == tbl.WasteSourceID).FirstOrDefault() != null)
            {
                model.WasteSourceIDName = context.PP_WasteSourceInfos.Where(q => q.WasteSourceID == tbl.WasteSourceID).FirstOrDefault().WasteSourceName;
            }
            if (context.PP_WorkersInfos.Where(q => q.WorkersID == tbl.WorkerID).FirstOrDefault() != null)
            {
                model.WorkerIDName = context.PP_WorkersInfos.Where(q => q.WorkersID == tbl.WorkerID).FirstOrDefault().WorkersName + " " + context.PP_WorkersInfos.Where(q => q.WorkersID == tbl.WorkerID).FirstOrDefault().WorkersSurname;
            }
            if (context.PP_FacilityInfos.Where(q => q.FacilityID == tbl.FacilityID).FirstOrDefault() != null)
            {
                model.FacilityIDName = context.PP_FacilityInfos.Where(q => q.FacilityID == tbl.FacilityID).FirstOrDefault().FacilityName;
            }
            if (context.PP_FaultInfos.Where(q => q.FaultID == tbl.FaultID).FirstOrDefault() != null)
            {
                model.FaultIDName = context.PP_FaultInfos.Where(q => q.FaultID == tbl.FaultID).FirstOrDefault().FaultName;
            }
            if (context.PP_ActionInfos.Where(q => q.ActionID == tbl.ActionID).FirstOrDefault() != null)
            {
                model.ActionIDName = context.PP_ActionInfos.Where(q => q.ActionID == tbl.ActionID).FirstOrDefault().ActionName;
            }
            if (context.MRP_PartInfos.Where(q => q.PartID == tbl.WastePartID).FirstOrDefault() != null)
            {
                model.WastePartIDName = context.MRP_PartInfos.Where(q => q.PartID == tbl.WastePartID).FirstOrDefault().PartName;
            }
            if (context.PP_ProcessStageInfos.Where(q => q.ProcessStageID == tbl.WCProcessStageID).FirstOrDefault() != null)
            {
                model.WCProcessStageIDName = context.PP_ProcessStageInfos.Where(q => q.ProcessStageID == tbl.WCProcessStageID).FirstOrDefault().ProcessStageName;
            }
            if (context.PP_Tamins.Where(q => q.TaminID == tbl.TaminID).FirstOrDefault() != null)
            {
                model.TaminName = context.PP_Tamins.Where(q => q.TaminID == tbl.TaminID).FirstOrDefault().TaminName;
            }
            //model.WCProcessStageID = tbl.WCProcessStageID;
            return model;
        }
        public DataLayer.PP_WasteCanbanInfo ConvertToTable(WasteCanbanInfoModel model)
        {
            DataLayer.PP_WasteCanbanInfo tbl = new DataLayer.PP_WasteCanbanInfo();
            tbl.WasteCanbanID = model.WasteCanbanID;
            tbl.FacilityID = model.FacilityID;
            tbl.WorkerID = model.WorkerID;
            tbl.WasteSourceID = model.WasteSourceID;
            tbl.WTrackingCode = model.WTrackingCode;
            tbl.WPackageCode = model.WPackageCode;
            tbl.WInventoryCode = model.WInventoryCode;
            tbl.InputOutputID = model.InputOutputID;
            tbl.WastageQuantity = model.WastageQuantity;
            tbl.TaminID = model.TaminID;
            tbl.WasteDesc = model.WasteDesc;
            tbl.OvercomeDesc = model.OvercomeDesc;
            tbl.YearID = model.YearID;
            tbl.UserID = model.UserID;
            tbl.BranchID = model.BranchID;
            tbl.RegisteredDate = model.RegisteredDate;
            tbl.WCProcessStageID = model.WCProcessStageID;
            tbl.ActionID = model.ActionID;
            tbl.FaultID = model.FaultID;
            tbl.WasteSupplierID = model.WasteSupplierID;
            tbl.BOM = model.BOM;
            tbl.WastePartID = model.WastePartID;
            tbl.ReworkTime = model.ReworkTime;
            return tbl;
        }
        /// <summary>
        /// it returns all child for a specefic child 
        /// </summary>
        /// <param name="parentID">parent name</param>
        /// <returns></returns>
        public IQueryable<WasteCanbanInfoModel> GetAllDetail2(int? parentID)
        {
            if (parentID == null)
            {
                parentID = 0;
            }
            var query = from t in context.PP_WasteCanbanInfos
                        where
                        t.InputOutputID == parentID
                        select ConvertToModel(t);
            return query;
        }
        /// <summary>
        /// it delete all child for specfic parent
        /// </summary>
        /// <param name="parentID">the paretn id</param>
        /// <returns></returns>
        public Boolean DeleteAllDetail2(int parentID)
        {
            Boolean Result = false;
            try
            {
                var query = (from t in context.PP_WasteCanbanInfos
                             where
                                t.InputOutputID == parentID
                             select t);
                foreach (var item in query)
                {
                    context.PP_WasteCanbanInfos.DeleteOnSubmit(item);
                }
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
        /// this function saves all parent info
        /// </summary>
        /// <param name="model">parent info</param>
        public void SaveAllDetail2(IEnumerable<WasteCanbanInfoModel> model, int inputoutpotid)
        {
            foreach (var item in model)
            {
                DataLayer.PP_WasteCanbanInfo tbl = new DataLayer.PP_WasteCanbanInfo();
                tbl = ConvertToTable(item);
                tbl.InputOutputID = inputoutpotid;
                tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                tbl.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                tbl.UserID = CRMStaticData.StaticData.getUserID;
                tbl.YearID = CRMStaticData.StaticData.getYearID;
                context.PP_WasteCanbanInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
        /// <summary>
        /// this function edit all parent data
        /// first delete all parent id then save all sended parent info
        /// </summary>
        /// <param name="model">all parent info</param>
        public void EditAllDetail2(IEnumerable<WasteCanbanInfoModel> model)
        {
            DeleteAllDetail2((int)model.First().InputOutputID);
            foreach (var item in model)
            {
                DataLayer.PP_WasteCanbanInfo tbl = new DataLayer.PP_WasteCanbanInfo();
                tbl = ConvertToTable(item);
                context.PP_WasteCanbanInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
        public List<General.GeneralModels.Combo.ComboModel> WastageScheduleProductionLineCombo()
        {
            var query = from t in context.PP_ScheduleProductionLineInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = (int)t.ScheduleProductionLineID,
                            Name = t.RoutID.ToString(),
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> WastageFacilityCombo(int workStationID)
        {
            var query = from t in context.PP_FacilityInfos
                        where t.WorkStationID == workStationID
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.FacilityID,
                            Name = t.FacilityName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> WastageFacilityAllCombo()
        {
            var query = from t in context.PP_FacilityInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.FacilityID,
                            Name = t.FacilityName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> WastageWorkerCombo()
        {
            var query = from t in context.PP_WorkersInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.WorkersID,
                            Name = t.WorkersSurname,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> WasteSourceCombo()
        {
            var query = from t in context.PP_WasteSourceInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.WasteSourceID,
                            Name = t.WasteSourceName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> FaultCombo()
        {
            var query = from t in context.PP_FaultInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.FaultID,
                            Name = t.FaultName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> ActionCombo()
        {
            var query = from t in context.PP_ActionInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.ActionID,
                            Name = t.ActionName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> CodeCombo()
        {
            var query = from t in context.PP_CodeInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.CodeID,
                            Name = t.Code,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> ScheduleCombo()
        {
            var query = from t in context.PP_ScheduleProductionLineInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.ScheduleProductionLineID,
                            Name = t.Year.ToString() + "/" + t.Month.ToString() + "/" + t.Day.ToString() + " ; " + t.ScheduleStartTime,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> UnitCombo()
        {
            var query = from t in context.MRP_PartUnitInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.PartUnitID,
                            Name = t.PartUnitName,
                        };
            return query.ToList();
        }
    }
}
