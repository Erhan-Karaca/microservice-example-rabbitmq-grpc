using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncuService.Common;

public class OncuServiceConstants
{
    public const string RabbitMQHost = "localhost"; //"localhost";
    public const string RabbitMQUser = "admin";
    public const string RabbitMQPass = "admin";
    public const string DefaultExchangeType = "direct";

    public const string SmsExchangeName = "notification";
    public const string SmsQueueName = "notification.send_sms";

    public const string MailExchangeName = "notification";
    public const string MailQueueName = "notification.send_mail";
}
