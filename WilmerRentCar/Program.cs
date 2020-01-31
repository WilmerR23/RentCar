using System;
using System.IO;
using System.Windows.Forms;
using WilmerRentCar.BLL;
using WilmerRentCar.UTL;

namespace WilmerRentCar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.FirstChanceException += (s, eventArgs) => { Handler(eventArgs.Exception); };
            MapperHelper.Init();
                Application.Run(new Form1());
            
        }

        static void Handler(Exception ex)
        {
            try
            {
                MessageBox.Show("Ha ocurrido un error, favor de verificar el log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception exe)
            {
                throw exe;
            } finally
            {
                string[] s = { "\\bin" };
                string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0];
                SimpleLog.SetLogFile(logDir: ".\\Log", prefix: "MyLog_", writeText: false);
                SimpleLog.Error(string.Format("Mensaje: {0} Inner Exception Mensaje: {1}", ex.Message, ex.InnerException?.Message ?? ""));

            }
        }
    }
}
