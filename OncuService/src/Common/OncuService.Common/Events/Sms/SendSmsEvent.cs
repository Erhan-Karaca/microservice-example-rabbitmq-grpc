using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncuService.Common.Events.Sms;

public class SendSmsEvent
{
    public string? Phone { get; set; }
    public string? Message { get; set; }
}
