using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.Models.Users
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageBase64 { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public RegisterViewModel(string firstName, string lastName, string image, string email, string password) 
        {
            FirstName = firstName;
            LastName = lastName;
            ImageBase64 = image;
            Email = email;
            Password = password;
        }
    }
}
