using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Application.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string WalletAddress { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }


        public Users() { }
        public Users(string email,string username,string walletAddress,string telephone,string password="")
        {
            Id = Guid.NewGuid();
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
            UserName = !string.IsNullOrWhiteSpace(username) ? username : throw new ArgumentNullException(nameof(username));
            WalletAddress = !string.IsNullOrWhiteSpace(walletAddress) ? email : throw new ArgumentNullException(nameof(walletAddress));
            Telephone = !string.IsNullOrWhiteSpace(telephone) ? telephone : throw new ArgumentNullException(nameof(telephone));
        }
        public static Users AddUser(string email, string username, string walletAddress, string telephone, string password = "")
        {
            KeyGenerator generator = new KeyGenerator();
            password = generator.GetUniquePassword(6);
            return new Users(email,username,walletAddress,telephone,password);
        }
    }
}
