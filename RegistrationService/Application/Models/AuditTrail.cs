using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RegistrationService.Application.Models
{
    public class AuditTrail
    {
        public Guid Id { get; private set; }
        public string ModuleName { get; private set; }
        public string Page { get; private set; }
        public string Type { get; private set; }
        public string Action { get; private set; }
        public Guid UserId { get; private set; }
        public string IpAddress { get; private set; }
        public DateTime AuditDate { get; private set; }
        public DateTime ServerDate { get; private set; }
        public AuditTrail() { }
        public AuditTrail(string moduleName, string page, string action, Guid userId, string type)
        {
            Id = Guid.NewGuid();
            ModuleName = !string.IsNullOrWhiteSpace(moduleName) ? moduleName : throw new ArgumentNullException(nameof(moduleName));
            Type = !string.IsNullOrWhiteSpace(type) ? type : throw new ArgumentNullException(nameof(type));
            Page = !string.IsNullOrWhiteSpace(page) ? page : throw new ArgumentNullException(nameof(page));
            Action = !string.IsNullOrWhiteSpace(action) ? action : throw new ArgumentNullException(nameof(action));
            IpAddress = GetLocalIPAddress();
            UserId = !string.IsNullOrWhiteSpace(userId.ToString()) ? userId : Guid.Empty;
            AuditDate = DateTime.Now;
            ServerDate = DateTime.UtcNow;
        }

        public static AuditTrail AddAudiTrail(string moduleName, string page, string action, Guid userId, string type)
        {
            return new AuditTrail(moduleName, page, action, userId, type);
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
