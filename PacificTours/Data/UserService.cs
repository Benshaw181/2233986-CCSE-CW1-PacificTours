using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacificTours.Data
{
    public class UserService
    {
        private readonly UserManager<CustomerUser> _userManager;

        public UserService(UserManager<CustomerUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<CustomerUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<String> GetUserIdByEmail(string userName) // cleanup with help of basket controller
        {
            var users = await _userManager.Users.ToListAsync();
            var userId = "No User Found";
            foreach (var user in users)
            {
                if (user.Email == userName)
                {
                    userId = user.Id;
                }
            }
            return userId;
        }
    }
}
