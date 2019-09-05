using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductionLineBalancing.Models.ProductionLineInfo
{
    public class WorkersScheduleInfoModel 
    {
        public int? ScheduleProductionLineID { get; set; }
        public int? ScheduleProductionLineID2{ get; set; }
        
        [Display(Name = "تسهیل")]
        public int? W_FacilityID{get;set;}
        [Display(Name = "نام کاربر")]
        public int? W_WorkersID{get;set;}
        public int WorkersScheduleID{get;set;}
        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        public int? WorkerID { get;set; }
        public string FacilityName { get; set; }

        public string FacilityNumber { get; set; }

        public string WorkersAssociationName { get; set; }
        public string WorkersName { get; set; }

[Display(Name = "وضعیت همکاری")]
        public int?  WorkersAssociationID{ set; get; }
    }

    public class ScheduleProductionLineInfoModel 
    {
        public int ScheduleProductionLineID{set;get;}
        [Display(Name = "شماره زمان بندی ")]
        public int? ScheduleID{set;get;}
        [Display(Name = "زمان سیکل ایستگاه")]
        public double? CycleTime{set;get;}
        [Display(Name = "خط تولید ")]
        public int? ProductionLineID{set;get;}
        [Display(Name = "زمان شروع زمان بندی")]
        public string ScheduleStartTime{set;get;}
        [Display(Name = "زمان پایان زمان بندی")]
        public string ScheduleFinishTime{set;get;}
        [Display(Name = "رویه تولید قطعه")]
        public int? RoutID{set;get;}
        [Display(Name = "تاریخ ثبت ")]
        public int? InputID{set;get;}

        public string Date { set; get; }


        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }

    }

    public class ProductionLineInfoModel
    {
        public string WorkStationName { get; set; }
        public int ProductionLineID { set; get; }
        public int ProductionLineID2 { set; get; }
        [Display(Name = "توقف کل")]
        public int? ProductionLineStop { set; get; }
        [Display(Name = "نام گروه کاری ")]
        public int? WorkStationID { set; get; }
        [Display(Name = "نام خط")]
        public int? RoutID { set; get; }        
        [Display(Name = "نام مدیر خط ")]
        public int? ResponsibleID { set; get; }

        public string ResponsibleName { set; get; }
        public string ShiftName { get; set; }

        [Display(Name = "کارایی خط ")]
        public double? LineEfficiency { set; get; }
        [Display(Name = "حد پذیرش")]
        public double? LineAcceptance { set; get; }
        [Display(Name = "حد غایت ")]
        public double? LineGoal { set; get; }

        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }
        public int? ScheduleProductionLineID2 { set; get; }
        public int? ScheduleProductionLineID { set; get; }
        [Display(Name = "شماره زمان بندی ")]
        public int? ScheduleID { set; get; }
        [Display(Name = "زمان سیکل ایستگاه")]
        public double? CycleTime { set; get; }
        
        [Display(Name = "زمان شروع زمان بندی")]
        public string ScheduleStartTime { set; get; }
        [Display(Name = "زمان پایان زمان بندی")]
        public string ScheduleFinishTime { set; get; }
        
       
        public int? InputID { set; get; }
         [Display(Name = "تاریخ")]
        public string Date { set; get; }

        [Display(Name = "شیفت")]
        public int? Shift { get; set; }

      
        [Display(Name = "تسهیل")]
        public int? FacilityID { get; set; }
        [Display(Name = "نام کاربر")]
        public int? WorkerID { get; set; }

        [Display(Name = "نام کاربر")]
        public int? WorkersID { get; set; }
        public int WorkersScheduleID { get; set; }
        public string FacilityName { get; set; }
        public string WorkersScheduleName { get; set; }
        [Display(Name = "وضعیت همکاری")]
        public int? WorkersAssociationID { set; get; }

        public string RoutName { get; set; }
        [Display(Name = "زمان بندی به دقیقه")]
        public int? DurationTime { get; set; }
      
    }
}
