using System;

namespace Example
{
    public class UserLogic
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordGenerator _generator;
        private readonly IPasswordHasher _hasher;
        private readonly ITransformer _transformer;

        public UserLogic(IUserRepository repository, IPasswordGenerator generator, IPasswordHasher hasher, ITransformer transformer)
        {
            _repository = repository;
            _generator = generator;
            _hasher = hasher;
            _transformer = transformer;
        }

        public bool Create(User user)
        {
            if (!_repository.IsEmailAvailable(user.Email))
            {
                return false;
            }
            
            do
            {
                user.Id = Guid.NewGuid();
            } while (!_repository.IsGuidAvailable(user.Id));

            user.Secret = _transformer.Encrypt(user.Secret, out string key, out string iv);
            user.SecretIv = iv;
            user.SecretKey = key;
            
            user.Password = _hasher.Hash(_generator.GeneratePassword(), out string salt);
            user.Salt = salt;

            return _repository.Create(user);
        }

        public User Get(Guid id)
        {
            User user = _repository.Get(id);

            return Sanitize(user);
        }

        public User Get(string email)
        {
            User user = _repository.Get(email);

            return Sanitize(user);
        }

        private User Sanitize(User user)
        {
            user.Password = null;
            user.Salt = null;

            return user;
        }
    }
}