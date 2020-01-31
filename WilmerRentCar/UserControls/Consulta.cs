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
    public partial class Consulta : BaseUserControl
    {

        Manejador<BOL.Clientes, ClientesDto> _ManejadorCliente;
        Manejador<BOL.Vehículo, VehículoDto> _ManejadorVehiculo;
        ComboBox comboBoxCliente, comboBoxVehiculo;
        DateTimePicker dtpFinal, dtpInicio;
        Label lblVehiculoCliente, lblInicio, lblFinal;

        public int currentCliente, currentVehiculo;
        public DateTime FechaInicio, FechaFinal;

        public static string CurrentQuery;


        class ConsultaQuery
        {
            public string Identificador { get; set; }
            public string Texto { get; set; }

            public ConsultaQuery(string _Texto, string _Identificador)
            {
                this.Identificador = _Identificador;
                this.Texto = _Texto;
            }
        }

        public Consulta()
        {
            InitializeComponent();
            List<ConsultaQuery> cQ = new List<ConsultaQuery>();
            cQ.Add(new ConsultaQuery("Cliente","Renta por cliente"));
            cQ.Add(new ConsultaQuery("Vehiculo", "Renta por vehiculo"));
            cQ.Add(new ConsultaQuery("Fecha", "Renta por fecha"));

            lblVehiculoCliente = new Label();
            lblVehiculoCliente.Left = comboBox1.Left + 190;
            lblVehiculoCliente.Top = comboBox1.Top - 23;

            comboBox1.DataSource = cQ;
            comboBox1.ValueMember = "Identificador";
            comboBox1.DisplayMember = "Texto";

            //criterioCliente();
            
        }

        public void criterioCliente()
        {
                _ManejadorCliente = new Manejador<BOL.Clientes, ClientesDto>();
                comboBoxCliente = new ComboBox();
                comboBoxCliente.Left = comboBox1.Left + 190;
                comboBoxCliente.Top = comboBox1.Top;
                comboBoxCliente.Width = comboBox1.Width;
                comboBoxCliente.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxCliente.SelectedIndexChanged += (object obj, EventArgs eArgs) => ClienteSelected(obj, eArgs);

                var data = _ManejadorCliente.ObtenerTodos(new[] { "Persona" });
                comboBoxCliente.DataSource = data;
                comboBoxCliente.ValueMember = "Id";
                comboBoxCliente.DisplayMember = "Nombre";
                this.Controls.Add(comboBoxCliente);

        }

        private void VehiculoSelected(object sender, EventArgs e)
        {
            var vehiculo = (VehículoDto)comboBoxVehiculo.SelectedItem;
            currentVehiculo = vehiculo.Id;
            CurrentQuery = string.Format(" WHERE rd.VehiculoId = {0}", currentVehiculo);
            SuccessFunction();
        }

        private void ClienteSelected(object sender, EventArgs e)
        {
            var client = (ClientesDto)comboBoxCliente.SelectedItem;
            currentCliente = client.Id;
            CurrentQuery = string.Format(" WHERE rd.ClienteId = {0}", currentCliente);
            SuccessFunction();
        }

        

        public void criterioVehiculo()
        {
                _ManejadorVehiculo = new Manejador<BOL.Vehículo, VehículoDto>();
                comboBoxVehiculo = new ComboBox();
                comboBoxVehiculo.Left = comboBox1.Left + 190;
                comboBoxVehiculo.Top = comboBox1.Top;
                comboBoxVehiculo.Width = comboBox1.Width;
                comboBoxVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxVehiculo.SelectedIndexChanged += (object obj, EventArgs eArgs) => VehiculoSelected(obj, eArgs);

                var data = _ManejadorVehiculo.ObtenerTodos(new[] { "Marca", "Modelo" });
                comboBoxVehiculo.DataSource = data;
                comboBoxVehiculo.ValueMember = "Id";
                comboBoxVehiculo.DisplayMember = "Nombre";
                
                this.Controls.Add(comboBoxVehiculo);
        }


        private void FechaFinalSelected(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            FechaFinal = Convert.ToDateTime(dtp.Text);
            FechaInicio = FechaInicio != DateTime.MinValue ? FechaInicio : DateTime.Now;
            CurrentQuery = string.Format("WHERE rd.FechaRenta between '{0}' and '{1}' or rd.FechaDevolucion between '{0}' and '{1}'", FechaInicio.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"));
            SuccessFunction();
        }


        private void FechaIncioSelected(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            FechaInicio = Convert.ToDateTime(dtp.Text);
            FechaFinal = FechaFinal != DateTime.MinValue ? FechaFinal : DateTime.Now;
            CurrentQuery = string.Format("WHERE rd.FechaRenta between '{0}' and '{1}' or rd.FechaDevolucion between '{0}' and '{1}'", FechaInicio.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"));
            SuccessFunction();
        }                

        public void criterioFecha()
        {
            dtpInicio = new DateTimePicker();
            lblInicio = new Label();

            lblInicio.Text = "Fecha inicio";
            lblInicio.Left = comboBox1.Left + 190;
            lblInicio.Top = comboBox1.Top - 23;
            lblInicio.BackColor = Color.Transparent;

            dtpInicio.TextChanged += (object obj, EventArgs eArgs) => FechaIncioSelected(obj, eArgs);
            dtpInicio.Left = comboBox1.Left + 190;
            dtpInicio.Top = comboBox1.Top;
            this.Controls.Add(lblInicio);
            this.Controls.Add(dtpInicio);


            dtpFinal = new DateTimePicker();
            lblFinal = new Label();

            lblFinal.Text = "Fecha final";
            lblFinal.Left = dtpInicio.Left + 210;
            lblFinal.Top = comboBox1.Top - 23;

            dtpFinal.TextChanged += (object obj, EventArgs eArgs) => FechaFinalSelected(obj, eArgs);
            dtpFinal.Left = dtpInicio.Left + 210;
            dtpFinal.Top = comboBox1.Top;
            this.Controls.Add(lblFinal);
            this.Controls.Add(dtpFinal);
        }

        public void removeCriterios()
        {
            this.Controls.Remove(comboBoxCliente);
            this.Controls.Remove(comboBoxVehiculo);
            this.Controls.Remove(dtpInicio);
            this.Controls.Remove(dtpFinal);
            this.Controls.Remove(lblVehiculoCliente);
            this.Controls.Remove(lblInicio);
            this.Controls.Remove(lblFinal);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                var item = (ConsultaQuery)comboBox1.SelectedItem;
                var id = item.Texto;
                removeCriterios();


                switch (id)
                {
                    case "Cliente":
                        criterioCliente();
                        lblVehiculoCliente.Text = "Cliente";
                        this.Controls.Add(lblVehiculoCliente);
                        break;
                    case "Vehiculo":
                        criterioVehiculo();
                        lblVehiculoCliente.Text = "Vehiculo";
                        this.Controls.Add(lblVehiculoCliente);
                        break;
                    case "Fecha":
                        criterioFecha();
                        break;
                }
            }
        }

        public override void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler)
        {
            throw new NotImplementedException();
        }

        public override void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id = 0)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id, Func<Task> OnSuccess)
        {
            throw new NotImplementedException();
        }

        public override void Edit(DataGridViewRow row)
        {
            throw new NotImplementedException();
        }
    }
}
