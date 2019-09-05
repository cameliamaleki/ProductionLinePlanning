using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductionLineBalancing.Models.RoutInfo
{
    public class RoutFacilityInfoModel 
    {
        public int? IsActived { get; set; }
        public string PartName { get; set; }
        public string FaciltiyName { get; set; }
        public int RoutFacilityID{set;get;}
        [Display(Name = "نام خط")]
        public int? RoutID{set;get;}
        [Display(Name = "نام OP")]
        public int? FaciltiyID{set;get;}
        [Display(Name = "نام کالا")]
        public int? PartID{set;get;}
        [Display(Name = "مدت زمان")]
        public double? TimeDurationMin{set;get;}
        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }

    }
    public class RoutChildParentInfoModel 
    {
        [Display(Name = "نام خط تولید")]
        public int? RoutID{set;get;}
        [Display(Name = "زیر خط ")]
        public int? ChildRoutID{set;get;}
        public string ChildRoutName { set; get; }
        public int RoutChildParentID{set;get;}

    }
    public class RoutInfoModel
    {
        public int IsActived { get; set; }
        public int RoutID{set;get;}
        [Display(Name = "نام خط تولید")]
        public string RoutName{set;get;}
        [Display(Name = "نام گروه کاری  ")]
        public int? WorkStationID{set;get;}

        public string WorkStationName { get; set; }
        [Display(Name = "نوع خط ")]
        public int? RoutTypeID{set;get;}
        [Display(Name = "نام کالا")]
        public int? PartID{set;get;}

        public string PartName { get; set; }

        [Display(Name = "تاریخ ثبت ")]
        public string RegisteredDate { set; get; }
        [Display(Name = "سال مالی")]
        public int? YearID { set; get; }
        [Display(Name = "نام شعبه")]
        public int? BranchID { set; get; }
        [Display(Name = "نام کاربر")]
        public int? UserID { set; get; }
        public string RoutTypeName { get; set; }
    }
}
