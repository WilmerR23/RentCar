using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL.Dtos;
using WilmerRentCar.BOL;

namespace WilmerRentCar.UserControls
{
    public partial class Inspección : BaseUserControl
    {
        Manejador<BOL.Inspección, BOL.Dtos.InspeccionDto> _Manejador;
        Manejador<BOL.Clientes,BOL.Dtos.ClientesDto> _ManejadorCliente;
        Manejador<BOL.RentaDevolucion, BOL.Dtos.RentaDevolucionDto> _ManejadorRentaDevolucion;

        public IEnumerable<BOL.RentaDevolucion> ListaRevolucion;
        public IEnumerable<ClientesDto> ListaClientes;

        public Inspección()
        {
            InitializeComponent();
            _Manejador = new Manejador<BOL.Inspección,BOL.Dtos.InspeccionDto>();
            _ManejadorCliente  = new Manejador<BOL.Clientes, BOL.Dtos.ClientesDto>();

            ListaClientes = _ManejadorCliente.ObtenerTodos(new[] { "Persona" });
            cbCliente.DataSource = ListaClientes;
            cbCliente.ValueMember = "Id";
            cbCliente.DisplayMember = "Nombre";
            
        }

        public void Crear()
        {
           InspeccionDto _Inspeccion = new InspeccionDto();
            _Inspeccion.ClienteId = int.Parse(cbCliente.SelectedValue.ToString());
            _Inspeccion.VehiculoId = int.Parse(cbVehiculo.SelectedValue.ToString());
            _Inspeccion.CantidadCombustible = textBoxCantidadCombustible.Text;
            _Inspeccion.FechaInspeccion = Convert.ToDateTime(dtpFechaInspeccion.Text);
            _Inspeccion.FechaCreacion = DateTime.Now;

            var items = clbInspeccion.CheckedItems;

            _Inspeccion.Ralladuras = items.Contains("Ralladuras");
            _Inspeccion.GomaRepuesta = items.Contains("Goma Repuesta");
            _Inspeccion.Gato = items.Contains("Gato");
            _Inspeccion.RoturaCristal = items.Contains("Rotura de cristales");
            _Inspeccion.Goma1 = items.Contains("Goma izquierda frente");
            _Inspeccion.Goma2 = items.Contains("Goma derecha frente");
            _Inspeccion.Goma3 = items.Contains("Goma izquierda atras");
            _Inspeccion.Goma4 = items.Contains("Goma derecha atras");

            _Inspeccion.Estado = true;
            _Inspeccion.EmpleadoId = Form1.currentUserId;

            _Manejador.Crear(_Inspeccion, true);
        }


        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                var operacionInValida = cbCliente.SelectedItem == null || cbVehiculo.SelectedItem == null
                    || textBoxCantidadCombustible.Text == "" || dtpFechaInspeccion.Text == "";
                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Crear());
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void limpiarPantalla()
        {
            cbCliente.SelectedItem = null;
            cbVehiculo.SelectedItem = null;
            textBoxCantidadCombustible.Text = "";
            dtpFechaInspeccion.Text = "";
            for (int x = 0; x < 8; x++)
            {
                clbInspeccion.SetItemChecked(x, false);
            }
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
            _Manejador.Eliminar(id);
            OnSuccess();
            limpiarPantalla();
        }

