using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcialGrupoDEV.BLL
{
    public class PubsService
    {
        public List<PublisherDto> GetPublishers()
        {
            using (var ctx = new pubsEntities())
            {
                return ctx.publishers
                    .Select(p => new PublisherDto { PubId = p.pub_id, PubName = p.pub_name, City = p.city, Country = p.country })
                    .OrderBy(p => p.PubName)
                    .ToList();
            }
        }

        public List<TitleDto> GetTitles()
        {
            using (var ctx = new pubsEntities())
            {
                return ctx.titles
                    .Select(t => new TitleDto { TitleId = t.title_id, Title = t.title, Type = t.type, Price = t.price, YtdSales = t.ytd_sales })
                    .OrderBy(t => t.Title)
                    .ToList();
            }
        }

        public List<AuthorDto> GetAuthors()
        {
            using (var ctx = new pubsEntities())
            {
                return ctx.authors
                    .Select(a => new AuthorDto { AuId = a.au_id, Name = a.au_fname + " " + a.au_lname, City = a.city })
                    .OrderBy(a => a.Name)
                    .ToList();
            }
        }

        public List<TitleDto> GetLowSalesTitles(int threshold = 50)
        {
            using (var ctx = new pubsEntities())
            {
                return ctx.titles
                    .Where(t => t.ytd_sales < threshold)
                    .Select(t => new TitleDto { TitleId = t.title_id, Title = t.title, YtdSales = t.ytd_sales, Price = t.price })
                    .OrderBy(t => t.YtdSales)
                    .ToList();
            }
        }

        public List<TitleSalesDto> GetSalesByTitle()
        {
            using (var ctx = new pubsEntities())
            {
                var sales = ctx.sales.ToList();
                var titles = ctx.titles.ToList();
                var result = sales
                    .GroupBy(s => new { s.title_id, Title = titles.FirstOrDefault(t => t.title_id == s.title_id)?.title })
                    .Select(g => new TitleSalesDto { TitleId = g.Key.title_id, Title = g.Key.Title, TotalCantidad = g.Sum(x => x.qty) })
                    .OrderByDescending(x => x.TotalCantidad)
                    .ToList();
                return result;
            }
        }

        public List<SalesRangeDtoPubs> GetSalesInRange(DateTime start, DateTime end)
        {
            using (var ctx = new pubsEntities())
            {
                return ctx.sales
                    .Where(s => s.ord_date >= start && s.ord_date <= end)
                    .Select(s => new SalesRangeDtoPubs { OrdNum = s.ord_num, OrdDate = s.ord_date, TitleId = s.title_id, Qty = s.qty })
                    .OrderBy(s => s.OrdDate)
                    .ToList();
            }
        }

        public List<RevenueByPublisherDto> GetRevenueByPublisher()
        {
            using (var ctx = new pubsEntities())
            {
                var sales = ctx.sales.ToList();
                var titles = ctx.titles.ToList();
                var joined = sales.Join(titles, s => s.title_id, t => t.title_id, (s, t) => new { s, t });
                var result = joined
                    .GroupBy(x => new { x.t.pub_id, PubName = x.t.publishers != null ? x.t.publishers.pub_name : string.Empty })
                    .Select(g => new RevenueByPublisherDto { PubID = g.Key.pub_id, PubName = g.Key.PubName, TotalIngresos = g.Sum(x => x.s.qty * (x.t.price ?? 0m)) })
                    .OrderByDescending(x => x.TotalIngresos)
                    .ToList();
                return result;
            }
        }

        public List<TopTitleDto> GetTopTitles(int top = 10)
        {
            using (var ctx = new pubsEntities())
            {
                var sales = ctx.sales.ToList();
                var titles = ctx.titles.ToList();
                var joined = sales.Join(titles, s => s.title_id, t => t.title_id, (s, t) => new { s, t });
                var result = joined
                    .GroupBy(x => new { x.t.title_id, x.t.title })
                    .Select(g => new TopTitleDto { TitleID = g.Key.title_id, Title = g.Key.title, Ingreso = g.Sum(x => x.s.qty * (x.t.price ?? 0m)) })
                    .OrderByDescending(x => x.Ingreso)
                    .Take(top)
                    .ToList();
                return result;
            }
        }

        public List<AuthorAverageDto> GetAuthorsWithHighAverage(decimal threshold)
        {
            using (var ctx = new pubsEntities())
            {
                var allTitles = ctx.titles.ToList();
                var priceByTitle = allTitles.ToDictionary(t => t.title_id, t => (t.price ?? 0m));
                var allSales = ctx.sales.ToList();
                var ingresosPorTitulo = allSales
                    .GroupBy(s => s.title_id)
                    .ToDictionary(g => g.Key, g => g.Sum(s => s.qty * (priceByTitle.ContainsKey(g.Key) ? priceByTitle[g.Key] : 0m)));

                var result = ctx.titleauthor
                    .ToList()
                    .GroupBy(ta => new { ta.au_id, ta.authors.au_fname, ta.authors.au_lname })
                    .Select(g => new AuthorAverageDto
                    {
                        AuthorID = g.Key.au_id,
                        Name = g.Key.au_fname + " " + g.Key.au_lname,
                        PromedioIngreso = g.Select(ta => ta.title_id)
                            .Where(tid => !string.IsNullOrEmpty(tid))
                            .Select(tid => ingresosPorTitulo.ContainsKey(tid) ? ingresosPorTitulo[tid] : 0m)
                            .DefaultIfEmpty(0m)
                            .Average()
                    })
                    .Where(x => x.PromedioIngreso > threshold)
                    .OrderByDescending(x => x.PromedioIngreso)
                    .ToList();

                return result;
            }
        }

        public List<TitleDiversityDto> GetTitlesByStoreDiversity(int top = 20)
        {
            using (var ctx = new pubsEntities())
            {
                var sales = ctx.sales.ToList();
                var titles = ctx.titles.ToList();
                var result = sales
                    .GroupBy(s => new { s.title_id, Title = titles.FirstOrDefault(t => t.title_id == s.title_id)?.title })
                    .Select(g => new TitleDiversityDto
                    {
                        TitleID = g.Key.title_id,
                        Title = g.Key.Title,
                        DistintasTiendas = g.Select(x => x.stor_id).Distinct().Count(),
                        TotalCantidad = g.Sum(x => x.qty)
                    })
                    .OrderByDescending(x => x.DistintasTiendas)
                    .ThenByDescending(x => x.TotalCantidad)
                    .Take(top)
                    .ToList();
                return result;
            }
        }
    }
}
