using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using BackEnd.DTO;
using BackEnd.Modelo;

namespace BackEnd.Utilidades
{
    public class AutoMapperProfile: Profile
    {
        // utilizamos automapper para convertir las clases originales a las DTO necesarias
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();

            // En este caso ignoramos el idCategoriaNavigation, ya que ese campo lo creamos en DTO
            //Para eso se usa ForMember
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>().ForMember(destino =>
            destino.IdCategoriaNavigation,
            opt => opt.Ignore()
            );

            CreateMap<DetalleVenta, DetalleVentaDTO>();
            CreateMap<DetalleVentaDTO, DetalleVenta>();

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();

        }

    }
}
