using System;
using System.Collections.Generic;

namespace ParcialGrupoDEV.BLL
{
    public class CustomerBasicDto
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class ProductBasicDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }

    public class OrderBasicDto
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
    }

    public class SalesByCustomerDto
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public decimal TotalVentas { get; set; }
    }

    public class OrdersRangeDto
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
    }

    public class SalesByProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int TotalCantidad { get; set; }
        public decimal TotalVentas { get; set; }
    }

    public class TopCustomerDto
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public decimal TotalGastado { get; set; }
        public int Pedidos { get; set; }
    }

    public class CustomerAverageDto
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public decimal PromedioPorPedido { get; set; }
    }

    public class ProductDiversityDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int DistintosClientes { get; set; }
        public decimal TotalVentas { get; set; }
    }
}
