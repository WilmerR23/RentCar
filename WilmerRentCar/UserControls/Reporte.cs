using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace WilmerRentCar.UserControls
{
    public partial class Reporte : BaseUserControl
    {
        public Reporte()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void putReport()
        {
            var dtp1 = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            var dtp2 = Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy-MM-dd");
            // Set the processing mode for the ReportViewer to Local  
            reportViewer2.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = reportViewer2.LocalReport;

            var path = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName) + "\\Reporte\\ReportFecha.rdlc";
            localReport.ReportPath = path;
            localReport.DataSources.Clear();

            string query = string.Format(@"SELECT [Id] Numero
                                                ,[Renta] Renta
                                                ,(SELECT CONCAT(v.Placa, ' - ', ma.Nombre, ',', mo.Nombre) FROM Vehículo v INNER JOIN Marcas ma ON v.MarcaId = ma.Id INNER JOIN Modeloes mo ON v.ModeloId = mo.Id WHERE v.Id = rd.VehiculoId) Vehiculo
                                                ,(SELECT p.Nombre FROM Clientes c INNER JOIN Personas p ON c.PersonaId = p.Id WHERE c.Id = rd.ClienteId) Cliente
                                                ,(SELECT p.Nombre FROM Empleadoes e INNER JOIN Personas p ON e.PersonaId = p.Id WHERE e.Id = rd.EmpleadoId) Empleado
                                                ,[FechaRenta]
                                                ,[FechaDevolucion]
                                                ,[MontoDia]
                                                ,[Dias]
                                             FROM [RentCar].[dbo].[RentaDevolucions] rd
                                            WHERE rd.FechaRenta BETWEEN '{0}' and '{1}'", dtp1, dtp2);

            string connectionString = ConfigurationManager.ConnectionStrings["RentCar"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds);
            connection.Close();


            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer2.LocalReport.DataSources.Add(rds);

            // Refresh the report  
            reportViewer2.RefreshReport();
        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            throw new NotImplementedException();
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id = 0)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
            throw new NotImplementedException();
        }

        public override void Edit(DataGridViewRow row)
        {
            throw new NotImplementedException();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            putReport();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            putReport();
        }
    }
}
