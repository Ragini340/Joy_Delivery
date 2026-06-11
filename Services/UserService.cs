using Joy_Delivery.Models;
using Joy_Delivery.Seed;

namespace Joy_Delivery.Services
{
    public class UserService
    {
        private readonly List<User> _users = SeedData.Users;

        public User? FetchUserById(string userId) => _users.FirstOrDefault(user => user.Id == userId);
    }
}