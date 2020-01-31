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
    public partial class Empleadoes : BaseUserControl
    {
        public Manejador<Empleado, BOL.Dtos.EmpleadoDto> _ManejadorEmpleado;
        public Manejador<Persona,BOL.Dtos.PersonaDto> _ManejadorPersona;
        bool isCedulaEditing = false;
        public Empleadoes()
        {
            InitializeComponent();
            _ManejadorEmpleado = new Manejador<Empleado, BOL.Dtos.EmpleadoDto>();
            _ManejadorPersona = new Manejador<Persona, BOL.Dtos.PersonaDto>();
            textBoxCedula.Mask = "000-0000000-0";
        }

        public static bool validaCedula(string pCedula) {

            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;
            
            for (int vDig = 1; vDig <= pLongCed; vDig++)

            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                    if (vCalculo < 10)
                    vnTotal += vCalculo;

                     else

                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));

            }



            if (vnTotal % 10 == 0)
                return true;
            else
                return false;

        }


        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            try
            {
                var operacionInValida = textBoxCedula.Text == "" || textBoxComision.Text == "" || textBoxNombre.Text == "" || textBoxTanda.Text == "";
                validatorHandler(operacionInValida || !validaCedula(textBoxCedula.Text), !validaCedula(textBoxCedula.Text) ? "La cédula debe ser valida" : "Debes ingresar valores a los campos obligatorios." );


                if (!operacionInValida && validaCedula(textBoxCedula.Text))
                {
                    PersonaDto Persona = _ManejadorPersona.ObtenerPorFiltro(x => x.Cedula == textBoxCedula.Text);

                    if (Persona == null)
                    {
                        Persona = new PersonaDto();
                        Persona.Cedula = textBoxCedula.Text;
                        Persona.Estado = true;
                        Persona.FechaCreacion = DateTime.Now;
                        Persona.Nombre = textBoxNombre.Text;
                        Persona.TipoPersonaId = 1;

                        Persona = _ManejadorPersona.CrearSync(Persona, true);
                    } else if (Persona.Nombre != textBoxNombre.Text)
                    {
                        Persona.Nombre = textBoxNombre.Text;
                        _ManejadorPersona.Actualizar(Persona);
                    }

                    EmpleadoDto Empleado = _ManejadorEmpleado.ObtenerPorFiltro(x => x.Persona.Cedula == textBoxCedula.Text && x.Estado);

                    if (Empleado == null)
                    {
                        Empleado = new EmpleadoDto();
                        Empleado.TandaLabor = textBoxTanda.Text;
                        Empleado.PorCientoComision = textBoxComision.Text;
                        Empleado.Estado = true;
                        Empleado.PersonaId = Persona.Id;
                        Empleado.FechaCreacion = DateTime.Now;
                        Empleado.FechaIngreso = DateTime.Now;

                        _ManejadorEmpleado.Crear(Empleado, true);

                        limpiarPantalla();
                        OnSuccess();
                    }
                    else
                    {
                        string mensaje = "Ya existe un empleado con esta cédula.";
                        validatorHandler(true, mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

        }

        public void limpiarPantalla()
        {
            textBoxCedula.Text = "";
            textBoxComision.Text = "";
            textBoxTanda.Text = "";
            textBoxNombre.Text = "";
        }


        public override void Delete(int id, Func<Task> OnSuccess)
        {
             _ManejadorEmpleado.Eliminar(id);
             OnSuccess();
        }

        public override void Edit(DataGridViewRow row)
        {
            textBoxCedula.Text = row.Cells[7].Value.ToString();
            textBoxNombre.Text = row.Cells[6].Value.ToString();
            textBoxComision.Text = row.Cells[4].Value.ToString();
            textBoxTanda.Text = row.Cells[3].Value.ToString();
            isCedulaEditing = false;
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
            try
            {
                var operacionInValida = textBoxCedula.Text == "" || textBoxComision.Text == "" || textBoxNombre.Text == "" || textBoxTanda.Text == "";
                validatorHandler(operacionInValida, "Debes ingresar valores a los campos obligatorios.");

                if (!operacionInValida)
                {
                    PersonaDto Persona =  _ManejadorPersona.ObtenerPorFiltro(x => x.Cedula == textBoxCedula.Text && x.Estado);

                    if (Persona == null || !isCedulaEditing)
                    {
                            EmpleadoDto Empleado =  _ManejadorEmpleado.Obtener(id);
                            Persona =  _ManejadorPersona.Obtener(Empleado.PersonaId);

                            Persona.Cedula = textBoxCedula.Text;
                            Persona.Nombre = textBoxNombre.Text;

                         _ManejadorPersona.Actualizar(Persona);

                        Empleado.TandaLabor = textBoxTanda.Text;
                            Empleado.PorCientoComision = textBoxComision.Text;

                         _ManejadorEmpleado.Actualizar(Empleado);

                        limpiarPantalla();
                            OnSuccess();
                    }
                    else
                    {
                        validatorHandler(true, "Ya existe un cliente con esta cédula.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void textBoxCedula_TextChanged(object sender, EventArgs e)
        {
            isCedulaEditing = true;
        }
    }
}
