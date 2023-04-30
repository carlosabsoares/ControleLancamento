namespace ControleLancamento.Api.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public BaseEntity()
        {
            DataCriacao = DateTime.Now;
        }
    }
}