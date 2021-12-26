using Microsoft.AspNetCore.Identity;
using PeakyBarbers.Data.Enums;
using System;

namespace PeakyBarbers.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
