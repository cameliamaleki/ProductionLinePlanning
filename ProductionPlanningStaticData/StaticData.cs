using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace CRMStaticData
{
    public class StaticData
    {

        public static string CurrentSystem
        {
            get
            {
                //return "RealState";
                //return "CRM";
              //  return "SCM";
                   return "PICS";
            }
        }

        public static int getBranchID
        {
            get
            {
                return (int)User.BranchID;
            }
        }
        public static int WeekNumber
        {
            get
            {
                return 52;
            }
        }
        public static int MaxLT
        {
            get
            {

                return 100;
            }
        }
        public static int MonthNumber
        {
            get
            {
                return 12;
            }
        }

        public static int getYearID
        {
            get
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                int year = pc.GetYear(DateTime.Now);
                return year;
            }
        }

        public static string getRegisteredDate
        {
            get
            {
                return DateNow(0).Date;
            }
        }


        public static string getBankRefPurchase
        {
            get
            {
                return "00";
            }
        }

        public static string getBankRefCommodity
        {
            get
            {
                return "01";
            }
        }
        public static string getSubBankRefPurchase
        {
            get
            {
                return "11";
            }
        }



        public static int getUserID
        {
            get
            {
                return 0;
            }
        }

        public static string SystemName
        {
            get
            {
                return "فروش";
            }
        }
        public static string ModulesName
        {
            get
            {
                return "مشتری";
            }
        }


        public class DateTimeNow
        {
            public string Date { get; set; }
            public string Time { get; set; }
        }
        /// <summary>
        /// the time mines some day
        /// </summary>
        /// <param name="theDay"> total day you are gonna go back</param>
        /// <returns>date time </returns>
        public static DateTimeNow DateNow(int theDay)
        {

            DateTimeNow value = new DateTimeNow();
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            DateTime specieficDate = DateTime.Now.AddDays(-theDay);
            string Data = pc.GetYear(specieficDate).ToString() + "-" + pc.GetMonth(specieficDate).ToString().PadLeft(2, '0') + "-" + pc.GetDayOfMonth(specieficDate).ToString().PadLeft(2, '0');

            value.Date = Data;
            value.Time = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');

            return value;
        }

        public static int MonthNow
        {
            get
            {

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

                var aa = Convert.ToInt32(pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0'));


                return aa;
            }
        }

        public static DateTimeNow WeekNow
        {
            get
            {

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

                int dayOfYear = DateTime.Now.DayOfYear;
                int dayOfWeek = (int)DateTime.Now.DayOfWeek;

                return DateNow(dayOfWeek);
            }
        }

        public static int DayOfYear
        {
            get
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                int totalDayPassedFromThisYear = pc.GetDayOfYear(DateTime.Now);

                return totalDayPassedFromThisYear;
            }
        }

        public static int DayOfWeek
        {
            get
            {
                int dayOfWeek = (int)DateTime.Now.DayOfWeek;

                return dayOfWeek;
            }
        }

        public static int WorkingDayInMonth
        {
            get
            {

                return 26;
            }
        }
        public static int WorkingDayInWeek
        {
            get
            {

                return 6;
            }
        }

        public static RealState.Models.UserInfo.UserInfoModel User
        {
            get
            {
                try
                {

                    var User = (RealState.Models.UserInfo.UserInfoModel)System.Web.HttpContext.Current.Session["User"];

                    return User;

                }

                catch (Exception ex)
                {

                    return null;
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session["User"] = value;
            }
        }


        public static DateTimeNow DateToday
        {
            get
            {
                DateTimeNow value = new DateTimeNow();
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

                string Data = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0') + "/" + pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');

                value.Date = Data;
                value.Time = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0');




                return value;
            }
        }
    }

}
