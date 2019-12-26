using Microsoft.AspNetCore.Identity;
using System;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
