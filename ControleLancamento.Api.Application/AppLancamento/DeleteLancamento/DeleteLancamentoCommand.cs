﻿using ControleLancamento.Api.Application.Configuration.Commands;
using ControleLancamento.Api.Shared.Extension;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Api.Application.AppLancamento
{
    public class DeleteLancamentoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id.ToString(), "Id", "O Id do cargo é obrigatório")
                    .IsTrue(Id.ValidationGuid(), "Id", "O Id do cargo está inválido")
            );
        }
    }
}
