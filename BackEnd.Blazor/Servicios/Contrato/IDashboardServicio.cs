using BackEnd.DTO;

namespace BackEnd.Blazor.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>>Resumen(); 
    }
}
