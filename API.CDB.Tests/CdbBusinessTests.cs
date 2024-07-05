using API.Cdb.Domain.Dto;
using API.CDB.Business.Business;

namespace API.Cdb.Tests
{
    public class CdbBusinessTests
    {
        private readonly CdbBusiness _cdbBusiness;

        public CdbBusinessTests()
        {
            _cdbBusiness = new CdbBusiness();
        }

        [Theory]
        [InlineData(10000, 6, 10700.57, 8292.94)]
        [InlineData(10000, 12, 11339.98, 9071.99)]
        [InlineData(10000, 24, 12735.73, 10506.98)]
        [InlineData(10000, 36, 14303.27, 12157.78)]
        public void CalcularCdb_DeveRetornarValorBrutoEValorLiquido(decimal valorInicial, int meses, decimal valorBrutoEsperado, decimal valorLiquidoEsperado)
        {
            // Arrange
            var requestDto = new CalcularCdbRequestDto
            {
                ValorInicial = valorInicial,
                Meses = meses
            };

            // Act
            var responseDto = _cdbBusiness.CalcularCdb(requestDto);

            // Assert
            Assert.Equal(valorBrutoEsperado, responseDto.ValorBruto, 2);
            Assert.Equal(valorLiquidoEsperado, responseDto.ValorLiquido, 2);
        }
    }
}