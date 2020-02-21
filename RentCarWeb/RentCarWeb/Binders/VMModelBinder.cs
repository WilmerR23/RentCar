using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using WilmerRentCar.BOL.Dtos;

namespace RentCarWeb.Binders
{
    public class VMModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            //if (bindingContext.ModelType == typeof(VehículoDto))
            //{
            //    try
            //    {
            //        VehículoDto vm = JsonConvert.DeserializeObject<VehículoDto>(HttpContext.Current.Request.Form["vm"]);

            //        vm.TodosDocumentos = HttpContext.Current.Request.Files["Imagenes"];

            //        bindingContext.Model = vm;
            //        return true;
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }

            //}

            return false;
        }
    }
}