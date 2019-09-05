using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sell.LendingCars
{
    public class LendingCarsFlowModel
    {
        public string code { get; set; }
        public int radif { get; set; }
        public string StatusDesc { get; set; }
        public int F_UserID { get; set; }
        public string UserName { get; set; }
        public string StatusDate { get; set; }
        public string StatusTime { get; set; }
        public string Computer { get; set; }
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
        public string ShasiNO { get; set; }
    }
    public class KargozaranModel
    {
        public int IDKargozar { get; set; }
        public string FullName { get; set; }
    }
    public class LendingCarsViewModel
    {
        public string code { get; set; }
        public int radif { get; set; }
        public string DateA { get; set; }
        public int AGNID { get; set; }
        public string AGNCode { get; set; }
        public string AGNDesc { get; set; }
        ////color 
        public string pt_Desc { get; set; }
        public int Days { get; set; }
        public int F_Deliver { get; set; }
        public string AcceptanceNo { get; set; }
        public string AcceptanceDate { get; set; }
        public string bodyNo { get; set; }
        public string Delivery { get; set; }
        public string ShasiNO { get; set; }
        public string CarCode { get; set; }
        public string StatusDesc { get; set; }
        public string Usage { get; set; }
    }
    public class LendingCarsModel : Core.BaseModel
    {
        [Display(Name = "درخواست")]
        public int IDrequstAmani { get; set; }
        [Display(Name = "شماره درخواست")]
        public string code { get; set; }
        [Display(Name = " تاریخ")]
        public string DateA { get; set; }
        [Display(Name = "نمایندگی")]
        public int? F_AgnID { get; set; }
        [Display(Name = "نوع محصول")]
        public int? TrackID { get; set; }
        public Boolean FlgTaahod { get; set; }
    }
    public class LendingCarsDetailModel : Core.BaseModel
    {
        public int IDDetailReqAmani { get; set; }
        public int? F_IDrequstAmani { get; set; }
        [Display(Name = "ماشین")]
        public int? F_IDCar { get; set; }
        public int? AcceptanceType { get; set; }
        [Display(Name = "روز")]
        public int? Days { get; set; }
        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDate { get; set; }
        public string StatusTime { get; set; }
        public string Statusdate { get; set; }
        public int? status { get; set; }
        [Display(Name = "رنگ")]
        public int? F_color { get; set; }
        [Display(Name = "تعداد")]
        public int? num { get; set; }
        [Display(Name = "ردیف")]
        public int? radif { get; set; }
        public int? num_ok { get; set; }
        public string NameDeliv { get; set; }
        [Display(Name = "نماینده")]
        public int? F_Deliver { get; set; }
        [Display(Name = "نوع تحویل")]
        public int? DelivType { get; set; }
        public int? F_UserIDAccConfirm { get; set; }
        public string AccConfirmReason { get; set; }
        public int? F_UserIDConfirm { get; set; }
        public int? F_UserIDTasvib { get; set; }
        [Display(Name = "کاربری")]
        public int F_UsageType { get; set; }
    }
    public class LendingCarsPrintModel
    {
        [Display(Name = "درخواست")]
        public int LCP_IDrequstAmani { get; set; }
        [Display(Name = "کاربری")]
        public string LCP_code { get; set; }
        [Display(Name = "نمایندگی")]
        public int? LCP_F_AgnID { get; set; }
        [Display(Name = "نوع محصول")]
        public int? LCP_TrackID { get; set; }
        [Display(Name = "از تاریخ")]
        public string LCP_FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string LCP_ToDate { get; set; }
    }
    public class LendingCarsDetailViewModel
    {
        public int IDDetailReqAmani { get; set; }
        public int entekhab { get; set; }
        public int radif { get; set; }
        public string CarName { get; set; }
        public string pt_desc { get; set; }
        public int num { get; set; }
        public int num_ok { get; set; }
        public int Days { get; set; }
        public string typeDliv { get; set; }
        public string nameDliv { get; set; }
        public string StatusDesc { get; set; }
        public int? F_color { get; set; }
        public int? F_IDCar { get; set; }
        public byte AcceptanceType { get; set; }
        public int? status { get; set; }
        public int? F_Deliver { get; set; }
        public byte DelivType { get; set; }
        public int? F_UsageType { get; set; }
        public int? F_IdCar { get; set; }
        public string ShasiNO { get; set; }
    }
    public class LendingCarsDetailViewSModel
    {
        public Boolean IsDelete { get; set; }
        public int IDDetailReqAmani { get; set; }
        public int entekhab { get; set; }
        public int radif { get; set; }
        public string CarName { get; set; }
        public string pt_desc { get; set; }
        public int num { get; set; }
        public int num_ok { get; set; }
        public int Days { get; set; }
        public string typeDliv { get; set; }
        public string nameDliv { get; set; }
        public string StatusDesc { get; set; }
        public int? F_color { get; set; }
        public int? F_IDCar { get; set; }
        public byte AcceptanceType { get; set; }
        public int? status { get; set; }
        public int? F_Deliver { get; set; }
        public byte DelivType { get; set; }
        public int? F_UsageType { get; set; }
        public string ShasiNO { get; set; }
    }
    public class TahvilAmaniModel
    {
        [Display(Name = "از تاریخ")]
        public string TA_FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string TA_ToDate { get; set; }
        [Display(Name = "تحویل گیرنده")]
        public int TA_Recevier { get; set; }
        [Display(Name = "")]
        public string TA_RecevierType { get; set; }
        [Display(Name = "درخواست")]
        public string TA_TahvilType { get; set; }
    }
}
