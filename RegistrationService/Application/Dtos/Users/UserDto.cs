using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Dtos.Users
{
    public class UserDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string WalletAddress { get; set; }
        public string Telephone { get; set; }
    }
}
