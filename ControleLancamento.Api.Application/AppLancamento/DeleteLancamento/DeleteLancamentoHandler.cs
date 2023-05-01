using AutoMapper;
using ControleLancamento.Api.Application.Configuration.Commands;
using ControleLancamento.Api.Application.Configuration.Events;
using ControleLancamento.Api.Domain.Entities;
using ControleLancamento.Api.Domain.Enum;
using ControleLancamento.Api.Domain.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Api.Application.AppLancamento
{
    public class DeleteLancamentoHandler : Notifiable, ICommandHandler<DeleteLancamentoCommand>
    {

        private readonly ILancamentoRepository _repoLancamento;
        private readonly IMapper _mapper;
        private readonly CancellationToken cancellationToken = new CancellationToken(true);

        public DeleteLancamentoHandler(ILancamentoRepository repoLancamento, IMapper mapper)
        {
            _repoLancamento = repoLancamento;
            _mapper = mapper;
        }

        public async Task<IEvent> Handle(DeleteLancamentoCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            var _lancamentoRepo = (await _repoLancamento.FindAll()).OrderByDescending(x=> x.DataCriacao).ToList();

            int? indexIdDelete = _lancamentoRepo.FindIndex(x=> x.Id.Equals(request.Id));
            int indexIdAtualizar = 0;
            decimal valorSaldoFinal = 0;

            LancamentoEntity registroDeletar = _lancamentoRepo.FirstOrDefault(x => x.Id.Equals(request.Id));

            if(indexIdDelete != null && indexIdDelete > 0)
            {
                indexIdAtualizar = indexIdDelete.Value - 1;
            }

            var registroAtualizar = _lancamentoRepo.ElementAt(indexIdAtualizar);

            valorSaldoFinal = EnTipoOperacao.Debito.Equals(registroDeletar.TipoOperacao) ?
                                        registroDeletar.SaldoInicial + (registroAtualizar.Valor * -1) :
                                        registroDeletar.SaldoInicial + registroAtualizar.Valor;

            registroAtualizar.SaldoInicial = registroDeletar.SaldoInicial;
            registroAtualizar.SaldoFinal = valorSaldoFinal;

            await _repoLancamento.BeginTransactionAsync();

            var resultDelete = await _repoLancamento.Delete(registroDeletar);
            var resultUpdate = await _repoLancamento.Update(registroAtualizar);

            await _repoLancamento.CommitTransactionAsync();

            //return new ResultEvent(true, resultUpdate ? resultUpdate : null);
            return new ResultEvent(true, null);
        }
    }
}
