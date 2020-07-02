namespace RA.Notification.Contract
{
    public interface IChannelFactory
    {
        IChannel Create(ChannelSettings settings, NotificationType type);
    }
}
