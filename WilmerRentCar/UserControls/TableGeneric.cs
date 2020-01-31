using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using System.IO;
using System.Threading;

namespace WilmerRentCar.UserControls
{
    public partial class TableGeneric : UserControl
    {

        public TableGeneric(string menuName, Action loadingHandler, int mainPanelWidth, bool filterByState)
        {
            InitializeComponent();

            dataGridView1.Cursor = Cursors.Hand;
            dataGridView1.GridColor = Color.Linen;
            FillData(menuName,loadingHandler,mainPanelWidth,filterByState);
        }

            public TableGeneric(Button btn, Action<DataGridViewRow> rowEdit, Action<int> rowDelete, Action<int> rowReturn = null, string menuItemName = "")
        {
            InitializeComponent();
            dataGridView1.CellClick += (object sender, DataGridViewCellEventArgs e) =>
            {
                var row = (sender as DataGridView).CurrentRow;
                if (e.ColumnIndex == 0)
                {
                    btn.Visible = true;
                    rowEdit(row);
                } else if (e.ColumnIndex == 1)
                {
                   var option = MessageBox.Show("Estas seguro ?","Alerta", MessageBoxButtons.OKCancel);
                    if (option == DialogResult.OK)
                    {
                        var id = row.Cells[2].Value.ToString();
                        rowDelete(int.Parse(id));
                    }
                } else if (e.ColumnIndex == 2 && menuItemName == "RentaDevolucions")
                {
                    var option = MessageBox.Show("Estas seguro de devolver este vehiculo ?", "Alerta", MessageBoxButtons.OKCancel);
                    if (option == DialogResult.OK)
                    {
                        var id = row.Cells[3].Value.ToString();
                        rowReturn(int.Parse(id));
                    }
                }
            };

            string[] s = { "\\bin" };
            var path = string.Format("{0}\\Images", Application.StartupPath.Split(s, StringSplitOptions.None)[0]);

            var colBtnEdit = new DataGridViewImageColumn();
            colBtnEdit.HeaderText = "Editar";
            colBtnEdit.Image = (new Bitmap(Image.FromFile(string.Format("{0}\\edit.png", path)), 24, 24));

            var colBtnDelete = new DataGridViewImageColumn();
            colBtnDelete.HeaderText = "Eliminar";
            colBtnDelete.Image = (new Bitmap(Image.FromFile(string.Format("{0}\\delete.png", path)), 24, 24));
            
            dataGridView1.Columns.Add(colBtnEdit);
            dataGridView1.Columns.Add(colBtnDelete);

            if (menuItemName == "RentaDevolucions")
            {
                var colbtnReturn = new DataGridViewImageColumn();
                colbtnReturn.HeaderText = "Devolver";
                colbtnReturn.Image = (new Bitmap(Image.FromFile(string.Format("{0}\\return.png", path)), 24, 24));
                dataGridView1.Columns.Add(colbtnReturn);
            }

            dataGridView1.Cursor = Cursors.Hand;

            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
            dataGridView1.GridColor = Color.Linen;


            //FillData("SELECT * FROM Prueba");

        }
        
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        public async Task FillData(string menuItemName, Action loadingHandler, int mainPanelWidth, bool filter = true) {

            var query = string.Format("SELECT * FROM {0} WHERE {0}",menuItemName);

            switch (menuItemName)
            {
                case "Clientes":
                    query = @"SELECT [Id] Numero
                                      ,[TarjetaCredito]
                                      ,[LimiteCredito]
                                      ,(SELECT Nombre FROM Personas p WHERE p.Id = c.PersonaId) Nombre
                                      ,(SELECT Cedula FROM Personas p WHERE p.Id = c.PersonaId) Cedula 
                                      ,[FechaCreacion] FechaIngreso
                            FROM [RentCar].[dbo].[Clientes] c WHERE c";
                    break;
                case "Empleadoes":
                    query = @"SELECT [Id] Numero
                                      ,[TandaLabor]
                                      ,[PorCientoComision]
                                      ,[FechaIngreso]
	                                  ,(SELECT Nombre FROM Personas p WHERE p.Id = e.PersonaId) Nombre
	                                  ,(SELECT Cedula FROM Personas p WHERE p.Id = e.PersonaId) Cedula 
                            FROM [RentCar].[dbo].[Empleadoes] e WHERE e";
                    break;
                case "Marcas":
                    query = @"SELECT [Id] Numero
                                          ,[Nombre]
                                      FROM [RentCar].[dbo].[Marcas] m WHERE m";
                    break;
                case "Modeloes":
                    query = @"SELECT [Id] Numero
                                      ,(SELECT Nombre FROM Marcas m WHERE m.Id = mo.MarcaId) NombreMarca
                                      ,[Nombre]
                                  FROM [RentCar].[dbo].[Modeloes] mo WHERE mo";
                    break;
                case "TipoVehiculoes":
                    query = @"SELECT [Id] Numero
                                      ,[Nombre]
                                  FROM [RentCar].[dbo].[TipoVehiculoes] tv WHERE tv";
                    break;
                case "TipoCombustibles":
                    query = @"SELECT [Id] Numero
                                      ,[Nombre]
                                  FROM [RentCar].[dbo].[TipoCombustibles] tc WHERE tc";
                    break;
                case "Vehículo":
                    query = @"SELECT [Id] Numero,[Chasis],[Motor],[Placa]
	                                  ,(SELECT Nombre FROM TipoVehiculoes tv WHERE tv.Id = v.TipoVehiculoId) TipoVehiculo
	                                  ,(SELECT Nombre FROM TipoCombustibles tc WHERE tc.Id = v.TipoCombustibleId) TipoCombustible
	                                  ,(SELECT Nombre FROM Marcas m WHERE m.Id = v.MarcaId) NombreMarca
	                                  ,(SELECT Nombre FROM Modeloes mo WHERE mo.Id = v.ModeloId) NombreModelo
                                  FROM [RentCar].[dbo].[Vehículo] v WHERE v";
                    break;
                case "RentaDevolucions":
                    query = @"SELECT [Id] Numero
                                      ,[Renta]
                                      ,(SELECT CONCAT(v.Placa, ' - ', ma.Nombre, ',', mo.Nombre) FROM Vehículo v INNER JOIN Marcas ma ON v.MarcaId = ma.Id INNER JOIN Modeloes mo ON v.ModeloId = mo.Id WHERE v.Id = rd.VehiculoId) Vehiculo
                                      ,(SELECT p.Nombre FROM Clientes c INNER JOIN Personas p ON c.PersonaId = p.Id WHERE c.Id = rd.ClienteId) Cliente
                                      ,(SELECT p.Nombre FROM Empleadoes e INNER JOIN Personas p ON e.PersonaId = p.Id WHERE e.Id = rd.EmpleadoId) Empleado
                                      ,[FechaRenta]
                                      ,[FechaDevolucion]
                                      ,[MontoDia]
                                      ,[Dias]
                                  FROM [RentCar].[dbo].[RentaDevolucions] rd WHERE rd";
                    break;
                case "Inspección":
                    query = @"SELECT [Id] Numero
	                                     ,(SELECT CONCAT(v.Placa, ' - ', mo.Nombre) FROM Vehículo v INNER JOIN Modeloes mo ON v.ModeloId = mo.Id WHERE v.Id = I.VehiculoId) Vehiculo
                                         ,(SELECT p.Nombre FROM Clientes cl INNER JOIN Personas p ON cl.PersonaId = p.Id WHERE cl.Id = I.ClienteId) Cliente
		                                 ,(SELECT p.Nombre FROM Empleadoes em INNER JOIN Personas p ON em.PersonaId = p.Id WHERE em.Id = I.EmpleadoId) Empleado
                                      ,[CantidadCombustible]
                                      ,[FechaInspeccion]
                                      ,(SELECT (CASE WHEN Ralladuras = 1 THEN 'Sí' ELSE 'No' END)) Ralladura
                                      ,(SELECT (CASE WHEN [GomaRepuesta] = 1 THEN 'Sí' ELSE 'No' END)) GomaRepuesta
                                      ,(SELECT (CASE WHEN [Gato] = 1 THEN 'Sí' ELSE 'No' END)) Gato
                                      ,(SELECT (CASE WHEN [RoturaCristal] = 1 THEN 'Sí' ELSE 'No' END)) RoturaCristal
                                      ,(SELECT (CASE WHEN [Goma1] = 1 THEN 'Sí' ELSE 'No' END)) GomaIzquierdaFrente
                                      ,(SELECT (CASE WHEN [Goma2] = 1 THEN 'Sí' ELSE 'No' END)) GomaDerechaFrente
                                      ,(SELECT (CASE WHEN [Goma3] = 1 THEN 'Sí' ELSE 'No' END)) GomaIzquierdaAtras
                                      ,(SELECT (CASE WHEN [Goma4] = 1 THEN 'Sí' ELSE 'No' END)) GomaDerechaAtras
                                  FROM [RentCar].[dbo].[Inspección] I WHERE I";
                    break;
                case "Consulta":
                    query = @"SELECT [Id] Numero
	                                ,[Renta]
	                                ,(SELECT CONCAT(v.Placa, ' - ', ma.Nombre, ',', mo.Nombre) FROM Vehículo v 
	                                INNER JOIN Marcas ma ON v.MarcaId = ma.Id 
	                                INNER JOIN Modeloes mo ON v.ModeloId = mo.Id WHERE v.Id = rd.VehiculoId) Vehiculo
	                                ,(SELECT p.Nombre FROM Clientes c INNER JOIN Personas p ON c.PersonaId = p.Id WHERE c.Id = rd.ClienteId) Cliente
	                                ,(SELECT p.Nombre FROM Empleadoes e INNER JOIN Personas p ON e.PersonaId = p.Id WHERE e.Id = rd.EmpleadoId) Empleado
	                                ,[FechaRenta]
	                                ,[FechaDevolucion]
	                                ,[MontoDia]
	                                ,[Dias]
	                                FROM [RentCar].[dbo].[RentaDevolucions] rd";
                    break;
                case "Usuarios":
                    query = @"SELECT [Id] Numero
                                      ,[Nombre] NombreUsuario
                                      ,(SELECT p.Nombre FROM Empleadoes em INNER JOIN Personas p ON em.PersonaId = p.Id WHERE em.Id = us.EmpleadoId) Empleado
                                  FROM [RentCar].[dbo].[Usuarios] us WHERE us";
                    break;

            }

            if (filter)
            {
                query = string.Format("{0}{1}", query, ".Estado = 1 ORDER BY Id DESC");
            } else
            {
                query = string.Format("{0} {1}", query, Consulta.CurrentQuery);
            }
            
            string connectionString = ConfigurationManager.ConnectionStrings["RentCar"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            await connection.OpenAsync();
            dataadapter.Fill(ds, "Tabla");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tabla";
            
            int width = 0;
            foreach(DataGridViewColumn col in dataGridView1.Columns)
            {
                width += col.Width;
            }

            dataGridView1.Width = mainPanelWidth > (width + 65) ? width + 65 : mainPanelWidth - 40;
            dataGridView1.Left = Math.Abs(mainPanelWidth - dataGridView1.Width) / 2;
            loadingHandler();
        }

    }
}
