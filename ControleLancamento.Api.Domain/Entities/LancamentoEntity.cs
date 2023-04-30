namespace ControleLancamento.Api.Domain.Entities
{
    public class LancamentoEntity : BaseEntity
    {
        public decimal SaldoInicial { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal SaldoFinal { get; set; }
    }
}