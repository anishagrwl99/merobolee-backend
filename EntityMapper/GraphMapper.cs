using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class GraphMapper
    {
        public BidInviterGraphDto ToBidInviterGraph(List<TenderEntity> tenders)
        {
            if (tenders != null && tenders.Count > 0)
            {
                BidInviterGraphDto dto = new BidInviterGraphDto
                {
                    PendingByCategory = new List<GraphPoint>(),
                    CompletedByCategory = new List<GraphPoint>(),
                    PendingByMonth = new List<GraphPoint>(),
                    CompletedByMonth = new List<GraphPoint>()
                };

                dto.PendingByMonth = (from t in tenders
                                      where t.Live_Start_Date >= DateTime.Now && DateTime.Now <= t.Live_End_Date
                                      group t by new { t.Date_created.Year, t.Date_created.Month } into g
                                      select new GraphPoint
                                      {
                                          Key = new DateTime(g.Key.Year, g.Key.Month, DateTime.DaysInMonth(g.Key.Year, g.Key.Month)).ToString(),
                                          Value = g.Count().ToString()
                                      }
                                 ).ToList();

                dto.CompletedByMonth = (from t in tenders
                                        where t.Live_End_Date < DateTime.Now
                                        group t by new { t.Date_created.Year, t.Date_created.Month } into g
                                        select new GraphPoint
                                        {
                                            Key = new DateTime(g.Key.Year, g.Key.Month, DateTime.DaysInMonth(g.Key.Year, g.Key.Month)).ToString(),
                                            Value = g.Count().ToString()
                                        }
                                 ).ToList();

                dto.PendingByCategory = (from t in tenders
                                         where t.Live_Start_Date >= DateTime.Now && DateTime.Now <= t.Live_End_Date
                                         group t by new { t.CategoryEntity.Category } into g
                                         select new GraphPoint
                                         {
                                             Key = g.Key.Category,
                                             Value = g.Count().ToString()
                                         }
                                 ).ToList();

                dto.CompletedByCategory = (from t in tenders
                                           where t.Live_End_Date < DateTime.Now
                                           group t by new { t.CategoryEntity.Category } into g
                                           select new GraphPoint
                                           {
                                               Key = g.Key.Category,
                                               Value = g.Count().ToString()
                                           }
                                 ).ToList();



                /*
                List<TenderSubmission> completed = submissions.Where(x => x.StatusId == 4).ToList();
                List<TenderSubmission> invited = submissions.Where(x => x.StatusId == 3).ToList();
                List<TenderSubmission> pending = submissions.Where(x => x.StatusId == 1 || x.StatusId == 2).ToList();

                foreach (var item in completed)
                {
                    dto.Completed.Add(new GraphPoint
                    {
                        Key = new DateTime(item.Date_created.Year, item.Date_created.Month, item.Date_created.Day).ToString(),
                        Value = "1"
                    });
                }

                foreach (var item in invited)
                {
                    dto.Invited.Add(new GraphPoint
                    {
                        Key = new DateTime(item.Date_created.Year, item.Date_created.Month, item.Date_created.Day).ToString(),
                        Value = "1"
                    });
                }

                foreach (var item in pending)
                {
                    dto.Pending.Add(new GraphPoint
                    {
                        Key = new DateTime(item.Date_created.Year, item.Date_created.Month, item.Date_created.Day).ToString(),
                        Value = "1"
                    });
                }
                */
                return dto;
            }
            return null;
        }

        public SupplierGraphDto ToSupplierGraph(List<TenderEntity> registeredTenders, List<TenderEntity> wonTenders)
        {
            SupplierGraphDto dto = null;
            if (registeredTenders != null & registeredTenders.Count > 0)
            {
                dto = new SupplierGraphDto();
                dto.RegisteredByCategory = new List<GraphPoint>();
                dto.RegisteredByMonth = new List<GraphPoint>();
            }

            if (wonTenders != null & wonTenders.Count > 0)
            {
                if (dto == null)
                {
                    dto = new SupplierGraphDto();
                }
                dto.WonByCategory = new List<GraphPoint>();
                dto.WonByMonth = new List<GraphPoint>();
            }

            if (dto != null)
            {
                dto.RegisteredByCategory = (from t in registeredTenders
                                            group t by new { t.CategoryEntity.Category } into g
                                            select new GraphPoint
                                            {
                                                Key = g.Key.Category,
                                                Value = g.Count().ToString()
                                            }
                                    ).ToList();


                dto.RegisteredByMonth = (from t in registeredTenders
                                         group t by new { t.Date_created.Year, t.Date_created.Month } into g
                                         select new GraphPoint
                                         {
                                             Key = new DateTime(g.Key.Year, g.Key.Month, DateTime.DaysInMonth(g.Key.Year, g.Key.Month)).ToString(),
                                             Value = g.Count().ToString()
                                         }
                                     ).ToList();


                dto.WonByCategory = (from t in wonTenders
                                     group t by new { t.CategoryEntity.Category } into g
                                     select new GraphPoint
                                     {
                                         Key = g.Key.Category,
                                         Value = g.Count().ToString()
                                     }
                                    ).ToList();


                dto.WonByMonth = (from t in wonTenders
                                  group t by new { t.Date_created.Year, t.Date_created.Month } into g
                                  select new GraphPoint
                                  {
                                      Key = new DateTime(g.Key.Year, g.Key.Month, DateTime.DaysInMonth(g.Key.Year, g.Key.Month)).ToString(),
                                      Value = g.Count().ToString()
                                  }
                                     ).ToList();
                return dto;
            }
            return null;
        }
    }
}
