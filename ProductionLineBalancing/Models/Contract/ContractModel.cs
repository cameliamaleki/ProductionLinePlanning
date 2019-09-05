using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sell.Contract
{


    public class ContractSharedModel
    {
        [Display(Name = "شماره قرارداد")]
        public int ContractShared_Id { get; set; }
        [Display(Name = "شماره قرارداد")]
        public int ContractShared_No { get; set; }
        [Display(Name = "نمایندگی")]
        public int ContractShared_AGNId { get; set; }
        [Display(Name = "ناریخ قرارداد")]
        public string ContractShared_Date { get; set; }

        [Display(Name = "نوع انتقال گیرنده")]
        public int ContractShared_SenderType { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string ContractShared_SenderName { get; set; }
        [Display(Name = "فرزند")]
        public string ContractShared_SenderFatherName { get; set; }
        [Display(Name = "شماره شناسنامه")]
        public string ContractShared_SenderSHSH { get; set; }
        [Display(Name = "کد ملی")]
        public string ContractShared_SenderNationalCode { get; set; }
        [Display(Name = "تاریخ تولد")]
        public string ContractShared_SenderBirthDate { get; set; }
        [Display(Name = "محل تولد")]
        public int ContractShared_SenderBirthPlace { get; set; }
        [Display(Name = "آدرس")]
        public string ContractShared_SenderAddress { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string ContractShared_WitnessName { get; set; }
        [Display(Name = "فرزند")]
        public string ContractShared_WitnessFatherName { get; set; }
        [Display(Name = "شماره شناسنامه")]
        public string ContractShared_WitnessSHSH { get; set; }
        [Display(Name = "آدرس")]
        public string ContractShared_WitnessAddress { get; set; }

        [Display(Name = "شماره فیش")]
        public string ContractShared_ReciptNumber { get; set; }
        [Display(Name = "مورخ")]
        public string ContractShared_ReciptDate { get; set; }
        [Display(Name = "مبلغ")]
        public string ContractShared_ReciptAmount { get; set; }
    }
    public class ContractModel : Core.BaseModel
    {

        [Display(Name = "شماره قرارداد")]
        public string Contract_Alabel { get; set; }


        [Display(Name = "شماره قرارداد")]
        public int Contract_CNTID { get; set; }
        [Display(Name = "تاریخ قرارداد")]
        public string Contract_CNTDate { get; set; }
        [Display(Name = "مشتری")]
        public int? Contract_F_CustomerID { get; set; }

        [Display(Name = "نمایندگی")]
        public int? Contract_F_AgencyID { get; set; }
        [Display(Name = "شماره سریال فرم قرارداد")]
        public string Contract_CNTSerial { get; set; }

        [Display(Name = "درصد کمیسیون")]
        public int? Contract_CNTCommissionPercent { get; set; }
        [Display(Name = "وضعیت قرارداد")]
        public Boolean Contract_Status { get; set; }
        [Display(Name = "ردیف قرارداد")]
        public int? Contract_CntStatus { get; set; }
        [Display(Name = "دلیل استرداد")]
        public string Contract_RejectionReason { get; set; }


        public int? Contract_IsOkbyAccounting { get; set; }

        [Display(Name = "فروش عمده")]
        public Boolean Contract_PublicSale { get; set; }

        [Display(Name = "تاریخ تخمینی تحویل")]
        public string Contract_TahvilDate { get; set; }

        [Display(Name = "معرف")]
        public int? Contract_F_SponsorID { get; set; }

        public int? Contract_F_cntTransfer { get; set; }

        public string Contract_CNTSerialOld { get; set; }

        public int Contract_F_ParameterID { get; set; }

        public int Contract_FlgOkContract { get; set; }

        [Display(Name = "اطلاع رسانی از طریق پیامک")]
        public Boolean Contract_SendSms { get; set; }

        public int? Contract_TrackID { get; set; }
        [Display(Name = "صاحب پلاک")]
        public string Contract_PelakOwner { get; set; }
        [Display(Name = "وضعیت قرارداد")]
        public string ContractStatusDesc { get; set; }

    }
    public class ContractModelView : Core.BaseModel
    {

        [Display(Name = "شماره قرارداد")]
        public string Contract_AlabelView { get; set; }
        [Display(Name = "شماره قرارداد")]
        public int Contract_CNTIDView { get; set; }
        [Display(Name = "تاریخ قرارداد")]
        public string Contract_CNTDateView { get; set; }
        [Display(Name = "مشتری")]
        public int? Contract_F_CustomerIDView { get; set; }
        [Display(Name = "نمایندگی")]
        public int? Contract_F_AgencyIDView { get; set; }
        [Display(Name = "شماره سریال فرم قرارداد")]
        public string Contract_CNTSerialView { get; set; }

        [Display(Name = "درصد کمیسیون")]
        public int? Contract_CNTCommissionPercentView { get; set; }
        [Display(Name = "وضعیت قرارداد")]
        public Boolean Contract_StatusView { get; set; }
        [Display(Name = "ردیف قرارداد")]
        public int? Contract_CntStatusView { get; set; }
        [Display(Name = "دلیل استرداد")]
        public string Contract_RejectionReasonView { get; set; }


        public int? Contract_IsOkbyAccountingView { get; set; }

        [Display(Name = "فروش عمده")]
        public Boolean Contract_PublicSaleView { get; set; }

        [Display(Name = "تاریخ تخمینی تحویل")]
        public string Contract_TahvilDateView { get; set; }

        [Display(Name = "معرف")]
        public int? Contract_F_SponsorIDView { get; set; }

        public int? Contract_F_cntTransferView { get; set; }

        public string Contract_CNTSerialOldView { get; set; }

        public int Contract_F_ParameterIDView { get; set; }

        public int Contract_FlgOkContractView { get; set; }

        [Display(Name = "اطلاع رسانی از طریق پیامک")]
        public Boolean Contract_SendSmsView { get; set; }

        public int? Contract_TrackIDView { get; set; }
        [Display(Name = "صاحب پلاک")]
        public string Contract_PelakOwnerView { get; set; }
        [Display(Name = "وضعیت قرارداد")]
        public string ContractStatusDescView { get; set; }

    }
    public class ContractDetailModel : Core.BaseModel
    {


        public int ContractDetail_CNTRowID { get; set; }
        [Display(Name = "شماره قرارداد")]
        public int? ContractDetail_CntRowNo { get; set; }

        public int ContractDetail_F_CNTID { get; set; }

        public int ContractDetail_F_SaleRowID { get; set; }

        [Display(Name = "آدرس")]
        public int? ContractDetail_F_DeliveryAddressID { get; set; }

        [Display(Name = "رنگ")]
        public int? ContractDetail_F_ColorID { get; set; }
        [Display(Name = "تودوزی")]

        public int? ContractDetail_F_DecorationID { get; set; }
        [Display(Name = "تعداد")]
        public int? ContractDetail_CNTQuantity { get; set; }
        [Display(Name = "")]
        public int? ContractDetail_CNTRowStatus { get; set; }

        [Display(Name = "قابلیت واگذاری دارد ")]
        public int? ContractDetail_AssignAble { get; set; }
        [Display(Name = "فاکتور به نام")]
        public int? ContractDetail_FactorBy { get; set; }
        [Display(Name = "شماره سند")]
        public int? ContractDetail_DocumentBy { get; set; }
        [Display(Name = "شماره حواله")]
        public int? ContractDetail_HavaleBy { get; set; }
        [Display(Name = "سود")]
        public int? ContractDetail_Mosharekat { get; set; }

        [Display(Name = "3% هزینه شماره گذاری")]
        public int? ContractDetail_ShomarehGozari { get; set; }
        [Display(Name = "مالیات")]
        public double? ContractDetail_Tax { get; set; }

        [Display(Name = "سایر هزینه های شماره گذاری")]
        public Boolean? ContractDetail_SayerHazSh { get; set; }
        public int? ContractDetail_F_EsghatyID { get; set; }

        [Display(Name = "تخفیف")]
        public int? ContractDetail_CNTPercent { get; set; }
        public string ContractDetail_Tafcnt { get; set; }
        public double? ContractDetail_taxForIncrease { get; set; }
        public int? ContractDetail_F_UsageType { get; set; }
        public Boolean ContractDetail_FlgAssignCar { get; set; }
        public int? ContractDetail_InsOfStatus { get; set; }
        public int? ContractDetail_FlgOkLizing { get; set; }
        public string ContractDetail_ReaseonLizing { get; set; }
        public string PlackOwnerText { get;set;}

    }
    public class ContractDetailEditModel : Core.BaseModel
    {


        public int? ContractDetail_CNTRowID { get; set; }
        [Display(Name = "شماره قرارداد")]
        public int? ContractDetail_CntRowNo { get; set; }

        public int? ContractDetail_F_CNTID { get; set; }

        public int? ContractDetail_F_SaleRowID { get; set; }

        [Display(Name = "آدرس")]
        public int? ContractDetail_F_DeliveryAddressID { get; set; }

        [Display(Name = "رنگ")]
        public int? ContractDetail_F_ColorID { get; set; }
        [Display(Name = "تودوزی")]

        public int? ContractDetail_F_DecorationID { get; set; }
        [Display(Name = "تعداد")]
        public int? ContractDetail_CNTQuantity { get; set; }
        [Display(Name = "")]
        public int? ContractDetail_CNTRowStatus { get; set; }

        [Display(Name = "قابلیت واگذاری دارد ")]
        public int? ContractDetail_AssignAble { get; set; }
        [Display(Name = "فاکتور به نام")]
        public int? ContractDetail_FactorBy { get; set; }
        [Display(Name = "شماره سند")]
        public int? ContractDetail_DocumentBy { get; set; }
        [Display(Name = "شماره حواله")]
        public int? ContractDetail_HavaleBy { get; set; }
        [Display(Name = "سود")]
        public int? ContractDetail_Mosharekat { get; set; }

        [Display(Name = "3% هزینه شماره گذاری")]
        public int? ContractDetail_ShomarehGozari { get; set; }
        [Display(Name = "مالیات")]
        public double? ContractDetail_Tax { get; set; }

        [Display(Name = "سایر هزینه های شماره گذاری")]
        public Boolean? ContractDetail_SayerHazSh { get; set; }
        public int? ContractDetail_F_EsghatyID { get; set; }

        [Display(Name = "تخفیف")]
        public int? ContractDetail_CNTPercent { get; set; }
        public string ContractDetail_Tafcnt { get; set; }
        public double? ContractDetail_taxForIncrease { get; set; }
        public int? ContractDetail_F_UsageType { get; set; }
        //public Boolean? ContractDetail_FlgAssignCar { get; set; }
        public int? ContractDetail_InsOfStatus { get; set; }
        public int? ContractDetail_FlgOkLizing { get; set; }
        public string ContractDetail_ReaseonLizing { get; set; }

        public string PlackOwnerText { get; set; }
    }
    public class ContractDetailViewModel
    {
        public int? CNTRowID { get; set; }
        public int? F_SaleRowID { get; set; }
        public string SaleRowDesc { get; set; }
        public int? F_DeliveryAddressID { get; set; }
        public string DeliveryAddress { get; set; }
        public int? F_ColorID { get; set; }
        public string Color { get; set; }
        public int? F_DecorationID { get; set; }
        public string Decoration { get; set; }
        public int? CNTQuantity { get; set; }
        public int? CNTRowStatus { get; set; }
        public byte? AssignAble { get; set; }
        public byte? FactorBy { get; set; }
        public byte? DocumentBy { get; set; }
        public byte? CntRowNo { get; set; }
        public byte? Mosharekat { get; set; }
        public int? ShomarehGozari { get; set; }
        public double? tax { get; set; }
        public Boolean? SayerHazSh { get; set; }
        public int? F_EsghatyID { get; set; }
        public string StatusDesc { get; set; }
        public byte? HavaleBy { get; set; }
        public decimal? CNTPercent { get; set; }
        public int? CarCode { get; set; }
        public int? F_UsageType { get; set; }
        public string PelakOwner { get; set; }

    }



    public class ContractViewModel
    {
        public int? CNTID { get; set; }
        public string CNTDate { get; set; }
        public int? F_CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int? F_AgencyID { get; set; }
        public string AgencyDesc { get; set; }
        public string CNTSerial { get; set; }
        public decimal? CNTCommissionPercet { get; set; }
        public short? CntStatus { get; set; }
        public string STATUSDESC { get; set; }
        public Boolean? Status { get; set; }
        public Boolean? PublicSale { get; set; }
        public string TahvilDate { get; set; }
        public int? F_SponsorID { get; set; }

        public string SaleRowDesc { get; set; }



    }

    public class ContractReport
    {
        [Display(Name = "شماره قرارداد از")]
        public string CR_ContractNoFrom { get; set; }
        [Display(Name = "تاریخ قرارداد از")]
        public string CR_ContractDateFrom { get; set; }
        [Display(Name = "شماره قرارداد تا")]
        public string CR_ContractNoTo { get; set; }
        [Display(Name = "تاریخ قرارداد تا")]
        public string CR_ContractDateTo { get; set; }
        [Display(Name = "مشتری")]
        public string CR_Customer { get; set; }

    }

    public class RegistryPrint
    {
        [Display(Name = "مشتری")]
        public string RP_Customer { get; set; }
        [Display(Name = "قرارداد")]
        public string Rp_Contract { get; set; }
        [Display(Name = "جزییات قرارداد")]
        public string Rp_ContractDetail { get; set; }
    }
    public class ColorPriority
    {
        public int SaleColorID { get; set; }
        public int Selected { get; set; }
        public Int16 Priority { get; set; }
        public string pt_desc { get; set; }
        public int F_ColorID { get; set; }

    }

}
namespace Sell.Report
{
    public class ContractFlowViewModel
    {
        public int? CNTID { get; set; }
        public string CNTDate { get; set; }
        public int? F_CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDesc { get; set; }
        public int? F_AgencyID { get; set; }
        public string AgencyDesc { get; set; }
        public string CNTSerial { get; set; }
        public decimal? CNTCommissionPercent { get; set; }
        public int? CntStatus { get; set; }
        public string StatusDesc { get; set; }



        public int? F_CNTID { get; set; }
        public string Status_Date { get; set; }
        public string Status_Time { get; set; }
        public int? F_StatusID { get; set; }
        public string D_StatusDesc { get; set; }
        public int? F_UserID { get; set; }
        public string UserDesc { get; set; }
        public string Computer { get; set; }
    }

    public class ContractFlowMasterViewModel
    {
        public int? CNTID { get; set; }
        public string CNTDate { get; set; }
        public int? F_CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDesc { get; set; }
        public int? F_AgencyID { get; set; }
        public string AgencyDesc { get; set; }
        public string CNTSerial { get; set; }
        public decimal? CNTCommissionPercent { get; set; }
        public int? CntStatus { get; set; }
        public string StatusDesc { get; set; }
    }
    public class ContractFlowDetailViewModel
    {
        public int? F_CNTID { get; set; }
        public string Status_Date { get; set; }
        public string Status_Time { get; set; }
        public int? F_StatusID { get; set; }
        public string StatusDesc { get; set; }
        public int? F_UserID { get; set; }
        public string UserDesc { get; set; }
        public string Computer { get; set; }
    }



    public class CustomerReportViewModel
    {
        public int? CMID { get; set; }
        public byte? CMType { get; set; }
        public string Type { get; set; }
        public string CMCode { get; set; }
        public int? F_CMGroupID { get; set; }
        public string Group { get; set; }
        public string CMName { get; set; }
        public string CMFamily { get; set; }
        public string CMFatherName { get; set; }
        public string CMIDNo { get; set; }
        public int? F_CMIssueLocation { get; set; }
        public string IssueLocation { get; set; }
        public string CMBirthDate { get; set; }
        public int? F_CMJobCode { get; set; }
        public string Job { get; set; }
        public string CMIssueDate { get; set; }
        public string CMNationalCode { get; set; }
        public int? F_CMSexID { get; set; }
        public string Sex { get; set; }
        public string CMLicenceNo { get; set; }
        public string CMLicenceIssueDate { get; set; }
        public int? F_CMLicenceIssueLocation { get; set; }
        public string LicenceIssueLocation { get; set; }
        public string CMFirmName { get; set; }
        public string CMFirmRegNo { get; set; }
        public int? F_CMFirmTypeID { get; set; }
        public string FirmType { get; set; }
        public string CMEconCode { get; set; }
        public int? F_CMAdrsCity { get; set; }
        public string City { get; set; }
        public string CMAdrsStreet { get; set; }
        public string CMAdrsAlley { get; set; }
        public string CMAdrsNo { get; set; }
        public string CMTelPhone { get; set; }
        public string CMTelCode { get; set; }
        public string CMPostCode { get; set; }
        public int? F_CMCityRCode { get; set; }
        public string CityRCode { get; set; }
        public string EmailAddress { get; set; }
        public int? F_CMBankID { get; set; }
        public string Bank { get; set; }
        public int? F_CMAccType { get; set; }
        public string AccType { get; set; }
        public string CMBankBranch { get; set; }
        public string CMAccNo { get; set; }
        public string CodeTafsili { get; set; }
        public int? f_ShomareGozariCity { get; set; }

    }

    public class ContractRegisterReportDetailViewModel
    {
        public decimal Moneys { get; set; }
        public int F_CntId { get; set; }

    }
    public class ContractRegisterReportMasterViewModel
    {
        public int CNTID { get; set; }
        public string CNTSerial { get; set; }
        public string CNTDate { get; set; }
        public int? CNTRowID { get; set; }
        public int? F_CustomerID { get; set; }
        public string CMCode { get; set; }
        public byte CMType { get; set; }
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

    public class ContractRegisterReportViewModel
    {

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


    public class LendingCarReportViewModel
    {

        public string code { get; set; }
        public int? radif { get; set; }
        public string DateA { get; set; }
        public int? AGNID { get; set; }
        public int? AGNCode { get; set; }
        public string AGNDesc { get; set; }
        public string pt_Desc { get; set; }
        public int? Days { get; set; }
        public int? F_Deliver { get; set; }
        public string AcceptanceNo { get; set; }
        public string AcceptanceDate { get; set; }
        public string bodyNo { get; set; }
        public string Delivery { get; set; }
        public string ShasiNO { get; set; }
        public string CarCode { get; set; }
        public string StatusDesc { get; set; }
        public string Usage { get; set; }


    }


    public class ViewInsuranceReportViewModel
    {
        public int? F_CntID { get; set; }
        public string CustCode { get; set; }
        public string CusName { get; set; }
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
        public int? IDCar { get; set; }
        public string BodyNO { get; set; }
        public int? F_CarID { get; set; }
        public int? F_ColorID { get; set; }
        public Int16? Status { get; set; }
        public string ProductDate { get; set; }
        public int? F_DecorationID { get; set; }
        public string Decorate { get; set; }
        public string F_N_KHODRO { get; set; }
        public string Quality { get; set; }
        public string CarCode { get; set; }
        public string CarName { get; set; }
        public string CarColor { get; set; }
        int? F_UsageType { get; set; }
        public string pt_desc { get; set; }
        public int? FactorID { get; set; }
        public string DeliveryDate { get; set; }
        public int? ExitCardNo { get; set; }
        public int? F_CntRowID { get; set; }
        public decimal? MabMazad { get; set; }
        public int? F_TypeItemSanad { get; set; }
        public Boolean PublicSale { get; set; }
        public string FactDate { get; set; }
        public string MabKasryP { get; set; }
        public string ShasiNO { get; set; }
        public Int16? FlgIsBime33 { get; set; }
        public Int16? FlgIsBime22 { get; set; }
        public string NoIns { get; set; }
        public string DateIns { get; set; }

    }

    public class GhateiDeliveredReportViewModel
    {
        public int? CNTID { get; set; }
        public int? CMID { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public string MobileNo { get; set; }
        public string CarName { get; set; }
        public string ShasiNO { get; set; }
        public string MotorNO { get; set; }
        public string BodyNO { get; set; }
        public string pt_desc { get; set; }
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
        public int? ExitCardNo { get; set; }
        public string DeliveryDate { get; set; }
        public string FactNo { get; set; }
        public string FactDate { get; set; }
        public string NameDelivF { get; set; }
        public string Decorate { get; set; }
        public string ProductDate { get; set; }
        public string typeDliv { get; set; }
    }
    public class AmaniDeliveredReportViewModel
    {
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
        public string CarName { get; set; }
        public string DateA { get; set; }
        public int? Days { get; set; }
        public string AcceptanceNo { get; set; }
        public string AcceptanceDate { get; set; }
        public string BodyNO { get; set; }
        public string ShasiNO { get; set; }
        public string MotorNO { get; set; }
        public string pt_desc { get; set; }
        public string decorate { get; set; }
        public string NameDeliv { get; set; }
        public string typeDliv { get; set; }
    }
    public class CustomerInformationReportViewModel
    {
        public string CMCode { get; set; }
        public string Name { get; set; }
        public string CarName { get; set; }
        public int? F_ColorID { get; set; }
        public string pt_desc { get; set; }
        public string ShasiNO { get; set; }
        public decimal? PriceTehran { get; set; }
        public decimal? OptionPrice { get; set; }
        public string FactNo { get; set; }
        public string FactDate { get; set; }
        public string SanadNO { get; set; }
        public string SanadDate { get; set; }
        public int? F_CntRowID { get; set; }
        public byte? CntRowNo { get; set; }
        public string DeliveryDate { get; set; }
        public decimal? Mosharekat { get; set; }
        public decimal? Shomaregozari { get; set; }
        public string Address { get; set; }
        public string CMTelPhone { get; set; }
        public int? F_CntID { get; set; }
    }

    public class SaleInstractMasterReportViewModel
    {

        public Int16? AxelQty { get; set; }
        public Int16? TierQty { get; set; }
        public int? Tonage { get; set; }
        public string Capacity { get; set; }
        public Int16? SilenderQty { get; set; }
        public decimal FirstServiceFromKlm { get; set; }
        public decimal FirstServiceToKlm { get; set; }
        public Int16 MaxServiceMon { get; set; }
        public string Desc1 { get; set; }
        public string CarName { get; set; }
        public string SaleRowDesc { get; set; }
        public string SaleFromDate { get; set; }
        public string SaleToDate { get; set; }
        public string DelFromDate { get; set; }
        public string DelToDate { get; set; }
        public Int32 DiscountPrcnt { get; set; }
        public Int32 RejectPrcnt { get; set; }
        public decimal Discount { get; set; }
        public decimal? PriceBase { get; set; }
        public string Oil { get; set; }
        public string Type { get; set; }
        public string Tipe { get; set; }
        public string System { get; set; }
        public int? SaleRowID { get; set; }


    }
    public class SaleInstractDetailReportViewModel
    {
        public string pt_desc { get; set; }
        public decimal? OptionPrice { get; set; }
        public int FlgStandard { get; set; }
        public int CarCode { get; set; }


    }
    public class SaleInstractReportViewModel
    {
        public string pt_desc { get; set; }
        public decimal? OptionPrice { get; set; }
        public int FlgStandard { get; set; }
        public int CarCode { get; set; }
        public int? AxelQty { get; set; }
        public int? TierQty { get; set; }
        public int? Tonage { get; set; }
        public string Capacity { get; set; }
        public int? SilenderQty { get; set; }
        public decimal FirstServiceFromKlm { get; set; }
        public decimal FirstServiceToKlm { get; set; }
        public int? MaxServiceMon { get; set; }
        public string Desc1 { get; set; }
        public string CarName { get; set; }
        public string SaleRowDesc { get; set; }
        public string SaleFromDate { get; set; }
        public string SaleToDate { get; set; }
        public string DelFromDate { get; set; }
        public string DelToDate { get; set; }
        public decimal? DiscountPrcnt { get; set; }
        public decimal? RejectPrcnt { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PriceBase { get; set; }
        public string Oil { get; set; }
        public string Type { get; set; }
        public string Tipe { get; set; }
        public string System { get; set; }
        public int? SaleRowID { get; set; }

    }

    public class ContractSearchViewModel
    {

        public int? CNTID { get; set; }
        public string CNTDate { get; set; }
        public string CaneclCntDate { get; set; }
        public string CNTSerial { get; set; }
        public string CNTSerialOld { get; set; }
        public Int16? CntStatus { get; set; }
        public string CntStatusDesc { get; set; }
        public Boolean PublicSale { get; set; }
        public string DescPublicSale { get; set; }
        public int? CNTRowID { get; set; }
        public byte? CntRowNo { get; set; }
        public int? CNTRowStatus { get; set; }
        public string CNTRowStatusDesc { get; set; }
        public int? CNTQuantity { get; set; }
        public decimal? SumMoney { get; set; }
        //public string FactorId { get; set; }
        public string FactNo { get; set; }
        public string FactDate { get; set; }
        //public int? Status { get; set; }
        public string FactorStatusDesc { get; set; }
        public string SanadNO { get; set; }
        public string SanadDate { get; set; }
        //public int? F_AgencyID { get; set; }
        public string AgencyDesc { get; set; }
        //public int? F_CustomerID { get; set; }
        public string custName { get; set; }
        public string zinafName { get; set; }
        //public int? F_CustFact { get; set; }
        public string CustFact { get; set; }
        //public int? F_CustDoc { get; set; }
        public string CustDoc { get; set; }
        //public int? pyprmtflID { get; set; }
        public string pt_desc { get; set; }
        //public int? SaleRowID { get; set; }
        public string SaleRowDesc { get; set; }
        //public int? CarGroup { get; set; }
        public string CarGroupDesc { get; set; }
        public int? CarId { get; set; }
        public string CarName { get; set; }
        public string BodyNO { get; set; }
        [Display(Name = "شماره شاسی")]
        public string ShasiNO { get; set; }
        [Display(Name = "شماره موتور")]
        public string MotorNO { get; set; }
        //public int? F_ColorID { get; set; }
        [Display(Name = "رنگ")]
        public string color { get; set; }
        //public int? F_DecorationID { get; set; }
        [Display(Name = "تزئینات")]
        public string Decor { get; set; }
        //public decimal? CNTCommissionPercent { get; set; }
        //public string SolhDesc { get; set; }
        [Display(Name = "کاربری")]
        public string Usagetype { get; set; }



    }


    public class SaleFlowChartMasterReportViewModel
    {
        public int CNTID { get; set; }
        public string CNTDate { get; set; }
        public int? F_CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDesc { get; set; }
        public int? F_AgencyID { get; set; }
        public string AgencyDesc { get; set; }
        public string CNTSerial { get; set; }
        public int? CNTCommissionPercent { get; set; }
        public Int16 CntStatus { get; set; }
        public string StatusDesc { get; set; }




    }
    public class SaleFlowChartDetailReportViewModel
    {

        public int F_CNTID { get; set; }
        public string StatusDate { get; set; }
        public string StatusTime { get; set; }
        public Int16 F_StatusID { get; set; }
        public string StatusDesc { get; set; }
        public int? F_UserID { get; set; }
        public string UserDesc { get; set; }
        public string Computer { get; set; }
    }
    public class SaleFlowChartReportViewModel
    {
        public int F_CNTID { get; set; }
        public string StatusDate { get; set; }
        public string StatusTime { get; set; }
        public Int16 F_StatusID { get; set; }
        public string LastStatusDesc { get; set; }
        public int? F_UserID { get; set; }
        public string UserDesc { get; set; }
        public string Computer { get; set; }
        public int CNTID { get; set; }
        public string CNTDate { get; set; }
        public int? F_CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDesc { get; set; }
        public int? F_AgencyID { get; set; }
        public string AgencyDesc { get; set; }
        public string CNTSerial { get; set; }
        public int? CNTCommissionPercent { get; set; }
        public Int16 CntStatus { get; set; }
        public string StatusDesc { get; set; }


    }


}

