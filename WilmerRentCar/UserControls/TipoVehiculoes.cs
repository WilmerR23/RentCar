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

namespace WilmerRentCar.UserControls
{
    public partial class TipoVehiculoes : BaseUserControl
    {
        Manejador<BOL.TipoVehiculo,TipoVehiculoDto> _Manejador;
        public TipoVehiculoes()
        {
            InitializeComponent();
            _Manejador = new Manejador<BOL.TipoVehiculo, TipoVehiculoDto>();
        }

        public void Crear()
        {
            TipoVehiculoDto _TipoVehiculo = new TipoVehiculoDto();
            _TipoVehiculo.Estado = true;
            _TipoVehiculo.Nombre = textBoxNombre.Text;
            _TipoVehiculo.FechaCreacion = DateTime.Now;
             _Manejador.Crear(_TipoVehiculo, true);
        }

        public void Actualizar(int id)
        {
            TipoVehiculoDto _TipoVehiculo =  _Manejador.Obtener(id);
            _TipoVehiculo.Nombre = textBoxNombre.Text;
             _Manejador.Actualizar(_TipoVehiculo);
        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                    var operacionInValida = textBoxNombre.Text == "";
                    Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Crear());
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }


        public void limpiarPantalla()
        {
            textBoxNombre.Text = "";
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
             _Manejador.Eliminar(id);
             OnSuccess();
            limpiarPantalla();
        }

        public override void Edit(DataGridViewRow row)
        {
            textBoxNombre.Text = row.Cells[3].Value.ToString();
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
            try
            {
                var operacionInValida = textBoxNombre.Text == "";
                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Actualizar(id));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}
