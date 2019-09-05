using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductionLineBalancing.Models.InputOutputInfo
{
    public class WasteCanbanInfoModel
    {

        public int? TaminID { get; set; }

        public string BOM { get; set; }
        public string TaminName { get; set; }
        public int? WasteSupplierID { get; set; }
        public int WasteCanbanID { set; get; }
        [Display(Name = "نام تسهیل")]
        public int? FacilityID { set; get; }
        [Display(Name = "نام کارمند")]
        public int? WorkerID { set; get; }
        [Display(Name = "منشا خطا")]
        public int? WasteSourceID { set; get; }
        [Display(Name = "کد رهگیری")]
        public int? WTrackingCode { set; get; }
        [Display(Name = "کد بسته بندی")]
        public int? WPackageCode { set; get; }
        [Display(Name = "کد قطعه")]
        public int? WastePartID { set; get; }
        [Display(Name = "کد انبار")]
        public int? WInventoryCode { set; get; }
        public int? InputOutputID { set; get; }
        [Display(Name = "مقدار ")]
        public int? WastageQuantity { set; get; }
        [Display(Name = "توضیح ضایعات")]
        public string WasteDesc { set; get; }
        [Display(Name = "توضیح بازخورد")]
        public string OvercomeDesc { set; get; }
        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }
        public int? ReworkTime { get; set; }



        [Display(Name = "نام عیب")]
        public int? FaultID { set; get; }
        [Display(Name = "نوع برخورد")]
        public int? ActionID { set; get; }

        [Display(Name = "مرحله ایجاد شده")]
        public int? WCProcessStageID { set; get; }



        public string WInventoryCodeName { get; set; }
        public string WPackageCodeName { get; set; }
        public string WTrackingCodeName { get; set; }
        public string WasteSourceIDName { get; set; }
        public string WorkerIDName { get; set; }
        public string FacilityIDName { get; set; }
        public string FaultIDName { get; set; }
        public string ActionIDName { get; set; }
        public string WasteCanbanIDName { get; set; }
        public string InputOutputIDName { get; set; }
        public string WastePartIDName { get; set; }
        public string WCProcessStageIDName { get; set; }


    }
    public class CanbanInfoModel
    {

        public int CanbanID { set; get; }
        [Display(Name = "کد رهگیری ")]
        public int? IOTrackingCode { set; get; }
        [Display(Name = "کد بسته بندی ")]
        public int? IOPackageCode { set; get; }
        [Display(Name = "کد انبار ")]
        public int? IOInventoryCode { set; get; }

        public int? InputOutputID { set; get; }
        [Display(Name = "قطعه ")]
        public int? CanbanPartID { set; get; }
        [Display(Name = "کد فنی ")]
        public string TechnicalCode { set; get; }
        [Display(Name = "واحد ")]
        public int? UnitID { set; get; }
        [Display(Name = "مقدار ")]
        public int? Quantity { set; get; }
        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }


        [Display(Name = "مرحله نیاز کانبان")]
        public int? CProcessStageID { set; get; }


        public string WorkerName { get; set; }
        [Display(Name = "نام پرسنل")]
        public int? CWorkerID { get; set; }
        public string IOTrackingCodeName { get; set; }
        public string IOPackageCodeName { get; set; }
        public string IOInventoryCodeName { get; set; }
        public string CanbanPartIDName { get; set; }
        public string TechnicalCodeName { get; set; }
        public string UnitIDName { get; set; }
    
        public string CProcessStageIDName { get; set; }

    }
    public class InputOutputInfoModel
    {
        /// <summary>
        /// ///////////facilitystop
        /// </summary>
        /// 
        public string StopReasonName { get; set; }
        public string StopName { get; set; }
        public int? WasteFaultID { get; set; }
        public int FacilityIDStop { get; set; }
        public string FacilityName { set; get; }
       public int WorkerIDStop { get; set; }
        public string WorkerName { set; get; }
        public int FacilityStopID { set; get; }
        [Display(Name = "مدت زمان توقف ")]
        public double? FacilityStopDuration { set; get; }
        [Display(Name = "زمان شروع توقف")]
        public string FacilityStopStartTime { set; get; }
        [Display(Name = "توضیحات ")]
        public string FacilityStopDesc { set; get; }

        [Display(Name = "توضیحات ")]
        public double? OEE { set; get; }
        

        [Display(Name = "نوع توقف")]
        public int? StopID { set; get; }

        [Display(Name = "علت توقف")]
        public int? StopReasonID { set; get; }

        [Display(Name = " موجب توقف کل خط میشود")]
        public Boolean RoutDown { get; set; }

        [Display(Name = "واحد سازمانی")]
        public int? DepartmentID { set; get; }


        //////////
        [Display(Name = "وضعیت کالا")]
        public int? CProcessStageID { set; get; }
        public int InputOutputID { set; get; }
        [Display(Name = "کد شناسایی ")]
        public string InputOutputCode { set; get; }
        [Display(Name = "ورودی/خروجی ")]
        public bool? InputOutputIndicator { set; get; }
        [Display(Name = "شماره زمانبندی ")]
        public int? ScheduleProductionLineID { set; get; }

        public int? ScheduleProductionLineIDInput { set; get; }

        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }



        [Display(Name = "مرحله ایجاد شده")]
        public int? WCProcessStageID { set; get; }
        /////////////////

            public int? TaminID { get; set; }
        public int WasteCanbanID { set; get; }
        [Display(Name = "نام تسهیل")]
        public int? FacilityID { set; get; }
        [Display(Name = "نام کارمند")]
        public int? WorkerID { set; get; }
        [Display(Name = "منشا خطا")]
        public int? WasteSourceID { set; get; }
        [Display(Name = "کد رهگیری")]
        public int? WTrackingCode { set; get; }
        [Display(Name = "کد بسته بندی")]
        public int? WPackageCode { set; get; }
        [Display(Name = "کد قطعه/کالا")]
        public int? WastePartID { set; get; }
        [Display(Name = "کد انبار")]
        public int? WInventoryCode { set; get; }

        [Display(Name = "مقدار ")]
        public int? WastageQuantity { set; get; }
        [Display(Name = "توضیح ضایعات")]
        public string WasteDesc { set; get; }
        [Display(Name = "توضیح بازخورد")]
        public string OvercomeDesc { set; get; }
        [Display(Name = "تایم دوباره کاری")]
        public int? ReworkTime { get; set; }

        [Display(Name = "نام عیب")]
        public int? FaultID { set; get; }
        [Display(Name = "نوع برخورد")]
        public int? ActionID { set; get; }

        ///////////////////////////////

        public int CanbanID { set; get; }
        [Display(Name = "کد رهگیری ")]
        public int? IOTrackingCode { set; get; }
        [Display(Name = "کد بسته بندی ")]
        public int? IOPackageCode { set; get; }
        [Display(Name = "کد انبار ")]
        public int? IOInventoryCode { set; get; }
        [Display(Name = "نام پرسنل")]
        public int? CWorkerID { get; set; }
        [Display(Name = "قطعه /کالا ")]
        public int? CanbanPartID { set; get; }
        [Display(Name = "کد قطعه ")]
        public string TechnicalCode { set; get; }
        [Display(Name = "واحد ")]
        public int? UnitID { set; get; }
        [Display(Name = "مقدار ")]
        public int? Quantity { set; get; }

        //////////////////////////////
        public int PersonInDetailID { set; get; }
        [Display(Name = "نام کارمند")]
        public int? PDWorkerID { set; get; }
        [Display(Name = "روز")]
        public string PDDate { set; get; }
        [Display(Name = "تعداد کالاهای غیر منطبق کل op")]
        public int? PDTotalNotOK { set; get; }
        [Display(Name = "تعداد دفعات انجام نادرست op")]
        public int? PDTotalNotOKMachine { set; get; }
        [Display(Name = "تعداد دفعات انجام صحیح op")]
        public int? PDTotalOK { set; get; }
        [Display(Name = "میزان توقف ایستگاه")]
        public int? PDTotalStop { set; get; }
        [Display(Name = "میزان توقف op")]
        public int? PDTotalStopFacility { set; get; }
        [Display(Name = "مدت زمان کل کارکرد")]
        public int? PDTotalWork { set; get; }
        [Display(Name = "تامین کننده")]
        public int SupplierID { get; set; }

        [Display(Name = "تامین کننده")]
        public int WasteSupplierID { get; set; }

        public string BOM { get; set; }

        ////////justgrid/////////
       public string IOTrackingCodeName {get;set;}
       public string IOPackageCodeName { get; set; }
       public string IOInventoryCodeName { get; set; }
       public string CanbanPartIDName { get; set; }
       public string TechnicalCodeName { get; set; }
       public string UnitIDName { get; set; }
     
       public string CProcessStageIDName { get; set; }




       public string WInventoryCodeName { get; set; }
        public string WPackageCodeName    {get;set;}
        public string WTrackingCodeName   {get;set;}
        public string WasteSourceIDName   {get;set;}
        public string WorkerIDName        {get;set;}
        public string FacilityIDName      {get;set;}
        public string FaultIDName         {get;set;}
        public string ActionIDName        {get;set;}
       
        public string WastePartIDName     {get;set;} 
        public string WCProcessStageIDName{get;set;}
    }
}
