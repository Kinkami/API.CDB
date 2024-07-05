using API.Cdb.Domain.Dto;
using API.Cdb.Domain.Interfaces.Business;
using API.CDB.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Cdb.Tests
{
    public class CdbControllerTests
    {
        private readonly Mock<ICdbBusiness> _mockCdbBusiness;
        private readonly CdbController _controller;

        public CdbControllerTests()
        {
            _mockCdbBusiness = new Mock<ICdbBusiness>();
            _controller = new CdbController(_mockCdbBusiness.Object);
        }

        [Fact]
        public void CalcularCdb_DeveRetornarOkResult_ComRespostaValida()
        {
            // Arrange
            var request = new CalcularCdbRequestDto { Meses = 12, ValorInicial = 10000 };
            var response = new CalcularCdbResponseDto { ValorBruto = 12167.79m, ValorLiquido = 9734.23m };

            _mockCdbBusiness.Setup(b => b.CalcularCdb(request)).Returns(response);

            // Act
            var result = _controller.CalcularCdb(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CalcularCdbResponseDto>(okResult.Value);
            Assert.Equal(response.ValorBruto, returnValue.ValorBruto);
            Assert.Equal(response.ValorLiquido, returnValue.ValorLiquido);
        }

        [Fact]
        public void CalcularCdb_DeveRetornarBadRequest_ParaValoresInvalidos()
        {
            // Arrange
            var request = new CalcularCdbRequestDto { Meses = -1, ValorInicial = -10000 };

            _mockCdbBusiness.Setup(b => b.CalcularCdb(request)).Throws(new ArgumentException("Valores inválidos."));

            // Act
            var result = _controller.CalcularCdb(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Valores inválidos.", badRequestResult.Value);
        }

    }
}
