using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProductionLineBalancing.Models.RoutInfo
{
    public class RoutInfo
    {
        public RoutInfoModel _model = new RoutInfoModel();
        DataLayer.MRPDataContext context = new DataLayer.MRPDataContext();
        Boolean IsEdit;
        /// <summary>
        /// to find the max ID for save new on
        /// </summary>
        /// <returns></returns> the ID for new one
        private int GetMaxID()
        {
            int ID = 1;
            try
            {
                var query = (from t in context.PP_RoutInfos
                             select t).Max(p => p.RoutID);
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
        public Boolean Add(RoutInfoModel model)
        {
            Boolean result = true;
            try
            {
                _model = model;
                _model.BranchID = CRMStaticData.StaticData.getBranchID;
                _model.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                _model.UserID = CRMStaticData.StaticData.getUserID;
                _model.YearID = CRMStaticData.StaticData.getYearID;
                _model.IsActived = 1;
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
        public Boolean Edit(RoutInfoModel model)
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
            int Result = 0;
            try
            {
                if (IsEdit)
                {
                    var query = (from t in context.PP_RoutInfos
                                 where
                                    t.RoutID == _model.RoutID
                                 select t).FirstOrDefault();
                    query.RoutID = _model.RoutID;
                    query.RoutName = _model.RoutName;
                    query.WorkStationID = _model.WorkStationID;
                    query.RoutTypeID = _model.RoutTypeID;
                    query.PartID = _model.PartID;
                    query.BranchID = CRMStaticData.StaticData.getBranchID;
                    query.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                    query.UserID = CRMStaticData.StaticData.getUserID;
                    query.YearID = CRMStaticData.StaticData.getYearID;
                    query.IsActived = 1;
                    context.SubmitChanges();
                    Result = query.RoutID;
                }
                else
                {
                    context.PP_RoutInfos.InsertOnSubmit(ConvertToTable(_model));
                    context.SubmitChanges();
                    Result = _model.RoutID;
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
        public DataLayer.PP_RoutInfo ConvertToTable(RoutInfoModel model)
        {
            DataLayer.PP_RoutInfo tbl = new DataLayer.PP_RoutInfo();
            tbl.RoutID = model.RoutID;
            tbl.RoutName = model.RoutName;
            tbl.WorkStationID = model.WorkStationID;
            tbl.RoutTypeID = model.RoutTypeID;
            tbl.PartID = model.PartID;
            tbl.YearID = model.YearID;
            tbl.BranchID = model.BranchID;
            tbl.UserID = model.UserID;
            tbl.RegisteredDate = model.RegisteredDate;
            tbl.IsActived = model.IsActived;
            return tbl;
        }
        /// <summary>
        /// this function conver the table form to model
        /// </summary>
        /// <param name="tbl"></param> the covertable table
        /// <returns></returns>the converted model
        public RoutInfoModel ConvertToModel(DataLayer.PP_RoutInfo tbl)
        {
            RoutInfoModel model = new RoutInfoModel();
            model.RoutID = tbl.RoutID;
            model.RoutName = tbl.RoutName;
            model.WorkStationID = tbl.WorkStationID;
            model.RoutTypeID = tbl.RoutTypeID;
            model.PartID = tbl.PartID;
            model.YearID = tbl.YearID;
            model.BranchID = tbl.BranchID;
            model.UserID = tbl.UserID;
            model.IsActived = (int)tbl.IsActived;
            model.RegisteredDate = tbl.RegisteredDate;
            model.PartName = context.MRP_PartInfos.Where(q => q.PartID == tbl.PartID).FirstOrDefault().PartName;
            model.WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == tbl.WorkStationID).FirstOrDefault().WorkStationName;
            model.RoutTypeName = context.PP_RoutTypeInfos.Where(q => q.RoutTypeID == tbl.RoutTypeID).FirstOrDefault().RoutTypeName;
            return model;
        }
        /// <summary>
        /// the function finds from table by ID
        /// </summary>
        /// <param name="id"></param> the ID u wnt to find the table form
        /// <returns></returns> returns the the converted table to model
        /// 
        public RoutInfoModel GetByID(int id)
        {
            var query = (from t in context.PP_RoutInfos
                         where
                            t.RoutID == id
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
                var query = (from t in context.PP_RoutInfos
                             where
                                t.RoutID == id
                             select t).FirstOrDefault();
                DeleteAllDetail1(id);
                DeleteAllDetail2(id);
               context.PP_RoutInfos.DeleteOnSubmit(query);
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
        public IQueryable<RoutInfoModel> GetAll()
        {
            var query = from t in context.PP_RoutInfos
                        select ConvertToModel(t);
            return query;
        }
        public RoutFacilityInfoModel ConvertToModel(DataLayer.PP_RoutFacilityInfo tbl)
        {
            RoutFacilityInfoModel model = new RoutFacilityInfoModel();
            model.RoutFacilityID = tbl.RoutFacilityID;
            model.RoutID = tbl.RoutID;
            model.FaciltiyID = tbl.FaciltiyID;
            model.PartID = tbl.PartID;
            model.TimeDurationMin = tbl.TimeDurationMin;
            model.YearID = tbl.YearID;
            model.BranchID = tbl.BranchID;
            model.UserID = tbl.UserID;
            model.RegisteredDate = tbl.RegisteredDate;
            model.FaciltiyName = context.PP_FacilityInfos.Where(q => q.FacilityID == tbl.FaciltiyID).FirstOrDefault().FacilityName;
            model.PartName = context.MRP_PartInfos.Where(q => q.PartID == tbl.PartID).FirstOrDefault().PartName;
            return model;
        }
        public DataLayer.PP_RoutFacilityInfo ConvertToTable(RoutFacilityInfoModel model)
        {
            DataLayer.PP_RoutFacilityInfo tbl = new DataLayer.PP_RoutFacilityInfo();
          //  tbl.RoutFacilityID = model.RoutFacilityID;
            tbl.RoutID = model.RoutID;
            tbl.FaciltiyID = model.FaciltiyID;
            // part id saved in Master
            tbl.PartID = _model.PartID;
            tbl.TimeDurationMin = model.TimeDurationMin;
            tbl.YearID = model.YearID;
            tbl.BranchID = model.BranchID;
            tbl.UserID = model.UserID;
            tbl.RegisteredDate = model.RegisteredDate;
            tbl.PartID = model.PartID;
            return tbl;
        }
        public RoutChildParentInfoModel ConvertToModel(DataLayer.PP_RoutChildParentInfo tbl)
        {
            RoutChildParentInfoModel model = new RoutChildParentInfoModel();
            model.RoutID = tbl.RoutID;
            model.ChildRoutID = tbl.ChildRoutID;
            model.RoutChildParentID = tbl.RoutChildParentID;
            return model;
        }
        public DataLayer.PP_RoutChildParentInfo ConvertToTable(RoutChildParentInfoModel model)
        {
            DataLayer.PP_RoutChildParentInfo tbl = new DataLayer.PP_RoutChildParentInfo();
            tbl.RoutID = model.RoutID;
            tbl.ChildRoutID = model.ChildRoutID;
            tbl.RoutChildParentID = model.RoutChildParentID;
            return tbl;
        }
        /// <summary>
        /// it returns all child for a specefic child 
        /// </summary>
        /// <param name="parentID">parent name</param>
        /// <returns></returns>
        public IQueryable<RoutFacilityInfoModel> GetAllDetail1(int parentID)
        {
            var query = from t in context.PP_RoutFacilityInfos
                        where
                        t.RoutID == parentID
                        select ConvertToModel(t);
            return query;
        }
        /// <summary>
        /// it delete all child for specfic parent
        /// </summary>
        /// <param name="parentID">the paretn id</param>
        /// <returns></returns>
        public Boolean DeleteAllDetail1(int parentID)
        {
            Boolean Result = false;
            try
            {
                var query = (from t in context.PP_RoutFacilityInfos
                             where
                                t.RoutID == parentID
                             select t);
                foreach (var item in query)
                {
                    context.PP_RoutFacilityInfos.DeleteOnSubmit(item);
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
        public Boolean DeleteDetail1(int parentID)
        {
            Boolean Result = false;
            try
            {
                var query = (from t in context.PP_RoutFacilityInfos
                             where
                                t.RoutFacilityID == parentID
                             select t);
                foreach (var item in query)
                {
                    context.PP_RoutFacilityInfos.DeleteOnSubmit(item);
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
        public void SaveAllDetail1(IEnumerable<RoutFacilityInfoModel> model)
        {
            if (model.FirstOrDefault().RoutID != null)
            {
                context.ExecuteQuery<int>("DELETE from PP_RoutFacilityInfo where RoutID=" + model.FirstOrDefault().RoutID).FirstOrDefault();
            }
           // var itIsID = GetMaxID() - 1;
            foreach (var item in model)
            {
                DataLayer.PP_RoutFacilityInfo tbl = new DataLayer.PP_RoutFacilityInfo();
                tbl = ConvertToTable(item);
                if (item.RoutID != null)
                {
                    tbl.RoutID = item.RoutID;
                }
                else
                {
                    tbl.RoutID= GetMaxID() - 1;
                }
                tbl.BranchID = CRMStaticData.StaticData.getBranchID;
                tbl.RegisteredDate = CRMStaticData.StaticData.getRegisteredDate;
                tbl.UserID = CRMStaticData.StaticData.getUserID;
                tbl.YearID = CRMStaticData.StaticData.getYearID;
                context.PP_RoutFacilityInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
            context.ExecuteQuery<int>("UPDATE PP_RoutInfo set PartID=" + model.FirstOrDefault().PartID + "where RoutID=" + model.FirstOrDefault().RoutID);
        }
        /// <summary>
        /// this function edit all parent data
        /// first delete all parent id then save all sended parent info
        /// </summary>
        /// <param name="model">all parent info</param>
        public void EditAllDetail1(IEnumerable<RoutFacilityInfoModel> model)
        {
            DeleteAllDetail1((int)model.First().RoutID);
            foreach (var item in model)
            {
                DataLayer.PP_RoutFacilityInfo tbl = new DataLayer.PP_RoutFacilityInfo();
                tbl = ConvertToTable(item);
                context.PP_RoutFacilityInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
        /******************** second detail **************************/
        /// <summary>
        /// it returns all child for a specefic child 
        /// </summary>
        /// <param name="parentID">parent name</param>
        /// <returns></returns>
        public IQueryable<RoutChildParentInfoModel> GetAllDetail2(int parentID)
        {
            var query = from t in context.PP_RoutChildParentInfos
                        where
                        t.RoutID == parentID
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
                var query = (from t in context.PP_RoutChildParentInfos
                             where
                                t.RoutID == parentID
                             select t);
                foreach (var item in query)
                {
                    context.PP_RoutChildParentInfos.DeleteOnSubmit(item);
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
        public void SaveAllDetail2(IEnumerable<RoutChildParentInfoModel> model)
        {
            var itIsID = GetMaxID() - 1;
            foreach (var item in model)
            {
                DataLayer.PP_RoutChildParentInfo tbl = new DataLayer.PP_RoutChildParentInfo();
                tbl = ConvertToTable(item);
                tbl.RoutID = itIsID;
                tbl.ChildRoutID = item.ChildRoutID;
                context.PP_RoutChildParentInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
        /// <summary>
        /// this function edit all parent data
        /// first delete all parent id then save all sended parent info
        /// </summary>
        /// <param name="model">all parent info</param>
        public void EditAllDetail2(IEnumerable<RoutChildParentInfoModel> model)
        {
            DeleteAllDetail2((int)model.First().RoutID);
            foreach (var item in model)
            {
                DataLayer.PP_RoutChildParentInfo tbl = new DataLayer.PP_RoutChildParentInfo();
                tbl = ConvertToTable(item);
                context.PP_RoutChildParentInfos.InsertOnSubmit(tbl);
                context.SubmitChanges();
            }
        }
        public List<General.GeneralModels.Combo.ComboModel> RoutPartCombo()
        {
            var query = from t in context.MRP_PartInfos
                        where t.BranchID==CRMStaticData.StaticData.getBranchID           
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = (t.PartID==null)?0:t.PartID,
                            Name = ((t.PartName==null)?"-": t.PartName) +"-"+ ((t.TechnicalNumber == null) ? "-" : t.TechnicalNumber),
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> RoutWorkStationCombo()
        {
            var query = from t in context.PP_WorkStationInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.WorkStationID,
                            Name = t.WorkStationName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> RoutTypeCombo()
        {
            var query = from t in context.PP_RoutTypeInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.RoutTypeID,
                            Name = t.RoutTypeName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> RoutCombo()
        {
            var query = from t in context.PP_RoutInfos
                        select new General.GeneralModels.Combo.ComboModel
                        {
                            Value = t.RoutID,
                            Name = t.RoutName,
                        };
            return query.ToList();
        }
        public List<General.GeneralModels.Combo.ComboModel> FacilityCombo(int workStationID)
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
    }
}
