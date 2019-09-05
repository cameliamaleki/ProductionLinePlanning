using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sell.Contract
{
    public class ContractSharedSelectModel
    {
        public int ContractID { get; set; }
        public string ContractNo { get; set; }
        public string ContractDate { get; set; }
        public int F_AgencyID { get; set; }
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
        public string CustomerName { get; set; }
    }
    public class ContractShareDetailModel
    {
        public string ContractNo { get; set; }
        public string ContractDate { get; set; }
        public int? F_AgencyID { get; set; }
        public decimal? ContractPrice { get; set; }
        public int? ContractStatus { get; set; }
        public string ShahedName { get; set; }
        public string ShahedFName { get; set; }
        public string ShahedShNo { get; set; }
        public string ShahedAdd { get; set; }
        public string PhishNo { get; set; }
        public string PhishDate { get; set; }
        public decimal? PhishMoney { get; set; }
        public string TransferName { get; set; }
        public string TransferFName { get; set; }
        public string TransferShNo { get; set; }
        public string TransferBirthDate { get; set; }
        public string TransferNationalCode { get; set; }
        public int? F_IssueLocationTransfer { get; set; }
        public string TransferAdd { get; set; }
        public int? TransferType { get; set; }
        public string F_IssueLocationTransferName { get; set; }
    }
    public class ContractShareCarsListReportModel
    {
        public int? ContractCarID { get; set; }
        public int? F_ContractId { get; set; }
        public string ContractNo { get; set; }
        public int? F_Status { get; set; }
        public int? carID { get; set; }
        public string CarCode { get; set; }
        public string ShasiNO { get; set; }
        public string MotorNO { get; set; }
        public string BodyNO { get; set; }
        public int? F_AgancyRsv { get; set; }
        public int? F_CustomerRsv { get; set; }
        public Int16 Status { get; set; }
        public string ContractDate { get; set; }
        public int? Model { get; set; }
        public string CarName { get; set; }
    }
    public class ContractShareCustomersListModel
    {
        public int? CMID { get; set; }
        public string FlName { get; set; }
        public string CMFatherName { get; set; }
        public string CMIDNo { get; set; }
        public string CMNationalCode { get; set; }
        public string pt_desc { get; set; }
        public string CMBirthDate { get; set; }
    }
    public class ContractShareCarsListModel
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int IDCar { get; set; }
        public string ShasiNO { get; set; }
        public string MotorNO { get; set; }
    }
    public class ContractShareMasterReport
    {
        public int? ContractID { get; set; }
        public string ContractNo { get; set; }
        public string ContractDate { get; set; }
        public int? F_AgencyID { get; set; }
        public decimal? ContractPrice { get; set; }
        public string ShahedName { get; set; }
        public int? ContractStatus { get; set; }
        public string ShahedFName { get; set; }
        public string ShahedShNo { get; set; }
        public string ShahedAdd { get; set; }
        public string PhishNo { get; set; }
        public string PhishDate { get; set; }
        public decimal? PhishMoney { get; set; }
        public string AGNDesc { get; set; }
        public string AGNAddress { get; set; }
        public string CMName { get; set; }
        public string CMFamily { get; set; }
        public string CMFatherName { get; set; }
        public string CMIDNo { get; set; }
        public string CMNationalCode { get; set; }
        public string CMAdrsStreet { get; set; }
        public string CMTelPhone { get; set; }
        public string CarName { get; set; }
        public int? Model { get; set; }
        public int? CarCount { get; set; }
        public byte? CMType { get; set; }
        public string TransferName { get; set; }
        public string TransferFname { get; set; }
        public string TransferShNo { get; set; }
        public string TransferBirthDate { get; set; }
        public string TransferNationalCode { get; set; }
        public string TransferSadere { get; set; }
        public string TransferAdd { get; set; }
        public int? TransferType { get; set; }
    }
    public class ContractShareCarsReport
    {
        public int? ContractCarID { get; set; }
        public int? F_ContractId { get; set; }
        public string ContractNo { get; set; }
        public int? carID { get; set; }
        public string CarCode { get; set; }
        public string ShasiNO { get; set; }
        public string MotorNO { get; set; }
        public string BodyNO { get; set; }
        public int? F_AgancyRsv { get; set; }
        public int? F_CustomerRsv { get; set; }
        public Int16? Status { get; set; }
        public string ContractDate { get; set; }
        public int? Model { get; set; }
        public string CarName { get; set; }
    }
    public class ContractShareCustomersReport
    {
        public int cmID { get; set; }
        public byte CMType { get; set; }
        public string CMCode { get; set; }
        public int F_CMGroupID { get; set; }
        public string CMName { get; set; }
        public string CMFamily { get; set; }
        public string CMFatherName { get; set; }
        public string CMIDNo { get; set; }
        public int F_CMIssueLocation { get; set; }
        public string sadere { get; set; }
        public string CMBirthDate { get; set; }
        public int F_CMJobCode { get; set; }
        public string CMIssueDate { get; set; }
        public string CMNationalCode { get; set; }
        public int? F_CMSexID { get; set; }
        public string CMLicenceNo { get; set; }
        public string CMLicenceIssueDate { get; set; }
        public int F_CMLicenceIssueLocation { get; set; }
        public string Agndesc { get; set; }
        public string CMaddStreet { get; set; }
        public string CMTelPhone { get; set; }
        public string NationalID { get; set; }
    }
    public class ContractShareReportFlow
    {
        public string ContractNo { get; set; }
        public string CustFlName { get; set; }
        public string shasiNo { get; set; }
        public string StatusDesc { get; set; }
        public int F_UserID { get; set; }
        public string UserName { get; set; }
        public string LogDate { get; set; }
        public string LogTime { get; set; }
        public string ComputerName { get; set; }
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
    }
    public class ContractShareReport
    {
        public List<ContractShareCustomersReport> ContractShareCustomers { get; set; }
        public List<ContractShareCarsReport> ContractShareCars { get; set; }
        public List<ContractShareMasterReport> ContractReportMaster { get; set; }
    }
    public class ContractShare
    {
        public Boolean CheckContractShareCustomers(int CustomerID, int ContractShareID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var query = from t in
                            context.T00050072s
                        where t.F_ContractId == ContractShareID
                        && t.F_CustomerID == CustomerID
                        select t;
            if (query.Count() > 0)
                return true;
            else return false;
        }
        public Boolean CheckContractShareCar(int CarID, int ContractShareID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var query = from t in
                            context.T00050071s
                        where t.F_ContractId == ContractShareID
                        && t.F_CarId == CarID
                        select t;
            if (query.Count() > 0)
                return true;
            else return false;
        }
        public ContractShareCarsListModel GetContractShareCarsByCarId(int CarID)
        {
            var model = new ContractShareCarsListModel();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"SELECT        T00050016.CarCode, T00050010.ShasiNO, T00050010.MotorNO, T00050010.BodyNO, T00050010.F_AgancyRsv, T00050010.F_CustomerRsv, T00050010.Status, T00050010.Model, T00050016.CarName,T00050010.IDCar
FROM            T00050010 INNER JOIN
                         T00050016 ON T00050010.F_CarID = T00050016.CarId
                where T00050010.IDCar=" + CarID;
            var query = context.ExecuteQuery<ContractShareCarsListModel>(Sql);
            model = query.FirstOrDefault();
            return model;
        }
        public ContractShareCustomersListModel GetContractShareCustomersByCustomerId(int CustomerId)
        {
            var model = new ContractShareCustomersListModel();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"SELECT        T00050001.CMID, T00050001.CMName + ' ' + T00050001.CMFamily AS FlName, 
                         CASE T00050001.CMType WHEN 1 THEN dbo.T00050001.CMFatherName WHEN 2 THEN dbo.T00050001.CMIDNo END AS CMFatherName, 
                         CASE T00050001.CMType WHEN 1 THEN dbo.T00050001.CMIDNo WHEN 2 THEN dbo.T00050001.CMNationalCode END AS CMIDNo, 
                         CASE T00050001.CMType WHEN 1 THEN dbo.T00050001.CMNationalCode WHEN 2 THEN dbo.T00050001.NationalID END AS CMNationalCode, T00020002.pt_desc, 
                         CASE T00050001.CMType WHEN 1 THEN dbo.T00050001.CMBirthDate WHEN 2 THEN dbo.T00050001.CMTelPhone END AS CMBirthDate
FROM            T00050001 INNER JOIN
                         T00020002 ON T00050001.F_CMIssueLocation = T00020002.pyprmtflID
                where T00050001.CMID=" + CustomerId;
            var query = context.ExecuteQuery<ContractShareCustomersListModel>(Sql);
            model = query.FirstOrDefault();
            return model;
        }
        public ContractShareReport GetContractShareReport(int ContractShareID)
        {
            ContractShareReport Result = new ContractShareReport();
            var modelReport = new List<ContractShareMasterReport>();
            var ModelReportCustomer = new List<ContractShareCustomersReport>();
            var ModelReportCars = new List<ContractShareCarsReport>();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"execute [sale].[STP_T00050070];5 " + ContractShareID;
            var query = context.ExecuteQuery<ContractShareMasterReport>(Sql);
            modelReport = query.ToList();
            Sql = @"execute [sale].[STP_T00050072];4 " + ContractShareID;
            var query1 = context.ExecuteQuery<ContractShareCustomersReport>(Sql);
            ModelReportCustomer = query1.ToList();
            Sql = @"execute [sale].[STP_T00050071];6 " + ContractShareID;
            var query2 = context.ExecuteQuery<ContractShareCarsReport>(Sql);
            ModelReportCars = query2.ToList();
            Sql = @"execute [sale].[STP_T00050071];9 " + ContractShareID;
            int count = context.ExecuteCommand(Sql);
            Result.ContractReportMaster = modelReport;
            Result.ContractShareCars = ModelReportCars;
            Result.ContractShareCustomers = ModelReportCustomer;
            return Result;
        }
        public List<ContractShareReportFlow> GetContractShareReportFlow()
        {
            List<ContractShareReportFlow> Result = new List<ContractShareReportFlow>();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"execute [sale].[STP_T00050070];8 ";
            var query = context.ExecuteQuery<ContractShareReportFlow>(Sql);
            Result = query.ToList();
            return Result;
        }
        public List<ContractShareCarsListReportModel> GetContractShareCarsList(int ContractShareID)
        {
            var model = new List<ContractShareCarsListReportModel>();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"execute [sale].[STP_T00050071];6 " + ContractShareID;
            var query = context.ExecuteQuery<ContractShareCarsListReportModel>(Sql);
            model = query.ToList();
            return model;
        }
        public List<ContractShareCustomersListModel> GetContractShareCustomersList(int ContractShareID)
        {
            var model = new List<ContractShareCustomersListModel>();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"execute [sale].[STP_T00050072];2 " + ContractShareID;
            var query = context.ExecuteQuery<ContractShareCustomersListModel>(Sql);
            model = query.ToList();
            return model;
        }
        public ContractShareDetailModel GetContractShareByID(int ContractShareID)
        {
            var model = new ContractShareDetailModel();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"execute [sale].[STP_T00050070];2 " + ContractShareID;
            var query = context.ExecuteQuery<ContractShareDetailModel>(Sql);
            model = query.FirstOrDefault();
            var Osttan = (from t in context.T00020002s
                          where t.pyprmtflID == model.F_IssueLocationTransfer
                          select t).FirstOrDefault();
            if (Osttan != null)
            {
                model.F_IssueLocationTransfer = (int)model.F_IssueLocationTransfer;
                model.F_IssueLocationTransferName = Osttan.pt_desc;
            }
            else
            {
                model.F_IssueLocationTransfer = 0;
                model.F_IssueLocationTransferName = "";
            }
            return model;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllContracts(string Name)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"SELECT DISTINCT    dbo.T00050070.ContractID, dbo.T00050070.ContractNo, dbo.T00050070.ContractDate,dbo.T00050070.F_AgencyID,
		 dbo.T00050002.AGNCode, dbo.T00050002.AGNDesc,
		 (SELECT     TOP 1 dbo.T00050001.CMName + ' ' + dbo.T00050001.CMFamily
                  FROM         dbo.T00050072 INNER JOIN
                  dbo.T00050001 ON dbo.T00050072.F_CustomerID = dbo.T00050001.CMID
                  WHERE     dbo.T00050072.F_ContractId = T00050070.ContractID) AS 'CustomerName'
FROM         dbo.T00050070 INNER JOIN
                      dbo.T00050002 ON dbo.T00050070.F_AgencyID = dbo.T00050002.AGNID INNER JOIN
                      dbo.T00050071 ON dbo.T00050070.ContractID = dbo.T00050071.F_ContractId";
            var query = context.ExecuteQuery<ContractSharedSelectModel>(Sql);
            var Result = query.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.ContractNo + " - " + p.ContractDate + " - " + p.AGNDesc + " - " + p.CustomerName,
                    Value = p.ContractID.ToString(),
                    Selected = false
                });
            Result = Result.Where(p => p.Text.Contains(Name));
            return Result.ToList();
        }
        public List<System.Web.Mvc.SelectListItem> GetContractsById(int ContractID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Sql = @"SELECT DISTINCT    dbo.T00050070.ContractID, dbo.T00050070.ContractNo, dbo.T00050070.ContractDate,dbo.T00050070.F_AgencyID,
		 dbo.T00050002.AGNCode, dbo.T00050002.AGNDesc,
		 (SELECT     TOP 1 dbo.T00050001.CMName + ' ' + dbo.T00050001.CMFamily
                  FROM         dbo.T00050072 INNER JOIN
                  dbo.T00050001 ON dbo.T00050072.F_CustomerID = dbo.T00050001.CMID
                  WHERE     dbo.T00050072.F_ContractId = T00050070.ContractID) AS 'CustomerName'
FROM         dbo.T00050070 INNER JOIN
                      dbo.T00050002 ON dbo.T00050070.F_AgencyID = dbo.T00050002.AGNID ";
            var query = context.ExecuteQuery<ContractSharedSelectModel>(Sql);
            var Result = query.Where(p => p.ContractID == ContractID).Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.ContractNo + " - " + p.ContractDate + " - " + p.AGNDesc + " - " + p.CustomerName,
                    Value = p.ContractID.ToString(),
                    Selected = false
                });
            return Result.ToList();
        }
        public int Insert(ContractSharedModel model)
        {
            string ContractDate = model.ContractShared_Date;
            int F_AgencyID = model.ContractShared_AGNId;
            int ContractPrice = 0;
            int ContractStatus = 827;
            string ShahedName = model.ContractShared_WitnessName;
            string ShahedFName = model.ContractShared_WitnessFatherName;
            string ShahedShNo = model.ContractShared_WitnessSHSH;
            string ShahedAdd = model.ContractShared_WitnessAddress;
            string PhishNo = string.IsNullOrEmpty(model.ContractShared_ReciptNumber) ? "" : model.ContractShared_ReciptNumber;
            string PhishDate = string.IsNullOrEmpty(model.ContractShared_ReciptDate) ? "" : model.ContractShared_ReciptDate;
            decimal PhishMoney = (model.ContractShared_ReciptAmount == null) ? 0 : Convert.ToDecimal(model.ContractShared_ReciptAmount);
            string TransferName = model.ContractShared_SenderName;
            string TransferFName = model.ContractShared_SenderFatherName;
            string TransferShNo = model.ContractShared_SenderSHSH;
            string TransferBirthDate = model.ContractShared_SenderBirthDate;
            string TransferNationalCode = model.ContractShared_SenderNationalCode;
            int F_IssueLocationTransfer = model.ContractShared_SenderBirthPlace;
            string TransferAdd = model.ContractShared_SenderAddress;
            int TransferType = model.ContractShared_SenderType;
            string sql = @"DECLARE		@Out int
                            EXEC	  [sale].[STP_T00050070]
                            @ContractDate = {0},
		                    @F_AgencyID = {1},
		                    @ContractPrice = {2},
		                    @ContractStatus = {3},
		                    @ShahedName = {4},
		                    @ShahedFName = {5},
		                    @ShahedShNo = {6},
		                    @ShahedAdd = {7},
		                    @PhishNo = {8},
		                    @PhishDate ={9}, 
		                    @PhishMoney = {10},
		                    @TransferName = {11},
		                    @TransferFName = {12},
		                    @TransferShNo = {13},
		                    @TransferBirthDate = {14},
		                    @TransferNationalCode = {15},
		                    @F_IssueLocationTransfer = {16},
		                    @TransferAdd = {17},
		                    @TransferType = {18},
                            @Out = @Out OUTPUT
                            SELECT	@Out as N'@Out' ";
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int count = context.ExecuteQuery<int>(sql,
                 ContractDate,
                 F_AgencyID,
                 ContractPrice,
                 ContractStatus,
                 ShahedName,
                 ShahedFName,
                 ShahedShNo,
                 ShahedAdd,
                 PhishNo,
                 PhishDate,
                 PhishMoney,
                 TransferName,
                 TransferFName,
                 TransferShNo,
                 TransferBirthDate,
                 TransferNationalCode,
                 F_IssueLocationTransfer,
                 TransferAdd,
                 TransferType).FirstOrDefault();
            return count;
        }
        public Boolean Update(ContractSharedModel model)
        {
            //                @ContractID INT , 
            //@ContractDate [char] (10)  ,
            //@F_AgencyID [int]  ,
            //@ContractPrice [numeric](18, 0)=0 , 
            //@ShahedName [nvarchar] (50)  ,
            //@ShahedFName [nvarchar] (50)  ,
            //@ShahedShNo [char] (10) ,
            //@ShahedAdd [nvarchar] (500)  ,
            //@PhishNo [char] (10) ,
            //@PhishDate [char] (10)  ,
            //@PhishMoney [numeric](18, 0),
            //@TransferName NVARCHAR(50),
            //@TransferFName NVARCHAR(50),
            //@TransferShNo CHAR(10),
            //@TransferBirthDate CHAR(10),
            //@TransferNationalCode CHAR(12),
            //@F_IssueLocationTransfer INT,
            //@TransferAdd NVARCHAR(500),
            //@TransferType int
            int ContractID = model.ContractShared_Id;
            string ContractDate = model.ContractShared_Date;
            int F_AgencyID = model.ContractShared_AGNId;
            int ContractPrice = 0;
            int ContractStatus = 827;
            string ShahedName = model.ContractShared_WitnessName;
            string ShahedFName = model.ContractShared_WitnessFatherName;
            string ShahedShNo = model.ContractShared_WitnessSHSH;
            string ShahedAdd = model.ContractShared_WitnessAddress;
            string PhishNo = string.IsNullOrEmpty(model.ContractShared_ReciptNumber) ? "" : model.ContractShared_ReciptNumber;
            string PhishDate = string.IsNullOrEmpty(model.ContractShared_ReciptDate) ? "" : model.ContractShared_ReciptDate;
            decimal PhishMoney = (model.ContractShared_ReciptAmount == null) ? 0 : Convert.ToDecimal(model.ContractShared_ReciptAmount);
            string TransferName = model.ContractShared_SenderName;
            string TransferFName = model.ContractShared_SenderFatherName;
            string TransferShNo = model.ContractShared_SenderSHSH;
            string TransferBirthDate = model.ContractShared_SenderBirthDate;
            string TransferNationalCode = model.ContractShared_SenderNationalCode;
            int F_IssueLocationTransfer = model.ContractShared_SenderBirthPlace;
            string TransferAdd = model.ContractShared_SenderAddress;
            int TransferType = model.ContractShared_SenderType;
            string sql = @"EXEC	  [sale].[STP_T00050070];4
                            @ContractID = {0},
                            @ContractDate = {1},
		                    @F_AgencyID = {2},
		                    @ContractPrice = {3}, 
		                    @ShahedName = {4},
		                    @ShahedFName = {5},
		                    @ShahedShNo = {6},
		                    @ShahedAdd = {7},
		                    @PhishNo = {8},
		                    @PhishDate ={9}, 
		                    @PhishMoney = {10},
		                    @TransferName = {11},
		                    @TransferFName = {12},
		                    @TransferShNo = {13},
		                    @TransferBirthDate = {14},
		                    @TransferNationalCode = {15},
		                    @F_IssueLocationTransfer = {16},
		                    @TransferAdd = {17},
		                    @TransferType = {18} ";
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int count = context.ExecuteCommand(sql,
                model.ContractShared_Id,
                 ContractDate,
                 F_AgencyID,
                 ContractPrice,
                 ShahedName,
                 ShahedFName,
                 ShahedShNo,
                 ShahedAdd,
                 PhishNo,
                 PhishDate,
                 PhishMoney,
                 TransferName,
                 TransferFName,
                 TransferShNo,
                 TransferBirthDate,
                 TransferNationalCode,
                 F_IssueLocationTransfer,
                 TransferAdd,
                 TransferType);
            return (count > 0) ? true : false;
        }
        public int InsertCars(int ContractId, int CarId)
        {
            string sql = @"DECLARE		@Out int
                            EXEC	  [sale].[STP_T00050071]
                            @F_ContractId = {0},
		                    @F_CarId = {1},
		                    @F_Status = {2},
                            @Out = @Out OUTPUT
                            SELECT	@Out as N'@Out' ";
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int count = context.ExecuteQuery<int>(sql,
                 ContractId,
                 CarId,
                 827).FirstOrDefault();
            return count;
        }
        public int InsertCustomers(int ContractId, int CustomerID)
        {
            string sql = @" EXEC	  [sale].[STP_T00050072]
                            @F_ContractId = {0},
		                    @F_CustomerID = {1}";
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int count = context.ExecuteQuery<int>(sql,
                 ContractId,
                 CustomerID).FirstOrDefault();
            return count;
        }
        public int InsertLogs(int ContractId, int StatusId, int UserID, string LogDate, string LogTime, string ComputerName)
        {
            string sql = @"  EXEC	  [sale].[STP_T00050073]
                            @F_ContractCarID = {0},
		                    @F_StatusId = {1},
                            @F_UserID = {2},
                            @LogDate = {3},
                            @LogTime = {4},
                            @ComputerName = {5}";
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int count = context.ExecuteCommand(sql,
                 ContractId,
                 StatusId,
                 UserID,
                 LogDate,
                 LogTime,
                 ComputerName);
            return count;
        }
        public Boolean DeleteCars(int ContractId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string sql = @"EXEC	  [sale].[STP_T00050071];5
		                    @F_ContractId = {0} ";
            var returnvalue = context.ExecuteCommand(sql,
                        ContractId);
            if (returnvalue > 0)
                return true;
            else return false;
        }
        public Boolean DeleteCustomers(int ContractId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string sql = @"EXEC	  [sale].[STP_T00050072];3
		                    @F_ContractId = {0} ";
            var returnvalue = context.ExecuteCommand(sql,
                        ContractId);
            if (returnvalue > 0)
                return true;
            else return false;
        }
    }
    public class Contract : Core.CoreRepository<ContractModel>
    {
        DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
        ContractModel _model = new ContractModel();
        Boolean IsEdit;
        public Boolean CheckEditSaleRowPercent()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            DataLayer.commondbDataContext Commoncontext = new DataLayer.commondbDataContext();
            var userID = BAL.StaticData.User.User_UserId;
            string sql = @"execute [dbo].[STP_TAccessUserToRole];9 
                             @SystemID = {0}, 
	                         @UserID = {1},
                             @RoleName = {2}";
            if (userID == 1)
                return true;
            var Result = Commoncontext.ExecuteQuery<BAL.UsersAgent>(sql, 5, userID, "EditSaleRowPercent").ToList();
            if (userID == 254 || userID == 454)
                return false;
            if (Result.Count() == 1)
                return true;
            else
                return false;
        }
        public List<System.Web.Mvc.SelectListItem> GetContractStatus()
        {
            //    select * from T00050099
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = from t in context.T00050099s
                         select new System.Web.Mvc.SelectListItem
                         {
                             Text = t.StatusDesc,
                             Value = t.StatusID.ToString()
                         };
            return Result.ToList();
        }
        public string GetContractSerial(int AgentId, int CarCode, string Year)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            Int64 Id = 0;
            string sql = @"SELECT        ISNULL(MAX(CAST(T00050014.CNTSerial AS BIGINT)), 0) + 1 AS CNTSerial
