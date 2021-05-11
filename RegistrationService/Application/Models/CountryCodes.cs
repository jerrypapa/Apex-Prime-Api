using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Models
{
    public class CountryCodes
    {
        public Guid Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
