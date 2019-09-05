using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProductionLineBalancing.Models.ReportInfo
{
    public class ReportInfoModel
    {

        public int? WasteSourceID { get; set; }
        public string BOM { get; set; }
        public string WasteSourceName { get; set; }
        public int FacilityStopID { get; set; }
        public double? TimeDurationMin { get; set; }
        public int? OEEID { get; set; }
        public int? Shift { get; set; }
        public string ShiftName { get; set; }
        public int? CWORKER { get; set; }
        public int? ReworkTime { get; set; }
        public double? ALL { get; set; }
        public double Access { get; set; }
        public string PartTypeName { get; set; }
        public string Daten { get; set; }
        public string BomNum { get; set; }
        public string BargeErsal { get; set; }
        public int WasteSupplierID { get; set; }
        public string ProcessStageName { get; set; }
        public string RoutTypeName { get; set; }
        public int? StopReasonID { get; set; }
        public double? FacilityStopDurationaccess { get; set; }
        public int? WFStopID { get; set; }
        public double? AVRQuantity { get; set; }
        public double? AVRWasteQuantity { get; set; }
        public int WorkerID { get; set; }
        [Display(Name = "نام خط")]
        public int RoutID { get; set; }
        public string RoutName { get; set; }
        [Display(Name = "از تاریخ")]
        public string FDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string TDate { get; set; }
        public int? SelectedYear { get; set; }
        public int? SelectedMonth { get; set; }
        public string SelectedMonthName { get; set; }
        public int DurationTime { get; set; }
        public int ScheduleProductionLineID { get; set; }
        public double FacilityStopDuration { get; set; }
        public double? FacilityStopDurationTotal { get; set; }
        public string Day { get; set; }
        public double? DurationTimeTotal { get; set; }
        public double? Accessibility { get; set; }
        public double? AccessibilityAverege { get; set; }
        public int ReportID { get; set; }
        [Display(Name = "نام ایستگاه")]
        public int WorkStationID { get; set; }
        public string WorkStationName { get; set; }
        [Display(Name = "نام تسهیل")]
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        [Display(Name = "نام پرسنل")]
        public int? WorkersID { get; set; }
        public string WorkerName { get; set; }
        public double CycleTime { get; set; }
        public int? CProcessStageID { get; set; }
        public int Quantity { get; set; }
        public double Efficiency { get; set; }
        public double EfficiencyTotal { get; set; }
        public double EfficiencyTotall { get; set; }
        public double Quality { get; set; }
        public double TotalQuality { get; set; }
        public int? WastageQuantity { get; set; }
        public int WCProcessStageID { get; set; }

        public string WCProcessStageName { get; set; }
        public double OEE { get; set; }

        public int CostPersentOfWaste {get;set;}
        public int TahviliPrice { get; set; }
        public int? PartID { get; set; }
        public string PartName { get; set; }
        public int? SupplierCode { get; set; }
        public string TaminName { get; set; }
        public string SupplierNum { get; set; }
        public string ClientSupplierName { get; set; }
        public double? PPM { get; set; }
        public string TechnicalNumber { get; set; }

        public int? WastageClaim { get; set; }
        public int? PartCount { get; set; }

        public int? ActionID { get; set; }

        public double? WastageCost { get; set; }
        public double? Price { get; set; }
        public int? PartPrice { get; set; }
        public double? TotalWastageCost { get; set; }
        public string ScheduleStartTime { get; set; }
        public string ScheduleFinishTime { get; set; }
        public int? FaultID { get; set; }
        public string FaultName { get; set; }
        public string ActionName { get; set; }
        public string WasteDesc { get; set; }
        public int? ResponsibleID { get; set; }
        public string ResponsibleName { get; set; }
        public string StopReasonName { get; set; }
        public string StopName { get; set; }

        public string UnitName { get; set; }
        public int? UnitID { get; set; }
        public string FacilityStopDesc { get; set; }

        public int? OKPart { get; set; }
        public int? ClaimPart { get; set; }
        public int? ConditionalPart { get;  set; }

        public int? TotalOKPart { get; set; }

        public int? TotalClaimPart { get; set; }
        public int? TotalConditionalPart { get; set; }

        public int WastePartID { get; set; }

        public string WastePartName { get; set; }

        public int? NumberOfWorker { get; set; }

        public int? WorkerMinutie { get; set; }

        public string WarehouseTypeInfoName { get; set; }
        public string OvercomeDesc { get; set; }

        public int? StopID { get; set; }

        public int NumberOfStops { get; set; }

        public double? MTTR { get; set; }

        public double? MTBF { get; set; }

        public double? StopMatchin { get; set; }
        public int? InputOutputID { get; set; }
        public string WorkersCode { get; set; }

       
    }

     public class OEEWorkerModel
    {
        public int OEEID { get; set;}
        public string Day { get; set; }
        public double? Access { get; set; }
        public double? Efficiency { get; set; }
        public double? Quality { get; set; }
    }

    public class OEEWorkermonthModel
    {
        public int OEEID { get; set; }
        public int Day { get; set; }
        public double? Access { get; set; }
        public double? Efficiency { get; set; }
        public double? Quality { get; set; }
    }
}
