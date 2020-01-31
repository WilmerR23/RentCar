using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WilmerRentCar.BLL;
using WilmerRentCar.BOL;

namespace WilmerRentCar.UserControls
{
    public abstract class BaseUserControl : UserControl
    {
        public Func<Task> SuccessFunction;
        public abstract void Add(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler);

        public virtual void Operation(bool invalido, Action<bool, string> validatorHandler, Action LimpiarScreen, Func<Task> OnSuccess, Action UCLogic)
        {
            validatorHandler(invalido, "Debes ingresar valores a los campos obligatorios.");
            if (!invalido) {
                UCLogic();
                OnSuccess();
                LimpiarScreen();
            }
        }

        public abstract void Update(Action<bool, string> validatorHandler, Func<Task> OnSuccess, Action<Exception> ExceptionHandler, int id = 0);
        public abstract void Delete(int id, Func<Task> OnSuccess);
        public abstract void Edit( DataGridViewRow row);
        
    }
}
