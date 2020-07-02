namespace RA.Notification.Contract
{
    public interface IDeliveryChannelFactory
    {
        IDeliveryChannel Create(ChannelSettings settings, NotificationType type);
    }
}
