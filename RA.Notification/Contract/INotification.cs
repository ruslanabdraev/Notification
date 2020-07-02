using System;
using System.Threading.Tasks;

namespace RA.Notification.Contract
{
    public interface INotification
    {
        Task NotifyAsync(NotificationInfo info, NotificationType type);
    }

    public class NotificationInfo
    {
        public string Sender { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Address { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }

    public enum NotificationType
    {
        Email,
        Sms,
        Telegram,
    }
}
