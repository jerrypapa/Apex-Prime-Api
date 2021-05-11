using RegistrationService.Application.Dtos;
using RegistrationService.Application.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Repositories
{
    public interface IUsersRepository
    {
        Task<CreateResponseDto> CreateUser(UserDto userdetails);
    }
}
