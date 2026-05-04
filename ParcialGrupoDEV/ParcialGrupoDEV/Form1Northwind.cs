using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using ParcialGrupoDEV.BLL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialGrupoDEV
{
    public partial class Form1Northwind : Form
    {
        private readonly NorthwindService _nwService = new NorthwindService();
        public Form1Northwind()
        {
            InitializeComponent();
            // Inicializar opciones de consultas
            cmbBasic.Items.AddRange(new object[] { "Clientes", "Productos", "Pedidos", "Productos bajo stock (<20)" });
            cmbInter.Items.AddRange(new object[] { "Ventas por cliente", "Pedidos en rango de fechas", "Total vendido por producto" });
            cmbAvan.Items.AddRange(new object[] { "Top 10 clientes por gasto", "Clientes con promedio de pedido alto", "Productos por diversidad de clientes" });
            if (cmbBasic.Items.Count > 0) cmbBasic.SelectedIndex = 0;
            if (cmbInter.Items.Count > 0) cmbInter.SelectedIndex = 0;
            if (cmbAvan.Items.Count > 0) cmbAvan.SelectedIndex = 0;
        }

        private void btnConsulBasic_Click(object sender, EventArgs e)
        {
            try
            {
                var opcion = (cmbBasic.SelectedItem ?? string.Empty).ToString();
                switch (opcion)
                {
                    case "Clientes":
                        dgvConsulNorthwind.DataSource = _nwService.GetBasicCustomers();
                        break;
                    case "Productos":
                        dgvConsulNorthwind.DataSource = _nwService.GetBasicProducts();
                        break;
                    case "Pedidos":
                        dgvConsulNorthwind.DataSource = _nwService.GetBasicOrders();
                        break;
                    case "Productos bajo stock (<20)":
                        dgvConsulNorthwind.DataSource = _nwService.GetLowStockProducts();
                        break;
                    default:
                        dgvConsulNorthwind.DataSource = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando consulta básica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsulInter_Click(object sender, EventArgs e)
        {
            try
            {
                var opcion = (cmbInter.SelectedItem ?? string.Empty).ToString();
                switch (opcion)
                {
                    case "Ventas por cliente":
                        dgvConsulNorthwind.DataSource = _nwService.GetSalesByCustomer();
                        break;
                    case "Pedidos en rango de fechas":
                        var start = new DateTime(1997, 1, 1);
                        var end = new DateTime(1998, 12, 31);
                        dgvConsulNorthwind.DataSource = _nwService.GetOrdersInRange(start, end);
                        break;
                    case "Total vendido por producto":
                        dgvConsulNorthwind.DataSource = _nwService.GetSalesByProduct();
                        break;
                    default:
                        dgvConsulNorthwind.DataSource = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando consulta intermedia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsulAvan_Click(object sender, EventArgs e)
        {
            try
            {
                var opcion = (cmbAvan.SelectedItem ?? string.Empty).ToString();
                switch (opcion)
                {
                    case "Top 10 clientes por gasto":
                        dgvConsulNorthwind.DataSource = _nwService.GetTopCustomers(10);
                        break;
                    case "Clientes con promedio de pedido alto":
                        dgvConsulNorthwind.DataSource = _nwService.GetCustomersWithHighAverage(500m);
                        break;
                    case "Productos por diversidad de clientes":
                        dgvConsulNorthwind.DataSource = _nwService.GetProductsByCustomerDiversity(20);
                        break;
                    default:
                        dgvConsulNorthwind.DataSource = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando consulta avanzada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
