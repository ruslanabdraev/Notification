using System.Globalization;
using System.Threading.Tasks;
using RA.Notification.Contract;

namespace RA.Notification
{
    public class DefaultNotification : INotification
    {
        private readonly INotificationConfiguration _configuration;
        private readonly IDeliveryChannelFactory _channelFactory;

        public DefaultNotification(INotificationConfiguration configuration, IDeliveryChannelFactory channelFactory)
        {
            _configuration = configuration;
            _channelFactory = channelFactory;
        }

        public async Task NotifyAsync(NotificationInfo info, NotificationType type)
        {
            var settings = _configuration.GetChannelSettings(type);
            var channel = _channelFactory.Create(settings, type);

            await channel.SendAsync(
                info.Sender, 
                info.TypeCode, 
                info.TypeName, 
                info.Address, 
                info.MessageText,
                info.Date.ToString(CultureInfo.InvariantCulture)
                );
        }
    }
}
