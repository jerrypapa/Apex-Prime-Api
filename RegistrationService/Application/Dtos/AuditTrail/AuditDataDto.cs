using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Dtos.AuditTrail
{
    public class AuditDataDto
    {
        public Guid Id { get; set; }
        public string ModuleName { get; set; }
        public string Page { get; set; }
        public string Action { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; }
    }
}
