using MediatR;
using RegistrationService.Application.Dtos;
using RegistrationService.Application.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RegistrationService.Commands
{
    public class AddUserCommand : IRequest<CreateResponseDto>
    {
        [DataMember]
        public UserDto newUser { get; set; }
    }
}
