using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OncuService.Common;
using OncuService.Common.Events.Mail;
using OncuService.Common.Infrastructure;
using OncuService.Common.Models.RequestModels;
using OncuService.EventBus.Base.Abstraction;
using OncuService.EventBus.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncuService.Api.Application.Features.Commands.Mail;

public class SendMailCommandHandler : IRequestHandler<SendMailCommand, bool>
{
    public Task<bool> Handle(SendMailCommand request, CancellationToken cancellationToken)
    {
        var @event = new SendMailEvent()
        {
            To = request.To,
            Message = request.Message,
            Subject = request.Subject,
        };

        QueueFactory.SendMessageToExchange(exchangeName: OncuServiceConstants.MailExchangeName, exchangeType: OncuServiceConstants.DefaultExchangeType, queueName: OncuServiceConstants.MailQueueName, obj: @event);

        return Task.FromResult(true);
    }
}
