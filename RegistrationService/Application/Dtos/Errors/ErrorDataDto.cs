using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Dtos.Errors
{
    public class ErrorDataDto
    {
        public string Module { get; set; }
        public string Description { get; set; }
        public int ErrorLine { get; set; }
        public string ErrorCode { get; set; }
        public string Custom { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
    }
}
