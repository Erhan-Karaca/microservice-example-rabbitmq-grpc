using MediatR;

namespace OncuService.Common.Models.RequestModels;

public class SendSmsCommand : IRequest<bool>
{
    public string? Phone { get; set; }

    public string? Message { get; set; }
}
