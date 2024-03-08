using BackEnd.DTO;

namespace BackEnd.Blazor.Servicios.Contrato
{
    public interface IVentaServicio
    {
       
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
      
    }
}
