using Flunt.Validations;
using ControleLancamento.Api.Application.Configuration.Events;
using MediatR;

namespace ControleLancamento.Api.Application.Configuration.Queries
{
    public interface IQuery : IRequest<IEvent>, IValidatable
    {
    }
}