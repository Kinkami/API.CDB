using API.Cdb.Domain.Dto;

namespace API.Cdb.Domain.Interfaces.Business
{
    public interface ICdbBusiness
    {
        CalcularCdbResponseDto CalcularCdb(CalcularCdbRequestDto calcularCdbRequestDto);
    }
}