FROM            T00050014 INNER JOIN
                         T00050015 ON T00050014.CNTID = T00050015.F_CNTID INNER JOIN
                         T00050009 ON T00050015.F_SaleRowID = T00050009.SaleRowID
WHERE        (CAST(T00050014.CNTSerial AS char) LIKE '" + Year + "%') AND (T00050014.F_AgencyID = " + AgentId + ") AND (T00050009.CarCode = " + CarCode + ")";
            Id = context.ExecuteQuery<Int64>(sql).FirstOrDefault();
            return Id.ToString();
        }
        public int Insert(ContractModel model)
        {
            int Id = 0;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string Date = model.Contract_CNTDate;
            int CustomerID = (int)model.Contract_F_CustomerID;
            int AgencyID = (int)model.Contract_F_AgencyID;
            string Serial = model.Contract_CNTSerial;
            int CommissionPercent = (int)model.Contract_CNTCommissionPercent;
            int CntStatus = 1;
            Boolean PublicSale = model.Contract_PublicSale;
            string TahvilDate = model.Contract_TahvilDate;
            int? F_SponsorID = model.Contract_F_SponsorID;
            Boolean SendSms = true;
            string Pleka = string.IsNullOrEmpty(model.Contract_PelakOwner) ? "" : model.Contract_PelakOwner;
            string sql = @"DECLARE		@Out int
                            EXEC	  [sale].[STP_T00050014]
		                    @Date = {0},
		                    @CustomerID = {1},
		                    @AgencyID = {2},
		                    @Serial = {3},
		                    @CommissionPercent = {4},
		                    @CntStatus = {5},
		                    @PublicSale = {6},
		                    @TahvilDate = {7},
		                    @F_SponsorID = {8},
		                    @SendSms = {9},
                            @PelakOwner={10},
		                    @Out = @Out OUTPUT
                            SELECT	@Out as N'@Out' ";
            Id = context.ExecuteQuery<int>(sql,
                             Date,
                             CustomerID,
                             AgencyID,
                             Serial,
                             CommissionPercent,
                             CntStatus,
                             PublicSale,
                             TahvilDate,
                             F_SponsorID,
                             SendSms,
                             Pleka).FirstOrDefault();
            return Id;
        }
        public int Update(ContractModel model)
        {
            int Id = 0;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            string Date = model.Contract_CNTDate;
            int CustomerID = (int)model.Contract_F_CustomerID;
            int AgencyID = (int)model.Contract_F_AgencyID;
            string Serial = model.Contract_CNTSerial;
            int CommissionPercent = (int)model.Contract_CNTCommissionPercent;
            Boolean PublicSale = model.Contract_PublicSale;
            string TahvilDate = model.Contract_TahvilDate;
            int? F_SponsorID = model.Contract_F_SponsorID;
            Boolean SendSms = model.Contract_SendSms;
            string Pleka = string.IsNullOrEmpty(model.Contract_PelakOwner) ? "" : model.Contract_PelakOwner;
            string sql = @" EXEC	  [sale].[STP_T00050014];2 
                            @ID = {0},
		                    @Date = {1},
		                    @CustomerID = {2},
		                    @AgencyID = {3},
		                    @Serial = {4},
		                    @CommissionPercent = {5}, 
		                    @PublicSale = {6},
		                    @TahvilDate = {7},
		                    @F_SponsorID = {8},
		                    @SendSms = {9},
		                    @PelakOwner={10}";
            Id = context.ExecuteQuery<int>(sql,
                             model.Contract_CNTID,
                             Date,
                             CustomerID,
                             AgencyID,
                             Serial,
                             CommissionPercent,
                             PublicSale,
                             TahvilDate,
                             F_SponsorID,
                             SendSms,
                            Pleka).FirstOrDefault();
            return Id;
        }
        private int GetMaxID()
        {
            int ID = 1;
            try
            {
                var query = (from t in
                                 context.T00050014s
                             select t).Max(p => p.CNTID);
                ID = query + 1;
            }
            catch { }
            return ID;
        }
        public Boolean Add(ContractModel model)
        {
            Boolean result = true;
            try
            {
                _model = model;
            }
            catch (Exception ex)
            {
                Framework.Logger.Logger.Log(ex.ToString());
                result = false;
            }
            return result;
        }
        public Boolean Edit(ContractModel model)
        {
            Boolean result = true;
            try
            {
                IsEdit = true;
                _model = model;
            }
            catch (Exception ex)
            {
                Framework.Logger.Logger.Log(ex.ToString());
                result = false;
            }
            return result;
        }
        public Boolean Save()
        {
            Boolean Result = true;
            try
            {
                if (IsEdit)
                {
                    var query = (from t in context.T00050014s
                                 where
                                    t.CNTID == _model.Contract_CNTID
                                 select t).FirstOrDefault();
                    query.CNTCommissionPercent = _model.Contract_CNTCommissionPercent;
                    query.CNTDate = _model.Contract_CNTDate;
                    query.CNTID = _model.Contract_CNTID;
                    query.CNTSerial = _model.Contract_CNTSerial;
                    query.CNTSerialOld = _model.Contract_CNTSerialOld;
                    query.CntStatus = (short?)_model.Contract_CntStatus;
                    query.F_AgencyID = _model.Contract_F_AgencyID;
                    query.F_cntTransfer = _model.Contract_F_cntTransfer;
                    query.F_CustomerID = _model.Contract_F_CustomerID;
                    query.F_ParameterID = _model.Contract_F_ParameterID;
                    query.F_SponsorID = _model.Contract_F_SponsorID;
                    query.FlgOkContract = _model.Contract_FlgOkContract;
                    query.IsOkbyAccounting = (byte?)_model.Contract_IsOkbyAccounting;
                    query.PelakOwner = _model.Contract_PelakOwner;
                    query.PublicSale = _model.Contract_PublicSale;
                    query.RejectionReason = _model.Contract_RejectionReason;
                    query.SendSms = _model.Contract_SendSms;
                    query.Status = _model.Contract_Status;
                    query.TahvilDate = _model.Contract_TahvilDate;
                    query.TrackID = _model.Contract_TrackID;
                    context.SubmitChanges();
                    Result = true;
                }
                else
                {
                    _model.Contract_CNTID = GetMaxID();
                    context.T00050014s.InsertOnSubmit(ConvertToTable(_model));
                    context.SubmitChanges();
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                Result = false;
                Framework.Logger.Logger.Log(ex.ToString());
            }
            return Result;
        }
        public DataLayer.T00050014 ConvertToTable(ContractModel model)
        {
            DataLayer.T00050014 tbl = new DataLayer.T00050014();
            tbl.CNTCommissionPercent = model.Contract_CNTCommissionPercent;
            tbl.CNTDate = model.Contract_CNTDate;
            tbl.CNTID = model.Contract_CNTID;
            tbl.CNTSerial = model.Contract_CNTSerial;
            tbl.CNTSerialOld = model.Contract_CNTSerialOld;
            tbl.CntStatus = (short?)model.Contract_CntStatus;
            tbl.F_AgencyID = model.Contract_F_AgencyID;
            tbl.F_cntTransfer = model.Contract_F_cntTransfer;
            tbl.F_CustomerID = model.Contract_F_CustomerID;
            tbl.F_ParameterID = model.Contract_F_ParameterID;
            tbl.F_SponsorID = model.Contract_F_SponsorID;
            tbl.FlgOkContract = model.Contract_FlgOkContract;
            tbl.IsOkbyAccounting = (byte?)model.Contract_IsOkbyAccounting;
            tbl.PelakOwner = model.Contract_PelakOwner;
            tbl.PublicSale = model.Contract_PublicSale;
            tbl.RejectionReason = model.Contract_RejectionReason;
            tbl.SendSms = model.Contract_SendSms;
            tbl.Status = model.Contract_Status;
            tbl.TahvilDate = model.Contract_TahvilDate;
            tbl.TrackID = model.Contract_TrackID;
            return tbl;
        }
        public ContractModel ConvertToModel(DataLayer.T00050014 tbl)
        {
            ContractModel model = new ContractModel();
            model.Contract_CNTCommissionPercent = tbl.CNTCommissionPercent;
            model.Contract_CNTDate = tbl.CNTDate;
            model.Contract_CNTID = tbl.CNTID;
            model.Contract_CNTSerial = tbl.CNTSerial;
            model.Contract_CNTSerialOld = tbl.CNTSerialOld;
            model.Contract_CntStatus = tbl.CntStatus;
            model.Contract_F_AgencyID = tbl.F_AgencyID;
            model.Contract_F_cntTransfer = tbl.F_cntTransfer;
            model.Contract_F_CustomerID = tbl.F_CustomerID;
            model.Contract_F_ParameterID = tbl.F_ParameterID;
            model.Contract_F_SponsorID = tbl.F_SponsorID;
            model.Contract_FlgOkContract = tbl.FlgOkContract;
            model.Contract_IsOkbyAccounting = tbl.IsOkbyAccounting;
            model.Contract_PelakOwner = tbl.PelakOwner;
            model.Contract_PublicSale = tbl.PublicSale;
            model.Contract_RejectionReason = tbl.RejectionReason;
            model.Contract_SendSms = tbl.SendSms;
            model.Contract_Status = tbl.Status;
            model.Contract_TahvilDate = tbl.TahvilDate;
            model.Contract_TrackID = (int?)tbl.TrackID;
            return model;
        }
        public ContractModel GetByID(int id)
        {
            var query = (from t in context.T00050014s
                         where
                            t.CNTID == id
                         select t).FirstOrDefault();
            return ConvertToModel(query);
        }
        public ContractModel GetByIDCustomer(int id)
        {
            var query = (from t in context.T00050014s
                         where
                            t.F_CustomerID == id
                         select t).FirstOrDefault();
            return ConvertToModel(query);
        }
        public Boolean Delete(int id)
        {
            Boolean Result = false;
            try
            {
                string sql = @"EXEC	  [sale].[STP_T00050014];22
		                    @CNTID = {0} ";
                var returnvalue = context.ExecuteCommand(sql,
                            id);
                if (returnvalue > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                Framework.Logger.Logger.Log(ex.ToString());
                Result = false;
            }
            return Result;
        }
        public IQueryable<ContractModel> GetAll()
        {
            var query = from t in context.T00050014s
                        select new ContractModel
                        {
                            Contract_CNTCommissionPercent = t.CNTCommissionPercent,
                            Contract_CNTDate = t.CNTDate,
                            Contract_CNTID = t.CNTID,
                            Contract_CNTSerial = t.CNTSerial,
                            Contract_CNTSerialOld = t.CNTSerialOld,
                            Contract_CntStatus = t.CntStatus,
                            Contract_F_AgencyID = t.F_AgencyID,
                            Contract_F_cntTransfer = t.F_cntTransfer,
                            Contract_F_CustomerID = t.F_CustomerID,
                            Contract_F_ParameterID = t.F_ParameterID,
                            Contract_F_SponsorID = t.F_SponsorID,
                            Contract_FlgOkContract = t.FlgOkContract,
                            Contract_IsOkbyAccounting = t.IsOkbyAccounting,
                            Contract_PelakOwner = t.PelakOwner,
                            Contract_PublicSale = t.PublicSale,
                            Contract_RejectionReason = t.RejectionReason,
                            Contract_SendSms = t.SendSms,
                            Contract_Status = t.Status,
                            Contract_TahvilDate = t.TahvilDate,
                            Contract_TrackID = (int?)t.TrackID,
                        };
            return query;
        }
        public List<ContractModel> GetAllList()
        {
            var query = from t in context.T00050014s
                        select new ContractModel
                        {
                            Contract_CNTCommissionPercent = t.CNTCommissionPercent,
                            Contract_CNTDate = t.CNTDate,
                            Contract_CNTID = t.CNTID,
                            Contract_CNTSerial = t.CNTSerial,
                            Contract_CNTSerialOld = t.CNTSerialOld,
                            Contract_CntStatus = t.CntStatus,
                            Contract_F_AgencyID = t.F_AgencyID,
                            Contract_F_cntTransfer = t.F_cntTransfer,
                            Contract_F_CustomerID = t.F_CustomerID,
                            Contract_F_ParameterID = t.F_ParameterID,
                            Contract_F_SponsorID = t.F_SponsorID,
                            Contract_FlgOkContract = t.FlgOkContract,
                            Contract_IsOkbyAccounting = t.IsOkbyAccounting,
                            Contract_PelakOwner = t.PelakOwner,
                            Contract_PublicSale = t.PublicSale,
                            Contract_RejectionReason = t.RejectionReason,
                            Contract_SendSms = t.SendSms,
                            Contract_Status = t.Status,
                            Contract_TahvilDate = t.TahvilDate,
                            Contract_TrackID = (int?)t.TrackID,
                        };
            return query.ToList();
        }
        public void Dispose()
        {
        }
        public List<ContractViewModel> GetAllContractListAll()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<ContractViewModel>("select  *  FROM viwT00050014").ToList();
            if (BAL.StaticData.IsAgent)
            {
                var AgentCode = BAL.StaticData.AgentCode;
                data = data.Where(p => p.F_AgencyID == AgentCode).ToList();
            }
            return data;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllContractListCombo()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<ContractViewModel>("select * FROM viwT00050014 order by CNTID").ToList();
            if (BAL.StaticData.IsAgent)
            {
                var AgentCode = BAL.StaticData.AgentCode;
                data = data.Where(p => p.F_AgencyID == AgentCode).ToList();
            }
            var Result = data.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.CNTID + " - " + p.AgencyDesc + "-" + p.CustomerName + "-" + p.CNTDate + "-" + p.CNTSerial,
                    Value = p.CNTID.ToString()
                }).ToList();
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllContractListCombo(int CustomerID, int id)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<ContractViewModel>("select * FROM viwT00050014 order by CNTID").ToList();
            data = data.Where(p => p.F_CustomerID == CustomerID).ToList();
            if (BAL.StaticData.IsAgent)
            {
                var AgentCode = BAL.StaticData.AgentCode;
                data = data.Where(p => p.F_AgencyID == AgentCode).ToList();
            }
            var Result = data.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.CNTID + " - " + p.AgencyDesc + "-" + p.CustomerName + "-" + p.CNTDate + "-" + p.CNTSerial,
                    Value = p.CNTID.ToString()
                }).ToList();
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllContractListFcatorCombo()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<ContractViewModel>("select * FROM viwT00050014 order by CNTID").ToList();
            if (BAL.StaticData.IsAgent)
            {
                var AgentCode = BAL.StaticData.AgentCode;
                data = data.Where(p => p.F_AgencyID == AgentCode).ToList();
            }
            var Result = data.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.CNTID + " - " + p.AgencyDesc + "-" + p.CustomerName + "-" + p.CNTDate + "-" + p.CNTSerial,
                    Value = p.CNTID.ToString()
                }).ToList();
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllContractListCombo(int CNTID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<ContractViewModel>("select  *  FROM viwT00050014 where CNTID=" + CNTID).ToList();
            var Result = data.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.AgencyDesc + "," + p.CustomerName + "," + p.CNTDate,
                    Value = p.CNTID.ToString()
                }).ToList();
            return Result;
        }
        public List<System.Web.Mvc.SelectListItem> GetAllContractByCustomerIDListCombo(int CustomerId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var data = context.ExecuteQuery<ContractViewModel>("select  *  FROM viwT00050014 where F_CustomerID=" + CustomerId).ToList();
            var Result = data.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Text = p.AgencyDesc + "," + p.CustomerName + "," + p.CNTDate + "," + p.CNTID,
                    Value = p.CNTID.ToString()
                }).ToList();
            return Result;
        }
        public List<ContractViewModel> GetAllContractList()
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<ContractViewModel>(@"SELECT        T00050014.CNTID, T00050014.CNTDate, T00050014.F_CustomerID, T00050001.CMName + ' ' + T00050001.CMFamily AS CustomerName, T00050014.F_AgencyID, T00050002.AGNDesc, T00050014.CNTSerial, 
                         T00050014.CNTCommissionPercent, T00050014.CntStatus, T00050009.SaleRowDesc
FROM            T00050014 INNER JOIN
                         T00050015 ON T00050014.CNTID = T00050015.F_CNTID INNER JOIN
                         T00050009 ON T00050015.F_SaleRowID = T00050009.SaleRowID INNER JOIN
                         T00050001 ON T00050014.F_CustomerID = T00050001.CMID INNER JOIN
                         T00050002 ON T00050014.F_AgencyID = T00050002.AGNID ").ToList();
            if (BAL.StaticData.IsAgent)
            {
                var AgentCode = BAL.StaticData.AgentCode;
                Result = Result.Where(p => p.F_AgencyID == AgentCode).ToList();
            }
            return Result;
        }
        public List<ContractViewModel> GetAllContractList(int CNTID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<ContractViewModel>("select  *  FROM viwT00050014 where CNTID=" + CNTID).ToList();
            return Result;
        }
    }
    public class ContractDetail : Core.CoreRepository<ContractDetailModel>
    {
        DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
        ContractDetailModel _model = new ContractDetailModel();
        Boolean IsEdit;
        public int Insert(ContractDetailModel model)
        {
            int Id = 0;
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int ContractID = model.ContractDetail_F_CNTID;
            int SaleRowID = model.ContractDetail_F_SaleRowID;
            int DeliveryAddressID = (int)model.ContractDetail_F_DeliveryAddressID;
            int ColorID = (int)model.ContractDetail_F_ColorID;
            int DecorationID = (int)model.ContractDetail_F_DecorationID;
            int Quantity = (int)model.ContractDetail_CNTQuantity;
            int AssignAble = (model.ContractDetail_AssignAble == null) ? 0 : (int)model.ContractDetail_AssignAble;
            int FactorBy = (model.ContractDetail_FactorBy == null) ? 0 : (int)model.ContractDetail_FactorBy;
            int DocumentBy = (model.ContractDetail_DocumentBy == null) ? 0 : (int)model.ContractDetail_DocumentBy;
            int Mosharekat = (model.ContractDetail_Mosharekat == null) ? 0 : (int)model.ContractDetail_Mosharekat;
            int ShomarehGozari = (model.ContractDetail_ShomarehGozari == null) ? 0 : (int)model.ContractDetail_ShomarehGozari;
            float tax = (model.ContractDetail_Tax == null) ? 0 : (int)model.ContractDetail_Tax;
            Boolean SayerHazSh = (model.ContractDetail_SayerHazSh == null) ? false : (Boolean)model.ContractDetail_SayerHazSh;
            int F_EsghatyID = (model.ContractDetail_F_EsghatyID == null) ? 0 : (int)model.ContractDetail_F_EsghatyID;
            int HavaleBy = (model.ContractDetail_HavaleBy == null) ? 0 : (int)model.ContractDetail_HavaleBy;
            decimal CNTPercent = (model.ContractDetail_CNTPercent == null) ? 0 : (int)model.ContractDetail_CNTPercent;
            string PreTaf = "";
            string Year = "";
            string NewCode = "";
            float taxForIncrease = (model.ContractDetail_taxForIncrease == null) ? 0 : (int)model.ContractDetail_taxForIncrease;
            int F_UsageType = (model.ContractDetail_F_UsageType == null) ? 0 : (int)model.ContractDetail_F_UsageType;
            string sql = @"DECLARE		@Out int
                            EXEC	  [sale].[STP_T00050015]
	                        @ContractID ={0},
	                        @SaleRowID ={1},
	                        @DeliveryAddressID= {2},
	                        @ColorID ={3},
	                        @DecorationID ={4},
	                        @Quantity ={5},
	                        @AssignAble=	{6},
	                        @FactorBy	={7},
	                        @DocumentBy=	{8},
                            @Mosharekat  ={9},
                            @ShomarehGozari ={10}, 
	                        @tax ={11}, 
	                        @SayerHazSh ={12},
	                        @F_EsghatyID	={13},
	                        @HavaleBy ={14},
	                        @CNTPercent= {15},
	                        @PreTaf ={16},
	                        @Year ={17},
	                        @NewCode ={18}, 
	                        @taxForIncrease ={19},
	                        @F_UsageType ={20},
	                        @Out = @Out OUTPUT 
                            SELECT	@Out as N'@Out'";
            Id = context.ExecuteQuery<int>(sql,
                           ContractID,
                           SaleRowID,
                           DeliveryAddressID,
                           ColorID,
                           DecorationID,
                           Quantity,
                           AssignAble,
                           FactorBy,
                           DocumentBy,
                           Mosharekat,
                           ShomarehGozari,
                           tax,
                           SayerHazSh,
                           F_EsghatyID,
                           HavaleBy,
                           CNTPercent,
                           PreTaf,
                           Year,
                           NewCode,
                           taxForIncrease,
                           F_UsageType).FirstOrDefault();
            return Id;
        }
        public int Update(ContractDetailModel model)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            int ID = model.ContractDetail_CNTRowID;
            int ContractID = model.ContractDetail_F_CNTID;
            int SaleRowID = model.ContractDetail_F_SaleRowID;
            int DeliveryAddressID = (int)model.ContractDetail_F_DeliveryAddressID;
            int ColorID = (int)model.ContractDetail_F_ColorID;
            int DecorationID = (int)model.ContractDetail_F_DecorationID;
            int Quantity = (int)model.ContractDetail_CNTQuantity;
            int AssignAble = (model.ContractDetail_AssignAble == null) ? 0 : (int)model.ContractDetail_AssignAble;
            int FactorBy = (model.ContractDetail_FactorBy == null) ? 0 : (int)model.ContractDetail_FactorBy;
            int DocumentBy = (model.ContractDetail_DocumentBy == null) ? 0 : (int)model.ContractDetail_DocumentBy;
            int Mosharekat = (model.ContractDetail_Mosharekat == null) ? 0 : (int)model.ContractDetail_Mosharekat;
            int ShomarehGozari = (model.ContractDetail_ShomarehGozari == null) ? 0 : (int)model.ContractDetail_ShomarehGozari;
            float tax = (model.ContractDetail_Tax == null) ? 0 : (int)model.ContractDetail_Tax;
            Boolean SayerHazSh = (model.ContractDetail_SayerHazSh == null) ? false : (Boolean)model.ContractDetail_SayerHazSh;
            int F_EsghatyID = (model.ContractDetail_F_EsghatyID == null) ? 0 : (int)model.ContractDetail_F_EsghatyID;
            int HavaleBy = (model.ContractDetail_HavaleBy == null) ? 0 : (int)model.ContractDetail_HavaleBy;
            decimal CNTPercent = (model.ContractDetail_CNTPercent == null) ? 0 : (int)model.ContractDetail_CNTPercent;
            string PreTaf = "";
            string Year = "";
            string NewCode = "";
            string taf = "";
            float taxForIncrease = (model.ContractDetail_taxForIncrease == null) ? 0 : (int)model.ContractDetail_taxForIncrease;
            int F_UsageType = (model.ContractDetail_F_UsageType == null) ? 0 : (int)model.ContractDetail_F_UsageType;
            string sql = @"
EXEC	  [sale].[STP_T00050015];2
		@ID ={0},
	@SaleRowID ={1},
	@DeliveryAddressID= {2},
	@ColorID ={3},
	@DecorationID ={4},
	@Quantity ={5},
	@AssignAble=	{6},
	@FactorBy	={7},
	@DocumentBy=	{8},
       	@Mosharekat  ={9},
       	@ShomarehGozari ={10}, 
	@tax ={11}, 
	@SayerHazSh ={12},
	@F_EsghatyID	={13},
	@HavaleBy ={14},
	@CNTPercent= {15},
	@Taf={16}, 
	@F_UsageType ={17} ";
            var Rows = context.ExecuteCommand(sql,
                            ID,
                            SaleRowID,
                            DeliveryAddressID,
                            ColorID,
                            DecorationID,
                            Quantity,
                            AssignAble,
                            FactorBy,
                            DocumentBy,
                            Mosharekat,
                            ShomarehGozari,
                            tax,
                            SayerHazSh,
                            F_EsghatyID,
                            HavaleBy,
                            CNTPercent,
                            taf,
                            F_UsageType);
            return Rows;
        }
        private int GetMaxID()
        {
            int ID = 1;
            try
            {
                var query = (from t in
                                 context.T00050015s
                             select t).Max(p => p.CNTRowID);
                ID = query + 1;
            }
            catch { }
            return ID;
        }
        public Boolean Add(ContractDetailModel model)
        {
            Boolean result = true;
            try
            {
                _model = model;
            }
            catch (Exception ex)
            {
                Framework.Logger.Logger.Log(ex.ToString());
                result = false;
            }
            return result;
        }
        public Boolean Edit(ContractDetailModel model)
        {
            Boolean result = true;
            try
            {
                IsEdit = true;
                _model = model;
            }
            catch (Exception ex)
            {
                Framework.Logger.Logger.Log(ex.ToString());
                result = false;
            }
            return result;
        }
        public Boolean Save()
        {
            Boolean Result = true;
            try
            {
                if (IsEdit)
                {
                    var query = (from t in context.T00050015s
                                 where
                                    t.CNTRowID == _model.ContractDetail_CNTRowID
                                 select t).FirstOrDefault();
                    query.AssignAble = (byte?)_model.ContractDetail_AssignAble;
                    query.CNTPercent = _model.ContractDetail_CNTPercent;
                    query.CNTQuantity = _model.ContractDetail_CNTQuantity;
                    query.CNTRowID = _model.ContractDetail_CNTRowID;
                    query.CntRowNo = (byte?)_model.ContractDetail_CntRowNo;
                    query.CNTRowStatus = _model.ContractDetail_CNTRowStatus;
                    query.DocumentBy = (byte?)_model.ContractDetail_DocumentBy;
                    query.F_CNTID = _model.ContractDetail_F_CNTID;
                    query.F_ColorID = _model.ContractDetail_F_ColorID;
                    query.F_DecorationID = _model.ContractDetail_F_DecorationID;
                    query.F_DeliveryAddressID = _model.ContractDetail_F_DeliveryAddressID;
                    query.F_EsghatyID = _model.ContractDetail_F_EsghatyID;
                    query.F_SaleRowID = _model.ContractDetail_F_SaleRowID;
                    query.F_UsageType = _model.ContractDetail_F_UsageType;
                    query.FactorBy = (byte?)_model.ContractDetail_FactorBy;
                    query.FlgAssignCar = _model.ContractDetail_FlgAssignCar;
                    query.FlgOkLizing = _model.ContractDetail_FlgOkLizing;
                    query.HavaleBy = (byte?)_model.ContractDetail_HavaleBy;
                    query.InsOfStatus = (short?)_model.ContractDetail_InsOfStatus;
                    query.Mosharekat = (byte?)_model.ContractDetail_Mosharekat;
                    query.ReaseonLizing = _model.ContractDetail_ReaseonLizing;
                    query.SayerHazSh = _model.ContractDetail_SayerHazSh;
                    query.ShomarehGozari = _model.ContractDetail_ShomarehGozari;
                    query.Tafcnt = _model.ContractDetail_Tafcnt;
                    query.Tax = _model.ContractDetail_Tax;
                    query.taxForIncrease = _model.ContractDetail_taxForIncrease;
                    context.SubmitChanges();
                    Result = true;
                }
                else
                {
                    _model.ContractDetail_CNTRowID = GetMaxID();
                    context.T00050015s.InsertOnSubmit(ConvertToTable(_model));
                    context.SubmitChanges();
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                Result = false;
                Framework.Logger.Logger.Log(ex.ToString());
            }
            return Result;
        }
        public DataLayer.T00050015 ConvertToTable(ContractDetailModel model)
        {
            DataLayer.T00050015 tbl = new DataLayer.T00050015();
            tbl.AssignAble = (byte?)model.ContractDetail_AssignAble;
            tbl.CNTPercent = model.ContractDetail_CNTPercent;
            tbl.CNTQuantity = model.ContractDetail_CNTQuantity;
            tbl.CNTRowID = model.ContractDetail_CNTRowID;
            tbl.CntRowNo = (byte?)model.ContractDetail_CntRowNo;
            tbl.CNTRowStatus = model.ContractDetail_CNTRowStatus;
            tbl.DocumentBy = (byte?)model.ContractDetail_DocumentBy;
            tbl.F_CNTID = model.ContractDetail_F_CNTID;
            tbl.F_ColorID = model.ContractDetail_F_ColorID;
            tbl.F_DecorationID = model.ContractDetail_F_DecorationID;
            tbl.F_DeliveryAddressID = model.ContractDetail_F_DeliveryAddressID;
            tbl.F_EsghatyID = model.ContractDetail_F_EsghatyID;
            tbl.F_SaleRowID = model.ContractDetail_F_SaleRowID;
            tbl.F_UsageType = model.ContractDetail_F_UsageType;
            tbl.FactorBy = (byte?)model.ContractDetail_FactorBy;
            tbl.FlgAssignCar = model.ContractDetail_FlgAssignCar;
            tbl.FlgOkLizing = model.ContractDetail_FlgOkLizing;
            tbl.HavaleBy = (byte?)model.ContractDetail_HavaleBy;
            tbl.InsOfStatus = (short?)model.ContractDetail_InsOfStatus;
            tbl.Mosharekat = (byte?)model.ContractDetail_Mosharekat;
            tbl.ReaseonLizing = model.ContractDetail_ReaseonLizing;
            tbl.SayerHazSh = model.ContractDetail_SayerHazSh;
            tbl.ShomarehGozari = model.ContractDetail_ShomarehGozari;
            tbl.Tafcnt = model.ContractDetail_Tafcnt;
            tbl.Tax = model.ContractDetail_Tax;
            tbl.taxForIncrease = model.ContractDetail_taxForIncrease;
            return tbl;
        }
        public ContractDetailModel ConvertToModel(DataLayer.T00050015 tbl)
        {
            ContractDetailModel model = new ContractDetailModel();
            model.ContractDetail_AssignAble = tbl.AssignAble;
            model.ContractDetail_CNTPercent = (int?)tbl.CNTPercent;
            model.ContractDetail_CNTQuantity = tbl.CNTQuantity;
            model.ContractDetail_CNTRowID = tbl.CNTRowID;
            model.ContractDetail_CntRowNo = tbl.CntRowNo;
            model.ContractDetail_CNTRowStatus = tbl.CNTRowStatus;
            model.ContractDetail_DocumentBy = tbl.DocumentBy;
            model.ContractDetail_F_CNTID = tbl.F_CNTID;
            model.ContractDetail_F_ColorID = tbl.F_ColorID;
            model.ContractDetail_F_DecorationID = tbl.F_DecorationID;
            model.ContractDetail_F_DeliveryAddressID = tbl.F_DeliveryAddressID;
            model.ContractDetail_F_EsghatyID = tbl.F_EsghatyID;
            model.ContractDetail_F_SaleRowID = tbl.F_SaleRowID;
            model.ContractDetail_F_UsageType = tbl.F_UsageType;
            model.ContractDetail_FactorBy = tbl.FactorBy;
            model.ContractDetail_FlgAssignCar = tbl.FlgAssignCar;
            model.ContractDetail_FlgOkLizing = tbl.FlgOkLizing;
            model.ContractDetail_HavaleBy = tbl.HavaleBy;
            model.ContractDetail_InsOfStatus = tbl.InsOfStatus;
            model.ContractDetail_Mosharekat = tbl.Mosharekat;
            model.ContractDetail_ReaseonLizing = tbl.ReaseonLizing;
            model.ContractDetail_SayerHazSh = tbl.SayerHazSh;
            model.ContractDetail_ShomarehGozari = tbl.ShomarehGozari;
            model.ContractDetail_Tafcnt = tbl.Tafcnt;
            model.ContractDetail_Tax = tbl.Tax;
            model.ContractDetail_taxForIncrease = tbl.taxForIncrease;
            return model;
        }
        public ContractDetailModel GetByID(int id)
        {
            var query = (from t in context.T00050015s
                         where
                            t.CNTRowID == id
                         select t).FirstOrDefault();
            return ConvertToModel(query);
        }
        public Boolean Delete(int id)
        {
            Boolean Result = false;
            try
            {
                var query = (from t in context.T00050015s
                             where
                               t.CNTRowID == id
                             select t).FirstOrDefault();
                context.T00050015s.DeleteOnSubmit(query);
                context.SubmitChanges();
                Result = true;
            }
            catch (Exception ex)
            {
                Framework.Logger.Logger.Log(ex.ToString());
                Result = false;
            }
            return Result;
        }
        public IQueryable<ContractDetailModel> GetAll()
        {
            var query = from t in context.T00050015s
                        select new ContractDetailModel
                        {
                            ContractDetail_AssignAble = t.AssignAble,
                            ContractDetail_CNTPercent = (int?)t.CNTPercent,
                            ContractDetail_CNTQuantity = t.CNTQuantity,
                            ContractDetail_CNTRowID = t.CNTRowID,
                            ContractDetail_CntRowNo = t.CntRowNo,
                            ContractDetail_CNTRowStatus = t.CNTRowStatus,
                            ContractDetail_DocumentBy = t.DocumentBy,
                            ContractDetail_F_CNTID = t.F_CNTID,
                            ContractDetail_F_ColorID = t.F_ColorID,
                            ContractDetail_F_DecorationID = t.F_DecorationID,
                            ContractDetail_F_DeliveryAddressID = t.F_DeliveryAddressID,
                            ContractDetail_F_EsghatyID = t.F_EsghatyID,
                            ContractDetail_F_SaleRowID = t.F_SaleRowID,
                            ContractDetail_F_UsageType = t.F_UsageType,
                            ContractDetail_FactorBy = t.FactorBy,
                            ContractDetail_FlgAssignCar = t.FlgAssignCar,
                            ContractDetail_FlgOkLizing = t.FlgOkLizing,
                            ContractDetail_HavaleBy = t.HavaleBy,
                            ContractDetail_InsOfStatus = t.InsOfStatus,
                            ContractDetail_Mosharekat = t.Mosharekat,
                            ContractDetail_ReaseonLizing = t.ReaseonLizing,
                            ContractDetail_SayerHazSh = t.SayerHazSh,
                            ContractDetail_ShomarehGozari = t.ShomarehGozari,
                            ContractDetail_Tafcnt = t.Tafcnt,
                            ContractDetail_Tax = t.Tax,
                            ContractDetail_taxForIncrease = t.taxForIncrease,
                        };
            return query;
        }
        public List<ContractDetailModel> GetAllList()
        {
            var query = from t in context.T00050015s
                        select new ContractDetailModel
                        {
                            ContractDetail_AssignAble = t.AssignAble,
                            ContractDetail_CNTPercent = (int?)t.CNTPercent,
                            ContractDetail_CNTQuantity = t.CNTQuantity,
                            ContractDetail_CNTRowID = t.CNTRowID,
                            ContractDetail_CntRowNo = t.CntRowNo,
                            ContractDetail_CNTRowStatus = t.CNTRowStatus,
                            ContractDetail_DocumentBy = t.DocumentBy,
                            ContractDetail_F_CNTID = t.F_CNTID,
                            ContractDetail_F_ColorID = t.F_ColorID,
                            ContractDetail_F_DecorationID = t.F_DecorationID,
                            ContractDetail_F_DeliveryAddressID = t.F_DeliveryAddressID,
                            ContractDetail_F_EsghatyID = t.F_EsghatyID,
                            ContractDetail_F_SaleRowID = t.F_SaleRowID,
                            ContractDetail_F_UsageType = t.F_UsageType,
                            ContractDetail_FactorBy = t.FactorBy,
                            ContractDetail_FlgAssignCar = t.FlgAssignCar,
                            ContractDetail_FlgOkLizing = t.FlgOkLizing,
                            ContractDetail_HavaleBy = t.HavaleBy,
                            ContractDetail_InsOfStatus = t.InsOfStatus,
                            ContractDetail_Mosharekat = t.Mosharekat,
                            ContractDetail_ReaseonLizing = t.ReaseonLizing,
                            ContractDetail_SayerHazSh = t.SayerHazSh,
                            ContractDetail_ShomarehGozari = t.ShomarehGozari,
                            ContractDetail_Tafcnt = t.Tafcnt,
                            ContractDetail_Tax = t.Tax,
                            ContractDetail_taxForIncrease = t.taxForIncrease,
                        };
            return query.ToList();
        }
        public List<ContractDetailViewModel> GetContractDetailByContractId(int ContractId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<ContractDetailViewModel>("execute  sale.STP_T00050015;4 " + ContractId);
            return Result.ToList();
        }
        public List<System.Web.Mvc.SelectListItem> GetContractDetailByContractIdCombo(int ContractId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Master = (from t in context.T00050014s
                          join agent in context.T00050002s
                          on t.F_AgencyID equals agent.AGNID
                          where t.CNTID == ContractId
                          select agent).FirstOrDefault();
            var data = context.ExecuteQuery<ContractDetailViewModel>("execute  sale.STP_T00050015;4 " + ContractId);
            var Result = data.Select(p =>
                new System.Web.Mvc.SelectListItem
                {
                    Value = p.CNTRowID.ToString(),
                    Text = "پیش فروش : " + p.SaleRowDesc + "- نمایندگی : " + Master.AGNDesc + "- رنگ : " + p.Color + "-تودوزی  : " + p.Decoration
                }
                );
            return Result.ToList();
        }
        public List<Sell.Report.ContractFlowViewModel> GetContractFlow(int FromContractID, int ToContractID, string FromDate, string ToDate, int CustomerCode)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Master = context.ExecuteQuery<Sell.Report.ContractFlowMasterViewModel>("execute  sale.STP_T00050014;10 '" + ((FromContractID == 0) ? "" : FromContractID.ToString()) + "','" + ((FromContractID == 0) ? "" : FromContractID.ToString()) + "'," + FromDate + "," + ToDate + "," + CustomerCode);
            var Detail = context.ExecuteQuery<Sell.Report.ContractFlowDetailViewModel>("execute  sale.STP_T00050014;11 '" + ((FromContractID == 0) ? "" : FromContractID.ToString()) + "','" + ((FromContractID == 0) ? "" : FromContractID.ToString()) + "'," + FromDate + "," + ToDate + "," + CustomerCode);
            var Result = from m in Master
                         join d in Detail
                         on m.CNTID equals d.F_CNTID
                         select new Sell.Report.ContractFlowViewModel
                         {
                             AgencyDesc = m.AgencyDesc,
                             CNTCommissionPercent = m.CNTCommissionPercent,
                             CNTDate = m.CNTDate,
                             CNTID = m.CNTID,
                             CNTSerial = m.CNTSerial,
                             CntStatus = m.CntStatus,
                             Computer = d.Computer,
                             CustomerCode = m.CustomerCode,
                             CustomerDesc = m.CustomerDesc,
                             D_StatusDesc = d.StatusDesc,
                             F_AgencyID = m.F_AgencyID,
                             F_CNTID = d.F_CNTID,
                             F_CustomerID = m.F_CustomerID,
                             F_StatusID = d.F_StatusID,
                             F_UserID = d.F_UserID,
                             Status_Date = d.Status_Date,
                             Status_Time = d.Status_Time,
                             StatusDesc = m.StatusDesc,
                             UserDesc = d.UserDesc
                         };
            return Result.ToList();
        }
        public List<ColorPriority> GetColorPriority(int SalesRowId, int ContractId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var model = context.ExecuteQuery<ColorPriority>("execute  sale.STP_T00050055;5 " + SalesRowId + "," + ContractId).ToList();
            return model;
        }
        public void Dispose()
        {
        }
    }
    public class Report
    {
        public List<Sell.Report.ContractSearchViewModel> GetContractSearch(int se_Agancy, string se_ConNOFrom, string se_FactorDateTo, string se_DocNoFrom, string se_FormNoFrom, string se_pastFormNoFrom, string se_FactorNo, string se_LastConStatue, string se_ConNOTo, string se_DocNoTo, string se_FormNoTo, string se_pastFormNoTo, string se_Customer, string se_Tuduzi, string se_CarGroup, string se_CarType, string se_SaleType, string se_SaleRow, string se_Color, string se_ConDateFrom, string se_DocDateFrom, string se_PaymentDateFrom, string se_FactorDateFrom, string se_ConDateTo, string se_DocDateTo, string se_PaymentDateTo, string se_ConStatus, string se_ConRawStatus, string se_FactorStatus, string se_greementstatus, string se_ConType, string se_FactorType, string se_PaymentView)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            //var Result = context.ExecuteQuery<Sell.Report.ContractSearchViewModel>("execute  sale.STP_T00050014;25 " + se_DocNoFrom + "," + se_DocNoTo + "," + se_SaleType + "," + se_Agancy + "," + se_Customer + ",'" + se_ConDateFrom + "','" + se_ConDateTo + "','" + se_FormNoFrom + "','" + se_FormNoTo + "'," + se_SaleRow + "," + se_Color + "," + se_Tuduzi + "," + se_LastConStatue + "," + se_ConStatus + ",'" + se_SaleType + "'," + se_CarGroup + "," + se_CarType + "," + se_FactorStatus + ",0,'','','','',0,0,0,0,'','','','',0,0");
            //  @ID int
            //,	@ID2  int
            //, @PublicSale  tinyint
            //,	@AgencyID int
            //,	@CustomerID int
            //,	@FromDate char(10)
            //,	@ToDate char(10)
            //,	@FromSerial varchar(10)
            //,	@ToSerial varchar(10)
            //,	@SaleRowID int
            //,	@ColorID int
            //,	@DecorationID int
            //,	@LastStatus smallint
            //,	@Status smallint
            //,	@F_SaleType varchar (5)
            //,	@CarGroup int 
            //,	@F_CarID int
            //,	@FactNo int=0 
            //,	@SanadNoFrom int=0 ?
            //,	@FromDate1 char(10)=''
            //,	@ToDate1 char(10)=''
            //,	@FromDate2 char(10)=''
            //,	@ToDate2 char(10)=''
            //,	@Facstatus smallint  
            //,	@FactReject smallint  ?
            //,	@ShowDetaliMoney smallint ?
            //,	@SanadNoTo int=0 ?
            //, @CrDateFrom char(10)=''
            //, @CrDateTo char(10)=''
            //,	@FromSerialOld varchar(10)
            //,	@ToSerialOld varchar(10)
            //,	@CNTRowStatus smallint-->Enseraf=1,NoEnseraf=2,Esterdadi=3,All=0
            //,	@Solh smallint	 --> @Solh=1,No@Solh=2,All=0
            context.CommandTimeout = 300000;
            var sql = @"execute  sale.STP_T00050014;25 "
                  + se_ConNOFrom + ","
                  + se_ConNOTo + ","
                  + se_ConType + ","
                  + se_Agancy + ","
                  + se_Customer + ",'"
                  + se_ConDateFrom + "','"
                  + se_ConDateTo + "','"
                  + ((se_FormNoFrom == "0") ? "" : se_FormNoFrom) + "','"
                  + ((se_FormNoTo == "0") ? "" : se_FormNoTo) + "',"
                  + se_SaleRow + ","
                  + se_Color + ","
                  + se_Tuduzi + ","
                  + se_LastConStatue + ","
                  + se_ConStatus + ",'"
                  + ((se_SaleType == "0") ? "" : se_SaleType) + "',"
                  + se_CarGroup + ","
                  + se_CarType + ","
                  + se_FactorNo + ","
                  + se_DocNoFrom + ",'"
                  + se_FactorDateFrom + "','"
                  + se_FactorDateTo + "','"
                  + se_DocDateFrom + "','"
                  + se_DocDateTo + "',"
                  + se_FactorStatus + ","
                  + se_FactorType + ","
                  + se_PaymentView + ","
                  + se_DocNoTo + ",'"
                  + se_PaymentDateFrom + "','"
                  + se_PaymentDateTo + "','"
                  + ((se_pastFormNoFrom == "0") ? "" : se_pastFormNoFrom) + "','"
                  + ((se_pastFormNoTo == "0") ? "" : se_pastFormNoTo) + "',"
                  + se_ConRawStatus + ","
                  + se_greementstatus;
            var Result = context.ExecuteQuery<Sell.Report.ContractSearchViewModel>(sql);
            return Result.OrderBy(p => p.CNTID).ToList();
        }
        public List<Sell.Report.CustomerReportViewModel> GetCustomers(string FromCode, string ToCode)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.CustomerReportViewModel>("execute  STP_T00050001;7 " + FromCode + " , " + ToCode);
            return Result.ToList();
        }
        public ContractPrintModel GetContractPrint(int CntId, int CntRowId)
        {
            //        execute sale.stp_t00050015;55 cntId   ContractPrintCustomers 
            //execute sale.stp_t00050005;15 cntId,cntRowId     ContractPrintOptions 
            //execute sale.stp_t00050015; 62 cntRowId, cntId ContractPrintPayment
            var m = GetContractRegister(CntId, CntRowId).FirstOrDefault();
            var model = new ContractPrintModel
            {
                AGNCityIDDesc = m.AGNCityIDDesc,
                AGNCode = m.AGNCode,
                AGNDesc = m.AGNDesc,
                BankIDDesc = m.BankIDDesc,
                CarCode = m.CarCode,
                CarId = m.CarId,
                CarName = m.CarName,
                CMAdrsAlley = m.CMAdrsAlley,
                CMAdrsCityDesc = m.CMAdrsCityDesc,
                CMAdrsNo = m.CMAdrsNo,
                CMAdrsStreet = m.CMAdrsStreet,
                CMBirthDate = m.CMBirthDate,
                CMCityRCodeDesc = m.CMCityRCodeDesc,
                CMCode = m.CMCode,
                CMFamily = m.CMFamily,
                CMFatherName = m.CMFatherName,
                CMIDNo = m.CMIDNo,
                CMIssueDate = m.CMIssueDate,
                CMIssueLocationDesc = m.CMIssueLocationDesc,
                CMJobCodeDesc = m.CMJobCodeDesc,
                CMName = m.CMName,
                CMNationalCode = m.CMNationalCode,
                CMPostCode = m.CMPostCode,
                CMTelCode = m.CMTelCode,
                CMTelPhone = m.CMTelPhone,
                CMType = m.CMType,
                CNTDate = m.CNTDate,
                CNTID = m.CNTID,
                CNTQuantity = m.CNTQuantity,
                CNTRowID = m.CNTRowID,
                CNTSerial = m.CNTSerial,
                Color1 = m.Color1,
                Color2 = m.Color2,
                Color3 = m.Color3,
                CompleteDesMoney = m.CompleteDesMoney,
                DescOstan = m.DescOstan,
                DESCRIPTION = m.DESCRIPTION,
                DocDate = m.DocDate,
                DocNo = m.DocNo,
                F_AGNCityID = m.F_AGNCityID,
                F_BankID = m.F_BankID,
                F_BranchID = m.F_BranchID,
                F_CMAdrsCity = m.F_CMAdrsCity,
                F_CMCityRCode = m.F_CMCityRCode,
                F_CMIssueLocation = m.F_CMIssueLocation,
                F_CMJobCode = m.F_CMJobCode,
                F_CustomerID = m.F_CustomerID,
                F_SaleTypeId = m.F_SaleTypeId,
                F_UsageType = m.F_UsageType,
                MobileNo = m.MobileNo,
                Money = m.Money,
                Moneys = m.Moneys,
                PayAmount = m.PayAmount,
                PelakOwner = m.PelakOwner,
                SaleRowDesc = m.SaleRowDesc,
                SaleRowID = m.SaleRowID,
                TahvilDate = m.TahvilDate,
                TotalFactorPrice = m.TotalFactorPrice,
                UsageType = m.UsageType
            };
            model.Customers = new List<ContractPrintCustomers>();
            model.Options = new List<ContractPrintOptions>();
            model.Payments = new List<ContractPrintPayment>();
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            model.Customers = context.ExecuteQuery<ContractPrintCustomers>("execute sale.stp_t00050015;55 " + CntId).ToList();
            model.Customers.Reverse();
            model.Options = context.ExecuteQuery<ContractPrintOptions>("execute sale.stp_t00050005;15 " + CntId + " , " + CntRowId).ToList();
            model.Payments = context.ExecuteQuery<ContractPrintPayment>("execute sale.stp_t00050015;62 " + CntRowId + " , " + CntId).ToList();
            if (model.CMType == 2)
            {
                model.LName = model.CMName;
                // model.CMName = "";
                //model.CMFamily = "";
                //model.CMNationalCode = "";
                model.ACmidno = model.CMIDNo;
                model.CMIDNo = "";
                model.ATell = model.CMTelPhone;
                model.CMTelPhone = "";
                model.Customers.Clear();
                model.CodeA = "کد افتصادی";
                model.CMTelCode = "";
            }
            else
            {
                model.CodeA = "کد ملی";
            }
            if (model.F_SaleTypeId == 16)
            {
                model.Naghdi = "X";
                model.Etebari = "";
            }
            if (model.F_SaleTypeId != 16)
            {
                model.Etebari = "X";
                model.Naghdi = "";
            }
            if (model.CarId == 3 || model.CarId == 14)
            {
                model.Molahezat = "خودرو تحويلي مدل 92 می باشد";
            }
            //        if {STP_T00050015;32.CarId} =3 or {STP_T00050015;32.CarId}=14 then
            //    "خودرو تحويلي مدل 92 می باشد"
            //else
            //    ""
            if (model.F_SaleTypeId != 16)
            {
                model.Desc19 = "ارائه هرگونه خدمات گارانتي مشروط به عدم بدهي معوقه به شركتهاي ليزينگ خواهد بود";
                model.Desc20 = 20;
            }
            // public string Desc19 { get; set; }
            //        if {STP_T00050015;32.F_SaleTypeId}<>16 then  
            //    ".-20ارائه هرگونه خدمات گارانتي مشروط به عدم بدهي معوقه به شركتهاي ليزينگ خواهد بود "
            //else
            //    ""
            return model;
        }
        public List<Sell.Report.ContractRegisterReportViewModel> GetContractRegister(int ContractId, int ContractRowId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Master = context.ExecuteQuery<Sell.Report.ContractRegisterReportMasterViewModel>("execute sale.STP_T00050015;32   " + ContractId + "," + ContractRowId).ToList();
            var Detail = context.ExecuteQuery<Sell.Report.ContractRegisterReportDetailViewModel>("execute  sale.STP_T00050030;63 " + ContractId).ToList();
            var Result = from m in Master
                         join d in Detail
                         on m.CNTID equals d.F_CntId into dd
                         from det in dd.DefaultIfEmpty()
                         select new Sell.Report.ContractRegisterReportViewModel
                         {
                             AGNCityIDDesc = m.AGNCityIDDesc,
                             AGNCode = m.AGNCode,
                             AGNDesc = m.AGNDesc,
                             BankIDDesc = m.BankIDDesc,
                             CarCode = m.CarCode,
                             CarId = m.CarId,
                             CarName = m.CarName,
                             CMAdrsAlley = m.CMAdrsAlley,
                             CMAdrsCityDesc = m.CMAdrsCityDesc,
                             CMAdrsNo = m.CMAdrsNo,
                             CMAdrsStreet = m.CMAdrsStreet,
                             CMBirthDate = m.CMBirthDate,
                             CMCityRCodeDesc = m.CMCityRCodeDesc,
                             CMCode = m.CMCode,
                             CMFamily = m.CMFamily,
                             CMFatherName = m.CMFatherName,
                             CMIDNo = m.CMIDNo,
                             CMIssueDate = m.CMIssueDate,
                             CMIssueLocationDesc = m.CMIssueLocationDesc,
                             CMJobCodeDesc = m.CMJobCodeDesc,
                             CMName = m.CMName,
                             CMNationalCode = m.CMNationalCode,
                             CMPostCode = m.CMPostCode,
                             CMTelCode = m.CMTelCode,
                             CMTelPhone = m.CMTelPhone,
                             CMType = m.CMType,
                             CNTDate = m.CNTDate,
                             CNTID = m.CNTID,
                             CNTQuantity = m.CNTQuantity,
                             CNTRowID = m.CNTRowID,
                             CNTSerial = m.CNTSerial,
                             Color1 = m.Color1,
                             Color2 = m.Color2,
                             Color3 = m.Color3,
                             CompleteDesMoney = m.CompleteDesMoney,
                             DescOstan = m.DescOstan,
                             DESCRIPTION = m.DESCRIPTION,
                             DocDate = m.DocDate,
                             DocNo = m.DocNo,
                             F_AGNCityID = m.F_AGNCityID,
                             F_BankID = m.F_BankID,
                             F_BranchID = m.F_BranchID,
                             F_CMAdrsCity = m.F_CMAdrsCity,
                             F_CMCityRCode = m.F_CMCityRCode,
                             F_CMIssueLocation = m.F_CMIssueLocation,
                             F_CMJobCode = m.F_CMJobCode,
                             F_CustomerID = m.F_CustomerID,
                             F_SaleTypeId = m.F_SaleTypeId,
                             F_UsageType = m.F_UsageType,
                             MobileNo = m.MobileNo,
                             Money = m.Money,
                             Moneys = (det != null) ? det.Moneys : 0,
                             PayAmount = m.PayAmount,
                             PelakOwner = m.PelakOwner,
                             SaleRowDesc = m.SaleRowDesc,
                             SaleRowID = m.SaleRowID,
                             TahvilDate = m.TahvilDate,
                             TotalFactorPrice = m.TotalFactorPrice,
                             UsageType = m.UsageType
                         };
            return Result.ToList();
        }
        public List<Sell.Report.LendingCarReportViewModel> GetELndingCarsReport(int AGNID, int Code, string FromDate, string ToDate, int F_CarID, int F_color, int F_UsageType)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.LendingCarReportViewModel>("execute  sale.STP_T00050061;10 " + AGNID + "," + ((FromDate == "") ? "'13  /  /  '," : "'" + FromDate + "',") + ((ToDate == "") ? "'13  /  /  '," : "'" + ToDate + "',") + F_CarID + "," + F_color + "," + F_UsageType + "");
            return Result.ToList();
        }
        public List<Sell.Report.AmaniDeliveredReportViewModel> GetAmaniDeliveredReport(int Delivf, int TypeDeliver, string NameDelivF, string FromDate, string ToDate, int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.AmaniDeliveredReportViewModel>("execute  sale.STP_T000500RP;50 " + Delivf + "," + TypeDeliver + ",'" + NameDelivF + "','" + FromDate + "','" + ToDate + "'," + AGNID);
            return Result.ToList();
        }
        public List<Sell.Report.GhateiDeliveredReportViewModel> GetGhateiDeliveredReport(int Delivf, int TypeDeliver, string NameDelivF, string FromDate, string ToDate, int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.GhateiDeliveredReportViewModel>("execute  sale.STP_T000500RP;49 " + Delivf + "," + TypeDeliver + ",'" + NameDelivF + "','" + FromDate + "','" + ToDate + "'," + AGNID);
            return Result.ToList();
        }
        public List<Sell.Report.ViewInsuranceReportViewModel> GetViewInsuranceReport(int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.ViewInsuranceReportViewModel>("execute dbo.STP_T00050010;101 '','','','','','',0,0,1," + AGNID);
            return Result.ToList();
        }
        public List<Sell.Report.CustomerInformationReportViewModel> GetCustomerDetailReport(string CMCode, int F_CntID, int CntRowNo, int AGNID)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Result = context.ExecuteQuery<Sell.Report.CustomerInformationReportViewModel>("execute  sale.STP_T000500RP;19 '" + CMCode + "'," + F_CntID + "," + CntRowNo + "," + AGNID);
            return Result.ToList();
        }
        public List<Sell.Report.SaleInstractReportViewModel> GetSaleInstractReport(int SaleRowID, int CarId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Master = context.ExecuteQuery<Sell.Report.SaleInstractMasterReportViewModel>("execute  sale.STP_T000500RP;40 " + SaleRowID).ToList();
            var Detail = context.ExecuteQuery<Sell.Report.SaleInstractDetailReportViewModel>("execute  sale.STP_T000500RP;41 " + CarId).ToList();
            var Result = from m in Master
                         join d in Detail
                        on m.SaleRowID equals d.CarCode into detail
                         from dd in detail.DefaultIfEmpty()
                         select new Sell.Report.SaleInstractReportViewModel
                         {
                             AxelQty = m.AxelQty,
                             Capacity = m.Capacity,
                             CarCode = (int)m.SaleRowID,
                             CarName = m.CarName,
                             DelFromDate = m.DelFromDate,
                             DelToDate = m.DelToDate,
                             Desc1 = m.Desc1,
                             Discount = m.Discount,
                             DiscountPrcnt = m.DiscountPrcnt,
                             FirstServiceFromKlm = m.FirstServiceFromKlm,
                             FirstServiceToKlm = m.FirstServiceToKlm,
                             FlgStandard = (dd == null) ? 0 : dd.FlgStandard,
                             MaxServiceMon = m.MaxServiceMon,
                             Oil = m.Oil,
                             OptionPrice = (dd == null) ? 0 : dd.OptionPrice,
                             PriceBase = m.PriceBase,
                             pt_desc = (dd == null) ? "" : dd.pt_desc,
                             RejectPrcnt = m.RejectPrcnt,
                             SaleFromDate = m.SaleFromDate,
                             SaleRowDesc = m.SaleRowDesc,
                             SaleRowID = m.SaleRowID,
                             SaleToDate = m.SaleToDate,
                             SilenderQty = m.SilenderQty,
                             System = m.System,
                             TierQty = m.TierQty,
                             Tipe = m.Tipe,
                             Tonage = m.Tonage,
                             Type = m.Type,
                         };
            return Result.ToList();
            //  return null;
        }
        public List<Sell.Report.SaleFlowChartReportViewModel> GetSaleFlowChartReport(string fromCode, string ToCode, string FromDate, string ToDate, int CustomerId)
        {
            DataLayer.AtsTotalNewDataContext context = new DataLayer.AtsTotalNewDataContext();
            var Master = context.ExecuteQuery<Sell.Report.SaleFlowChartMasterReportViewModel>("execute  sale.STP_T00050014;10 '" + fromCode + "','" + ToCode + "','" + FromDate + "','" + ToDate + "'," + CustomerId).ToList();
            var Detail = context.ExecuteQuery<Sell.Report.SaleFlowChartDetailReportViewModel>("execute  sale.STP_T00050014;11 '" + fromCode + "','" + ToCode + "','" + FromDate + "','" + ToDate + "'," + CustomerId).ToList();
            var Result = from m in Master
                         join dd in Detail
                         on m.CNTID equals dd.F_CNTID into det
                         from d in det.DefaultIfEmpty()
                         select new Sell.Report.SaleFlowChartReportViewModel
                         {
                             AgencyDesc = m.AgencyDesc,
                             CNTCommissionPercent = m.CNTCommissionPercent,
                             CNTDate = m.CNTDate,
                             CNTID = m.CNTID,
                             CNTSerial = m.CNTSerial,
                             LastStatusDesc = m.StatusDesc,
                             Computer = (d == null) ? "" : d.Computer,
                             CustomerCode = m.CustomerCode,
                             CntStatus = m.CntStatus,
                             CustomerDesc = m.CustomerDesc,
                             F_AgencyID = m.F_AgencyID,
                             F_CNTID = (d == null) ? 0 : d.F_CNTID,
                             F_CustomerID = (d == null) ? 0 : m.F_CustomerID,
                             F_StatusID = (d == null) ? (short)0 : d.F_StatusID,
                             F_UserID = (d == null) ? 0 : d.F_UserID,
                             StatusDate = (d == null) ? "" : d.StatusDate,
                             StatusDesc = (d == null) ? "" : d.StatusDesc,
                             StatusTime = (d == null) ? "" : d.StatusTime,
                             UserDesc = (d == null) ? "" : d.UserDesc
                         };
            return Result.ToList();
        }
    }
    public class ContractPrintModel
    {
        public List<ContractPrintCustomers> Customers { get; set; }
        public List<ContractPrintOptions> Options { get; set; }
        public List<ContractPrintPayment> Payments { get; set; }
        public string CodeA { get; set; }
        public string Molahezat { get; set; }
        //        if {STP_T00050015;32.CarId} =3 or {STP_T00050015;32.CarId}=14 then
        //    "خودرو تحويلي مدل 92 می باشد"
        //else
        //    ""
        public string Desc19 { get; set; }
        //        if {STP_T00050015;32.F_SaleTypeId}<>16 then  
        //    ".-20ارائه هرگونه خدمات گارانتي مشروط به عدم بدهي معوقه به شركتهاي ليزينگ خواهد بود "
        //else
        //    ""
        public int Desc20 { get; set; }
        public string Naghdi { get; set; }
        public string Etebari { get; set; }
        public string CmNamee { get; set; }
        public string CmFamilyy { get; set; }
        public string LName { get; set; }
        public string ACmidno { get; set; }
        public string ATell { get; set; }
        public decimal Moneys { get; set; }
        public int CNTID { get; set; }
        public string CNTSerial { get; set; }
        public string CNTDate { get; set; }
        public int? CNTRowID { get; set; }
        public int? F_CustomerID { get; set; }
        public string CMCode { get; set; }
        public int? CMType { get; set; }
        public string CMName { get; set; }
        public string CMFamily { get; set; }
        public string CMFatherName { get; set; }
        public string CMIDNo { get; set; }
        public int? F_CMIssueLocation { get; set; }
        public string CMIssueLocationDesc { get; set; }
        public string CMBirthDate { get; set; }
        public string CMIssueDate { get; set; }
        public int? F_CMJobCode { get; set; }
        public string CMJobCodeDesc { get; set; }
        public string CMTelCode { get; set; }
        public string CMTelPhone { get; set; }
        public string MobileNo { get; set; }
        public int? F_CMAdrsCity { get; set; }
        public string DescOstan { get; set; }
        public string CMAdrsCityDesc { get; set; }
        public string CMAdrsStreet { get; set; }
        public string CMAdrsAlley { get; set; }
        public string CMAdrsNo { get; set; }
        public int? F_CMCityRCode { get; set; }
        public string CMCityRCodeDesc { get; set; }
        public string CMNationalCode { get; set; }
        public string CMPostCode { get; set; }
        public int? CarId { get; set; }
        public string CarCode { get; set; }
        public string CarName { get; set; }
        public int? CNTQuantity { get; set; }
        public string TahvilDate { get; set; }
        public int? SaleRowID { get; set; }
        public string AGNDesc { get; set; }
        public string AGNCode { get; set; }
        public int? F_AGNCityID { get; set; }
        public string AGNCityIDDesc { get; set; }
        public string DocNo { get; set; }
        public string DocDate { get; set; }
        public int? F_BankID { get; set; }
        public string BankIDDesc { get; set; }
        public string F_BranchID { get; set; }
        public decimal? Money { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string CompleteDesMoney { get; set; }
        public int? F_UsageType { get; set; }
        public string UsageType { get; set; }
        public decimal? TotalFactorPrice { get; set; }
        public int? F_SaleTypeId { get; set; }
        public decimal? PayAmount { get; set; }
        public string DESCRIPTION { get; set; }
        public string SaleRowDesc { get; set; }
        public string PelakOwner { get; set; }
    }
    public class ContractPrintCustomers
    {
        public int CNTID { get; set; }
        public string CMName { get; set; }
        public string CMFamily { get; set; }
        public string CMFatherName { get; set; }
        public string CMIDNo { get; set; }
        public string CMIssueLocationDesc { get; set; }
        public string CMBirthDate { get; set; }
        public string CMJobCodeDesc { get; set; }
        public double? Sahm { get; set; }
    }
    public class ContractPrintOptions
    {
        //public int? CNTRowOptID { get; set; }
        //public int? F_CNTRowID { get; set; }
        //public int? F_ValidOptionID { get; set; }
        //public string IsAssign { get; set; }
        //public string Flag_TypeOption { get; set; }
        //public string IsFree { get; set; }
        public string pt_desc { get; set; }
        public decimal OptionPrice { get; set; }
    }
    public class ContractPrintPayment
    {
        //public int?  CrID{ get; set; }
        //  public string 	CrCode{ get; set; }
        //  public string 	CrDate{ get; set; }
        //  public string 	F_TypeOfDP	{ get; set; }
        //  public string F_TypeOfDoc{ get; set; }
        public string DocNo { get; set; }
        public string DocDate { get; set; }
        //  public string 	AccountNo{ get; set; }
        //  public string 	F_TypeOfAcc	{ get; set; }
        public decimal Money { get; set; }
        //  public string Description	{ get; set; }
        //  public string RecidORPay	{ get; set; }
        //  public string F_CNTRowID	{ get; set; }
        //  public string Status	{ get; set; }
        //  public string F_Mpardakht	{ get; set; }
        //  public string F_CustVaset{ get; set; }
        //  public string 	F_CntId{ get; set; }
        //  public string 	F_CustMotalebat	{ get; set; }
        //  public string F_CashId	{ get; set; }
        //  public string F_BankCoId	{ get; set; }
        //  public string F_BranchCoId	{ get; set; }
        //  public string F_AccNoCoId	{ get; set; }
        //  public string F_MoAccNo{ get; set; }
        //  public string 	ExpDocNoP	{ get; set; }
        //  public string ExpDocDateP	{ get; set; }
        //  public string F_CRID_Transfer	{ get; set; }
        //  public string AnuncmentNum	{ get; set; }
        //  public string AnuncmentDate	{ get; set; }
        public string pt_desc { get; set; }
        public string bankName { get; set; }
    }
}
//        execute sale.stp_t00050015;55 cntId   ContractPrintCustomers
//execute sale.stp_t00050005;15 cntId,cntRowId     ContractPrintOptions
//execute sale.stp_t00050015; 62 cntRowId, cntId ContractPrintPayment