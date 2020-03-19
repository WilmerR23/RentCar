using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WilmerRentCar.BOL;
using WilmerRentCar.BOL.Dtos;
using WilmerRentCar.DAL;

namespace WilmerRentCar.BLL
{

    public class Manejador<T, TDto> where T : BaseEntity
                                   where TDto : BaseEntityDto
    {
        public DbSet<T> _dbSet;
        public RentCarDbContext _RentCarDbContext;


        public Manejador()
        {
            _RentCarDbContext = new RentCarDbContext();
            _dbSet = _RentCarDbContext.Set<T>();
        }

        public void Crear(TDto entity, bool willSave = false)
        {
            T entidad = Mapper.Map<TDto, T>(entity);
            entidad.FechaCreacion = DateTime.Now;
            entidad.Estado = true;
            _dbSet.Add(entidad);
            _RentCarDbContext.SaveChanges();
        }

        public List<TDto> CrearRange(List<TDto> entities, bool willSave = false)
        {
            List<T> entidades = Mapper.Map<List<TDto>, List<T>>(entities);
            entidades.ForEach((x) => { x.Estado = true; x.FechaCreacion = DateTime.Now; });
            _dbSet.AddRange(entidades);
            _RentCarDbContext.SaveChanges();

            return Mapper.Map<List<T>, List<TDto>>(entidades);
        }

        

        public TDto CrearSync(TDto entity, bool willSave = false)
        {
            T entidad = Mapper.Map<TDto, T>(entity);
            entidad.FechaCreacion = DateTime.Now;
            entidad.Estado = true;
            _dbSet.Add(entidad);

            if (willSave)
                _RentCarDbContext.SaveChanges();

            return Mapper.Map<T, TDto>(entidad);
        }

        public TDto Actualizar(TDto entity)
        {
            var entidad = Mapper.Map<TDto, T>(entity);
            var ent = _dbSet.Find(entidad.Id);
            var fecha = ent.FechaCreacion;
            Mapper.Map(entity, ent);
            ent.FechaCreacion = fecha;
            ent.Estado = true;
            _RentCarDbContext.SaveChanges();

            return Mapper.Map<T, TDto>(ent);
        }

        public IEnumerable<TDto> ObtenerTodos(string[] paths = null)
        {
            var query = Include(paths);
            return Mapper.Map<List<T>, List<TDto>>((paths != null ? query.Where(x => x.Estado).ToList() : query.Where(x => x.Estado).ToList()));
        }

        public IQueryable<T> Include(string[] paths = null)
        {
            var query = _dbSet.AsQueryable();
            if (paths != null)
            {
                foreach (string item in paths)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        public DbSet<T> IncludeDbSet(string[] paths = null)
        {
            if (paths != null)
            {
                foreach (string item in paths)
                {
                    _dbSet.Include(item);
                }
            }
            return _dbSet;
        }


        public TDto ObtenerPorFiltro(Expression<Func<T, bool>> predicate, string[] paths = null)
        {
                var query = Include(paths);
                var data = query.FirstOrDefault(predicate);
                var Mapper = MapperHelper.MapperInstance();
                TDto entidad = Mapper.Map<T, TDto>(data);
                return entidad;
        }
        
        public IEnumerable<T> ObtenerTodosPorFiltro(Expression<Func<T, bool>> predicate, string[] paths = null)
        {
            var query = Include(paths);
            var data = query.Where(predicate).ToList();            
            return data; 
        }

        public IEnumerable<TDto> ObtenerTodosPorFiltroDto(Expression<Func<T, bool>> predicate, string[] paths = null)
        {
            var query = Include(paths);
            var data = query.Where(predicate).ToList();
            var Mapper = MapperHelper.MapperInstance();
            IEnumerable<TDto> entidades = Mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(data);
            return entidades;
        }


        public TDto Obtener(int id, string[] paths = null)
        {
            var query = IncludeDbSet(paths);
            var data = query.Find(id);
            return Mapper.Map<T,TDto>(data);
        }

        public void Eliminar(int id)
        {
                var entity = _dbSet.Find(id);
                entity.Estado = false;
                _RentCarDbContext.SaveChanges();
        }
    }
}
