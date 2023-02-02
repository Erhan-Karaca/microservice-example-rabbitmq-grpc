using MediatR;

namespace OncuService.Common.Models.RequestModels;

public class SendMailCommand : IRequest<bool>
{
    public string To { get; set; }
    public string Subject { get; set; } = "Subject";
    public string? Html { get; set; }
    public string? Message { get; set; }
}
