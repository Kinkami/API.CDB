namespace API.Cdb.Domain.Entities
{
    public class CdbEntidade
    {
        public int Meses { get; set; }
        public decimal ValorInicial { get; set; }

        public decimal ValorBruto { get; set; }

        public decimal Cdi { get; set; }

        public decimal Tb { get; set; }

        public decimal Imposto { get; set; }

        public decimal ValorLiquido { get; set; }
    }
}
