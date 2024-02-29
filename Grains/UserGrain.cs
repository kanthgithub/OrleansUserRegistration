using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrainInterfaces;
using Orleans;

namespace Grains
{
    public class UserGrain : Grain, IUserGrain
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public Task<string> RegisterUser(string userName, string email, string postalCode, string phoneNumber)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                Email = email,
                PostalCode = postalCode,
                PhoneNumber = phoneNumber
            };

            users[user.Id] = user;
            return Task.FromResult(user.Id);
        }

        public Task<User> GetUserById(string id)
        {
            users.TryGetValue(id, out var user);
            return Task.FromResult(user);
        }

        public Task<User> GetUserByUserName(string userName)
        {
            var user = users.Values.FirstOrDefault(u => u.UserName == userName);
            return Task.FromResult(user);
        }

        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(users.Values.ToList());
        }
    }
}