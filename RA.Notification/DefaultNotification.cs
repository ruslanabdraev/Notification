using System.Globalization;
using System.Threading.Tasks;
using RA.Notification.Contract;

namespace RA.Notification
{
    public class DefaultNotification : INotification
    {
        private readonly IConfiguration _configuration;
        private readonly IChannelFactory _channelFactory;

        public DefaultNotification(IConfiguration configuration, IChannelFactory channelFactory)
        {
            _configuration = configuration;
            _channelFactory = channelFactory;
        }

        public async Task NotifyAsync(NotificationInfo info, NotificationType type)
        {
            var settings = _configuration.LoadSettings(type);
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
