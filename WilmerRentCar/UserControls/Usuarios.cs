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
using System.Security.Cryptography;
using WilmerRentCar.UTL;

namespace WilmerRentCar.UserControls
{
    public partial class Usuarios : BaseUserControl
    {
        Manejador<BOL.Usuario, BOL.Dtos.UsuarioDto> _Manejador;
        Manejador<BOL.Empleado, BOL.Dtos.EmpleadoDto> _ManejadorEmpleado;

        public IEnumerable<EmpleadoDto> ListaEmpleado;
        public Usuarios()
        {
            InitializeComponent();
            _Manejador = new Manejador<BOL.Usuario, BOL.Dtos.UsuarioDto>();
            _ManejadorEmpleado = new Manejador<BOL.Empleado, BOL.Dtos.EmpleadoDto>();

                ListaEmpleado =  _ManejadorEmpleado.ObtenerTodos(new[] { "Persona" });
                cbEmpleado.DataSource = ListaEmpleado;
                cbEmpleado.ValueMember = "Id";
                cbEmpleado.DisplayMember = "Nombre";

        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                    var operacionInValida = textBoxNombre.Text == "" || textBoxClave.Text == "" || cbEmpleado.SelectedItem == null;
                    Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => CrearData());

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void CrearData()
        {
            UsuarioDto _Usuario = new UsuarioDto();
            _Usuario.Estado = true;
            _Usuario.Nombre = textBoxNombre.Text;
            _Usuario.Clave = textBoxClave.Text.generateShaText();
            _Usuario.FechaCreacion = DateTime.Now;
            _Usuario.EmpleadoId = int.Parse(cbEmpleado.SelectedValue.ToString());
             _Manejador.Crear(_Usuario, true);
        }

        public void limpiarPantalla()
        {
            textBoxNombre.Text = "";
            textBoxClave.Text = "";
            cbEmpleado.SelectedItem = null;
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
             _Manejador.Eliminar(id);
             OnSuccess();
            limpiarPantalla();
        }

        public void Actualizar(int id)
        {
            UsuarioDto _Usuario =  _Manejador.Obtener(id);
            _Usuario.Nombre = textBoxNombre.Text;
            _Usuario.Clave = textBoxClave.Text.generateShaText();
            _Usuario.EmpleadoId = int.Parse(cbEmpleado.SelectedValue.ToString());
             _Manejador.Actualizar(_Usuario);
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
            try
            {
                var operacionInValida = textBoxNombre.Text == "" || textBoxClave.Text == "" || cbEmpleado.SelectedItem == null;
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
            cbEmpleado.SelectedValue = ListaEmpleado.FirstOrDefault(x => x.Nombre == row.Cells[4].Value.ToString()).Id;
        }
    }
}
