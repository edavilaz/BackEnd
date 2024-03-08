using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage ="Ingresa Nombre")]
        public string? Nombre { get; set; }
        
        [Required(ErrorMessage = "Ingresa Descripción")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }
        
        [Required(ErrorMessage = "Ingresa Precio")]
        public decimal? Precio { get; set; }
        
        [Required(ErrorMessage = "Ingresa Precio Oferta")]
        public decimal? PrecioOferta { get; set; }
        
        [Required(ErrorMessage = "Ingresa Cantidad")]
        public int? Cantidad { get; set; }
        
        [Required(ErrorMessage = "Ingresa Imagen")]
        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }


        // Acá usaremos la CategoriaDTO, estamos intentando dejar a un lado nuestras clases originales
        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}
