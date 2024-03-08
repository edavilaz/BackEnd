 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


using BackEnd.Repositorio.Contrato;
using BackEnd.Repositorio.DBContext;

namespace BackEnd.Repositorio.Implementacion
{
    public class GenericoRepositorio<TModelo>:IGenericoRepositorio<TModelo> where TModelo : class
    {
        // referencia a la BD
        private readonly DbBackendContext _dbContext;

        public GenericoRepositorio(DbBackendContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
        {
            IQueryable<TModelo> consulta = (filtro == null) ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
            return consulta;
        }

        public async Task<TModelo> Crear(TModelo modelo) //insert into
        { 
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;

            }catch

            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true; //devolvemos true porque en la implementación es booleano

            }
            catch

            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch

            {
                throw;
            }
        }
    }
}
