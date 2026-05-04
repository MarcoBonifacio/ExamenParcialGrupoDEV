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
    public partial class Form2Pubs : Form
    {
        private readonly PubsService _pubsService = new PubsService();
        public Form2Pubs()
        {
            InitializeComponent();
            // Inicializar ComboBoxes
            cmbBasic.Items.AddRange(new object[] { "Publishers", "Titles", "Authors", "Titles con ventas bajas (<50)" });
            cmbInter.Items.AddRange(new object[] { "Ventas por título", "Ventas en rango de fechas", "Ingresos por editorial" });
            cmbAvan.Items.AddRange(new object[] { "Top 10 títulos por ingreso", "Autores con promedio de ingreso alto", "Títulos por diversidad de tiendas" });
            if (cmbBasic.Items.Count > 0) cmbBasic.SelectedIndex = 0;
            if (cmbInter.Items.Count > 0) cmbInter.SelectedIndex = 0;
            if (cmbAvan.Items.Count > 0) cmbAvan.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2Pubs_Load(object sender, EventArgs e)
        {

        }

        private void btnConsulBasic_Click(object sender, EventArgs e)
        {
            try
            {
                var opcion = (cmbBasic.SelectedItem ?? string.Empty).ToString();
                switch (opcion)
                {
                    case "Publishers":
                        dgvConsulPubs.DataSource = _pubsService.GetPublishers();
                        break;
                    case "Titles":
                        dgvConsulPubs.DataSource = _pubsService.GetTitles();
                        break;
                    case "Authors":
                        dgvConsulPubs.DataSource = _pubsService.GetAuthors();
                        break;
                    case "Titles con ventas bajas (<50)":
                        dgvConsulPubs.DataSource = _pubsService.GetLowSalesTitles();
                        break;
                    default:
                        dgvConsulPubs.DataSource = null;
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
                    case "Ventas por título":
                        dgvConsulPubs.DataSource = _pubsService.GetSalesByTitle();
                        break;
                    case "Ventas en rango de fechas":
                        var start = new DateTime(1996, 1, 1);
                        var end = new DateTime(1997, 12, 31);
                        dgvConsulPubs.DataSource = _pubsService.GetSalesInRange(start, end);
                        break;
                    case "Ingresos por editorial":
                        dgvConsulPubs.DataSource = _pubsService.GetRevenueByPublisher();
                        break;
                    default:
                        dgvConsulPubs.DataSource = null;
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
                    case "Top 10 títulos por ingreso":
                        dgvConsulPubs.DataSource = _pubsService.GetTopTitles(10);
                        break;
                    case "Autores con promedio de ingreso alto":
                        dgvConsulPubs.DataSource = _pubsService.GetAuthorsWithHighAverage(10000m);
                        break;
                    case "Títulos por diversidad de tiendas":
                        dgvConsulPubs.DataSource = _pubsService.GetTitlesByStoreDiversity(20);
                        break;
                    default:
                        dgvConsulPubs.DataSource = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando consulta avanzada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
