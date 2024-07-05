using API.Cdb.Domain.Dto;
using API.Cdb.Domain.Interfaces.Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.CDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdbController : ControllerBase
    {
        private readonly ICdbBusiness _cdbBusiness;

        public CdbController(ICdbBusiness cdbBusiness)
        {
            _cdbBusiness = cdbBusiness;
        }

        /// <summary>
        /// Calcular CDB
        /// </summary>
        /// <returns>retorna o valor bruto e líquido</returns>
        [HttpGet("calcularCdb")]
        [EnableCors()]
        public ActionResult CalcularCdb([FromQuery][Required] CalcularCdbRequestDto calcularCdbRequest)
        {
            try
            {
                var result = _cdbBusiness.CalcularCdb(calcularCdbRequest);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
