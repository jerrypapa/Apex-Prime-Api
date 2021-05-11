using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistrationService.Application.Dtos;
using RegistrationService.Application.Repositories;
using RegistrationService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsersRepository _usersRepository;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IMediator mediator, ILogger<UsersController> logger, IUsersRepository usersRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<CreateResponseDto>> CreateNewUser([FromBody] AddUserCommand addUserCommand)
        {

            try
            {
                var response = await _mediator.Send(addUserCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                //log errors in file....
                //  throw e;
                return null;
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
