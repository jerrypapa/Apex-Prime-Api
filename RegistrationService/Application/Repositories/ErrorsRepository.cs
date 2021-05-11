using RegistrationService.Application.Context;
using RegistrationService.Application.Dtos.Errors;
using RegistrationService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Repositories
{
    public class ErrorsRepository : IErrorsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ErrorsRepository() { }
        public ErrorsRepository(ApplicationContext  applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }
        public async Task<bool> LogError(ErrorDataDto details)
        {

            try
            {
                var newError = ErrorLog.LogError(details.Module, details.Description, details.ErrorCode, details.Custom, details.ErrorLine, details.Source, details.StackTrace);

                _applicationContext.ErrorLog.Add(newError);
                await _applicationContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;

            }

            return true;
        }
    }
}
