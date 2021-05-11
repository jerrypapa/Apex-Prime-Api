using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Dtos
{
    public class CreateResponseDto
    {
        public string Success { get; set; }
        /// <summary>
        /// 0 Success
        /// 1 Failed
        /// </summary>
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
