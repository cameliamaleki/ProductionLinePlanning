using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sell.LendingCars
{
    public class LendingCars
    {
        public int Insert(LendingCarsModel model)
        {
            int Id = 0;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string sal = (Core.StaticData.DateNow.Date.Split('/')[0]).Substring(2);
            string DateA = model.DateA;
            int F_AgnID = (int)model.F_AgnID;
            int? FlgTaahod = (model.FlgTaahod == true) ? 1 : 0;
            string sql = @"DECLARE		@Out int
                        EXEC	  [sale].[STP_T00050061];1
		                @sal ={0},
	                    @DateA ={1},
	                    @F_AgnID= {2},
	                    @FlgTaahod ={3},
	                    @Out = @Out OUTPUT
                        SELECT	@Out as N'@Out'";
            Id = context.ExecuteQuery<int>(sql,
                           sal,
                           DateA,
                           F_AgnID,
                           FlgTaahod).FirstOrDefault();
            return Id;
        }
        public Boolean Update(LendingCarsModel model)
        {
            Boolean Result = false;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string DateA = model.DateA;
            int F_AgnID = (int)model.F_AgnID;
            int? FlgTaahod = (model.FlgTaahod == true) ? 1 : 0;
            int IDrequstAmani = model.IDrequstAmani;
            string sql = @"EXEC	  [sale].[STP_T00050061];2
		                @IDrequstAmani ={0},
	                    @DateA ={1},
	                    @F_AgnID= {2},
	                    @FlgTaahod ={3}";
            context.ExecuteCommand(sql,
                                    IDrequstAmani,
                                    DateA,
                                    F_AgnID,
                                    FlgTaahod);
            return Result;
        }
        public Boolean CheckEbtal(int LendingCarsId)
        {
            Boolean Result = false;
                 DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
                 var Query = from t in context.T00050060s
                             where t.F_IDrequstAmani == LendingCarsId
                             select t;
                 foreach (var a in Query)
                     if (a.status == 809)
                         Result = true;
            return Result;
        }
        public Boolean CheckForEdit(int LendingCarsId)
        {
            Boolean Result = true;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Query = from t in context.T00050060s
                        where t.F_IDrequstAmani == LendingCarsId
                        select t;
            foreach (var a in Query)
                if (a.status != 801)
                    Result = false;
            return Result;
        }
        public Boolean Delete(int LendingCarsId)
        {
            Boolean Result = false;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string sql = @"update  T00050060 set status=809
WHERE        (f_IdrequstAmani = " + LendingCarsId + ")";
            context.ExecuteCommand(sql);
            return Result;
        }
        public LendingCarsModel GetById(int id)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            LendingCarsModel model = new LendingCarsModel();
            var query = (from t in context.T00050061s
                         where (t.IDrequstAmani == id)
                         select t).FirstOrDefault();
            model.code = query.code;
            model.DateA = query.DateA;
            model.F_AgnID = query.F_AgnID;
            model.FlgTaahod = Convert.ToBoolean(query.FlgTaahod);
            model.TrackID = (int?)query.TrackID;
            return model;
        }
        public List<LendingCarsViewModel> GetAll(int AGNID, string code, string FromDate, string ToDate, int F_CarID, int F_color, int F_UsageType)
        {
            if (FromDate == "")
                FromDate = "13  /  /  ";
            if (ToDate == "")
                ToDate = "13  /  /  ";
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<LendingCarsViewModel>("execute  sale.STP_T00050061;10 " + AGNID + "," + code + ",'" + FromDate + "','" + ToDate + "'," + F_CarID + "," + F_color + "," + F_UsageType).ToList();
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllComboBox(int AGNID, string Name)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = new List<System.Web.Mvc.SelectListItem>();
            if (BAL.StaticData.IsAgent)
            {
                var agnCode = BAL.StaticData.AgentCode;
                var query = from t in context.T00050061s
                            join agent in context.T00050002s
                            on t.F_AgnID equals agent.AGNID
                            where t.F_AgnID == agnCode
                            select
                   new System.Web.Mvc.SelectListItem
                   {
                       Selected = false,
                       Text = t.code + "-" + t.DateA + "-" + agent.AGNDesc,
                       Value = t.IDrequstAmani.ToString()
                   };
                Result = query.Where(p => p.Text.Contains(Name)).Take(20).ToList();
            }
            else
            {
                var query = from t in context.T00050061s
                            join agent in context.T00050002s
                            on t.F_AgnID equals agent.AGNID
                            select
                   new System.Web.Mvc.SelectListItem
                   {
                       Selected = false,
                       Text = t.code + "-" + t.DateA + "-" + agent.AGNDesc,
                       Value = t.IDrequstAmani.ToString()
                   };
                Result = query.Where(p => p.Text.Contains(Name)).Take(20).ToList();
            }
            if (Name == "")
                Result.Add(new System.Web.Mvc.SelectListItem { Selected = true, Text = "انتخاب کنید", Value = "0" });
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllKargozranComboBox()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = new List<System.Web.Mvc.SelectListItem>();
            var r = context.ExecuteQuery<KargozaranModel>("select * from ViwT0005_kargozaran").ToList();
            foreach (var a in r)
            {
                Result.Add(new System.Web.Mvc.SelectListItem
                {
                    Value = a.IDKargozar.ToString(),
                    Text = a.FullName,
                    Selected = false
                });
            }
            Result.Add(new System.Web.Mvc.SelectListItem { Selected = true, Text = "انتخاب کنید", Value = "0" });
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllBarbariComboBox()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = new List<System.Web.Mvc.SelectListItem>();
            Result = (from t in context.T00050064s
                      select new System.Web.Mvc.SelectListItem
                      {
                          Selected = false,
                          Text = t.Name,
                          Value = t.IdBarbary.ToString()
                      }).ToList();
            Result.Add(new System.Web.Mvc.SelectListItem { Selected = true, Text = "انتخاب کنید", Value = "0" });
            return Result;
        }
        public List<LendingCarsFlowModel> GetLendingCarsFlow(int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<LendingCarsFlowModel>("execute  sale.STP_T00050062;2");
            if (BAL.StaticData.IsAgent)
            {
                //Result = Result.Where(p => p.AGNCode == AGNID);
            }
            return Result.ToList();
        }
    }
    public class LendingCarsDetail
    {
        public int Insert(LendingCarsDetailModel model)
        {
            int Id = 0;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int F_IDrequstAmani = (int)model.F_IDrequstAmani;
            int F_IDCar = (int)model.F_IDCar;
            int AcceptanceType = (int)model.AcceptanceType;
            int F_color = (int)model.F_color;
            int num = (int)model.num;
            int radif = (int)model.radif;
            int Days = (int)model.Days;
            int DelivType = (int)model.DelivType;
            int F_Deliver = (int)model.F_Deliver;
            string NameDeliv = model.NameDeliv;
            int F_UsageType = model.F_UsageType;
            string sql = @"DECLARE		@Out int
                        EXEC	  [sale].[STP_T00050060];1
		                @F_IDrequstAmani ={0},
	                    @F_IDCar ={1},
	                    @AcceptanceType= {2},
	                    @F_color ={3},
                        @num ={4},
                        @radif ={5},
                        @Days ={6},
                        @DelivType ={7},
                        @F_Deliver ={8},
                        @NameDeliv ={9},
                        @F_UsageType ={10},
	                    @Out = @Out OUTPUT
                        SELECT	@Out as N'@Out'";
            Id = context.ExecuteQuery<int>(sql,
                           F_IDrequstAmani,
                           F_IDCar,
                           AcceptanceType,
                           F_color,
                           num,
                           radif,
                           Days,
                           DelivType,
                           F_Deliver,
                           NameDeliv,
                           F_UsageType).FirstOrDefault();
            DataLayer.AtsTotalNewDataContext NewContext = new DataLayer.AtsTotalNewDataContext();
            var query = (from t in NewContext.T00050060s
                         where t.IDDetailReqAmani == Id
                         select t).FirstOrDefault();
            query.status = 801;
            query.Statusdate = Core.StaticData.DateNow.Date;
            query.StatusTime = Core.StaticData.DateNow.Time;
            NewContext.SubmitChanges();
            return Id;
        }
        public Boolean Update(LendingCarsDetailModel model)
        {
            Boolean Result = false;
            return Result;
        }
        public Boolean DeleteByMaster(int IDrequstAmani)
        {
            Boolean Result = false;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string sql = @"delete from T00050060 where IDDetailReqAmani=" + IDrequstAmani;
            context.ExecuteCommand(sql );
            //3
            return Result;
        }
        public LendingCarsDetailModel GetById(int id)
        {
            LendingCarsDetailModel model = new LendingCarsDetailModel();
            return model;
        }
        public List<LendingCarsDetailViewModel> GetByAmaniID(int AmaniID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<LendingCarsDetailViewModel>("execute  sale.STP_T00050060;4 " + AmaniID + ",0,0,0").ToList(); ;
            foreach (var record in Result)
            {
                var query = (from t in context.T00050060s
                             where t.IDDetailReqAmani == record.IDDetailReqAmani
                             select t).FirstOrDefault();
                record.F_IDCar = query.F_IDCar;
            }
            return Result;
        }
        public List<Sell.Report.AmaniDeliveredReportViewModel> GetAmaniDeliveredReport(int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.AmaniDeliveredReportViewModel>("execute  sale.STP_T000500RP;50 0,0,'','',''," + AGNID);
            return Result.ToList();
        }
        public List<Sell.Report.AmaniDeliveredReportViewModel> GetDeliveredReport(int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.AmaniDeliveredReportViewModel>("execute  sale.STP_T000500RP;50 0,0,'','',''," + AGNID);
            return Result.ToList();
        }
    }
}
