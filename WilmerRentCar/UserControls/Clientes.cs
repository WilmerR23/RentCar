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
using WilmerRentCar.DAL;
using System.Threading;
using System.Configuration;
using WilmerRentCar.BOL.Dtos;

namespace WilmerRentCar.UserControls
{
    public partial class Clientes : BaseUserControl
    {
        public Manejador<Persona,BOL.Dtos.PersonaDto> _ManejadorPersona;
        public Manejador<BOL.Clientes, BOL.Dtos.ClientesDto> _ManejadorCliente;
        bool isCedulaEditing = false;

        public Clientes()
        {
            InitializeComponent();
             _ManejadorPersona = new Manejador<Persona, BOL.Dtos.PersonaDto>();
            _ManejadorCliente = new Manejador<BOL.Clientes, BOL.Dtos.ClientesDto>();
            textBoxCedula.Mask = "000-0000000-0";
            textBoxTarjeta.Mask = "0000-0000-0000-0000";
            textBoxLimite.Mask = ConfigurationManager.AppSettings["MontoLimite"];

        }

        public static bool validaCedula(string pCedula)
        {

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
                var operacionInValida = textBoxCedula.Text == "" || textBoxNombre.Text == "" || textBoxLimite.Text == "" || textBoxTarjeta.Text == "";
                validatorHandler(operacionInValida || !validaCedula(textBoxCedula.Text), !validaCedula(textBoxCedula.Text) ? "La cédula debe ser valida" : "Debes ingresar valores a los campos obligatorios.");

                if (!operacionInValida)
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

                    ClientesDto cliente = _ManejadorCliente.ObtenerPorFiltro(x => x.Persona.Cedula == textBoxCedula.Text && x.Estado);

                    if (cliente == null)
                    {
                        cliente = new ClientesDto();
                        cliente.TarjetaCredito = textBoxTarjeta.Text;
                        cliente.LimiteCredito = int.Parse(textBoxLimite.Text);
                        cliente.Estado = true;
                        cliente.PersonaId = Persona.Id;
                        cliente.FechaCreacion = DateTime.Now;

                        _ManejadorCliente.Crear(cliente, true);

                        limpiarPantalla();
                        OnSuccess();
                    } else
                    {
                        string mensaje = "Ya existe un cliente con esta cédula.";
                        validatorHandler(true, mensaje);
                    }

                    //} else
                    //{

                    //}
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
            textBoxNombre.Text = "";
            textBoxLimite.Text = "";
            textBoxTarjeta.Text = "";
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
             _ManejadorCliente.Eliminar(id);
             OnSuccess();
            limpiarPantalla();
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id)
        {
            try
            {
                var operacionInValida = textBoxCedula.Text == "" || textBoxNombre.Text == "" || textBoxLimite.Text == "" || textBoxTarjeta.Text == "";
                validatorHandler(operacionInValida, "Debes ingresar valores a los campos obligatorios.");

                if (!operacionInValida)
                {
                    PersonaDto Persona = _ManejadorPersona.ObtenerPorFiltro(x => x.Cedula == textBoxCedula.Text && x.Estado);
                    ClientesDto Cliente = _ManejadorCliente.ObtenerPorFiltro(x => x.TarjetaCredito == textBoxTarjeta.Text && x.Estado);

                    if (Persona == null || !isCedulaEditing)
                    {
                        if (Cliente == null)
                        {
                            Cliente =  _ManejadorCliente.Obtener(id);
                            Persona =  _ManejadorPersona.Obtener(Cliente.PersonaId);

                            Persona.Cedula = textBoxCedula.Text;
                            Persona.Nombre = textBoxNombre.Text;

                             _ManejadorPersona.Actualizar(Persona);

                            Cliente.TarjetaCredito = textBoxTarjeta.Text;
                            Cliente.LimiteCredito = int.Parse(textBoxLimite.Text);

                             _ManejadorCliente.Actualizar(Cliente);

                            limpiarPantalla();
                             OnSuccess();
                        } else
                        {
                            validatorHandler(true, "Ya existe un cliente con este numero de tarjeta de credito.");
                        }
                    } else
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


        public override void Edit(DataGridViewRow row)
        {
            textBoxCedula.Text = row.Cells[6].Value.ToString();
            textBoxNombre.Text = row.Cells[5].Value.ToString();
            textBoxLimite.Text = row.Cells[4].Value.ToString();
            textBoxTarjeta.Text = row.Cells[3].Value.ToString();
            isCedulaEditing = false;
        }

        private void textBoxCedula_TextChanged(object sender, EventArgs e)
        {
            isCedulaEditing = true;
        }
    }
}
