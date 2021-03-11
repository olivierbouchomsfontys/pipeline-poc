namespace Example.Tests.Mocks
{
    public class NullPasswordHasher : IPasswordHasher
    {
        public string Hash(string password, out string salt)
        {
            salt = "salt";

            return password;
        }
    }
}