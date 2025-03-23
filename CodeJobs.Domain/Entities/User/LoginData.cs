using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJobs.Domain.Entities.User
{
    public class LoginData
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public LoginData(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }
}
