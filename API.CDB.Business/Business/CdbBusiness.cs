using API.Cdb.Domain.Dto;
using API.Cdb.Domain.Entities;
using API.Cdb.Domain.Interfaces.Business;


namespace API.CDB.Business.Business
{
    public class CdbBusiness : ICdbBusiness
    {
        public CalcularCdbResponseDto CalcularCdb(CalcularCdbRequestDto calcularCdbRequestDto)
        {

            if (calcularCdbRequestDto.ValorInicial <= 0 || calcularCdbRequestDto.Meses <= 0)
            {
                throw new ArgumentException("Valores inválidos.");
            }

            const decimal CdiValorFixo = 0.009m;
            const decimal TbValorFixo = 1.08m;

            var cdbEntidade = new CdbEntidade
            {
                ValorInicial = calcularCdbRequestDto.ValorInicial,
                Meses = calcularCdbRequestDto.Meses,
                Cdi = CdiValorFixo,
                Tb = TbValorFixo
            };

            cdbEntidade.Imposto = AliquotaDeImposto(cdbEntidade.Meses);
            cdbEntidade.ValorLiquido = CalcularValorLiquido(cdbEntidade);

            return new CalcularCdbResponseDto
            {
                ValorBruto = Math.Round(cdbEntidade.ValorBruto, 2),
                ValorLiquido = Math.Round(cdbEntidade.ValorLiquido, 2),
            };
        }

        private static decimal AliquotaDeImposto(int meses)
        {
            if (meses <= 6) return 0.225m;
            if (meses <= 12) return 0.20m;
            if (meses <= 24) return 0.175m;
            return 0.15m;
        }

        private static decimal CalcularValorLiquido(CdbEntidade cdbEntidade)
        {
            decimal valorMes = cdbEntidade.ValorInicial;

            for (int i = 0; i <= cdbEntidade.Meses; i++)
            {
                cdbEntidade.ValorBruto = valorMes * (1 + (cdbEntidade.Cdi * cdbEntidade.Tb));
                valorMes = cdbEntidade.ValorBruto;
            }
            return cdbEntidade.ValorBruto * (1 - cdbEntidade.Imposto);
        }
    }
}
