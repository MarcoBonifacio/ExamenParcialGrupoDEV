using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcialGrupoDEV.BLL
{
    public class NorthwindService
    {
        public List<CustomerBasicDto> GetBasicCustomers()
        {
            using (var ctx = new NorthwindEntities())
            {
                return ctx.Customers
                    .Select(c => new CustomerBasicDto { CustomerID = c.CustomerID, CompanyName = c.CompanyName, ContactName = c.ContactName, City = c.City, Country = c.Country })
                    .OrderBy(x => x.CompanyName)
                    .ToList();
            }
        }

        public List<ProductBasicDto> GetBasicProducts()
        {
            using (var ctx = new NorthwindEntities())
            {
                return ctx.Products
                    .Select(p => new ProductBasicDto { ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, Discontinued = p.Discontinued })
                    .OrderBy(x => x.ProductName)
                    .ToList();
            }
        }

        public List<OrderBasicDto> GetBasicOrders()
        {
            using (var ctx = new NorthwindEntities())
            {
                return ctx.Orders
                    .Select(o => new OrderBasicDto { OrderID = o.OrderID, CustomerID = o.CustomerID, OrderDate = o.OrderDate, ShippedDate = o.ShippedDate, Freight = o.Freight })
                    .OrderByDescending(x => x.OrderDate)
                    .ToList();
            }
        }

        public List<ProductBasicDto> GetLowStockProducts(int threshold = 20)
        {
            using (var ctx = new NorthwindEntities())
            {
                return ctx.Products
                    .Where(p => p.UnitsInStock < threshold)
                    .Select(p => new ProductBasicDto { ProductID = p.ProductID, ProductName = p.ProductName, UnitsInStock = p.UnitsInStock })
                    .OrderBy(x => x.UnitsInStock)
                    .ToList();
            }
        }

        public List<SalesByCustomerDto> GetSalesByCustomer()
        {
            using (var ctx = new NorthwindEntities())
            {
                var orders = ctx.Orders.Include("Order_Details").Include("Customers").ToList();
                var result = orders
                    .Where(o => o.Order_Details != null && o.Order_Details.Any())
                    .GroupBy(o => new { o.CustomerID, CompanyName = o.Customers != null ? o.Customers.CompanyName : string.Empty })
                    .Select(g => new SalesByCustomerDto
                    {
                        CustomerID = g.Key.CustomerID,
                        CompanyName = g.Key.CompanyName,
                        TotalVentas = g.SelectMany(o => o.Order_Details).Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
                    })
                    .OrderByDescending(x => x.TotalVentas)
                    .ToList();

                return result;
            }
        }

        public List<OrdersRangeDto> GetOrdersInRange(DateTime start, DateTime end)
        {
            using (var ctx = new NorthwindEntities())
            {
                return ctx.Orders
                    .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                    .Select(o => new OrdersRangeDto { OrderID = o.OrderID, CustomerID = o.CustomerID, OrderDate = o.OrderDate, ShippedDate = o.ShippedDate, Freight = o.Freight })
                    .OrderBy(o => o.OrderDate)
                    .ToList();
            }
        }

        public List<SalesByProductDto> GetSalesByProduct()
        {
            using (var ctx = new NorthwindEntities())
            {
                var ods = ctx.Order_Details.Include("Products").ToList();
                var result = ods
                    .GroupBy(od => new { od.ProductID, ProductName = od.Products != null ? od.Products.ProductName : string.Empty })
                    .Select(g => new SalesByProductDto
                    {
                        ProductID = g.Key.ProductID,
                        ProductName = g.Key.ProductName,
                        TotalCantidad = g.Sum(x => (int)x.Quantity),
                        TotalVentas = g.Sum(x => x.UnitPrice * x.Quantity * (1 - (decimal)x.Discount))
                    })
                    .OrderByDescending(x => x.TotalVentas)
                    .ToList();

                return result;
            }
        }

        public List<TopCustomerDto> GetTopCustomers(int top = 10)
        {
            using (var ctx = new NorthwindEntities())
            {
                var customers = ctx.Customers.Include("Orders.Order_Details").ToList();
                var result = customers
                    .Select(c => new TopCustomerDto
                    {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        TotalGastado = c.Orders.SelectMany(o => o.Order_Details).Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount)),
                        Pedidos = c.Orders.Count()
                    })
                    .OrderByDescending(x => x.TotalGastado)
                    .Take(top)
                    .ToList();

                return result;
            }
        }

        public List<CustomerAverageDto> GetCustomersWithHighAverage(decimal threshold)
        {
            using (var ctx = new NorthwindEntities())
            {
                var customers = ctx.Customers.Include("Orders.Order_Details").ToList();
                var result = customers
                    .Select(c => new CustomerAverageDto
                    {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        PromedioPorPedido = c.Orders != null && c.Orders.Any()
                            ? c.Orders.Select(o => o.Order_Details.Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))).DefaultIfEmpty(0m).Average()
                            : 0m
                    })
                    .Where(x => x.PromedioPorPedido > threshold)
                    .OrderByDescending(x => x.PromedioPorPedido)
                    .ToList();

                return result;
            }
        }

        public List<ProductDiversityDto> GetProductsByCustomerDiversity(int top = 20)
        {
            using (var ctx = new NorthwindEntities())
            {
                var ods = ctx.Order_Details.Include("Orders").Include("Products").ToList();
                var result = ods
                    .GroupBy(od => new { od.ProductID, ProductName = od.Products != null ? od.Products.ProductName : string.Empty })
                    .Select(g => new ProductDiversityDto
                    {
                        ProductID = g.Key.ProductID,
                        ProductName = g.Key.ProductName,
                        DistintosClientes = g.Select(x => x.Orders != null ? x.Orders.CustomerID : null).Distinct().Count(x => x != null),
                        TotalVentas = g.Sum(x => x.UnitPrice * x.Quantity * (1 - (decimal)x.Discount))
                    })
                    .OrderByDescending(x => x.DistintosClientes)
                    .ThenByDescending(x => x.TotalVentas)
                    .Take(top)
                    .ToList();

                return result;
            }
        }
    }
}
