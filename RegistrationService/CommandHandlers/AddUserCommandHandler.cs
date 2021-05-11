using MediatR;
using Microsoft.Extensions.Logging;
using RegistrationService.Application.Dtos;
using RegistrationService.Application.Dtos.Errors;
using RegistrationService.Application.Repositories;
using RegistrationService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RegistrationService.CommandHandlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, CreateResponseDto>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IErrorsRepository _errorsRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<AddUserCommandHandler> _logger;
        public AddUserCommandHandler(UsersRepository usersRepository, IMediator mediator, ILogger<AddUserCommandHandler> logger, IErrorsRepository errorsRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _errorsRepository = errorsRepository ?? throw new ArgumentNullException(nameof(errorsRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        public async Task<CreateResponseDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("----- Initiating UserCreation - NewUser: {@Email}", request.newUser.Email);
                var response = await _usersRepository.CreateUser(request.newUser);

                return response;
            }
            catch (Exception ex)
            {
                var errordata = new ErrorDataDto
                {
                    Custom = "Occured during Adding User with Email~" +
                    request.newUser.Email,
                    Description = ex.Message,
                    ErrorCode = "User_Creation",
                    ErrorLine = 0,
                    Module = "User Management Service",
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                };
                await _errorsRepository.LogError(errordata);
                return new CreateResponseDto
                {
                    Code = "1",
                    Description = "user Not Added"
                };

            }
        }


    }
}
