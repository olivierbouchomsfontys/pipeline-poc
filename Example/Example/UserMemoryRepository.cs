using System;
using System.Collections.Generic;
using System.Linq;

namespace Example
{
    public class UserRepository : IUserRepository
    {
        private ICollection<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User
            {
                Id = Guid.Parse("B243192F-372D-4261-8107-C05A0A983961"),
                Email = "exists@example.com",
                Password = "password",
                Salt = "salt"
            });
        }
        
        public bool IsGuidAvailable(Guid guid)
        {
            return !_users.Any(c => c.Id == guid);
        }

        public bool IsEmailAvailable(string email)
        {
            return !_users.Any(c => c.Email == email);
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