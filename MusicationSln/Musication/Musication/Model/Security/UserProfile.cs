using Musication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musication.Model.Security
{
    public class UserProfile : IUserProfile
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}