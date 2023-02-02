using OncuService.Common.Models.RequestModels;
using MediatR;
using AutoMapper;
using OncuService.Common.Infrastructure;
using OncuService.Common.Events.Sms;
using OncuService.Common;

namespace OncuService.Api.Application.Features.Commands.Sms;

public class SendSmsCommandHandler : IRequestHandler<SendSmsCommand, bool>
{
    private readonly IMapper mapper;

    public SendSmsCommandHandler(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public Task<bool> Handle(SendSmsCommand request, CancellationToken cancellationToken)
    {
        var @event = new SendSmsEvent()
        {
            Phone = request.Phone,
            Message = request.Message
        };

        QueueFactory.SendMessageToExchange(exchangeName: OncuServiceConstants.SmsExchangeName, exchangeType: OncuServiceConstants.DefaultExchangeType, queueName: OncuServiceConstants.SmsQueueName, obj: @event);

        return Task.FromResult(true);
    }
}
