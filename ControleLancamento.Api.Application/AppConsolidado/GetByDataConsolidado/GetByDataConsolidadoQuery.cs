using ControleLancamento.Api.Application.Configuration.Queries;
using ControleLancamento.Api.Domain.Enum;
using DocumentFormat.OpenXml.Office2010.Excel;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Api.Application.AppConsolidado
{
    public class GetByDataConsolidadoQuery : Notifiable, IQuery
    {
        public DateTime Data { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsFalse(Data.ToString() == "01/01/0001 00:00:00", "Data", "A data é obrigatória"));
        }
    }
}
