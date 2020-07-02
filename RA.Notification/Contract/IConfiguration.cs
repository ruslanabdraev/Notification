namespace RA.Notification.Contract
{
    public interface IConfiguration
    {
        ChannelSettings LoadSettings(NotificationType type);
    }

    public class ChannelSettings
    {
        public string Module { get; set; }
        public string Url { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CertNumber { get; set; }
        public string CertIssuer { get; set; }
        public string Additional { get; set; }
    }
}
