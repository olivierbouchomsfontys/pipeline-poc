using System;

namespace Example
{
    public interface IUserRepository
    {
        bool IsGuidAvailable(Guid guid);

        bool IsEmailAvailable(string email);

        bool Create(User user);

        User Get(Guid id);

        User Get(string email);
    }
}