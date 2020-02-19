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
            _dbSet.Add(entidad);
            _RentCarDbContext.SaveChanges();
        }

        public TDto CrearSync(TDto entity, bool willSave = false)
        {
            T entidad = Mapper.Map<TDto, T>(entity);
            _dbSet.Add(entidad);

            if (willSave)
                _RentCarDbContext.SaveChanges();

            return Mapper.Map<T, TDto>(entidad);
        }

        public void Actualizar(TDto entity)
        {
            var entidad = Mapper.Map<TDto, T>(entity);
            var ent = _dbSet.Find(entidad.Id);
            Mapper.Map(entity, ent);
            _RentCarDbContext.SaveChanges();
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
