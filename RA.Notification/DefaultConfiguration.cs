using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using RA.Notification.Contract;

namespace RA.Notification
{
    public class DefaultConfiguration: INotificationConfiguration
    {
        private static readonly Dictionary<NotificationType, ChannelSettings> Settings = new Dictionary<NotificationType, ChannelSettings>();
      
        static DefaultConfiguration()
        {
            Initialize();
        }

        public ChannelSettings GetChannelSettings(NotificationType type)
        {
            return Settings[type];
        }

        private static void Initialize()
        {
            foreach (NotificationType type in Enum.GetValues(typeof(NotificationType)))
            {
                var prefix = type.ToString("G");

                Settings[type] = new ChannelSettings()
                {
                    Module = GetSetting(prefix + "ChannelModule", ""),
                    Url = GetSetting(prefix + "ChannelUrl", ""),
                    Domain = GetSetting(prefix + "ChannelDomain", ""),
                    Username = GetSetting(prefix + "ChannelUsername", ""),
                    Password = GetSetting(prefix + "ChannelPassword", ""),
                    CertNumber = GetSetting(prefix + "ChannelCertNumber", ""),
                    CertIssuer = GetSetting(prefix + "ChannelCertIssuer", ""),
                    Additional = GetSetting(prefix + "ChannelAdditional", "")
                };
            }
        }

        private static string GetSetting(string key, string defaultValue)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return defaultValue;
            }
        }

    }
}
