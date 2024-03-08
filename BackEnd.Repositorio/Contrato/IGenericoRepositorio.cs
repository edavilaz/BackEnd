using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repositorio.Contrato
{
    // Creamos esta Interface para lograr trabajar con cualquier clase que vaya a necesitar hacer el CRUD
    public interface IGenericoRepositorio<TModelo> where TModelo : class
    {
        IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null);
        Task<TModelo> Crear(TModelo modelo);
        Task<bool> Editar(TModelo modelo);
        Task<bool> Eliminar(TModelo modelo);

    }
}
