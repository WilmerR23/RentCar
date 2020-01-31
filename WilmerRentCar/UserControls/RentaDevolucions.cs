using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WilmerRentCar.BOL.Dtos;
using WilmerRentCar.BLL;

namespace WilmerRentCar.UserControls
{
    public partial class RentaDevolucions : BaseUserControl
    {
        Manejador<BOL.RentaDevolucion, RentaDevolucionDto> _Manejador;
        Manejador<BOL.Clientes, ClientesDto> _ManejadorCliente;
        Manejador<BOL.Vehículo, VehículoDto> _ManejadorVehículo;

        public IEnumerable<ClientesDto> ListaClientes;
        public IEnumerable<VehículoDto> ListaVehiculos;
        public RentaDevolucions()
        {
            InitializeComponent();

            _Manejador = new Manejador<BOL.RentaDevolucion, RentaDevolucionDto>();


                _ManejadorCliente = new Manejador<BOL.Clientes, ClientesDto>();
                ListaClientes =  _ManejadorCliente.ObtenerTodos(new[] { "Persona" });
                cbCliente.DataSource = ListaClientes;
                cbCliente.ValueMember = "Id";
                cbCliente.DisplayMember = "Nombre";

                _ManejadorVehículo = new Manejador<BOL.Vehículo, VehículoDto>();
                ListaVehiculos =  _ManejadorVehículo.ObtenerTodos(new[] { "Marca", "Modelo" });
                cbVehículo.DataSource = ListaVehiculos;
                cbVehículo.ValueMember = "Id";
                cbVehículo.DisplayMember = "Nombre";

        }

        public void Crear()
        {
            RentaDevolucionDto _RentaDevolucion = new RentaDevolucionDto();
            _RentaDevolucion.ClienteId = int.Parse(cbCliente.SelectedValue.ToString());
            _RentaDevolucion.VehiculoId = int.Parse(cbVehículo.SelectedValue.ToString());

            VehículoDto _Vehiculo = _ManejadorVehículo.Obtener(_RentaDevolucion.VehiculoId);
            _Vehiculo.Estado = false;
            _ManejadorVehículo.Actualizar(_Vehiculo);

            _RentaDevolucion.MontoDia = textBoxMontoDia.Text;
            _RentaDevolucion.Renta = textBoxTotalRenta.Text;
            _RentaDevolucion.Dias = textBoxDias.Text;
            _RentaDevolucion.FechaCreacion = DateTime.Now;
            _RentaDevolucion.FechaRenta = Convert.ToDateTime(dtpFechaInicio.Text);
            _RentaDevolucion.FechaDevolucion = Convert.ToDateTime(dtpFechaFinal.Text);
            _RentaDevolucion.Estado = true;
            _RentaDevolucion.EmpleadoId = Form1.currentUserId;

            _Manejador.Crear(_RentaDevolucion, true);
        }

        public void Actualizar(int id)
        {
            RentaDevolucionDto _RentaDevolucion =  _Manejador.Obtener(id, new[] { "Vehiculo", "Vehiculo.Modelo" });
            _RentaDevolucion.ClienteId = int.Parse(cbCliente.SelectedValue.ToString());
            _RentaDevolucion.VehiculoId = int.Parse(cbVehículo.SelectedValue.ToString());
            _RentaDevolucion.MontoDia = textBoxMontoDia.Text;
            _RentaDevolucion.Renta = textBoxTotalRenta.Text;
            _RentaDevolucion.Dias = textBoxDias.Text;
            _RentaDevolucion.FechaRenta = Convert.ToDateTime(dtpFechaInicio.Text);
            _RentaDevolucion.FechaDevolucion = Convert.ToDateTime(dtpFechaFinal.Text);
            _RentaDevolucion.EmpleadoId = Form1.currentUserId;

            _Manejador.Actualizar(_RentaDevolucion);
        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                var operacionInValida = cbCliente.SelectedItem == null || cbVehículo.SelectedItem == null || dtpFechaInicio.Text == "" 
                || dtpFechaFinal.Text == "" || textBoxDias.Text == "" || textBoxMontoDia.Text == "" || textBoxTotalRenta.Text == "";
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
            cbVehículo.SelectedItem = null;
            textBoxDias.Text = "";
            textBoxMontoDia.Text = "";
            textBoxTotalRenta.Text = "";
            dtpFechaInicio.Text = "";
            dtpFechaFinal.Text = "";
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
             _Manejador.Eliminar(id);
             OnSuccess();
            limpiarPantalla();
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
            try
            {
                var operacionInValida = cbCliente.SelectedItem == null || cbVehículo.SelectedItem == null || dtpFechaInicio.Text == "" 
                    || dtpFechaFinal.Text == "" || textBoxDias.Text == "" || textBoxMontoDia.Text == "" || textBoxTotalRenta.Text == "";
                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Actualizar(id));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public override void Edit(DataGridViewRow row)
        {
            cbCliente.SelectedItem = ListaClientes.FirstOrDefault(x => x.Nombre == row.Cells[6].Value.ToString()).Id;
            cbVehículo.SelectedItem = ListaVehiculos.FirstOrDefault(x => (string.Format("{0} - {1},{2}",x.Placa,x.Marca.Nombre, x.Modelo.Nombre)) == row.Cells[5].Value.ToString()).Id;
            textBoxDias.Text = row.Cells[11].Value.ToString();
            textBoxMontoDia.Text = row.Cells[10].Value.ToString(); 
            textBoxTotalRenta.Text = row.Cells[4].Value.ToString(); 
            dtpFechaInicio.Text = row.Cells[8].Value.ToString(); 
            dtpFechaFinal.Text = row.Cells[9].Value.ToString(); 
        }

        private void textBoxMontoDia_TextChanged(object sender, EventArgs e)
        {
            setTotalRenta();
        }

        private void textBoxDias_TextChanged(object sender, EventArgs e)
        {
            setTotalRenta();
        }

        public void setTotalRenta() {
            int dias = 0;
            int monto = 0;

            int.TryParse(textBoxDias.Text, out dias);
            int.TryParse(textBoxMontoDia.Text,out monto);
            int totalRenta = dias * monto;

            textBoxTotalRenta.Text = totalRenta.ToString();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            SetDias(dtp.Text);
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            SetDias(dtp.Text);
        }

        public void SetDias(string date)
        {
           var fechaFinal = Convert.ToDateTime(dtpFechaFinal.Text) == DateTime.MinValue ? DateTime.Now : Convert.ToDateTime(dtpFechaFinal.Text);
           var fechaInicio = Convert.ToDateTime(dtpFechaInicio.Text) == DateTime.MinValue ? DateTime.Now : Convert.ToDateTime(dtpFechaInicio.Text);

           var dias = fechaFinal.Subtract(fechaInicio).Days;
           textBoxDias.Text = dias.ToString();

        }
    }
}
