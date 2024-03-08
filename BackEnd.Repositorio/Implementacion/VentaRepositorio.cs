using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Modelo;
using BackEnd.Repositorio.Contrato;
using BackEnd.Repositorio.DBContext;



namespace BackEnd.Repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly DbBackendContext _dbContext;

        public VentaRepositorio(DbBackendContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
         
        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            // usaremos transacciones para que en el caso de error elimine todos los cambios realizados en todas las tablas

            using(var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta dv in modelo.DetalleVenta) 
                    {
                        // Restamos la cantidad de productos vendidos 
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First(); 
                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);

                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();
                    ventaGenerada = modelo;
                    transaction.Commit();
                }
                catch
                { 
                    transaction.Rollback();
                    throw;
                }
            }

            return ventaGenerada;
        }
    }

}
