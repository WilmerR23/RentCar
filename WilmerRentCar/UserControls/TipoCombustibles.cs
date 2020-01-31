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
    public partial class TipoCombustibles : BaseUserControl
    {
        Manejador<BOL.TipoCombustible, TipoCombustibleDto> _Manejador;
        public TipoCombustibles()
        {
            InitializeComponent();
            _Manejador = new Manejador<BOL.TipoCombustible, TipoCombustibleDto>();
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

        public void Crear()
        {
            TipoCombustibleDto _TipoCombustible = new TipoCombustibleDto();
            _TipoCombustible.Estado = true;
            _TipoCombustible.Nombre = textBoxNombre.Text;
            _TipoCombustible.FechaCreacion = DateTime.Now;
            _Manejador.Crear(_TipoCombustible, true);
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

        public void Actualizar(int id)
        {
            TipoCombustibleDto _TipoCombustible = _Manejador.Obtener(id);
            _TipoCombustible.Nombre = textBoxNombre.Text;
            _Manejador.Actualizar(_TipoCombustible);
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
