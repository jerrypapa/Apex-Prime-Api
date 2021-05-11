using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Models
{
    public class ErrorLog
    {
        public Guid Id { get; set; }
        public string Module { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime ServerDate { get; set; }
        public string Description { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public int ErrorLine { get; set; }
        public string ErrorCode { get; set; }
        public string DeveloperCustomException { get; set; }
        public ErrorLog() { }
        public ErrorLog(string module, string description, string errorCode, string devError, int errorLine, string src, string stack)
        {
            Id = Guid.NewGuid();
            Module = !string.IsNullOrWhiteSpace(module) ? module : throw new ArgumentNullException(nameof(module));
            Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ArgumentNullException(nameof(description));
            Source = !string.IsNullOrWhiteSpace(src) ? src : "";
            StackTrace = !string.IsNullOrWhiteSpace(stack) ? stack : "";
            ErrorCode = !string.IsNullOrWhiteSpace(errorCode) ? errorCode : "000";
            ErrorLine = !string.IsNullOrWhiteSpace(errorLine.ToString()) ? errorLine : 0;
            DateLogged = DateTime.Now;
            ServerDate = DateTime.UtcNow;
            DeveloperCustomException = !string.IsNullOrWhiteSpace(devError) ? devError : "NO REF";
        }

        public static ErrorLog LogError(string module, string description, string errorCode, string devError, int errorLine, string src, string stack)
        {
            return new ErrorLog(module, description, errorCode, devError, errorLine, src, stack);
        }
    }
}
