using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;
using WilmerRentCar.UserControls;
using WilmerRentCar.UTL;

namespace WilmerRentCar
{
    public partial class Form1 : Form
    {
        Timer t;
        bool isOpen = true;
        private TableGeneric tableGeneric1;
        BaseUserControl uC;
        Label labelError;
        string menuItemName;
        int currentRowId;
        public static int currentUserId;
        Manejador<BOL.Usuario, BOL.Dtos.UsuarioDto> _Manejador;
        bool isFirstClick = true;

        public Form1()
        {
            InitializeComponent();
            menuStrip2.ForeColor = Color.White;
            operationPanel.Visible = false;
            panelHeader.Visible = false;
            _Manejador = new Manejador<Usuario, BOL.Dtos.UsuarioDto>();

            UsuarioDto userAdmin = _Manejador.ObtenerPorFiltro(x => x.Nombre == "Admin");

            if (userAdmin == null)
            {
                labelInicioSesion.Visible = true;

                Manejador<Empleado, BOL.Dtos.EmpleadoDto> _ManejadorEmpleado = new Manejador<Empleado, BOL.Dtos.EmpleadoDto>();
                Manejador<Persona, BOL.Dtos.PersonaDto> _ManejadorPersona = new Manejador<Persona, BOL.Dtos.PersonaDto>();
                Manejador<TipoPersona, BOL.Dtos.TipoPersonaDto> _ManejadorTipoPersona = new Manejador<TipoPersona, BOL.Dtos.TipoPersonaDto>();

                TipoPersonaDto _TipoPersona = new TipoPersonaDto();
                _TipoPersona.Nombre = "Fisica";
                _TipoPersona.Estado = true;
                _TipoPersona.FechaCreacion = DateTime.Now;

                var tipoPerson = _ManejadorTipoPersona.CrearSync(_TipoPersona, true);

                PersonaDto Persona = new PersonaDto();
                Persona.Cedula = "000-0000000-0";
                Persona.Estado = true;
                Persona.FechaCreacion = DateTime.Now;
                Persona.Nombre = "Admin";
                Persona.TipoPersonaId = tipoPerson.Id;

                var person = _ManejadorPersona.CrearSync(Persona, true);

                EmpleadoDto Empleado = new EmpleadoDto();
                Empleado.Estado = true;
                Empleado.PersonaId = person.Id;
                Empleado.FechaCreacion = DateTime.Now;
                Empleado.TandaLabor = "24/7";
                Empleado.PorCientoComision = "100";
                Empleado.FechaIngreso = DateTime.Now;

                var employer = _ManejadorEmpleado.CrearSync(Empleado, true);

                userAdmin = new UsuarioDto();
                userAdmin.Estado = true;
                userAdmin.Nombre = "Admin";
                userAdmin.Clave = "Admin".generateShaText();
                userAdmin.FechaCreacion = DateTime.Now;
                userAdmin.EmpleadoId = employer.Id;
                _Manejador.Crear(userAdmin,true);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (menuStrip2.Visible)
                menuStrip2.Visible = false;
            else
                menuStrip2.Visible = true;
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        private async void toolStrip3MenuItem_Click(object sender, EventArgs e)
        {
            var toolSender = ((ToolStripMenuItem)sender);
            await doLogic(toolSender, toolSender.AccessibleName,true);
        }


        private async void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolSender = ((ToolStripMenuItem)sender);
            await doLogic(toolSender, toolSender.Text);
        }

        public async Task doLogic(ToolStripMenuItem sender, string texto, bool removeLastChar = false)
        {
            operationPanel.Visible = true;
            panelHeader.Visible = true;
            panelBienvenido.Visible = false;


            if (uC != null)
                uC.Dispose();

            if (menuItemName == sender.Name)
                return;

            menuItemName = removeLastChar ? sender.Name.Remove(sender.Name.Length - 1,1) : sender.Name;

            if (!loadingCircle1.Visible && menuItemName != "Reporte")
            {
                loadingCircle1.Visible = true;
                loadingCircle1.Active = true;
            }

            uC = (BaseUserControl)Activator.CreateInstance(Type.GetType(string.Format("{0}.{1}", "WilmerRentCar.UserControls", menuItemName)));
            uC.AutoScroll = true;
            operationPanel.Height = uC.Height + 50;
            uC.Left = (operationPanel.Width - uC.Width) / 2;
            uC.Top = 20;

            operationPanel.Controls.Clear();
            operationPanel.Controls.Add(uC);
            uC.Show();
            labelGeneral.Text = texto;

            if (menuItemName != "Reporte")
            {
                btnAdd.Visible = true;
                if (isFirstClick == true)
                {
                    btnAdd.Click += (object sender2, EventArgs e2) => uC.Add((bo, t) => OnError(bo, t), () => OnSuccess(), ex => ExcepcionHandler(ex));
                    btnUpdate.Click += (object sender2, EventArgs e2) => uC.Update((bo, t) => OnError(bo, t), () => OnSuccess(), ex => ExcepcionHandler(ex), currentRowId);
                }
                isFirstClick = false;

                MainPanel.Controls.Remove(tableGeneric1);

                if (menuItemName != "Consulta")
                {
                    tableGeneric1 = new TableGeneric(btnUpdate, (DataGridViewRow row) =>
                    {
                        var type = row.Cells[2].Value.GetType();
                        currentRowId = int.Parse(type.Name == "Bitmap" ? row.Cells[3].Value.ToString() : row.Cells[2].Value.ToString());
                        uC.Edit(row);
                    }, (int id) =>
                    {
                        loadingCircle1.Visible = true;
                        loadingCircle1.Active = true;
                        uC.Delete(id, async () => await OnSuccess());
                    }, (int id) => {
                        loadingCircle1.Visible = true;
                        loadingCircle1.Active = true;
                        Manejador<RentaDevolucion, RentaDevolucionDto> _Manejador = new Manejador<RentaDevolucion, RentaDevolucionDto>();
                        RentaDevolucionDto renta = _Manejador.ObtenerPorFiltro(x => x.Id == id, new[] { "Vehiculo", "Vehiculo.Modelo", "Vehiculo.Marca" });
                        renta.Estado = false;
                        _Manejador.Actualizar(renta);

                        Manejador<BOL.Vehículo, VehículoDto> _ManejadorVehiculo = new Manejador<BOL.Vehículo, VehículoDto>();
                        VehículoDto _Vehiculo = _ManejadorVehiculo.ObtenerPorFiltro(x => x.Id == renta.VehiculoId, new[] { "Marca", "Modelo" });
                        _Vehiculo.Estado = true;
                        _ManejadorVehiculo.Actualizar(_Vehiculo);
                        OnSuccess();
                    }, menuItemName);
                }
                else
                {
                    tableGeneric1 = new TableGeneric(menuItemName, loadingHandler, MainPanel.Width, false);
                    uC.SuccessFunction += async () => await SuccessFunction();
                }

                tableGeneric1.BackColor = Color.Transparent;
                //tableGeneric1.Left = (MainPanel.Width - tableGeneric1.Width) / 2;
                tableGeneric1.Name = "tableGeneric1";
                tableGeneric1.AutoSize = true;
                MainPanel.Controls.Add(tableGeneric1);

                if (menuItemName != "Consulta")
                {
                    await tableGeneric1.FillData(menuItemName, loadingHandler, MainPanel.Width);
                }

                tableGeneric1.Top = operationPanel.Height + 105;
            }
            else
            {
                btnAdd.Visible = false;
            }
        }

        public void ExcepcionHandler(Exception ex) {
            loadingCircle1.Active = false;
            loadingCircle1.Visible = false;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            isOpen = !isOpen;
            t = new Timer();

            t.Interval = 35;

            t.Enabled = true;

            t.Tick += new EventHandler(OnTimerEvent);

            menuStrip3.Visible = !isOpen;
            menuStrip2.Visible = isOpen;
        }

        public void OnError(bool valido, string textoError = null, Panel panel = null, Point? loc = null)
        {
            loadingCircle1.Visible = true;
            loadingCircle1.Active = true;
            panel = panel != null ? panel : operationPanel;

            if (!valido)
            {
                panel.Controls.Remove(labelError);
            }
            else
            {
                labelError = new Label();
                labelError.ForeColor = Color.Red;
                labelError.Font = new Font(new FontFamily("Calibri"), 12, FontStyle.Bold);
                labelError.AutoSize = true;
                labelError.Text = textoError;

                if (loc != null)
                {
                    labelError.Location = (Point) loc;
                }

                panel.Controls.Add(labelError);
                loadingCircle1.Active = false;
                loadingCircle1.Visible = false;
            }
        }

        public async Task OnSuccess()
        {
                btnUpdate.Visible = false;
                await tableGeneric1.FillData(menuItemName, loadingHandler, MainPanel.Width);
        }

        public async Task SuccessFunction()
        {
            await tableGeneric1.FillData(menuItemName, loadingHandler, MainPanel.Width, false);
        }

        

        public void loadingHandler()
        {
            loadingCircle1.Active = false;
            loadingCircle1.Visible = false;
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            if (isOpen)
            {
                if (menuStrip2.Width < 239)
                {
                    menuStrip2.Width = menuStrip2.Width + 40;
                    MainPanel.Width = MainPanel.Width - 40;
                    panelHeader.Width = panelHeader.Width - 40;
                    operationPanel.Width = operationPanel.Width - 40;
                    btnAdd.Left = btnAdd.Left - 40;
                    //btnDelete.Left = btnDelete.Left - 40;
                }
                else
                {
                    t.Enabled = false;
                }
            } else
            {
                if (menuStrip2.Width > 80)
                {
                    menuStrip2.Width = menuStrip2.Width - 40;
                    MainPanel.Width = MainPanel.Width + 40;
                    panelHeader.Width = panelHeader.Width + 40;
                    operationPanel.Width = operationPanel.Width + 40;
                    btnAdd.Left = btnAdd.Left + 40;
                }
                else
                {
                    //menuStrip2.Width = 0;
                    //menuStrip3.Location = new Point(MainPanel.Width,menuStrip3.Location.Y);
                    t.Enabled = false;
                    t.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var valido = textBox1.Text != "" && textBox2.Text != "";
            if (valido)
            {

                string clave = textBox2.Text.generateShaText();
                var usuario = _Manejador.ObtenerPorFiltro(x => x.Nombre.ToLower() == textBox1.Text.ToLower() && x.Clave == clave);

                if (usuario != null)
                {
                    panelLogin.Visible = false;
                    toolStripTextBox1.Text = usuario.Nombre;
                    labelUser.Text = usuario.Nombre;
                    labelUser.Left = (MainPanel.Width - labelUser.Size.Width) / 2;
                    currentUserId = usuario.EmpleadoId;
                } else
                {
                    OnError(usuario == null, "Las credenciales son incorrectas.", panelCredenciales,
                    new Point(button1.Location.X - 5, button1.Location.Y + button1.Size.Height + 30));
                }
            } else
            {
                OnError(!valido, "Debe colocar todas las credenciales.", panelCredenciales, 
                    new Point(button1.Location.X - 5, button1.Location.Y + button1.Size.Height + 10));
            }
        }
    }
}
