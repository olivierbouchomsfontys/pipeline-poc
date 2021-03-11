namespace Example
{
    public interface IPasswordHasher
    {
        string Hash(string password, out string salt);
    }
}