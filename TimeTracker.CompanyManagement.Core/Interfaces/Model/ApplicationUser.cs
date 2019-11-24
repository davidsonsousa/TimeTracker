using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TimeTracker.CompanyManagement.Core.Interfaces.Model
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
