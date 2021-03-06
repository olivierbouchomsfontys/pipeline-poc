using System;
using System.Collections.Generic;
using System.Linq;

namespace Example
{
    public class UserRepository : IUserRepository
    {
        private readonly ICollection<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new()
                {
                    Id = Guid.Parse("B243192F-372D-4261-8107-C05A0A983961"),
                    Email = "exists@example.com",
                    Password = "password",
                    Salt = "salt"
                }
            };
        }
        
        public bool IsGuidAvailable(Guid guid)
        {
            return _users.All(c => c.Id != guid);
        }

        public bool IsEmailAvailable(string email)
        {
            return _users.All(c => c.Email != email);
        }

        public bool Create(User user)
        {
            _users.Add(user);

            return true;
        }

        public User Get(Guid id)
        {
            return _users.FirstOrDefault(c => c.Id == id);
        }

        public User Get(string email)
        {
            return _users.FirstOrDefault(c => c.Email == email);
        }
    }
}