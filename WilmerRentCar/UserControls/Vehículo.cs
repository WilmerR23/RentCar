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
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;

namespace WilmerRentCar.UserControls
{
    public partial class Vehículo : BaseUserControl
    {

        Manejador<BOL.Vehículo, VehículoDto> _Manejador;
        Manejador<Marca, MarcaDto> _ManejadorMarca;
        Manejador<Modelo, ModeloDto> _ManejadorModelo;
        Manejador<TipoVehiculo, TipoVehiculoDto> _ManejadorTipoVehiculo;
        Manejador<TipoCombustible, TipoCombustibleDto> _ManejadorCombustible;

        public IEnumerable<MarcaDto> ListaMarca;
        public IEnumerable<Modelo> ListaModelo;
        public IEnumerable<TipoVehiculoDto> ListaVehiculo;
        public IEnumerable<TipoCombustibleDto> ListaCombustible;

        public Vehículo()
        {
            InitializeComponent();

            _Manejador = new Manejador<BOL.Vehículo, VehículoDto>();

            _ManejadorMarca = new Manejador<Marca, MarcaDto>();
            ListaMarca =  _ManejadorMarca.ObtenerTodos();
            cbMarca.DataSource = ListaMarca;
            cbMarca.ValueMember = "Id";
            cbMarca.DisplayMember = "Nombre";

            _ManejadorTipoVehiculo = new Manejador<TipoVehiculo, TipoVehiculoDto>();
            ListaVehiculo =  _ManejadorTipoVehiculo.ObtenerTodos();
            cbTipoVehiculo.DataSource = ListaVehiculo;
            cbTipoVehiculo.ValueMember = "Id";
            cbTipoVehiculo.DisplayMember = "Nombre";

            _ManejadorCombustible = new Manejador<TipoCombustible, TipoCombustibleDto>();
            ListaCombustible =  _ManejadorCombustible.ObtenerTodos();
            cbTipoCombustible.DataSource = ListaCombustible;
            cbTipoCombustible.ValueMember = "Id";
            cbTipoCombustible.DisplayMember = "Nombre";

        }

        public void Crear()
        {
            VehículoDto _Vehiculo = new VehículoDto();
            _Vehiculo.MarcaId = int.Parse(cbMarca.SelectedValue.ToString());
            _Vehiculo.ModeloId = int.Parse(cbModelo.SelectedValue.ToString());
            _Vehiculo.TipoCombustibleId = int.Parse(cbTipoCombustible.SelectedValue.ToString());
            _Vehiculo.TipoVehiculoId = int.Parse(cbTipoVehiculo.SelectedValue.ToString());
            _Vehiculo.Chasis = textBoxChassis.Text;
            _Vehiculo.Motor = textBoxMotor.Text;
            _Vehiculo.Placa = textBoxPlaca.Text;
            _Vehiculo.FechaCreacion = DateTime.Now;
            _Vehiculo.Estado = true;

            _Manejador.Crear(_Vehiculo, true);
        }

        public void Actualizar(int id)
        {
            VehículoDto _Vehiculo = _Manejador.Obtener(id);
            _Vehiculo.MarcaId = int.Parse(cbMarca.SelectedValue.ToString());
            _Vehiculo.ModeloId = int.Parse(cbModelo.SelectedValue.ToString());
            _Vehiculo.TipoCombustibleId = int.Parse(cbTipoCombustible.SelectedValue.ToString());
            _Vehiculo.TipoVehiculoId = int.Parse(cbTipoVehiculo.SelectedValue.ToString());
            _Vehiculo.Chasis = textBoxChassis.Text;
            _Vehiculo.Motor = textBoxMotor.Text;
            _Vehiculo.Placa = textBoxPlaca.Text;

            _Manejador.Actualizar(_Vehiculo);
        }

        public override void Add(Action<bool,string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                    var operacionInValida = cbMarca.SelectedItem == null || cbModelo.SelectedItem == null || cbTipoCombustible.SelectedItem == null 
                    || cbTipoVehiculo.SelectedItem == null || textBoxChassis.Text == "" || textBoxMotor.Text == "" || textBoxPlaca.Text == "";
                    Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Crear());
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void limpiarPantalla()
        {
            cbMarca.SelectedItem = null;
            cbModelo.SelectedItem = null;
            cbTipoCombustible.SelectedItem = null;
            cbTipoVehiculo.SelectedItem = null;
            textBoxChassis.Text = "";
            textBoxMotor.Text = "";
            textBoxPlaca.Text = "";
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
                var operacionInValida = cbMarca.SelectedItem == null || cbModelo.SelectedItem == null || cbTipoCombustible.SelectedItem == null 
                    || cbTipoVehiculo.SelectedItem == null || textBoxChassis.Text == "" || textBoxMotor.Text == "" || textBoxPlaca.Text == "";
                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Actualizar(id));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public override void Edit(DataGridViewRow row)
        {
            textBoxChassis.Text = row.Cells[3].Value.ToString();
            textBoxMotor.Text = row.Cells[4].Value.ToString();
            textBoxPlaca.Text = row.Cells[5].Value.ToString();
            cbMarca.SelectedValue = ListaMarca.FirstOrDefault(x => x.Nombre == row.Cells[8].Value.ToString()).Id;
            cbModelo.SelectedValue = ListaModelo.FirstOrDefault(x => x.Nombre == row.Cells[9].Value.ToString()).Id;
            cbTipoCombustible.SelectedValue = ListaCombustible.FirstOrDefault(x => x.Nombre == row.Cells[7].Value.ToString()).Id;
            cbTipoVehiculo.SelectedValue = ListaVehiculo.FirstOrDefault(x => x.Nombre == row.Cells[6].Value.ToString()).Id;
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMarca.SelectedValue != null)
            {
                _ManejadorModelo = new Manejador<Modelo, ModeloDto>();
                var item = (MarcaDto)cbMarca.SelectedItem;
                cbModelo.Enabled = true;
                var id = item.Id;
                ListaModelo =  _ManejadorModelo.ObtenerTodosPorFiltro(x => x.MarcaId == id);
                cbModelo.DataSource = ListaModelo;
                cbModelo.DisplayMember = "Nombre";
                cbModelo.ValueMember = "Id";
            }
        }
        
    }
}