        public void Actualizar(int id)
        {
            InspeccionDto _Inspeccion = _Manejador.Obtener(id);
            _Inspeccion.ClienteId = int.Parse(cbCliente.SelectedValue.ToString());
            _Inspeccion.VehiculoId = int.Parse(cbVehiculo.SelectedValue.ToString());
            _Inspeccion.CantidadCombustible = textBoxCantidadCombustible.Text;
            _Inspeccion.FechaInspeccion = Convert.ToDateTime(dtpFechaInspeccion.Text);

            var items = clbInspeccion.CheckedItems;

            _Inspeccion.Ralladuras = items.Contains("Ralladuras");
            _Inspeccion.GomaRepuesta = items.Contains("Goma Repuesta");
            _Inspeccion.Gato = items.Contains("Gato");
            _Inspeccion.RoturaCristal = items.Contains("Rotura de cristales");
            _Inspeccion.Goma1 = items.Contains("Goma izquierda frente");
            _Inspeccion.Goma2 = items.Contains("Goma derecha frente");
            _Inspeccion.Goma3 = items.Contains("Goma izquierda atras");
            _Inspeccion.Goma4 = items.Contains("Goma derecha atras");

            _Inspeccion.EmpleadoId = Form1.currentUserId;

            _Manejador.Actualizar(_Inspeccion);
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
                var operacionInValida = cbCliente.SelectedItem == null || cbVehiculo.SelectedItem == null || 
                                    textBoxCantidadCombustible.Text == "" || dtpFechaInspeccion.Text == "";
                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Actualizar(id));
        }

        public override void Edit(DataGridViewRow row)
        {
            var celdaRalladuras = row.Cells[8].Value.ToString() == "Sí" ? true : false;
            var celdaGomaRepuesta = row.Cells[9].Value.ToString() == "Sí" ? true : false;
            var celdaGato = row.Cells[10].Value.ToString() == "Sí" ? true : false;
            var celdaRoturaCristal = row.Cells[11].Value.ToString() == "Sí" ? true : false;
            var celdaGomaIzqFrente = row.Cells[12].Value.ToString() == "Sí" ? true : false;
            var celdaGomaDerFrente = row.Cells[13].Value.ToString() == "Sí" ? true : false;
            var celdaIzqAtras = row.Cells[14].Value.ToString() == "Sí" ? true : false;
            var celdaDerAtras = row.Cells[15].Value.ToString() == "Sí" ? true : false;
            
            clbInspeccion.SetItemChecked(0, celdaRalladuras);
            clbInspeccion.SetItemChecked(1, celdaGomaRepuesta);
            clbInspeccion.SetItemChecked(2, celdaGato);
            clbInspeccion.SetItemChecked(3, celdaRoturaCristal);
            clbInspeccion.SetItemChecked(4, celdaGomaIzqFrente);
            clbInspeccion.SetItemChecked(5, celdaGomaDerFrente);
            clbInspeccion.SetItemChecked(6, celdaIzqAtras);
            clbInspeccion.SetItemChecked(7, celdaDerAtras);

            cbVehiculo.SelectedValue = ListaRevolucion.FirstOrDefault(x => x.Nombre == row.Cells[3].Value.ToString()).Id;
            textBoxCantidadCombustible.Text = row.Cells[6].Value.ToString();
            dtpFechaInspeccion.Text = row.Cells[7].Value.ToString();
            cbCliente.SelectedValue = ListaClientes.FirstOrDefault(x => x.Nombre == row.Cells[4].Value.ToString()).Id;
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedValue != null)
            {
                var item = (ClientesDto)cbCliente.SelectedItem;
                cbVehiculo.Enabled = true;
                var id = item.Id;
                _ManejadorRentaDevolucion = new Manejador<BOL.RentaDevolucion, RentaDevolucionDto>();
                ListaRevolucion = _ManejadorRentaDevolucion.ObtenerTodosPorFiltro(x => x.ClienteId == id, new [] {  "Vehiculo", "Vehiculo.Modelo"});

                var data = ListaRevolucion.ToList();

                for (int x = 0; x < data.Count(); x++)
                {
                    data[x].Nombre = string.Format("{0} - {1}", data[x].Vehiculo.Placa, data[x].Vehiculo.Modelo.Nombre);
                    data[x].Id = data[x].VehiculoId;
                }
                
                cbVehiculo.DataSource = data;
                cbVehiculo.DisplayMember = "Nombre";
                cbVehiculo.ValueMember = "Id";
            }
          }
    }
}



