using RegistrationService.Application.Dtos.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Repositories
{
    public interface IErrorsRepository
    {
        Task<bool> LogError(ErrorDataDto details);
    }
}
