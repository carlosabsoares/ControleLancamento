using AutoMapper;
using ControleLancamento.Api.Application.AppLancamento;
using ControleLancamento.Api.Application.Configuration.Events;
using ControleLancamento.Api.Application.Configuration.Queries;
using ControleLancamento.Api.Domain.Entities;
using ControleLancamento.Api.Domain.Enum;
using ControleLancamento.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Api.Application.AppConsolidado
{
    public class GetAllConsolidadoHandler : IQueryHandler<GetAllConsolidadoQuery>
    {
        private readonly ILancamentoRepository _repoLancamento;
        private readonly CancellationToken cancellationToken = new CancellationToken(true);

        public GetAllConsolidadoHandler(ILancamentoRepository repoLancamento)
        {
            _repoLancamento = repoLancamento;
        }

        public async Task<IEvent> Handle(GetAllConsolidadoQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repoLancamento.FindAll()).GroupBy(x=> x.DataCriacao.Date);

            List<ConsolidadoDto> consolidados = new List<ConsolidadoDto>();

            foreach (var itemGroup in result)
            {
                var consolidado = new ConsolidadoDto();

                consolidado.Data = itemGroup.Key.Date;
                consolidado.SaldoInicial = itemGroup.OrderBy(x => x.DataCriacao).FirstOrDefault(x => x.DataCriacao.Date.Equals(itemGroup.Key.Date)).SaldoInicial;
                consolidado.SaldoFinal = itemGroup.OrderByDescending(x => x.DataCriacao).FirstOrDefault(x => x.DataCriacao.Date.Equals(itemGroup.Key.Date)).SaldoFinal;
                consolidado.TotalDebito = itemGroup.Where(x => x.DataCriacao.Date.Equals(itemGroup.Key.Date) && x.TipoOperacao.Equals(EnTipoOperacao.Debito)).Select(x => x.Valor).Sum();
                consolidado.TotalCredito = itemGroup.Where(x => x.DataCriacao.Date.Equals(itemGroup.Key.Date) && x.TipoOperacao.Equals(EnTipoOperacao.Credito)).Select(x => x.Valor).Sum();

                consolidados.Add(consolidado);
            }

            if (consolidados.Any())
            {
                return new ResultEvent(true, consolidados.OrderByDescending(x=> x.Data));
            }
            else
            {
                return new ResultEvent(true, null);
            }
        }
    }
}
