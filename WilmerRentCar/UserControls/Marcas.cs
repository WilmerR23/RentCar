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
    public partial class Marcas : BaseUserControl
    {
        Manejador<BOL.Marca, BOL.Dtos.MarcaDto> _Manejador;
        public Marcas()
        {
            InitializeComponent();
            _Manejador = new Manejador<BOL.Marca, BOL.Dtos.MarcaDto>();
        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                var operacionInValida = textBoxNombre.Text == "";
                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => CrearData());
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void CrearData ()
        {
            MarcaDto _Marca = new MarcaDto();
            _Marca.Estado = true;
            _Marca.Nombre = textBoxNombre.Text;
            _Marca.FechaCreacion = DateTime.Now;
             _Manejador.Crear(_Marca, true);
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

        public void Actualizar(int id)
        {
            MarcaDto _Marca =  _Manejador.Obtener(id);
            _Marca.Nombre = textBoxNombre.Text;
             _Manejador.Actualizar(_Marca);
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


        public override void Edit(DataGridViewRow row)
        {
            textBoxNombre.Text = row.Cells[3].Value.ToString();
        }

    }
}
