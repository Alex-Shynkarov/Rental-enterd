using Microsoft.AspNetCore.Identity;
using System;

namespace RentalСenterApp.Data.Models
{
    public class User : IdentityUser
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
    }
}