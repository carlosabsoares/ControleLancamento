﻿using ControleLancamento.Api.Application.Configuration.Commands;
using ControleLancamento.Api.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Api.Application.AppLancamento
{
    public class PutLancamentoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public EnTipoOperacao TipoOperacao { get; set; }
        public DateTime Data { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNullOrNullable(Valor, "Valor", "O valor é obrigatório")
                    .IsTrue(ValidaTipoOperacao(TipoOperacao), "Tipo Operacao", "O tipo de operacao é inválido.")
            );
        }

        private bool ValidaTipoOperacao(EnTipoOperacao tipoOperacao)
        {
            bool _return = false;


            if ((int)tipoOperacao >= Enum.GetValues(typeof(EnTipoOperacao)).Cast<int>().Min() &&
               (int)tipoOperacao <= Enum.GetValues(typeof(EnTipoOperacao)).Cast<int>().Max())
                _return = true;

            return _return;
        }
    }
}
