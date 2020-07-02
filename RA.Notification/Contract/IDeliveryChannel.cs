using System.Threading.Tasks;

namespace RA.Notification.Contract
{
    public interface IDeliveryChannel
    {
        Task SendAsync(string source, string code, string name, string address, string message, string date);
    }
}
