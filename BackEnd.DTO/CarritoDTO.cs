using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public class CarritoDTO
    {
        // Para evitar problemas aumento ? para que acepten nulos y no me generen errores.
        public ProductoDTO? Producto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
