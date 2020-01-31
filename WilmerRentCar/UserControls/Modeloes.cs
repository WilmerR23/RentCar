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
    public partial class Modeloes : BaseUserControl
    {
        Manejador<BOL.Modelo, BOL.Dtos.ModeloDto> _Manejador;
        Manejador<BOL.Marca, BOL.Dtos.MarcaDto> _ManejadorMarca;
        public IEnumerable<MarcaDto> ListaMarca;
        public Modeloes()
        {
            InitializeComponent();
            _Manejador = new Manejador<BOL.Modelo, ModeloDto>();
            _ManejadorMarca = new Manejador<BOL.Marca, MarcaDto>();

                ListaMarca =  _ManejadorMarca.ObtenerTodos();
                cbMarca.DataSource = ListaMarca;
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Nombre";
        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                    var operacionInValida = textBoxNombre.Text == "" || cbMarca.SelectedItem == null;
                    Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Add());
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void Add()
        {
            ModeloDto _Modelo = new ModeloDto();
            _Modelo.Estado = true;
            _Modelo.Nombre = textBoxNombre.Text;
            _Modelo.FechaCreacion = DateTime.Now;
            _Modelo.MarcaId = int.Parse(cbMarca.SelectedValue.ToString());
             _Manejador.Crear(_Modelo, true);
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
             _Manejador.Eliminar(id);
             OnSuccess();
            limpiarPantalla();
        }

        public void limpiarPantalla()
        {
            textBoxNombre.Text = "";
            cbMarca.SelectedItem = null;
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
            try
            {
                var operacionInValida = textBoxNombre.Text == "" || cbMarca.SelectedItem == null;

                Operation(operacionInValida, validatorHandler, () => limpiarPantalla(), OnSuccess, () => Actualizar(id));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        public void Actualizar(int id)
        {
            ModeloDto _Modelo =  _Manejador.Obtener(id);
            _Modelo.Nombre = textBoxNombre.Text;
            _Modelo.MarcaId = int.Parse(cbMarca.SelectedValue.ToString());
             _Manejador.Actualizar(_Modelo);
        }

        public override void Edit(DataGridViewRow row)
        {
            textBoxNombre.Text = row.Cells[4].Value.ToString();
            cbMarca.SelectedValue = ListaMarca.FirstOrDefault(x => x.Nombre == row.Cells[3].Value.ToString()).Id;
        }
    }
}
