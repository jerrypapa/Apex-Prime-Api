using Microsoft.EntityFrameworkCore;
using RegistrationService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<AuditTrail> AuditTrail { get; set; }
        public DbSet<CountryCodes> CountryCodes { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
    }
}
