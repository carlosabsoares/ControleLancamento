using ControleLancamento.Api.Application.Configuration.Events;
using ControleLancamento.Api.Application.Configuration.Queries;

namespace ControleLancamento.Api.Application
{
    public class GetAllLancamentoHandler : IQueryHandler<GetAllLancamentoQuery>
    {
        public async Task<IEvent> Handle(GetAllLancamentoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}