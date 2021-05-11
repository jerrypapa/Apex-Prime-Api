using RegistrationService.Application.Dtos.AuditTrail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Repositories
{
    public interface IAuditTrailRepository
    {
        Task<AuditResponse> LogAAudit(AuditDataDto details);
        Task<AuditDataDto> RetrieveAuditInformationByUserId(Guid UserId);
        Task<AuditDataDto> RetrieveAuditInformationByAuditId(Guid AuditId);
        Task<AuditDataDto> RetrieveAllAuditInformation();
    }
}
