using RegistrationService.Application.Context;
using RegistrationService.Application.Dtos.AuditTrail;
using RegistrationService.Application.Dtos.Errors;
using RegistrationService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Repositories
{
    public class AuditTrailRepository : IAuditTrailRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AuditTrailRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));

        }
        public async Task<AuditResponse> LogAAudit(AuditDataDto details)
        {


            try
            {
                if (details.UserId == null)
                {
                    details.UserId = Guid.Empty;
                }
                var newAudit = AuditTrail.AddAudiTrail(details.ModuleName, details.Page, details.Action, details.UserId, details.Type);
                _applicationContext.AuditTrail.Add(newAudit);
                var saved = _applicationContext.SaveChanges();
                if (saved < 1)
                {
                    var errordata = new ErrorDataDto
                    {
                        Custom = "Occured during Logging Audit Trail",
                        Description = "Failed Audit Save",
                        ErrorCode = "LogAudit1",
                        ErrorLine = 0,
                        Module = "Internal",
                        Source = "Internal",
                        StackTrace = "Internal"
                    };
                    ErrorsRepository newEror = new ErrorsRepository();
                    newEror.LogError(errordata);
                    return new AuditResponse
                    {
                        Code = "1",
                        Description = "Audit Not Logged"
                    };
                }
                return new AuditResponse
                {
                    Code = "0",
                    Description = "Audit Successfully Logged"
                };
            }
            catch (Exception ex)
            {
                var errordata = new ErrorDataDto
                {
                    Custom = "Occured during Logging Audit Trail",
                    Description = ex.Message,
                    ErrorCode = "LogAudit1",
                    ErrorLine = 0,
                    Module = "User Management Service",
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                };
                ErrorsRepository newEror = new ErrorsRepository();
                await newEror.LogError(errordata);
                return new AuditResponse
                {
                    Code = "1",
                    Description = "Audit Not Logged"
                };
            }

        }

        public async Task<AuditDataDto> RetrieveAllAuditInformation()
        {
            throw new NotImplementedException();
        }

        public async Task<AuditDataDto> RetrieveAuditInformationByAuditId(Guid AuditId)
        {
            throw new NotImplementedException();
        }

        public async Task<AuditDataDto> RetrieveAuditInformationByUserId(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public AuditTrailRepository() { }
    }
}
