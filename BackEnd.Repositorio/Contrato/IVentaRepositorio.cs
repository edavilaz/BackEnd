using BackEnd.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repositorio.Contrato
{
    // acá trabajaremos exclusivamente con venta la lógica será distinta menos en la consulta
    public interface IVentaRepositorio: IGenericoRepositorio<Venta>
    {
        Task<Venta>Registrar(Venta modelo);
    }
}
 