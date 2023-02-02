using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncuService.Common.Events.Mail;

public class SendMailEvent
{
    public string To { get; set; }
    public string Subject { get; set; } = "Subject";
    public string? Html { get; set; }
    public string? Message { get; set; }
}
