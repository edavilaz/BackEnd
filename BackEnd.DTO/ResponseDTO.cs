using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    // Respuesta a las todas las solicitudes de nuestra API, a cualquier solicitud <T>
    public class ResponseDTO<T>
    {
        public T? Resultado { get; set; }

        public bool EsCorrecto { get; set; }

        public string? Mensaje { get; set; }



    }
}
