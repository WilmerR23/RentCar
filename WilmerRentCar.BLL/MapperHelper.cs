using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerRentCar.BLL
{
    public class MapperHelper
    {
        public static IMapper MapperInstance()
        {
            return Mapper.Instance;
        }

        public static void Init ()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<BOL.Clientes, BOL.Dtos.ClientesDto>();
                //.ForMember(x => x.Nombre, cpf => cpf.MapFrom(b => b.Persona.Nombre))
                //.ReverseMap()
                //.ForMember(x => x.Persona, cpf => cpf.Ignore());

                config.CreateMap<BOL.Marca, BOL.Dtos.MarcaDto>().ReverseMap();
                config.CreateMap<BOL.Modelo, BOL.Dtos.ModeloDto>().ReverseMap();


                config.CreateMap<BOL.Vehículo, BOL.Dtos.VehículoDto>()
                .ForMember(x => x.Nombre, cpf => cpf.MapFrom(b => string.Format("{0} - {1},{2}", b.Placa, b.Marca.Nombre, b.Modelo.Nombre)))
                .ForMember(x => x.MarcaDescripcion, cpf => cpf.MapFrom(b => b.Marca.Nombre))
                .ForMember(x => x.ModeloDescripcion, cpf => cpf.MapFrom(b => b.Modelo.Nombre))
                .ForMember(x => x.TipoVehiculoDescripcion, cpf => cpf.MapFrom(b => b.TipoVehiculo.Nombre))
                .ReverseMap()
                .ForMember(x => x.Modelo, cpf => cpf.Ignore())
                .ForMember(x => x.Marca, cpf => cpf.Ignore())
                .ForMember(x => x.TipoVehiculo, cpf => cpf.Ignore());

                //config.CreateMap<BOL.Empleado, BOL.Dtos.EmpleadoDto>()
                //.ForMember(x => x.Nombre, cpf => cpf.MapFrom(b => b.Persona.Nombre))
                //.ReverseMap()
                //.ForMember(x => x.Persona, cpf => cpf.Ignore());


                //config.CreateMap<BOL.Inspección, BOL.Dtos.InspeccionDto>().ReverseMap();
                config.CreateMap<BOL.Usuario, BOL.Dtos.UsuarioDto>().ReverseMap();
                //config.CreateMap<BOL.Persona, BOL.Dtos.PersonaDto>().ReverseMap();
                //config.CreateMap<BOL.TipoPersona, BOL.Dtos.TipoPersonaDto>().ReverseMap();


                config.CreateMap<BOL.RentaDevolucion, BOL.Dtos.RentaDevolucionDto>();
            });
        }
    }
}
