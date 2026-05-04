using System;
using System.Collections.Generic;

namespace ParcialGrupoDEV.BLL
{
    public class PublisherDto
    {
        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class TitleDto
    {
        public string TitleId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public int? YtdSales { get; set; }
    }

    public class AuthorDto
    {
        public string AuId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class TitleSalesDto
    {
        public string TitleId { get; set; }
        public string Title { get; set; }
        public int TotalCantidad { get; set; }
    }

    public class SalesRangeDtoPubs
    {
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public string TitleId { get; set; }
        public short Qty { get; set; }
    }

    public class RevenueByPublisherDto
    {
        public string PubID { get; set; }
        public string PubName { get; set; }
        public decimal TotalIngresos { get; set; }
    }

    public class TopTitleDto
    {
        public string TitleID { get; set; }
        public string Title { get; set; }
        public decimal Ingreso { get; set; }
    }

    public class AuthorAverageDto
    {
        public string AuthorID { get; set; }
        public string Name { get; set; }
        public decimal PromedioIngreso { get; set; }
    }

    public class TitleDiversityDto
    {
        public string TitleID { get; set; }
        public string Title { get; set; }
        public int DistintasTiendas { get; set; }
        public int TotalCantidad { get; set; }
    }
}
