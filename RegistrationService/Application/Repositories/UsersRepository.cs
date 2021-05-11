using RegistrationService.Application.Context;
using RegistrationService.Application.Dtos;
using RegistrationService.Application.Dtos.AuditTrail;
using RegistrationService.Application.Dtos.Errors;
using RegistrationService.Application.Dtos.Users;
using RegistrationService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IAuditTrailRepository _auditTrailRepository;
            private readonly IErrorsRepository _errorsRepository;
            public UsersRepository(ApplicationContext applicationContext, IAuditTrailRepository auditTrailRepository, IErrorsRepository errorsRepository)
            {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
                _auditTrailRepository = auditTrailRepository ?? throw new ArgumentNullException(nameof(auditTrailRepository));
                _errorsRepository = errorsRepository ?? throw new ArgumentNullException(nameof(errorsRepository));

            }
            public async Task<CreateResponseDto> CreateUser(UserDto userdetails)
            {
                try
                {

                    var newUser = Users.AddUser(userdetails.Email, userdetails.UserName, userdetails.WalletAddress, userdetails.Telephone);
                _applicationContext.Users.Add(newUser);

                    var saved = await _applicationContext.SaveChangesAsync();


                    if (saved >= 1)
                    {
                        var newAuditData = new AuditDataDto
                        {
                            Action = "Adding New User with Email ~ " + userdetails.Email,
                            ModuleName = "User Registration Module",
                            Page = "Users",
                            UserId = newUser.Id,
                            Type = "CREATE"
                        };
                    await _auditTrailRepository.LogAAudit(newAuditData); 
                    }

                return new CreateResponseDto
                {
                    Code = "0",
                    Description = "Successfully added user",
                    Success = "ok"
                    };
                }
                catch (Exception ex)
                {
                    var errordata = new ErrorDataDto
                    {
                        Custom = "Occured during Adding User with Email ~" +
                                          userdetails.Email,
                        Description = ex.Message,
                        ErrorCode = "User_Add",
                        ErrorLine = 0,
                        Module = "User Registration Service",
                        Source = ex.Source,
                        StackTrace = ex.StackTrace
                    };
                    await _errorsRepository.LogError(errordata);
                    return new CreateResponseDto
                    {
                        Code = "1",
                        Description = "User Not Added"
                    };
                }
            }
        }
   
}
