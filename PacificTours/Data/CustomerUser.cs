using Microsoft.AspNetCore.Identity;

namespace PacificTours.Data
{
    public class CustomerUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassportNumber { get; set; }
        public int ContactNumber { get; set; }

    }
}