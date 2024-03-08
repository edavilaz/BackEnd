using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    // Esta clase me serviré para agregar los campos de una tarjeta de crédito (sólo de ejemplo)
    public class TarjetaDTO
    {
        [Required(ErrorMessage ="Ingrese Titular")]
        public string? Titular { get; set; }
        
        [Required(ErrorMessage ="Ingrese Número de Tarjeta")]
        public string? Numero { get; set; }
        
        [Required(ErrorMessage ="Ingrese Vigencia")]
        public string? Vigencia { get; set; }
        
        [Required(ErrorMessage ="Ingrese código CVV")]
        public string? CVV { get; set; }

    }
}
