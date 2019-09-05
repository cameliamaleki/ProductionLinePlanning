using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
namespace ProductionLineBalancing.Models.ReportInfo
{
    public class ReportInfo
    {
        DataLayer.MRPDataContext context = new DataLayer.MRPDataContext();
        public List<ReportInfoModel> GetAllAccessibilityRoutDaily(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEE>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;2 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                if (ReportID == 3)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;3  '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result5 = new List<ReportInfoModel>();
                var facilitystoplist = context.PP_FacilityStopInfos.ToList();
                foreach (var y in Result)
                {
                    var schelist = facilitystoplist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList();
                    y.FacilityStopDuration = Convert.ToInt32(schelist.Where(q => q.StopID == 12 && q.WorkerID == 0).ToList().Sum(w => w.FacilityStopDuration));
                    Result5.Add(y);
                    //  }
                }
                var query = new List<ReportInfoModel>();
                query = Result5
               .GroupBy(l => l.ScheduleProductionLineID)
               .SelectMany(cl => cl.Select(
                       cc => new ReportInfoModel
                       {
                           ScheduleProductionLineID = (int)cc.ScheduleProductionLineID,
                           FacilityStopDurationTotal = cl.Sum(c => c.FacilityStopDuration),
                           DurationTimeTotal = cl.Sum(c => c.DurationTime),
                           Accessibility = Math.Round(((cc.DurationTime - cl.Sum(c => c.FacilityStopDuration)) / cc.DurationTime) * 100),
                           RoutName = cc.RoutName,
                           SelectedMonth = cc.SelectedMonth,
                           Day = cc.Day,
                           WorkStationName = cc.WorkStationName,
                           RoutID = cc.RoutID,
                           WorkStationID = cc.WorkStationID,
                       })).ToList();
                var query7 = query.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                if (ReportID == 1)
                {
                    var query2 = query7
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            AccessibilityAverege = Math.Round((double)(cl.Average(c => c.Accessibility)), 2),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName
                        }));
                    var List = query2.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 2)
                {
                    var query3 = query7
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            AccessibilityAverege = Math.Round((double)(cl.Average(c => c.Accessibility)), 2),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName
                        }));
                    var List = query3.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query4 = query7
                .GroupBy(l => l.RoutID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            RoutName = cc.RoutName,
                            RoutID = cc.RoutID,
                            AccessibilityAverege = Math.Round((double)(cl.Average(c => c.Accessibility)), 2),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query4.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.RoutID).Select(x => x.First()).ToList();
                    foreach (var c in List)
                    {
                        if (context.PP_OEEs.Where(q => q.RoutID == c.RoutID).FirstOrDefault() == null)
                        {
                            bulklist.Add(new DataLayer.PP_OEE
                            {
                                RoutID = c.RoutID,
                                Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEE Set Access= " + ((c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege) + " where RoutID=" + c.RoutID);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("RoutID", typeof(int));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.RoutID
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEE]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllAccessibilityByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEEW>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;4 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                if (ReportID == 6)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;5  '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result5 = new List<ReportInfoModel>();
                var facilitystoplist = context.PP_FacilityStopInfos.ToList();
                foreach (var y in Result)
                {
                    var schelist = facilitystoplist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList();
                    y.FacilityStopDuration = Convert.ToInt32(schelist.Where(q => q.StopID == 12 && q.WorkerID == 0).ToList().Sum(w => w.FacilityStopDuration));
                    Result5.Add(y);
                    //  }
                }
                var query = new List<ReportInfoModel>();
                query = Result5
               .GroupBy(l => l.ScheduleProductionLineID)
               .SelectMany(cl => cl.Select(
                       cc => new ReportInfoModel
                       {
                           ScheduleProductionLineID = (int)cc.ScheduleProductionLineID,
                           FacilityStopDurationTotal = cl.Sum(c => c.FacilityStopDuration),
                           DurationTimeTotal = cl.Sum(c => c.DurationTime),
                           Accessibility = Math.Round(((cl.Sum(c => c.DurationTime) - cl.Sum(c => c.FacilityStopDuration)) / cl.Sum(c => c.DurationTime)) * 100),
                           RoutName = cc.RoutName,
                           SelectedMonth = cc.SelectedMonth,
                           Day = cc.Day,
                           WorkStationName = cc.WorkStationName,
                           RoutID = cc.RoutID,
                           WorkStationID = cc.WorkStationID,
                       })).ToList();
                var query7 = query.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                if (ReportID == 4)
                {
                    var query2 = query7
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            AccessibilityAverege = Math.Round((double)(cl.Average(c => c.Accessibility)), 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName
                        }));
                    var List = query2.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 5)
                {
                    var query3 = query7
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            AccessibilityAverege = Math.Round((double)(cl.Average(c => c.Accessibility)), 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName
                        }));
                    var List = query3.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query4 = query7
                .GroupBy(l => l.WorkStationID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkStationName = cc.WorkStationName,
                            WorkStationID = cc.WorkStationID,
                            AccessibilityAverege = Math.Round((double)(cl.Average(c => c.Accessibility)), 2),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query4.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.WorkStationID).Select(x => x.First());
                    //foreach (var c in List)
                    //{
                    //    if (context.PP_OEEWs.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() == null)
                    //    {
                    //        DataLayer.PP_OEEW temp = new DataLayer.PP_OEEW();
                    //        temp.RoutID = c.WorkStationID;
                    //        temp.Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege;
                    //        context.PP_OEEWs.InsertOnSubmit(temp);
                    //        context.SubmitChanges();
                    //    }
                    //    else
                    //    {
                    //        context.ExecuteQuery<ReportInfoModel>("Update PP_OEEW Set Access= " + ((c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege) + " where RoutID=" + c.WorkStationID);
                    //    }
                    //};
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWs.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() == null)
                        {
                            //DataLayer.PP_OEE temp = new DataLayer.PP_OEE();
                            //temp.RoutID = c.RoutID;
                            //temp.Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege;
                            //context.PP_OEEs.InsertOnSubmit(temp);
                            //context.SubmitChanges();
                            bulklist.Add(new DataLayer.PP_OEEW
                            {
                                RoutID = c.WorkStationID,
                                Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEW Set Access= " + ((c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege) + " where RoutID=" + c.WorkStationID);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("RoutID", typeof(int));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.RoutID
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEW]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
                return Result;
            }
        }
        public List<ReportInfoModel> GetAllAccessibilityByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEEWorkerDaily>();
            var bulklist1 = new List<DataLayer.PP_OEEWorker>();
            var bulklist3 = new List<DataLayer.PP_OEEWorkerMonthly>();
            try
            {
                if (ReportID == 12)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;82 '" + FDate + "','" + TDate + "'").ToList();
                }
                if (ReportID != 12)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;38 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                var Result5 = new List<ReportInfoModel>();
                var facilitystoplist = context.PP_FacilityStopInfos.ToList();
                foreach (var y in Result)
                {
                    var schelist = facilitystoplist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList();
                    var facillist2 = schelist.Where(q => q.StopID == 12).ToList();
                    y.FacilityStopDuration = Convert.ToInt32(facillist2.Where(q => q.WorkerID == y.WorkerID).Sum(w => w.FacilityStopDuration)) + Convert.ToInt32(facillist2.Where(q => q.WorkerID == 0).Sum(w => w.FacilityStopDuration));
                    Result5.Add(y);
                    //  }
                }
                var query = new List<ReportInfoModel>();
                query = Result5
               .GroupBy(l => l.WorkerID)
               .SelectMany(cl => cl.Select(
                       cc => new ReportInfoModel
                       {
                           ScheduleProductionLineID = (int)cc.ScheduleProductionLineID,
                           FacilityStopDurationTotal = cl.Sum(c => c.FacilityStopDuration),
                           DurationTimeTotal = cl.Sum(c => c.DurationTime),
                           Accessibility = Math.Round(((cl.Sum(c => c.DurationTime) - cl.Sum(c => c.FacilityStopDuration)) / cl.Sum(c => c.DurationTime)) * 100),
                           // RoutName = cc.RoutName,
                           SelectedMonth = cc.SelectedMonth,
                           Day = cc.Day,
                           // WorkStationName = cc.WorkStationName,
                           WorkerName = cc.WorkerName,
                           //  RoutID = cc.RoutID,
                           //  WorkStationID = cc.WorkStationID,
                           WorkerID = cc.WorkerID,
                       })).ToList();
                if (ReportID == 10)
                {
                    var query2 = query
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            AccessibilityAverege = (cl.Average(c => c.Accessibility)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkerName = cc.WorkerName
                        }));
                    var List = query2.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.Day).Select(x => x.First());
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkerDailies.Where(q => q.Day == c.Day).FirstOrDefault() == null)
                        {
                            bulklist.Add(new DataLayer.PP_OEEWorkerDaily
                            {
                                Day = c.Day,
                                Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorkerDaily Set Access= " + ((c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege) + " where Day='" + c.Day + "'");
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("Day", typeof(string));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.Day
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorkerDaily]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
                if (ReportID == 11)
                {
                    var query3 = query
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            AccessibilityAverege = (cl.Average(c => c.Accessibility)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkerName = cc.WorkerName
                        }));
                    var List = query3.Where(q => q.AccessibilityAverege > 0).GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkerMonthlies.Where(q => q.Day == c.SelectedMonth).FirstOrDefault() == null)
                        {
                            bulklist3.Add(new DataLayer.PP_OEEWorkerMonthly
                            {
                                Day = c.SelectedMonth,
                                Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorkerMonthly Set Access= " + ((c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege) + " where Day=" + c.SelectedMonth);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("Day", typeof(string));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist3.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.Day
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorkerMonthly]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
                else
                {
                    var query4 = query
                .GroupBy(l => l.WorkerID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkerName = cc.WorkerName,
                            WorkerID = cc.WorkerID,
                            AccessibilityAverege = (cl.Average(c => c.Accessibility)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query4.Where(q => q.AccessibilityAverege > 0).Where(q => q.WorkerID != 0).GroupBy(x => x.WorkerID).Select(x => x.First());
                    //  return List.ToList();
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkers.Where(q => q.RoutID == c.WorkerID).FirstOrDefault() == null)
                        {
                            //DataLayer.PP_OEE temp = new DataLayer.PP_OEE();
                            //temp.RoutID = c.RoutID;
                            //temp.Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege;
                            //context.PP_OEEs.InsertOnSubmit(temp);
                            //context.SubmitChanges();
                            bulklist1.Add(new DataLayer.PP_OEEWorker
                            {
                                RoutID = c.WorkerID,
                                Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorker Set Access= " + ((c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege) + " where RoutID=" + c.WorkerID);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("RoutID", typeof(int));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist1.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.RoutID
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorker]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllEfficiencyByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEE>();
            var facilitistoplist = context.PP_FacilityStopInfos.ToList();
            if (ReportID == 15)
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;7 '" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                foreach (var c in Result)
                {
                    c.DurationTime = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.DurationTime));
                    var fgh = Convert.ToInt32(facilitistoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Sum(w => w.FacilityStopDuration));
                    if (c.DurationTime > fgh)
                    {
                        var ss = ((c.DurationTime - fgh) * 60) / c.CycleTime;
                        c.Efficiency = c.Quantity / ss;
                    }
                    if (c.DurationTime <= fgh)
                    {
                        c.Efficiency = 0;
                    }
                    if (c.Efficiency == null || c.Efficiency == 0)
                    {
                        var tt = 0;
                    }
                    Result2.Add(c);
                }
            }
            else
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;6 " + RoutID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                //foreach (var c in Result)
                //{
                //    c.DurationTime = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.DurationTime));
                //    var fgh = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Sum(w => w.FacilityStopDuration));
                //    var ss = ((c.DurationTime - fgh) * 60) / c.CycleTime;
                //    c.Efficiency = c.Quantity / ss;
                //    Result2.Add(c);
                //}
                var listt = Result
                .GroupBy(l => l.ScheduleProductionLineID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            DurationTime = Convert.ToInt32(cl.Average(c => c.DurationTime)),
                            FacilityStopDuration = cl.Sum(w => w.FacilityStopDuration),
                            Day = cc.Day,
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName,
                            SelectedMonth = cc.SelectedMonth,
                            ScheduleProductionLineID = cc.ScheduleProductionLineID,
                            Quantity = cc.Quantity,
                            CycleTime = cc.CycleTime
                        }));
                var List = listt.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                foreach (var c in List)
                {
                    var ss = ((c.DurationTime - c.FacilityStopDuration) * 60) / c.CycleTime;
                    c.Efficiency = c.Quantity / ss;
                    Result2.Add(c);
                }
            }
            var query2 = new List<ReportInfoModel>();
            if (ReportID == 13)
            {
                var query = Result2
            .GroupBy(l => l.Day)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        Day = cc.Day,
                        EfficiencyTotal = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
                        FDate = FDate,
                        TDate = TDate,
                        RoutName = cc.RoutName
                    }));
                var List = query.GroupBy(x => x.Day).Select(x => x.First());
                return List.ToList();
            }
            if (ReportID == 14)
            {
                var query100 = Result2
.GroupBy(l => l.Day)
.SelectMany(cl => cl.Select(
    cc => new ReportInfoModel
    {
        Day = cc.Day,
        EfficiencyTotall = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
        FDate = FDate,
        TDate = TDate,
        RoutName = cc.RoutName,
        SelectedMonth = cc.SelectedMonth,
    }));
                var List100 = query100.GroupBy(x => x.Day).Select(x => x.First());
                var query = List100
            .GroupBy(l => l.SelectedMonth)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        SelectedMonth = cc.SelectedMonth,
                        SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                        EfficiencyTotal = Math.Round((cl.Average(c => c.EfficiencyTotall)), 2),
                        FDate = FDate,
                        TDate = TDate,
                        RoutName = cc.RoutName
                    }));
                var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                return List.ToList();
            }
            if (ReportID == 15)
            {
                var query = Result2
            .GroupBy(l => l.RoutID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        RoutID = cc.RoutID,
                        RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                        EfficiencyTotal = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
                        FDate = FDate,
                        TDate = TDate,
                    }));
                var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                var oeelist = context.PP_OEEs.ToList();
                foreach (var c in List)
                {
                    if (oeelist.Where(q => q.RoutID == c.RoutID).FirstOrDefault() == null)
                    {
                        bulklist.Add(new DataLayer.PP_OEE
                        {
                            RoutID = c.RoutID,
                            Efficiency = (c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal,
                        });
                    }
                    else
                    {
                        context.ExecuteQuery<ReportInfoModel>("Update PP_OEE Set Efficiency= " + ((c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal) + " where RoutID=" + c.RoutID);
                    }
                };
                var table = new DataTable();
                table.Columns.Add("OEEID", typeof(int));
                table.Columns.Add("RoutID", typeof(int));
                table.Columns.Add("Access", typeof(float));
                table.Columns.Add("Quality", typeof(float));
                table.Columns.Add("Efficiency", typeof(float));
                // note : the order of the field is very important
                // and should be same as the defined in table structure.
                bulklist.ForEach(data => table.Rows.Add(
                      data.OEEID
                    , data.RoutID
                                                    , data.Access
                                                      , data.Quality
                                                    , data.Efficiency
                                                    ));
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                {
                    connection.Open();
                    var bulkCopy = new SqlBulkCopy(connection)
                    {
                        DestinationTableName = "[dbo].[PP_OEE]",
                        BatchSize = 1000
                    };
                    bulkCopy.WriteToServer(table);
                    bulkCopy.Close();
                };
                return List.ToList();
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllEfficiencyByResponsible(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var facilityustoplist = context.PP_FacilityStopInfos.ToList();
            var workerschedululist = context.PP_WorkersScheduleInfos.ToList();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;77 " + WorkerID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3 || q.CProcessStageID == 4).ToList();
                var listt = Result
           .GroupBy(l => l.ScheduleProductionLineID)
           .SelectMany(cl => cl.Select(
                   cc => new ReportInfoModel
                   {
                       DurationTime = Convert.ToInt32(cl.Average(d => cc.DurationTime)),
                       FacilityStopDuration = cl.Sum(w => w.FacilityStopDuration),
                       Day = cc.Day,
                       FDate = FDate,
                       TDate = TDate,
                       RoutName = cc.RoutName,
                       SelectedMonth = cc.SelectedMonth,
                       ScheduleProductionLineID = cc.ScheduleProductionLineID,
                       Quantity = cc.Quantity,
                       CycleTime = cc.CycleTime,
                       CProcessStageID = cc.CProcessStageID,
                       CWORKER = cc.CWORKER,
                       WorkersID = cc.WorkersID,
                       FacilityID = cc.FacilityID,
                       RoutID = cc.RoutID,
                       WorkerName = cc.WorkerName
                   })).ToList();
             //   var Liist = listt.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                var sslist = listt.Where(q => q.CProcessStageID == 3).ToList();
                var tlist = sslist.Where(q => q.CProcessStageID == 3).ToList();
                var tlist2 = listt.Where(q => q.CWORKER > 0).ToList();
                if (tlist.Count > 0)
                {
                    foreach (var m in tlist)
                    {
                        var hh = facilityustoplist.Where(q => q.ScheduleProductionLineID == m.ScheduleProductionLineID && m.CProcessStageID == 3).Sum(e => e.FacilityStopDuration);
                        var ss = ((m.DurationTime - hh) * 60) / m.CycleTime;
                        m.Efficiency = Convert.ToDouble(m.Quantity / ss);
                        if (m.Efficiency > 1000)
                        {
                            var ffg = 768;
                        }
                        Result2.Add(m);
                    }
                }
                foreach (var c in tlist2)
                {
                    var tlistt = Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList();
                    if (tlistt.Any(q => q.CProcessStageID == 3) == false)
                    {
                        foreach (var f in tlistt)
                        {
                            var facilitystoplist = facilityustoplist.Where(q => q.ScheduleProductionLineID == f.ScheduleProductionLineID).ToList();
                            f.DurationTime = Convert.ToInt32(tlistt.Average(w => w.DurationTime));
                            var fgh = 0;
                            if (facilitystoplist.Count > 0)
                            {
                                var fghworker = Convert.ToInt32(facilitystoplist.Where(q => q.WorkerID == f.CWORKER).ToList().Sum(w => w.FacilityStopDuration));
                                fgh = fghworker;
                            }
                            //  var fghfacility = Convert.ToInt32(facilitystoplist.Where(q=> q.FacilityID == c.FacilityID).ToList().Sum(w => w.FacilityStopDuration));
                            var facility = workerschedululist.Where(q => q.ScheduleProductionLineID == f.ScheduleProductionLineID && q.WorkersID == f.CWORKER).FirstOrDefault().FacilityID;
                            var cyc = context.PP_RoutFacilityInfos.Where(q => q.FaciltiyID == facility & q.RoutID == f.RoutID).FirstOrDefault().TimeDurationMin;
                            if (f.DurationTime > fgh)
                            {
                                var ss = ((f.DurationTime - fgh) * 60) / cyc;
                                f.Efficiency = Convert.ToDouble((f.Quantity) / ss);
                            }
                            if (f.DurationTime <= fgh)
                            {
                                // var ss = ((c.DurationTime - fgh) * 60) / cyc;
                                f.Efficiency = 0;
                            }
                            if (Result2.Count == 14)
                            {
                                var tt = 900;
                            }
                            Result2.Add(f);
                        }
                    }
                }
                var query2 = new List<ReportInfoModel>();
                var query = Result2
            .GroupBy(l => l.RoutID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        RoutID = cc.RoutID,
                        RoutName = cc.RoutName,
                        EfficiencyTotal = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
                        FDate = FDate,
                        TDate = TDate,
                        WorkerName = cc.WorkerName
                    }));
                var List = query.GroupBy(x => x.RoutID).Select(x => x.First()).ToList();
                return List;
            }
            catch (Exception e)
            {
                return Result2;
            }
        }
        public List<ReportInfoModel> GetAllEfficiencyByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEEW>();
            var facilitystoplist = context.PP_FacilityStopInfos.ToList();
            if (ReportID == 18)
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;9 '" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                foreach (var c in Result)
                {
                    c.DurationTime = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.DurationTime));
                    var fgh = Convert.ToInt32(facilitystoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Sum(w => w.FacilityStopDuration));
                    if (c.DurationTime > c.FacilityStopDuration)
                    {
                        var ss = ((c.DurationTime - fgh) * 60) / c.CycleTime;
                        c.Efficiency = c.Quantity / ss;
                    }
                    if (c.DurationTime <= c.FacilityStopDuration)
                    {
                        c.Efficiency = 0;
                    }
                    Result2.Add(c);
                }
            }
            else
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;8 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                foreach (var c in Result)
                {
                    if (c.RoutID == 2726)
                    {
                        var oo = 6686;
                    }
                    c.DurationTime = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.DurationTime));
                    var fgh = Convert.ToInt32(facilitystoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Sum(w => w.FacilityStopDuration));
                    var ss = ((c.DurationTime - fgh) * 60) / c.CycleTime;
                    c.Efficiency = c.Quantity / ss;
                    if (c.Efficiency > 1000)
                    {
                        var rttt = c.ScheduleProductionLineID;
                    }
                    if (c.Efficiency < 1000)
                    {
                        Result2.Add(c);
                    }
                }
            }
            var query2 = new List<ReportInfoModel>();
            if (ReportID == 16)
            {
                var query = Result2
            .GroupBy(l => l.Day)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        Day = cc.Day,
                        EfficiencyTotal = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
                        FDate = FDate,
                        TDate = TDate,
                        WorkStationName = cc.WorkStationName
                    }));
                var List = query.GroupBy(x => x.Day).Select(x => x.First());
                return List.ToList();
            }
            if (ReportID == 17)
            {
                var query = Result2
            .GroupBy(l => l.SelectedMonth)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        SelectedMonth = cc.SelectedMonth,
                        SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                        EfficiencyTotal = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
                        FDate = FDate,
                        TDate = TDate,
                        WorkStationName = cc.WorkStationName
                    }));
                var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                return List.ToList();
            }
            if (ReportID == 18)
            {
                var query = Result2
            .GroupBy(l => l.WorkStationID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        FDate = FDate,
                        TDate = TDate,
                        //   RoutID = cc.RoutID,
                        //RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                        WorkStationID = cc.WorkStationID,
                        WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == cc.WorkStationID).FirstOrDefault().WorkStationName,
                        EfficiencyTotal = Math.Round(((cl.Average(c => c.Efficiency)) * 100), 2),
                    }));
                var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                //foreach (var c in List)
                //{
                //    if (context.PP_OEEWs.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() == null)
                //    {
                //        DataLayer.PP_OEEW temp = new DataLayer.PP_OEEW();
                //        temp.RoutID = c.WorkStationID;
                //        temp.Efficiency = (c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal;
                //        context.PP_OEEWs.InsertOnSubmit(temp);
                //        context.SubmitChanges();
                //    }
                //    else
                //    {
                //        context.ExecuteQuery<ReportInfoModel>("Update PP_OEEW Set Efficiency= " + c.EfficiencyTotal + " where RoutID=" + c.WorkStationID);
                //    }
                //};
                var oeelist = context.PP_OEEWs.ToList();
                foreach (var c in List)
                {
                    //if (context.PP_OEEWs.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() == null)
                    //{
                    //    //DataLayer.PP_OEE temp = new DataLayer.PP_OEE();
                    //    //temp.RoutID = c.RoutID;
                    //    //temp.Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege;
                    //    //context.PP_OEEs.InsertOnSubmit(temp);
                    //    //context.SubmitChanges();
                    //    bulklist.Add(new DataLayer.PP_OEEW
                    //    {
                    //        RoutID = c.WorkStationID,
                    //        Access = (c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal,
                    //    });
                    //}
                    //else
                    //{
                    if (oeelist.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() != null)
                    {
                        context.ExecuteQuery<ReportInfoModel>("Update PP_OEEW Set Efficiency= " + ((c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal) + " where RoutID=" + c.WorkStationID);
                    }
                    //    }
                    //};
                    //var table = new DataTable();
                    //table.Columns.Add("OEEID", typeof(int));
                    //table.Columns.Add("RoutID", typeof(int));
                    //table.Columns.Add("Access", typeof(float));
                    //table.Columns.Add("Quality", typeof(float));
                    //table.Columns.Add("Efficiency", typeof(float));
                    //// note : the order of the field is very important
                    //// and should be same as the defined in table structure.
                    //bulklist.ForEach(data => table.Rows.Add(
                    //      data.OEEID
                    //    , data.RoutID
                    //                                    , data.Access
                    //                                      , data.Quality
                    //                                    , data.Efficiency
                    //                                    ));
                    //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    //{
                    //    connection.Open();
                    //    var bulkCopy = new SqlBulkCopy(connection)
                    //    {
                    //        DestinationTableName = "[dbo].[PP_OEEW]",
                    //        BatchSize = 1000
                    //    };
                    //    bulkCopy.WriteToServer(table);
                    //    bulkCopy.Close();
                    //};
                }
                return List.ToList();
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllEfficiencyByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var bulklist2 = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEEWorkerDaily>();
            var bulkilist3 = new List<DataLayer.PP_OEEWorkerMonthly>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 21)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;10 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;11 '" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 4).ToList();
                }
                var facilitystoplist = context.PP_FacilityStopInfos.ToList();
                foreach (var c in Result)
                {
                    if (Result2.Count == 579)
                    {
                        var ee = 67;
                    }
                    //var cycc = context.PP_RoutFacilityInfos.Where(q => q.FaciltiyID == c.FacilityID & q.RoutID == c.RoutID).FirstOrDefault();
                    //if (cycc != null)
                    //{
                    c.DurationTime = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.DurationTime));
                    var facilitystoplist2 = facilitystoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList();
                    var fgh = 0;
                    var fghworker = Convert.ToInt32(facilitystoplist2.Where(q => q.WorkerID == c.WorkersID).ToList().Sum(w => w.FacilityStopDuration));
                    var fghfacility = Convert.ToInt32(facilitystoplist2.Where(q => q.FacilityID == c.FacilityID).ToList().Sum(w => w.FacilityStopDuration));
                    var routstop = facilitystoplist2.Where(q => q.WorkerID == 0 && q.FacilityID == 0).ToList();
                    if (facilitystoplist2.Where(q => q.FacilityID == c.FacilityID).FirstOrDefault() != null)
                    {
                        fgh = fghfacility;
                        //if (routstop != null)
                        //{
                        //    fgh =Convert.ToInt32( fghfacility + routstop.FacilityStopDuration);
                        //}
                    }
                    if (facilitystoplist2.Where(q => q.FacilityID == c.FacilityID).FirstOrDefault() == null)
                    {
                        fgh = fghworker;
                        if (routstop.Count > 0)
                        {
                            fgh = Convert.ToInt32(fghworker + routstop.Sum(w => w.FacilityStopDuration));
                        }
                    }
                    // var quan = context.PP_WorkersScheduleInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID & q.FacilityID == c.FacilityID).ToList().Count();
                    // var wforfac = context.PP_WorkersScheduleInfos.Where(o => o.WorkersID == c.WorkersID & o.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault();
                    // var cyc = (context.PP_RoutFacilityInfos.Where(q => q.FaciltiyID == c.FacilityID & q.RoutID == c.RoutID).FirstOrDefault().TimeDurationMin) / quan;
                    if (c.DurationTime > fgh)
                    {
                        var ss = ((c.DurationTime - fgh) * 60) / c.TimeDurationMin;
                        c.Efficiency = Convert.ToDouble((c.Quantity) / ss);
                    }
                    if (c.DurationTime <= fgh)
                    {
                        // var ss = ((c.DurationTime - fgh) * 60) / cyc;
                        c.Efficiency = 0;
                    }
                    Result2.Add(c);
                    //  }
                }
                if (ReportID == 19)
                {
                    var query = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                            FDate = FDate,
                            TDate = TDate,
                            WorkerName = context.PP_WorkersInfos.Where(q => q.WorkersID == cc.WorkersID).FirstOrDefault().WorkersSurname,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkerDailies.Where(q => q.Day == c.Day).FirstOrDefault() == null)
                        {
                            bulklist.Add(new DataLayer.PP_OEEWorkerDaily
                            {
                                Day = c.Day,
                                Efficiency = (c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorkerDaily Set Efficiency= " + ((c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal) + " where Day='" + c.Day + "'");
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("Day", typeof(string));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.Day
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorkerDaily]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
                if (ReportID == 20)
                {
                    var query = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                            FDate = FDate,
                            TDate = TDate,
                            WorkerName = context.PP_WorkersInfos.Where(q => q.WorkersID == cc.WorkersID).FirstOrDefault().WorkersSurname,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkerMonthlies.Where(q => q.Day == c.SelectedMonth).FirstOrDefault() == null)
                        {
                            bulkilist3.Add(new DataLayer.PP_OEEWorkerMonthly
                            {
                                Day = c.SelectedMonth,
                                Efficiency = (c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorkerMonthly Set Efficiency= " + ((c.EfficiencyTotal == null) ? 0 : c.EfficiencyTotal) + " where Day=" + c.SelectedMonth);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("Day", typeof(string));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulkilist3.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.Day
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorkerMonthly]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
                else
                {
                    var query = Result2
                .GroupBy(l => l.WorkersID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkersID = cc.WorkersID,
                            WorkerName = cc.WorkerName,
                            EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkersID).Select(x => x.First());
                    var test = List.ToList();
                    var oeelist = context.PP_OEEWorkers.ToList();
                    foreach (var c in oeelist)
                    {
                        var bb = test.Where(q => q.WorkersID == c.RoutID).FirstOrDefault();
                        if (bb != null)
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorker Set Efficiency= " + ((bb.EfficiencyTotal == null) ? 0 : bb.EfficiencyTotal) + " where RoutID=" + bb.WorkersID);
                        }
                    };
                    return test;
                }
            }
            catch (Exception ex)
            {
                var ddd = Result2;
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllQualityByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEE>();
            var wastelist = context.PP_WasteCanbanInfos.ToList();
            try
            {
                if (ReportID != 24)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;12 " + RoutID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                    foreach (var c in Result)
                    {
                        // var input = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault();
                        var quan = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault().Quantity);
                        var waste = Convert.ToInt32(wastelist.Where(q => q.InputOutputID == c.InputOutputID && q.ActionID == 15).ToList().Sum(w => w.WastageQuantity));
                        c.Quality = Convert.ToDouble(quan) / Convert.ToDouble((quan + ((waste == null) ? 0 : waste)));
                        Result2.Add(c);
                    }
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;13 '" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                    foreach (var c in Result)
                    {
                        // if(c.ACtionID == 1011)
                        //   {
                        // var quan = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.Quantity));
                        // var waste = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Sum(w => w.WastageQuantity));
                        //  c.Quality = Convert.ToDouble(c.Quantity) / Convert.ToDouble((c.Quantity + ((c.WastageQuantity == null) ? 0 : c.WastageQuantity)));
                        // var input = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault();
                        var quan = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault().Quantity);
                        var waste = Convert.ToInt32(wastelist.Where(q => q.InputOutputID == c.InputOutputID && q.ActionID == 15).ToList().Sum(w => w.WastageQuantity));
                        c.Quality = Convert.ToDouble(quan) / Convert.ToDouble((quan + ((waste == null) ? 0 : waste)));
                        Result2.Add(c);
                        //   }
                        // else
                        //  {
                        //      c.Quality =1;
                        //      Result2.Add(c);
                        //  }
                    }
                }
                if (ReportID == 22)
                {
                    var query = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            TotalQuality = Math.Round(((cl.Average(c => c.Quality)) * 100), 2),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First()).OrderBy(q => q.Day);
                    return List.ToList();
                }
                if (ReportID == 23)
                {
                    var query = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            TotalQuality = Math.Round(((cl.Average(c => c.Quality)) * 100), 2),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result2
                .GroupBy(l => l.RoutID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            RoutID = cc.RoutID,
                            RoutName = cc.RoutName,
                            TotalQuality = Math.Round(((cl.Average(c => c.Quality)) * 100), 2),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                    //foreach (var c in List)
                    //{
                    //    if (context.PP_OEEs.Where(q => q.RoutID == c.RoutID).FirstOrDefault() == null)
                    //    {
                    //        DataLayer.PP_OEE temp = new DataLayer.PP_OEE();
                    //        temp.RoutID = c.RoutID;
                    //        temp.Quality = (c.TotalQuality == null) ? 0 : c.TotalQuality;
                    //        context.PP_OEEs.InsertOnSubmit(temp);
                    //        context.SubmitChanges();
                    //    }
                    //    else
                    //    {
                    //        context.ExecuteQuery<ReportInfoModel>("Update PP_OEE Set Quality= " + c.TotalQuality + " where RoutID=" + c.RoutID);
                    //    }
                    //};
                    //return List.ToList();
                    foreach (var c in List)
                    {
                        if (context.PP_OEEs.Where(q => q.RoutID == c.RoutID).FirstOrDefault() == null)
                        {
                            //DataLayer.PP_OEE temp = new DataLayer.PP_OEE();
                            //temp.RoutID = c.RoutID;
                            //temp.Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege;
                            //context.PP_OEEs.InsertOnSubmit(temp);
                            //context.SubmitChanges();
                            bulklist.Add(new DataLayer.PP_OEE
                            {
                                RoutID = c.RoutID,
                                Access = (c.TotalQuality == null) ? 0 : c.TotalQuality,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEE Set Quality= " + ((c.TotalQuality == null) ? 0 : c.TotalQuality) + " where RoutID=" + c.RoutID);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("RoutID", typeof(int));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.RoutID
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEE]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllQualityByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEEW>();
            var wastelist = context.PP_WasteCanbanInfos.ToList();
            try
            {
                if (ReportID != 27)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;14 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                    foreach (var c in Result)
                    {
                        //  var input = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault();
                        var quan = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault().Quantity);
                        var waste = Convert.ToInt32(wastelist.Where(q => q.InputOutputID == c.InputOutputID && q.ActionID == 15).ToList().Sum(w => w.WastageQuantity));
                        c.Quality = Convert.ToDouble(quan) / Convert.ToDouble((quan + ((waste == null) ? 0 : waste)));
                        Result2.Add(c);
                    }
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;15 '" + FDate + "','" + TDate + "'").ToList();
                    foreach (var c in Result)
                    {
                        //if (c.ACtionID == 1011)
                        //{
                        // var input = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault();
                        var quan = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault().Quantity);
                        var waste = Convert.ToInt32(wastelist.Where(q => q.InputOutputID == c.InputOutputID && q.ActionID == 15).ToList().Sum(w => w.WastageQuantity));
                        c.Quality = Convert.ToDouble(quan) / Convert.ToDouble((quan + ((waste == null) ? 0 : waste)));
                        Result2.Add(c);
                    }
                }
                if (ReportID == 25)
                {
                    var query = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            TotalQuality = Math.Round((cl.Average(c => c.Quality)) * 100, 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 26)
                {
                    var query = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            TotalQuality = Math.Round((cl.Average(c => c.Quality)) * 100, 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result2
                .GroupBy(l => l.WorkStationID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkStationID = cc.WorkStationID,
                            WorkStationName = cc.WorkStationName,
                            TotalQuality = Math.Round((cl.Average(c => c.Quality)) * 100, 2),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                    //foreach (var c in List)
                    //{
                    //    if (context.PP_OEEWs.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() == null)
                    //    {
                    //        DataLayer.PP_OEEW temp = new DataLayer.PP_OEEW();
                    //        temp.RoutID = c.WorkStationID;
                    //        temp.Quality = (c.TotalQuality == null) ? 0 : c.TotalQuality;
                    //        context.PP_OEEWs.InsertOnSubmit(temp);
                    //        context.SubmitChanges();
                    //    }
                    //    else
                    //    {
                    //        context.ExecuteQuery<ReportInfoModel>("Update PP_OEEW Set Quality= " + c.TotalQuality + " where RoutID=" + c.WorkStationID);
                    //    }
                    //};
                    //return List.ToList();
                    var oeelist = context.PP_OEEWs.ToList();
                    foreach (var c in List)
                    {
                        if (oeelist.Where(q => q.RoutID == c.WorkStationID).FirstOrDefault() != null)
                        {
                            //    //DataLayer.PP_OEE temp = new DataLayer.PP_OEE();
                            //    //temp.RoutID = c.RoutID;
                            //    //temp.Access = (c.AccessibilityAverege == null) ? 0 : c.AccessibilityAverege;
                            //    //context.PP_OEEs.InsertOnSubmit(temp);
                            //    //context.SubmitChanges();
                            //    bulklist.Add(new DataLayer.PP_OEEW
                            //    {
                            //        RoutID = c.WorkStationID,
                            //        Access = (c.TotalQuality == null) ? 0 : c.TotalQuality,
                            //    });
                            //}
                            //else
                            //{
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEW Set Quality= " + ((c.TotalQuality == null) ? 0 : c.TotalQuality) + " where RoutID=" + c.WorkStationID);
                        }
                    };
                    //var table = new DataTable();
                    //table.Columns.Add("OEEID", typeof(int));
                    //table.Columns.Add("RoutID", typeof(int));
                    //table.Columns.Add("Access", typeof(float));
                    //table.Columns.Add("Quality", typeof(float));
                    //table.Columns.Add("Efficiency", typeof(float));
                    //// note : the order of the field is very important
                    //// and should be same as the defined in table structure.
                    //bulklist.ForEach(data => table.Rows.Add(
                    //      data.OEEID
                    //    , data.RoutID
                    //                                    , data.Access
                    //                                      , data.Quality
                    //                                    , data.Efficiency
                    //                                    ));
                    //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    //{
                    //    connection.Open();
                    //    var bulkCopy = new SqlBulkCopy(connection)
                    //    {
                    //        DestinationTableName = "[dbo].[PP_OEEW]",
                    //        BatchSize = 1000
                    //    };
                    //    bulkCopy.WriteToServer(table);
                    //    bulkCopy.Close();
                    //};
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllQualityByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var bulklist = new List<DataLayer.PP_OEEWorkerDaily>();
            var bulklist2 = new List<DataLayer.PP_OEEWorker>();
            var bulklist3 = new List<DataLayer.PP_OEEWorkerMonthly>();
            var wastelist = context.PP_WasteCanbanInfos.Where(q => q.ActionID == 15).ToList();
            try
            {
                if (ReportID != 30)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;16 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;17 '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    //   var input = context.PP_InputOutputInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault();
                    // var quan = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).FirstOrDefault().Quantity);
                    var waste = Convert.ToInt32(wastelist.Where(q => q.InputOutputID == c.InputOutputID && q.WorkerID == c.WorkerID).ToList().Sum(w => w.WastageQuantity));
                    if (c.Quantity > waste)
                    {
                        c.Quality = Convert.ToDouble(c.Quantity) / Convert.ToDouble((c.Quantity + ((waste == null) ? 0 : waste)));
                        Result2.Add(c);
                    }
                    //  c.Quality = Convert.ToDouble(c.Quantity) / Convert.ToDouble((c.Quantity + ((waste == null) ? 0 : waste)));
                    //  Result2.Add(c);
                }
                if (ReportID == 28)
                {
                    var query = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            TotalQuality = (cl.Average(c => c.Quality)) * 100,
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkerDailies.Where(q => q.Day == c.Day).FirstOrDefault() == null)
                        {
                            bulklist.Add(new DataLayer.PP_OEEWorkerDaily
                            {
                                Day = c.Day,
                                Quality = (c.TotalQuality == null) ? 0 : c.TotalQuality,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorkerDaily Set Quality= " + ((c.TotalQuality == null) ? 0 : c.TotalQuality) + " where Day='" + c.Day + "'");
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("Day", typeof(string));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.Day
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorkerDaily]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
                if (ReportID == 29)
                {
                    var query = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            TotalQuality = (cl.Average(c => c.Quality)) * 100,
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    foreach (var c in List)
                    {
                        if (context.PP_OEEWorkerMonthlies.Where(q => q.Day == c.SelectedMonth).FirstOrDefault() == null)
                        {
                            bulklist3.Add(new DataLayer.PP_OEEWorkerMonthly
                            {
                                Day = c.SelectedMonth,
                                Quality = (c.TotalQuality == null) ? 0 : c.TotalQuality,
                            });
                        }
                        else
                        {
                            context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorkerMonthly Set Quality= " + ((c.TotalQuality == null) ? 0 : c.TotalQuality) + " where Day=" + c.SelectedMonth);
                        }
                    };
                    var table = new DataTable();
                    table.Columns.Add("OEEID", typeof(int));
                    table.Columns.Add("Day", typeof(string));
                    table.Columns.Add("Access", typeof(float));
                    table.Columns.Add("Quality", typeof(float));
                    table.Columns.Add("Efficiency", typeof(float));
                    // note : the order of the field is very important
                    // and should be same as the defined in table structure.
                    bulklist.ForEach(data => table.Rows.Add(
                          data.OEEID
                        , data.Day
                                                        , data.Access
                                                          , data.Quality
                                                        , data.Efficiency
                                                        ));
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[2].ToString()))
                    {
                        connection.Open();
                        var bulkCopy = new SqlBulkCopy(connection)
                        {
                            DestinationTableName = "[dbo].[PP_OEEWorkerMonthly]",
                            BatchSize = 1000
                        };
                        bulkCopy.WriteToServer(table);
                        bulkCopy.Close();
                    };
                    return List.ToList();
                }
                else
                {
                    var query = Result2
                .GroupBy(l => l.WorkerID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkerID = cc.WorkerID,
                            WorkerName = cc.WorkerName,
                            TotalQuality = (cl.Average(c => c.Quality)) * 100,
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkerID).Select(x => x.First());
                    var oeelist = context.PP_OEEWorkers.ToList();
                    foreach (var c in oeelist)
                    {
                        var bb = List.Where(q => q.WorkerID == c.RoutID).FirstOrDefault();
                        context.ExecuteQuery<ReportInfoModel>("Update PP_OEEWorker Set Quality= " + ((bb.TotalQuality == null) ? 0 : bb.TotalQuality) + " where RoutID=" + bb.WorkerID);
                    };
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllProductionCountByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 33)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;12 " + RoutID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;13 '" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                }
                if (ReportID == 31)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            // AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First()).OrderBy(q => q.Day);
                    return List.ToList();
                }
                if (ReportID == 32)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            //    AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.RoutID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            RoutID = cc.RoutID,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            // AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllProductionCountByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 36)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;51 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;52 '" + FDate + "','" + TDate + "'").Where(q => q.WCProcessStageID == 3 || q.WCProcessStageID == 0).ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                if (ReportID == 34)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            //AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First()).OrderBy(q => q.Day);
                    return List.ToList();
                }
                if (ReportID == 35)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            //AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.WorkStationID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkStationID = cc.WorkStationID,
                            WorkStationName = cc.WorkStationName,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            // AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
                return Result;
            }
        }
        public List<ReportInfoModel> GetAllProductionCountByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 39)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;53 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;54 '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                if (ReportID == 37)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            //AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            WorkerName = cc.WorkerName,
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 38)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            WorkerName = cc.WorkerName,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            //AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.WorkerID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkerID = cc.WorkerID,
                            WorkerName = cc.WorkerName,
                            AVRQuantity = (cl.Sum(c => c.Quantity)),
                            // AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkerID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
                return Result;
            }
        }
        public List<ReportInfoModel> GetAllOEECountByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var facilitystoplist = context.PP_FacilityStopInfos.ToList();
            var wastecanbanlist = context.PP_WasteCanbanInfos.Where(q => q.ActionID == 1011).ToList();
            try
            {
                if (ReportID != 42)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;18 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                //else
                //{
                //    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;19 '" + FDate + "','" + TDate + "'").Where(q => q.WCProcessStageID == 3 || q.WCProcessStageID == 0).ToList();
                //}
                var Result5 = new List<ReportInfoModel>();
                foreach (var y in Result)
                {
                    y.FacilityStopDurationaccess = facilitystoplist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID && q.StopID == 12).ToList().Sum(c => c.FacilityStopDuration);
                    y.FacilityStopDuration = (double)facilitystoplist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList().Sum(c => c.FacilityStopDuration);
                    y.WastageQuantity = wastecanbanlist.Where(q => q.InputOutputID == y.InputOutputID).ToList().Sum(w => w.WastageQuantity);
                    Result5.Add(y);
                }
                var query2 = Result5
             .GroupBy(l => l.ScheduleProductionLineID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            FacilityStopDuration = (cc.FacilityStopDuration == null) ? 0 : cc.FacilityStopDuration,
                            DurationTime = cc.DurationTime,
                            ScheduleProductionLineID = (int)cc.ScheduleProductionLineID,
                            FacilityStopDurationTotal = cl.Sum(c => c.FacilityStopDuration),
                            DurationTimeTotal = cl.Sum(c => c.DurationTime),
                            Accessibility = ((cc.DurationTime - cc.FacilityStopDurationaccess) / cc.DurationTime),
                            RoutID = cc.RoutID,
                            SelectedMonth = cc.SelectedMonth,
                            Day = cc.Day,
                            CycleTime = cc.CycleTime,
                            Quantity = cc.Quantity,
                            StopID = cc.StopID,
                            WastageQuantity = cc.WastageQuantity,
                            RoutName = cc.RoutName,
                        }));
                var query7 = query2.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in query7)
                {
                    var ss = ((c.DurationTime - c.FacilityStopDuration) * 60) / c.CycleTime;
                    c.Efficiency = c.Quantity / ss;
                    c.Quality = Convert.ToDouble(c.Quantity) / Convert.ToDouble((c.Quantity + c.WastageQuantity));
                    Result2.Add(c);
                }
                if (ReportID == 40)
                {
                    var query22 = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FDate = FDate,
                            TDate = TDate,
                            Quality = Math.Round((double)(cl.Average(c => c.Quality * 100))),
                            Efficiency = Math.Round((double)(cl.Average(c => c.Efficiency * 100))),
                            Accessibility = Math.Round((double)(cl.Average(c => c.Accessibility * 100))),
                            OEE = (Math.Round((cl.Average(c => c.Quality * 100))) *
                            Math.Round((cl.Average(c => c.Efficiency * 100))) *
                            Math.Round((double)(cl.Average(c => c.Accessibility * 100)))) / 10000,
                            RoutName = cc.RoutName
                            // OEE = 92.53,
                        }));
                    var List = query22.GroupBy(x => x.Day).Select(x => x.First()).OrderBy(q => q.Day);
                    return List.ToList();
                }
                if (ReportID == 41)
                {
                    var query33 = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            //   OEE = (double)(cl.Average(c=>c.Quality * c.Efficiency * c.Accessibility)) * 100,
                            //  OEE=92.53,
                            FDate = FDate,
                            TDate = TDate,
                            Quality = Math.Round((double)(cl.Average(c => c.Quality * 100))),
                            Efficiency = Math.Round((double)(cl.Average(c => c.Efficiency * 100))),
                            Accessibility = Math.Round((double)(cl.Average(c => c.Accessibility * 100))),
                            OEE = (Math.Round((cl.Average(c => c.Quality * 100))) *
                            Math.Round((cl.Average(c => c.Efficiency * 100))) *
                            Math.Round((double)(cl.Average(c => c.Accessibility * 100)))) / 10000,
                            RoutName = cc.RoutName
                        }));
                    var List = query33.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                    //    var query = Result2
                    //.GroupBy(l => l.RoutID)
                    //.SelectMany(cl => cl.Select(
                    //        cc => new ReportInfoModel
                    //        {
                    //            RoutID = cc.RoutID,
                    //            RoutName = cc.RoutName,
                    //            //  OEE = Math.Round((cl.Average(c => c.Quality)) *(cl.Average(c => c.Efficiency)) * (double)(cl.Average(c => c.Accessibility)))*100,
                    //            //OEE = 92.53,
                    //            FDate = FDate,
                    //            TDate = TDate,
                    //            Quality = Math.Round((double)(cl.Average(c => c.Quality * 100))),
                    //            Efficiency = Math.Round((double)(cl.Average(c => c.Efficiency * 100))),
                    //            Accessibility = Math.Round((double)(cl.Average(c => c.Accessibility * 100))),
                    //            OEE = (Math.Round((cl.Average(c => c.Quality * 100))) *
                    //            Math.Round((cl.Average(c => c.Efficiency * 100))) *
                    //            Math.Round((double)(cl.Average(c => c.Accessibility * 100)))) / 10000,
                    //        }));
                    context.ExecuteCommand("TRUNCATE TABLE PP_OEE");
                var acssess = GetAllAccessibilityRoutDaily(RoutID, FDate, TDate, 3);
                var eficiency = GetAllEfficiencyByRout(RoutID, FDate, TDate, 15);
                var quality = GetAllQualityByRout(RoutID, FDate, TDate, 24);
                var query = context.ExecuteQuery<ReportInfoModel>("select * from PP_OEE   where Access>0 and Efficiency>0 and Quality>0").ToList();
                //var query = context.ExecuteCommand("TRUNCATE TABLE PP_OEE");
                var Resultyear = new List<ReportInfoModel>();
                foreach (var t in query)
                {
                    if (t.Quality != null && t.Efficiency != null)
                    {
                        Resultyear.Add(new ReportInfoModel
                        {
                            RoutID = (int)t.RoutID,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == t.RoutID).FirstOrDefault().RoutName,
                            Quality = Math.Round((double)t.Quality, 2),
                            Accessibility = Math.Round((double)t.Access, 2),
                            Efficiency = Math.Round((double)t.Efficiency, 2),
                            OEE = Math.Round(((((double)t.Quality / 100) * ((double)t.Access / 100) * ((double)t.Efficiency / 100)) * 100), 2),
                            TDate = TDate,
                            FDate = FDate
                        });
                    }
                }
                // var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                return Resultyear.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllOEEByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var facilitylist = context.PP_FacilityStopInfos.ToList();
            var wastelist = context.PP_WasteCanbanInfos.Where(q => q.ActionID == 1011).ToList();
            try
            {
                if (ReportID != 45)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;20 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").Where(q => q.CProcessStageID == 3).ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;21 '" + FDate + "','" + TDate + "'").Where(q => q.WCProcessStageID == 3 || q.WCProcessStageID == 0).ToList();
                }
                var Result5 = new List<ReportInfoModel>();
                foreach (var y in Result)
                {
                    // y.DurationTime =Convert.ToInt32(( Result.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList().Average(c => c.DurationTime)/ Result.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList().Count()));
                    //  y.DurationTime = Convert.ToInt32((Result.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList().Average(c => c.DurationTime)));
                    y.FacilityStopDurationaccess = facilitylist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID && q.StopID == 12).ToList().Sum(c => c.FacilityStopDuration);
                    y.FacilityStopDuration = (double)facilitylist.Where(q => q.ScheduleProductionLineID == y.ScheduleProductionLineID).ToList().Sum(c => c.FacilityStopDuration);
                    y.WastageQuantity = wastelist.Where(q => q.InputOutputID == y.InputOutputID).ToList().Sum(w => w.WastageQuantity);
                    Result5.Add(y);
                }
                var query2 = Result5
             .GroupBy(l => l.ScheduleProductionLineID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            FacilityStopDuration = (cc.FacilityStopDuration == null) ? 0 : cc.FacilityStopDuration,
                            DurationTime = cc.DurationTime,
                            ScheduleProductionLineID = (int)cc.ScheduleProductionLineID,
                            FacilityStopDurationTotal = cl.Sum(c => c.FacilityStopDuration),
                            DurationTimeTotal = cl.Sum(c => c.DurationTime),
                            Accessibility = ((cc.DurationTime - cc.FacilityStopDurationaccess) / cc.DurationTime),
                            RoutID = cc.RoutID,
                            SelectedMonth = cc.SelectedMonth,
                            Day = cc.Day,
                            CycleTime = cc.CycleTime,
                            Quantity = cc.Quantity,
                            StopID = cc.StopID,
                            WastageQuantity = cc.WastageQuantity,
                            WorkStationID = cc.WorkStationID,
                            RoutName = cc.RoutName,
                        }));
                var query7 = query2.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in query7)
                {
                    if (c.DurationTime > c.FacilityStopDuration)
                    {
                        var ss = ((c.DurationTime - c.FacilityStopDuration) * 60) / c.CycleTime;
                        c.Efficiency = c.Quantity / ss;
                        if (c.Efficiency > 1000)
                        {
                            var f = 0000;
                        }
                        c.Quality = Convert.ToDouble(c.Quantity) / Convert.ToDouble((c.Quantity + c.WastageQuantity));
                        Result2.Add(c);
                    }
                }
                if (ReportID == 43)
                {
                    var query = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FDate = FDate,
                            TDate = TDate,
                            // OEE = (double)(cl.Average(c => c.Quality * c.Efficiency * c.Accessibility)) * 100,
                            Quality = Math.Round((double)(cl.Average(c => c.Quality * 100))),
                            Efficiency = Math.Round((double)(cl.Average(c => c.Efficiency * 100))),
                            Accessibility = Math.Round((double)(cl.Average(c => c.Accessibility * 100))),
                            OEE = (Math.Round((cl.Average(c => c.Quality * 100))) *
                            Math.Round((cl.Average(c => c.Efficiency * 100))) *
                            Math.Round((double)(cl.Average(c => c.Accessibility * 100)))) / 10000,
                            WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == cc.WorkStationID).FirstOrDefault().WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 44)
                {
                    var query = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            //   OEE = (double)(cl.Average(c => c.Quality * c.Efficiency * c.Accessibility)) * 100,
                            FDate = FDate,
                            TDate = TDate,
                            Quality = Math.Round((double)(cl.Average(c => c.Quality * 100))),
                            Efficiency = Math.Round((double)(cl.Average(c => c.Efficiency * 100))),
                            Accessibility = Math.Round((double)(cl.Average(c => c.Accessibility * 100))),
                            OEE = (Math.Round((cl.Average(c => c.Quality * 100))) *
                            Math.Round((cl.Average(c => c.Efficiency * 100))) *
                            Math.Round((double)(cl.Average(c => c.Accessibility * 100)))) / 10000,
                            WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == cc.WorkStationID).FirstOrDefault().WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    //    var query = Result2
                    //.GroupBy(l => l.WorkStationID)
                    //.SelectMany(cl => cl.Select(
                    //        cc => new ReportInfoModel
                    //        {
                    //            WorkStationID = cc.WorkStationID,
                    //            WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == cc.WorkStationID).FirstOrDefault().WorkStationName,
                    //            //  OEE = (double)(cl.Average(c => c.Quality * c.Efficiency * c.Accessibility)) * 100,
                    //            FDate = FDate,
                    //            TDate = TDate,
                    //            Quality = Math.Round((double)(cl.Average(c => c.Quality * 100))),
                    //            Efficiency = Math.Round((double)(cl.Average(c => c.Efficiency * 100))),
                    //            Accessibility = Math.Round((double)(cl.Average(c => c.Accessibility * 100))),
                    //            OEE = (Math.Round((cl.Average(c => c.Quality * 100))) *
                    //            Math.Round((cl.Average(c => c.Efficiency * 100))) *
                    //            Math.Round((double)(cl.Average(c => c.Accessibility * 100)))) / 10000,
                    //        }));
                    //    var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                    //    return List.ToList();
                    context.ExecuteCommand("TRUNCATE TABLE PP_OEEW");
                    var acssess = GetAllAccessibilityByWorkStation(WorkStationID, FDate, TDate, 6);
                    var eficiency = GetAllEfficiencyByWorkStation(WorkStationID, FDate, TDate, 18);
                    var quality = GetAllQualityByWorkStation(WorkStationID, FDate, TDate, 27);
                    var query = context.ExecuteQuery<ReportInfoModel>("select * from PP_OEEW   where Access>0 and Efficiency>0 and Quality>0").ToList();
                    //var query = context.ExecuteCommand("TRUNCATE TABLE PP_OEE");
                    var Resultyear = new List<ReportInfoModel>();
                    foreach (var t in query)
                    {
                        if (t.Quality != null && t.Efficiency != null)
                        {
                            Resultyear.Add(new ReportInfoModel
                            {
                                FDate = FDate,
                                TDate = TDate,
                                WorkStationID = (int)t.RoutID,
                                WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == t.RoutID).FirstOrDefault().WorkStationName,
                                Quality = Math.Round((double)t.Quality, 2),
                                Accessibility = Math.Round((double)t.Access, 2),
                                Efficiency = Math.Round((double)t.Efficiency, 2),
                                OEE = Math.Round(((((double)t.Quality / 100) * ((double)t.Access / 100) * ((double)t.Efficiency / 100)) * 100), 2)
                            });
                        }
                    }
                    // var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                    return Resultyear.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllOEEByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var result2 = new List<ReportInfoModel>();
            var workername = "";
            if (ReportID != 48)
            {
                workername = context.PP_WorkersInfos.Where(q => q.WorkersID == WorkerID).FirstOrDefault().WorkersSurname;
            }
            try
            {
                if (ReportID == 46)
                {
                    context.ExecuteCommand("TRUNCATE TABLE PP_OEEWorkerDaily");
                    GetAllAccessibilityByWorker(WorkerID, FDate, TDate, 10);
                    GetAllEfficiencyByWorker(WorkerID, FDate, TDate, 19);
                    GetAllQualityByWorker(WorkerID, FDate, TDate, 28);
                    var dailylist = context.ExecuteQuery<OEEWorkerModel>("select * from PP_OEEWorkerDaily where Access>0 and Quality>0 and Efficiency>0 ").ToList();
                    foreach (var t in dailylist)
                    {
                        if (t.Quality != null && t.Efficiency != null)
                        {
                            result2.Add(new ReportInfoModel
                            {
                                WorkerName = workername,
                                Day = t.Day,
                                Quality = Math.Round((double)t.Quality, 2),
                                Accessibility = Math.Round((double)t.Access, 2),
                                Efficiency = Math.Round((double)t.Efficiency, 2),
                                OEE = Math.Round(((((double)t.Quality / 100) * ((double)t.Access / 100) * ((double)t.Efficiency / 100)) * 100), 2),
                                TDate = TDate,
                                FDate = FDate
                            });
                        }
                    }
                    return result2.ToList();
                }
                if (ReportID == 47)
                {
                    context.ExecuteCommand("TRUNCATE TABLE PP_OEEWorkerMonthly");
                    GetAllAccessibilityByWorker(WorkerID, FDate, TDate, 11);
                    GetAllEfficiencyByWorker(WorkerID, FDate, TDate, 20);
                    GetAllQualityByWorker(WorkerID, FDate, TDate, 29);
                    var dailylist = context.ExecuteQuery<OEEWorkermonthModel>("select * from PP_OEEWorkerMonthly where Access>0 and Quality>0 and Efficiency>0 ").ToList();
                    foreach (var t in dailylist)
                    {
                        if (t.Quality != null && t.Efficiency != null)
                        {
                            result2.Add(new ReportInfoModel
                            {
                                WorkerName = workername,
                                SelectedMonth = Convert.ToInt32(t.Day),
                                SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == t.Day).FirstOrDefault().MonthName,
                                Quality = Math.Round((double)t.Quality, 2),
                                Accessibility = Math.Round((double)t.Access, 2),
                                Efficiency = Math.Round((double)t.Efficiency, 2),
                                OEE = Math.Round(((((double)t.Quality / 100) * ((double)t.Access / 100) * ((double)t.Efficiency / 100)) * 100), 2),
                                TDate = TDate,
                                FDate = FDate
                            });
                        }
                    }
                    return result2.ToList();
                }
                else
                {
                    context.ExecuteCommand("TRUNCATE TABLE PP_OEEWorker");
                    GetAllAccessibilityByWorker(0, FDate, TDate, 12);
                    GetAllEfficiencyByWorker(0, FDate, TDate, 21);
                    GetAllQualityByWorker(0, FDate, TDate, 30);
                    var query = context.ExecuteQuery<ReportInfoModel>("select * from PP_OEEWorker   where Access>0 and Efficiency>0 and Quality>0").ToList();
                    var workerslist = context.PP_WorkersInfos.ToList();
                    // var query = context.PP_OEEWorkers.ToList();
                    var Resultyear = new List<ReportInfoModel>();
                    foreach (var t in query)
                    {
                        if (t.Quality != null && t.Efficiency != null)
                        {
                            Resultyear.Add(new ReportInfoModel
                            {
                                WorkerName = workerslist.Where(q => q.WorkersID == t.RoutID).FirstOrDefault().WorkersSurname,
                                Quality = Math.Round((double)t.Quality, 2),
                                Accessibility = Math.Round((double)t.Access, 2),
                                Efficiency = Math.Round((double)t.Efficiency, 2),
                                OEE = Math.Round(((((double)t.Quality / 100) * ((double)t.Access / 100) * ((double)t.Efficiency / 100)) * 100), 2),
                                TDate = TDate,
                                FDate = FDate
                            });
                        }
                    }
                    // var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                    return Resultyear.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllPPM(int WorkerID, string FDate, string TDate, int ReportID)
        {
            //string f =Convert.ToDateTime(FDate).ToString("dd/MM/yyyy");
            //string t = Convert.ToDateTime(TDate).ToString("dd/MM/yyyy");
            var Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;24 '" + FDate + "','" + TDate + "'").Where(q => q.ActionID == 16).ToList();
            var Result2 = new List<ReportInfoModel>();
            var query = Result
                .GroupBy(l => l.PartID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            ClientSupplierName = cc.ClientSupplierName,
                            PartName = cc.PartName,
                            TechnicalNumber = cc.TechnicalNumber,
                            PartID = cc.PartID,
                            PartCount = cl.Sum(c => c.PartCount),
                            WastageClaim = cc.WastageClaim,
                            PPM = (Convert.ToDouble(cc.WastageClaim) / Convert.ToDouble(cl.Sum(c => c.PartCount))) * 1000000,
                            FDate = FDate,
                            TDate = TDate,
                        }));
            var List = query.GroupBy(x => x.PartID).Select(x => x.First()).OrderByDescending(q => q.PPM);
            return List.ToList();
            //foreach (var c in Result)
            //{
            //        c.PPM = (Convert.ToDouble(c.WastageClaim) / Convert.ToDouble(c.PartCount)) * 1000000;
            //    c.FDate = FDate;
            //    c.TDate = TDate;
            //    Result2.Add(c);
            //}
            return Result;
        }
        public List<ReportInfoModel> GetAllWastageCostByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;25 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    double price = 0;
                    var dd = context.PP_FactorInfos.Where(q => q.PartID == c.PartID).ToList().Count();
                    if (dd != 0)
                    {
                        price = (double)context.PP_FactorInfos.Where(q => q.PartID == c.PartID).ToList().Last().PartPrice;
                    }
                    c.WastageCost = c.WastageQuantity * price;
                    Result2.Add(c);
                }
                var query = Result2
            .GroupBy(l => l.PartID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        PartID = cc.PartID,
                        PartName = cc.PartName,
                        TotalWastageCost = cl.Sum(c => c.WastageCost),
                        FDate = FDate,
                        TDate = TDate,
                        RoutName = cc.RoutName,
                    }));
                var List = query.GroupBy(x => x.PartID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllWastageCostByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;26 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    double price = 0;
                    var dd = context.PP_FactorInfos.Where(q => q.PartID == c.PartID).ToList().Count();
                    if (dd != 0)
                    {
                        price = (double)context.PP_FactorInfos.Where(q => q.PartID == c.PartID).ToList().Last().PartPrice;
                    }
                    c.WastageCost = c.WastageQuantity * price;
                    if (c.WastageCost > 0)
                    {
                        Result2.Add(c);
                    }
                }
                var query = Result2
            .GroupBy(l => l.PartID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        PartID = cc.PartID,
                        PartName = cc.PartName,
                        TotalWastageCost = cl.Sum(c => c.WastageCost),
                        WorkStationName = cc.WorkStationName,
                        FDate = FDate,
                        TDate = TDate,
                    }));
                var List = query.GroupBy(x => x.PartID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllWastageCostByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;27 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    double price = 0;
                    var dd = context.PP_FactorInfos.Where(q => q.PartID == c.PartID).ToList().Count();
                    if (dd != 0)
                    {
                        price = (double)context.PP_FactorInfos.Where(q => q.PartID == c.PartID).ToList().Last().PartPrice;
                    }
                    c.WastageCost = c.WastageQuantity * price;
                    Result2.Add(c);
                }
                var query = Result2
            .GroupBy(l => l.PartID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        PartID = cc.PartID,
                        PartName = cc.PartName,
                        WorkerName = cc.WorkerName,
                        TotalWastageCost = cl.Sum(c => c.WastageCost),
                        FDate = FDate,
                        TDate = TDate,
                    }));
                var List = query.GroupBy(x => x.PartID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllFaultListByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var partlist = context.MRP_PartInfos.ToList();
            var workerslist = context.PP_WorkersInfos.ToList();
            var facilitylist = context.PP_FacilityInfos.ToList();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;28 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    c.ResponsibleName = workerslist.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault().WorkersSurname;
                    c.FacilityName = facilitylist.Where(q => q.FacilityID == c.FacilityID).FirstOrDefault().FacilityName;
                    c.PartName = partlist.Where(q => q.PartID == c.PartID).FirstOrDefault().PartName;
                    c.ProcessStageName = context.PP_ProcessStageInfos.Where(q => q.ProcessStageID == c.WCProcessStageID).FirstOrDefault().ProcessStageName;
                    c.FDate = FDate;
                    c.TDate = TDate;
                    Result2.Add(c);
                }
                return Result2.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllFaultDescParetoByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;29 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                var query = Result
            .GroupBy(l => l.FaultID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        FaultName = cc.FaultName,
                        FaultID = cc.FaultID,
                        AVRWasteQuantity = cl.Sum(c => c.WastageQuantity),
                        FDate = FDate,
                        TDate = TDate,
                        RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName
                    }));
                var List = query.GroupBy(x => x.FaultID).Select(x => x.First()).OrderByDescending(q => q.AVRWasteQuantity);
                return List.ToList();
            }
            catch (Exception ex)
            {
                return Result;
            }
            //return Result;
        }
        public List<ReportInfoModel> GetAllFaultDescParetoByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;30 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                var query = Result
            .GroupBy(l => l.FaultID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        FaultName = cc.FaultName,
                        FaultID = cc.FaultID,
                        AVRWasteQuantity = cl.Sum(c => c.WastageQuantity),
                        FDate = FDate,
                        TDate = TDate,
                        WorkStationName = context.PP_WorkStationInfos.Where(q => q.WorkStationID == cc.WorkStationID).FirstOrDefault().WorkStationName
                    }));
                var List = query.GroupBy(x => x.FaultID).Select(x => x.First()).OrderByDescending(q => q.AVRWasteQuantity);
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllFaultDescParetoByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;31 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                var query = Result
            .GroupBy(l => l.FaultID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        FaultName = cc.FaultName,
                        AVRWasteQuantity = cl.Sum(c => c.WastageQuantity),
                        FDate = FDate,
                        TDate = TDate,
                    }));
                var List = query.GroupBy(x => x.FaultID).Select(x => x.First()).OrderByDescending(q => q.AVRWasteQuantity);
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllStopListReport(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;132 '" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                var workerlist = context.PP_WorkersInfos.ToList();
                var facilitylist = context.PP_FacilityInfos.ToList();
                var facilitystoplist = context.PP_FacilityStopInfos.ToList();
                foreach (var c in Result)
                {
                    // c.ResponsibleName = context.PP_WorkersInfos.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault().WorkersSurname;
                    var ww = facilitystoplist.Where(q => q.FacilityStopID == c.FacilityStopID).FirstOrDefault();
                    c.FDate = FDate;
                    c.TDate = TDate;
                    if (ww.WorkerID > 0)
                    {
                        c.WorkerName = workerlist.Where(q => q.WorkersID == ww.WorkerID).FirstOrDefault().WorkersSurname;
                    }
                    if (ww.FacilityID > 0)
                    {
                        c.FacilityName = facilitylist.Where(q => q.FacilityID == ww.FacilityID).FirstOrDefault().FacilityName;
                    }
                    if (c.UnitID > 0)
                    {
                        c.UnitName = context.PP_UnitInfos.Where(q => q.UnitID == c.UnitID).FirstOrDefault().UnitName;
                    }
                    Result2.Add(c);
                }
                return Result2.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllUnitStopPercent(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;80 '" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    c.TotalOKPart = Convert.ToInt32(Result.ToList().Sum(q => q.FacilityStopDuration));
                }
                var query = Result
            .GroupBy(l => l.UnitID)
            .SelectMany(cl => cl.Select(
                    cc => new ReportInfoModel
                    {
                        UnitName = cc.UnitName,
                        UnitID = cc.UnitID,
                        FacilityStopDurationTotal = cl.Sum(c => c.FacilityStopDuration),
                        TotalQuality = (double)(cl.Sum(c => c.FacilityStopDuration) / cc.TotalOKPart) * 100,
                        FDate = FDate,
                        TDate = TDate,
                    }));
                var List = query.GroupBy(x => x.UnitID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllCumulativeStopDurationByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 61)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;33 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;32 '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                if (ReportID == 59)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 60)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.RoutID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            RoutID = cc.RoutID,
                            RoutName = context.PP_RoutInfos.Where(q => q.RoutID == cc.RoutID).FirstOrDefault().RoutName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllCumulativeStopDurationByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 64)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;34 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;134  '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                if (ReportID == 62)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 63)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.WorkStationID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkStationID = cc.WorkStationID,
                            WorkStationName = cc.WorkStationName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllCumulativeStopDurationByWorker(int WorkerID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 67)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;35 " + WorkerID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;135 '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                if (ReportID == 65)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkerName = cc.WorkerName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 66)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            WorkerName = cc.WorkerName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.WorkerID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkerID = cc.WorkerID,
                            WorkerName = cc.WorkerName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkerID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllSplitPartReport(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;36 '" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                foreach (var c in Result)
                {
                    if (c.ActionID == 8)
                    {
                        c.ClaimPart = c.WastageQuantity;
                        c.WastageQuantity = 0;
                    }
                    if (c.ActionID == 9)
                    {
                        c.ConditionalPart = c.WastageQuantity;
                        c.WastageQuantity = 0;
                    }
                    if (c.ActionID == 10)
                    {
                        c.WastageQuantity = c.WastageQuantity;
                    }
                    c.FDate = FDate;
                    c.TDate = TDate;
                    c.NumberOfWorker = context.PP_WorkersScheduleInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Count;
                    c.ResponsibleName = context.PP_WorkersInfos.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault().WorkersSurname;
                    Result2.Add(c);
                }
                var query = Result2
                           .GroupBy(l => l.ScheduleProductionLineID)
                           .SelectMany(cl => cl.Select(
                                   cc => new ReportInfoModel
                                   {
                                       TotalOKPart = cl.Sum(c => c.Quantity),
                                       TotalClaimPart = cl.Sum(c => c.ClaimPart),
                                       TotalConditionalPart = cl.Sum(c => c.ConditionalPart),
                                       AVRWasteQuantity = cl.Sum(c => c.WastageQuantity),
                                       WastePartName = context.MRP_PartInfos.Where(q => q.PartID == cc.WastePartID).FirstOrDefault().PartName,
                                       TotalQuality = Convert.ToDouble(cl.Sum(c => c.ClaimPart) + cl.Sum(c => c.ConditionalPart) + cl.Sum(c => c.WastageQuantity) + cl.Sum(c => c.Quantity)),
                                       FDate = FDate,
                                       TDate = TDate,
                                       DurationTime = cc.DurationTime,
                                       ClientSupplierName = cc.ClientSupplierName,
                                       Day = cc.Day,
                                       ResponsibleName = cc.ResponsibleName,
                                       NumberOfWorker = cc.NumberOfWorker,
                                       RoutName = cc.RoutName,
                                       PartName = cc.PartName
                                   }));
                var List = query.GroupBy(x => x.ScheduleProductionLineID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllReworkPartReport(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;37 '" + FDate + "','" + TDate + "'").Where(q => q.ActionID == 1014).ToList();
                var fultlist = context.PP_FaultInfos.ToList();
                var wastesourse = context.PP_WasteSourceInfos.ToList();
                var personellist = context.PP_WorkersInfos.ToList();
                foreach (var c in Result)
                {
                    if (fultlist.Where(q => q.FaultID == c.FaultID).FirstOrDefault() != null)
                    {
                        c.FaultName = fultlist.Where(q => q.FaultID == c.FaultID).FirstOrDefault().FaultName;
                    }
                    if (wastesourse.Where(q => q.WasteSourceID == c.WasteSourceID).FirstOrDefault() != null)
                    {
                        c.WasteSourceName = wastesourse.Where(q => q.WasteSourceID == c.WasteSourceID).FirstOrDefault().WasteSourceName;
                    }
                    if (personellist.Where(q => q.WorkersID == c.WorkerID).FirstOrDefault() != null)
                    {
                        c.WorkerName = personellist.Where(q => q.WorkersID == c.WorkerID).FirstOrDefault().WorkersSurname;
                    }
                    c.FDate = FDate;
                    c.TDate = TDate;
                    if (c.WasteSupplierID != 0)
                    {
                        c.ClientSupplierName = context.PP_PartSupplierInfos.Where(q => q.PartSupplierInfoID == c.WasteSupplierID).FirstOrDefault().PartSupplierInfoName;
                        c.FDate = FDate;
                        c.TDate = TDate;
                        if (context.PP_FactorInfos.Where(q => q.SupplierID == c.WasteSupplierID).FirstOrDefault() != null)
                        {
                            c.BargeErsal = context.PP_FactorInfos.Where(q => q.SupplierID == c.WasteSupplierID).FirstOrDefault().BargeErsal;
                            c.BomNum = context.PP_FactorInfos.Where(q => q.SupplierID == c.WasteSupplierID).FirstOrDefault().BomNum;
                        }
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllReworkPartParetoReport(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;37 '" + FDate + "','" + TDate + "'").Where(q => q.ActionID == 1014 && q.WorkStationID == WorkStationID).ToList();
                var query = Result
               .GroupBy(l => l.PartID)
               .SelectMany(cl => cl.Select(
                       cc => new ReportInfoModel
                       {
                           WorkStationName = cc.WorkStationName,
                           PartID = cc.PartID,
                           PartName = cc.PartName,
                           RoutName = cc.RoutName,
                           AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                           FDate = FDate,
                           TDate = TDate,
                       }));
                var List = query.GroupBy(x => x.PartID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllMTTRByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 72)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;39 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;40 '" + FDate + "','" + TDate + "'").ToList();
                }
                if (ReportID == 70)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            NumberOfStops = Result.Count(),
                            MTTR = Math.Round((cl.Sum(c => c.FacilityStopDuration)) / Result.Count(), 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First()).OrderBy(q => q.Day);
                    return List.ToList();
                }
                if (ReportID == 71)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            NumberOfStops = Result.Count(),
                            MTTR = Math.Round((cl.Sum(c => c.FacilityStopDuration)) / Result.Count(), 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.WorkStationID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkStationID = cc.WorkStationID,
                            WorkStationName = cc.WorkStationName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            NumberOfStops = Result.Count(),
                            MTTR = Math.Round((cl.Sum(c => c.FacilityStopDuration)) / Result.Count(), 2),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllMTBFByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 75)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;41 " + WorkStationID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;42 '" + FDate + "','" + TDate + "'").ToList();
                }
                if (ReportID == 73)
                {
                    var query = Result
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            NumberOfStops = Result.Where(q => q.FacilityStopDuration > 0).Count(),
                            Accessibility = cc.DurationTime - (cl.Sum(c => c.FacilityStopDuration)),
                            MTBF = (cl.Average(c => c.DurationTime)) / (Result.Where(q => q.FacilityStopDuration > 0).Count()),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First()).OrderBy(q => q.Day);
                    return List.ToList();
                }
                if (ReportID == 74)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            NumberOfStops = Result.Where(q => q.FacilityStopDuration > 0).Count(),
                            Accessibility = cc.DurationTime - (cl.Sum(c => c.FacilityStopDuration)),
                            MTBF = Math.Round((cl.Average(c => c.DurationTime)) / (Result.Where(q => q.FacilityStopDuration > 0).Count()), 2),
                            FDate = FDate,
                            TDate = TDate,
                            WorkStationName = cc.WorkStationName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => l.WorkStationID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            WorkStationID = cc.WorkStationID,
                            WorkStationName = cc.WorkStationName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            NumberOfStops = Result.Where(q => q.FacilityStopDuration > 0).Count(),
                            Accessibility = cc.DurationTime - (cl.Sum(c => c.FacilityStopDuration)),
                            MTBF = (cl.Average(c => c.DurationTime) / (Result.Where(q => q.FacilityStopDuration > 0).Count())),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllStopMatchinByWorkStation(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;43 '" + FDate + "','" + TDate + "'").ToList();
                var query = Result
               .GroupBy(l => l.WorkStationID)
               .SelectMany(cl => cl.Select(
                       cc => new ReportInfoModel
                       {
                           WorkStationID = cc.WorkStationID,
                           WorkStationName = cc.WorkStationName,
                           FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                           NumberOfStops = Result.Where(q => q.FacilityStopDuration > 0).Count(),
                           Accessibility = cc.DurationTime - (cl.Sum(c => c.FacilityStopDuration)),
                           StopMatchin = ((cl.Sum(c => c.FacilityStopDuration)) / ((cl.Sum(c => c.DurationTime)) - (cl.Sum(c => c.FacilityStopDuration)))) * 100,
                           FDate = FDate,
                           TDate = TDate,
                       }));
                var List = query.GroupBy(x => x.WorkStationID).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllStopReasonByRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 88)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;47 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;46 '" + FDate + "','" + TDate + "'").ToList();
                    Result2 = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;46 '" + FDate + "','" + TDate + "'").ToList();
                }
                if (ReportID == 31)
                {
                    var query = Result
                .GroupBy(l => l.StopReasonID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            StopReasonName = cc.StopReasonName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName,
                        }));
                    var List = query.GroupBy(x => x.StopReasonID).Select(x => x.First());
                    return query.ToList();
                }
                if (ReportID == 32)
                {
                    var query = Result
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = context.MRP_MonthInfos.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            StopReasonName = cc.StopReasonName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return query.ToList();
                }
                else
                {
                    var query = Result
                .GroupBy(l => new { l.StopReasonID })
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            StopReasonName = cc.StopReasonName,
                            FacilityStopDurationTotal = (cl.Sum(c => c.FacilityStopDuration)),
                            FDate = FDate,
                            TDate = TDate,
                            StopReasonID = cc.StopReasonID
                        }));
                    var List = query.GroupBy(x => x.StopReasonID).Select(x => x.First());
                    return List.ToList();
                    //  return Result;
                }
            }
            catch (Exception ex)
            {
                return Result;
            }
        }
        public List<ReportInfoModel> GetAllRepairPartReport(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;48 '" + FDate + "','" + TDate + "'").OrderByDescending(q => q.WastageQuantity).ToList();
                var wastesourcelist = context.PP_WasteSourceInfos.ToList();
                foreach (var c in Result)
                {
                    if (wastesourcelist.Where(q => q.WasteSourceID == c.WasteSourceID).FirstOrDefault() != null)
                    {
                        c.WasteSourceName = wastesourcelist.Where(q => q.WasteSourceID == c.WasteSourceID).FirstOrDefault().WasteSourceName;
                    }
                }
                return Result.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllRepairPartPAretoReport(int WorkStationID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;48 '" + FDate + "','" + TDate + "'").Where(q => q.WorkStationID == WorkStationID).OrderByDescending(q => q.WastageQuantity).ToList();
                var query = Result
              .GroupBy(l => l.PartID)
              .SelectMany(cl => cl.Select(
                      cc => new ReportInfoModel
                      {
                          WorkStationName = cc.WorkStationName,
                          FaultID = cc.FaultID,
                          FaultName = cc.FaultName,
                          AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                          FDate = FDate,
                          TDate = TDate,
                      }));
                var List = query.GroupBy(x => x.FaultID).Select(x => x.First());
                return List.ToList();
                return Result.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllSendToWareHouse(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;55 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                return Result.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllSendToWareHouseByWorkStation(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;56 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                return Result.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllZayeaatPartReport(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;49 '" + FDate + "','" + TDate + "'").ToList();
                var pricelist = context.PP_FactorInfos.ToList();
                var WasteSource = context.PP_WasteSourceInfos.ToList();
                var faultlist = context.PP_FaultInfos.ToList();
                foreach (var c in Result)
                {
                    if (c.WastePartID == 2459)
                    {
                        var dd = 999;
                    }
                    //c.FDate = FDate;
                    //c.TDate = TDate;
                    if (c.WastePartID != 0)
                    {
                        c.WastePartName = context.MRP_PartInfos.Where(q => q.PartID == c.WastePartID).FirstOrDefault().PartName;
                        c.WasteSourceName = (WasteSource.Where(q => q.WasteSourceID == c.WasteSourceID).FirstOrDefault() == null) ? "-" : WasteSource.Where(q => q.WasteSourceID == c.WasteSourceID).FirstOrDefault().WasteSourceName;
                        c.FaultName = (faultlist.Where(q => q.FaultID == c.FaultID).FirstOrDefault() == null) ? "-" : faultlist.Where(q => q.FaultID == c.FaultID).FirstOrDefault().FaultName;
                        c.TDate = TDate;
                        c.FDate = FDate;
                        c.TechnicalNumber = context.MRP_PartInfos.Where(q => q.PartID == c.WastePartID).FirstOrDefault().TechnicalNumber;
                        if (c.WasteSupplierID != 0)
                        {
                            //  var tmpfactor = context.PP_FactorInfos.Where(q => q.SupplierID == c.WasteSupplierID && q.PartID == c.WastePartID).ToList();
                            c.ClientSupplierName = context.PP_PartSupplierInfos.Where(q => q.PartSupplierInfoID == c.WasteSupplierID).FirstOrDefault().PartSupplierInfoName;
                            //foreach (var u in tmpfactor)
                            //{
                            //    var tt = Convert.ToInt32(u.Date.Split('-')[1]);
                            //    if (tt >= c.SelectedMonth - 1)
                            //    {
                            //        c.BargeErsal = u.BargeErsal;
                            //        c.BomNum = u.BomNum;
                            //        break;
                            //    }
                            //}
                            //   var tt = Convert.ToInt32(tmpfactor.FirstOrDefault().Date.Split('-')[1]);
                            var pr = pricelist.Where(q => q.PartID == c.WastePartID).LastOrDefault();
                            c.PartPrice = Convert.ToInt32(c.WastageQuantity * ((pr == null) ? 0 : pr.PartPrice));
                        }
                    }
                    Result2.Add(c);
                }
                return Result2.ToList();
            }
            catch (Exception ex)
            {
                return Result2;
            }
        }
        public List<ReportInfoModel> GetAllZayeatPareto(int WorkStation, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;49 '" + FDate + "','" + TDate + "'").Where(q => q.WorkStationID == WorkStation).OrderByDescending(q => q.WastageQuantity).ToList();
                var query = Result
              .GroupBy(l => l.PartID)
              .SelectMany(cl => cl.Select(
                      cc => new ReportInfoModel
                      {
                          WorkStationName = cc.WorkStationName,
                          PartID = cc.PartID,
                          PartName = cc.PartName,
                          RoutName = cc.RoutName,
                          AVRWasteQuantity = (cl.Sum(c => c.WastageQuantity)),
                          FDate = FDate,
                          TDate = TDate,
                      }));
                var List = query.GroupBy(x => x.PartID).Select(x => x.First());
                return List.ToList();
                return Result.ToList();
            }
            catch (Exception ex)
            {
                return Result2;
            }
        }
        public List<ReportInfoModel> GetAllQuantityByFacility(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;50 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                return Result.ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllNoneBalencingRout(int RoutID, string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                if (ReportID != 110)
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;78 " + RoutID + ",'" + FDate + "','" + TDate + "'").ToList();
                }
                else
                {
                    Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;79 '" + FDate + "','" + TDate + "'").ToList();
                }
                var Result2 = new List<ReportInfoModel>();
                var routfacilitylist = context.PP_RoutFacilityInfos.ToList();
                var facilitystoplist = context.PP_FacilityStopInfos.ToList();
                foreach (var c in Result)
                {
                    var hhh = context.PP_CanbanInfos.Where(q => q.InputOutputID == c.InputOutputID).ToList();
                    if (hhh.Any(q => q.CProcessStageID == 3) == false)
                    {
                        var tt = routfacilitylist.Where(q => q.FaciltiyID == c.FacilityID & q.RoutID == c.RoutID).FirstOrDefault();
                        if (tt != null)
                        {
                            c.DurationTime = Convert.ToInt32(Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList().Average(w => w.DurationTime));
                            var fgh = Convert.ToInt32(facilitystoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID & q.WorkerID == c.WorkersID).ToList().Sum(w => w.FacilityStopDuration));
                            var cyc = tt.TimeDurationMin;
                            if (c.DurationTime > fgh)
                            {
                                var ss = ((c.DurationTime - fgh) * 60) / cyc;
                                c.Efficiency = Convert.ToDouble((c.Quantity) / ss);
                            }
                            if (c.DurationTime <= fgh)
                            {
                                // var ss = ((c.DurationTime - fgh) * 60) / cyc;
                                c.Efficiency = 0;
                            }
                            Result2.Add(c);
                        }
                    }
                }
                var montlist = context.MRP_MonthInfos.ToList();
                if (ReportID == 108)
                {
                    var query = Result2
                .GroupBy(l => l.Day)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            Day = cc.Day,
                            EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName,
                        }));
                    var List = query.GroupBy(x => x.Day).Select(x => x.First());
                    return List.ToList();
                }
                if (ReportID == 109)
                {
                    var query = Result2
                .GroupBy(l => l.SelectedMonth)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            SelectedMonth = cc.SelectedMonth,
                            SelectedMonthName = montlist.Where(q => q.MonthID == cc.SelectedMonth).FirstOrDefault().MonthName,
                            EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                            FDate = FDate,
                            TDate = TDate,
                            RoutName = cc.RoutName,
                        }));
                    var List = query.GroupBy(x => x.SelectedMonth).Select(x => x.First());
                    return List.ToList();
                }
                else
                {
                    var query = Result2
                .GroupBy(l => l.RoutID)
                .SelectMany(cl => cl.Select(
                        cc => new ReportInfoModel
                        {
                            RoutID = cc.RoutID,
                            RoutName = cc.RoutName,
                            EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                            FDate = FDate,
                            TDate = TDate,
                        }));
                    var List = query.GroupBy(x => x.RoutID).Select(x => x.First());
                    return List.ToList();
                }
            }
            catch (Exception ex)
            {
                return Result;
            }
        }
        public List<ReportInfoModel> GetAllDurationTimeAndReworkByWorker(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;81 '" + FDate + "','" + TDate + "'").ToList();
                var Result2 = new List<ReportInfoModel>();
                var wastelist = context.PP_WasteCanbanInfos.ToList();
                foreach (var c in Result)
                {
                    var reworkstatus = wastelist.Where(q => q.InputOutputID == c.InputOutputID && q.WorkerID == c.WorkersID).FirstOrDefault();
                    c.FDate = FDate;
                    c.TDate = TDate;
                    if (reworkstatus != null)
                    {
                        c.ReworkTime = reworkstatus.ReworkTime;
                    }
                    else
                    {
                        c.ReworkTime = 0;
                    }
                    Result2.Add(c);
                }
                return Result2.OrderByDescending(q => q.Day).ToList();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllTolid(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;83 '" + FDate + "','" + TDate + "'").ToList();
                foreach (var c in Result)
                {
                    if (context.PP_WorkersInfos.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault() != null)
                    {
                        c.ResponsibleName = context.PP_WorkersInfos.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault().WorkersSurname;
                    }
                    c.FacilityStopDurationTotal = context.PP_FacilityStopInfos.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID && q.WorkerID == 0).Sum(e => e.FacilityStopDuration);
                    if (c.Shift == 2)
                    {
                        c.ShiftName = "روز";
                    }
                    if (c.Shift == 1)
                    {
                        c.ShiftName = "شب";
                    }
                    if (c.Shift == 3)
                    {
                        c.ShiftName = "عصر";
                    }
                    //else
                    //{
                    //    c.ShiftName = "-";
                    //}
                    c.FDate = FDate;
                    c.TDate = TDate;
                    Result2.Add(c);
                }
                return Result2.OrderByDescending(q => q.Day).ToList();
            }
            catch (Exception ex)
            {
                var tt = Result2;
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllTolidPersonel(string FDate, string TDate, int ReportID)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;84 '" + FDate + "','" + TDate + "'").Where(q => q.WorkerID > 0).ToList();
                var workerlist = context.PP_WorkersInfos.ToList();
                var workerschedullist = context.PP_WorkersScheduleInfos.ToList();
                var facilityroutlist = context.PP_RoutFacilityInfos.ToList();
                var facilitylist = context.PP_FacilityInfos.ToList();
                foreach (var c in Result)
                {
                    if (workerschedullist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID && q.WorkersID == c.WorkerID).FirstOrDefault() != null)
                    {
                        var facilityid = workerschedullist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID && q.WorkersID == c.WorkerID).FirstOrDefault().FacilityID;
                        c.FacilityName = facilitylist.Where(q => q.FacilityID == facilityid).FirstOrDefault().FacilityName;
                        if (workerlist.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault() != null)
                        {
                            c.ResponsibleName = workerlist.Where(q => q.WorkersID == c.ResponsibleID).FirstOrDefault().WorkersSurname;
                        }
                        var yh = workerlist.Where(q => q.WorkersID == c.WorkerID).FirstOrDefault();
                        if (yh != null)
                        {
                            c.WorkerName = yh.WorkersSurname;
                            c.WorkersCode = yh.WorkersCode;
                        }
                        if (facilityroutlist.Where(q => q.FaciltiyID == facilityid).FirstOrDefault() != null)
                        {
                            c.CycleTime = Math.Round((double)facilityroutlist.Where(q => q.FaciltiyID == facilityid).FirstOrDefault().TimeDurationMin);
                        }
                        c.FacilityStopDurationTotal = Convert.ToInt32(context.PP_FacilityStopInfos.Where(q => q.WorkerID == c.WorkerID && q.ScheduleProductionLineID == c.ScheduleProductionLineID).Sum(w => w.FacilityStopDuration)) + Convert.ToInt32(context.PP_FacilityStopInfos.Where(q => q.WorkerID == 0 && q.ScheduleProductionLineID == c.ScheduleProductionLineID).Sum(w => w.FacilityStopDuration));
                        if (c.Shift == 2)
                        {
                            c.ShiftName = "روز";
                        }
                        if (c.Shift == 1)
                        {
                            c.ShiftName = "شب";
                        }
                        if (c.Shift == 3)
                        {
                            c.ShiftName = "عصر";
                        }
                        //else
                        //{
                        //    c.ShiftName = "-";
                        //}
                        c.FDate = FDate;
                        c.TDate = TDate;
                        Result2.Add(c);
                    }
                }
                return Result2.OrderByDescending(q => q.Day).ToList();
            }
            catch (Exception ex)
            {
                var tt = Result2;
            }
            return Result;
        }
        public List<ReportInfoModel> GetAllEfficiencyRoutByWorker(int RoutID, string FDate, string TDate)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var routfacilitylist = context.PP_RoutFacilityInfos.ToList();
            var facilitystoplist = context.PP_FacilityStopInfos.ToList();
            var workerschedullist = context.PP_WorkersScheduleInfos.ToList();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;141 '" + FDate + "','" + TDate + "'").Where(q => q.RoutID == RoutID).ToList();
                foreach (var c in Result)
                {
                    var schedullist = Result.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID).ToList();
                    c.DurationTime = Convert.ToInt32(schedullist.Average(q => q.DurationTime));
                    var facility = workerschedullist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID && q.WorkersID == c.WorkerID).FirstOrDefault().FacilityID;
                    c.TimeDurationMin = (double)routfacilitylist.Where(q => q.FaciltiyID == facility && q.RoutID == c.RoutID).FirstOrDefault().TimeDurationMin;
                    var stopfacility = facilitystoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID && q.FacilityID == facility).FirstOrDefault();
                    var stopworker = facilitystoplist.Where(q => q.ScheduleProductionLineID == c.ScheduleProductionLineID && q.WorkerID == c.WorkerID).FirstOrDefault();
                    var fgh = 0;
                    if (stopfacility != null)
                    {
                        fgh = (int)stopfacility.FacilityStopDuration;
                    }
                    if (stopworker != null)
                    {
                        fgh = (int)stopworker.FacilityStopDuration;
                    }
                    if (c.DurationTime > fgh)
                    {
                        var ss = ((c.DurationTime - fgh) * 60) / c.TimeDurationMin;
                        c.Efficiency = Convert.ToDouble((c.Quantity) / ss);
                    }
                    if (c.DurationTime <= fgh)
                    {
                        // var ss = ((c.DurationTime - fgh) * 60) / cyc;
                        c.Efficiency = 0;
                    }
                    Result2.Add(c);
                }
                var query = Result2
              .GroupBy(x => new { x.WorkerID, x.RoutID })
               .SelectMany(cl => cl.Select(
                       cc => new ReportInfoModel
                       {
                           WorkerID = cc.WorkerID,
                           RoutID = cc.RoutID,
                           RoutName = cc.RoutName,
                           EfficiencyTotal = Math.Round((cl.Average(c => c.Efficiency)) * 100),
                           FDate = FDate,
                           TDate = TDate,
                           WorkerName = cc.WorkerName
                       }));
                var List = query.GroupBy(x => new { x.WorkerID, x.RoutID }).Select(x => x.First());
                return List.ToList();
            }
            catch (Exception e)
            {
                return Result2;
            }
        }
        public List<ReportInfoModel> GetAllFactor(string FDate, string TDate)
        {
            var Result = new List<ReportInfoModel>();
            var Result2 = new List<ReportInfoModel>();
            var wastelist = context.PP_WasteCanbanInfos.ToList();
            var workerlist = context.PP_WorkersInfos.ToList();
            var partlist = context.MRP_PartInfos.ToList();
            var fultlist = context.PP_FaultInfos.ToList();
            var inputoutputlist = context.PP_InputOutputInfos.ToList();
            var routlist = context.PP_RoutInfos.ToList();
            var schedullist = context.PP_ScheduleProductionLineInfos.ToList();
            var ttt = new List<int>();
            try
            {
                Result = context.ExecuteQuery<ReportInfoModel>("exec dbo.PICS_Report;142 '" + FDate + "','" + TDate + "'").OrderByDescending(w => w.Day).ToList();
                foreach (var f in Result)
                {
                    ttt.Add((int)f.PartID);
                    var wasteitmlist = wastelist.Where(q => q.WastePartID == f.PartID && q.ActionID== 16).ToList();
                    f.FDate = FDate;
                    f.TDate = TDate;
                    if (wasteitmlist.Count > 0)
                    {
                        foreach (var wasteitm in wasteitmlist)
                        {
                            if (wasteitm.BOM != null && wasteitm.BOM != "انتخاب کنید")
                            {
                                if (wasteitm.BOM != "")
                                {
                                    var aa = wasteitm.BOM.Substring(0, wasteitm.BOM.IndexOf("-")).Trim();
                                    var bb = wasteitm.BOM.Substring(wasteitm.BOM.LastIndexOf('-') + 1);
                                    if (aa == f.BargeErsal && bb == f.BomNum)
                                    {
                                        if (wasteitm.TaminID != null)
                                        {
                                            f.TaminName = context.PP_Tamins.Where(q => q.TaminID == wasteitm.TaminID).FirstOrDefault().TaminName;
                                        }
                                        var schedulid = inputoutputlist.Where(q => q.InputOutputID == wasteitm.InputOutputID).FirstOrDefault();
                                        if (schedulid != null)
                                        {
                                            var routid = schedullist.Where(q => q.ScheduleProductionLineID == schedulid.ScheduleProductionLineID).FirstOrDefault();
                                            if (routid != null)
                                            {
                                                f.Day = schedullist.Where(q => q.ScheduleProductionLineID == schedulid.ScheduleProductionLineID).FirstOrDefault().Date;
                                                if (wasteitm.WCProcessStageID != null)
                                                {
                                                    f.WCProcessStageName = context.PP_ProcessStageInfos.Where(q => q.ProcessStageID == wasteitm.WCProcessStageID).FirstOrDefault().ProcessStageName;
                                                }
                                                f.RoutName = routlist.Where(q => q.RoutID == routid.RoutID).FirstOrDefault().RoutName;
                                                f.AVRWasteQuantity = wasteitm.WastageQuantity;
                                                f.BOM = wasteitm.BOM;
                                                f.PartPrice = Convert.ToInt32(wasteitm.WastageQuantity * f.Price);
                                                f.TahviliPrice = Convert.ToInt32(f.PartCount * f.Price);
                                                f.CostPersentOfWaste = (int)((wasteitm.WastageQuantity * 100) / f.PartCount);
                                                if (wasteitm.WorkerID != null && wasteitm.WorkerID != 0)
                                                {
                                                    f.WorkerName = workerlist.Where(w => w.WorkersID == wasteitm.WorkerID).FirstOrDefault().WorkersSurname;
                                                }
                                                f.PartName = partlist.Where(q => q.PartID == wasteitm.WastePartID).FirstOrDefault().PartName;
                                                if (wasteitm.FaultID != null)
                                                {
                                                    f.FaultName = fultlist.Where(q => q.FaultID == wasteitm.FaultID).FirstOrDefault().FaultName;
                                                }
                                            }
                                        }
                                        Result2.Add(f);
                                    }
                                    else
                                    {
                                        f.PartName = partlist.Where(q => q.PartID == f.PartID).FirstOrDefault().PartName;
                                        f.BOM = f.BomNum + "-" + f.BargeErsal;
                                        // f.TahviliPrice = Convert.ToInt32(f.PartCount * f.Price);
                                        f.AVRWasteQuantity = 0;
                                        Result2.Add(f);
                                    }
                                }
                            }
                            else
                            {
                                f.PartName = partlist.Where(q => q.PartID == f.PartID).FirstOrDefault().PartName;
                                f.BOM = f.BomNum + "-" + f.BargeErsal;
                                // f.TahviliPrice = Convert.ToInt32(f.PartCount * f.Price);
                                f.AVRWasteQuantity = 0;
                                Result2.Add(f);
                            }
                        }
                    }
                    else
                    {
                        f.PartName = partlist.Where(q => q.PartID == f.PartID).FirstOrDefault().PartName;
                        f.BOM = f.BomNum + "-" + f.BargeErsal;
                        // f.TahviliPrice = Convert.ToInt32(f.PartCount * f.Price);
                        f.AVRWasteQuantity = 0;
                        Result2.Add(f);
                    }
                    //  }
                }
              //  var tt = Result2.RemoveAll(q => q.AVRWasteQuantity == 0 && q.TaminName != null);
                return Result2.Distinct().ToList();
            }
            catch (Exception e)
            {
                var yy = ttt;
                return Result2;
            }
        }
    }
}
